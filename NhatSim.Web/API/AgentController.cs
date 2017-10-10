using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using NhatSim.Model.Models;
using NhatSim.Service;
using NhatSim.Web.Infrastructure.Core;
using NhatSim.Web.Infrastructure.Extensions;
using NhatSim.Web.Models;

namespace NhatSim.Web.API
{
    [RoutePrefix("api/agent")]
    public class AgentController : ApiControllerBase
    {
        private IAgentService _agentService;

        public AgentController(IErrorService errorService, IAgentService agentService)
            : base(errorService)
        {
            this._agentService = agentService;
        }

        [Route("getall")]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _agentService.GetAll();

                var responseData = Mapper.Map<IEnumerable<Agent>, IEnumerable<AgentViewModel>>(model);
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }

        [Route("getbyid/{id}")]
        [HttpGet]
        public HttpResponseMessage GetById(HttpRequestMessage request, string id)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _agentService.GetById(id);

                var responseData = Mapper.Map<Agent, AgentViewModel>(model);

                var response = request.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }

        [Route("create")]
        public HttpResponseMessage Post(HttpRequestMessage request, AgentViewModel agentVm)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    Agent newAgent = new Agent();
                    newAgent.UpdateAgent(agentVm);
                    var agentReturn = _agentService.Add(newAgent);
                    _agentService.SaveChanges();
                    response = request.CreateResponse(HttpStatusCode.Created, agentReturn);
                }
                return response;
            });
        }

        [Route("update")]
        public HttpResponseMessage Put(HttpRequestMessage request, AgentViewModel agentVm)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var postAgentDb = _agentService.GetById(agentVm.Id);
                    postAgentDb.UpdateAgent(agentVm);
                    _agentService.Update(postAgentDb);
                    _agentService.SaveChanges();

                    var responseData = Mapper.Map<Agent, AgentViewModel>(postAgentDb);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }

        [Route("delete")]
        public HttpResponseMessage Delete(HttpRequestMessage request, string id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    _agentService.Delete(id);
                    _agentService.SaveChanges();
                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                return response;
            });
        }
    }
}
