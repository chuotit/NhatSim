﻿using System;
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
    [RoutePrefix("api/agentLevel")]
    public class AgentLevelController : ApiControllerBase
    {
        private IAgentLevelService _agentLevelService;

        public AgentLevelController(IErrorService errorService, IAgentLevelService agentLevelService)
            : base(errorService)
        {
            this._agentLevelService = agentLevelService;
        }

        [Route("getall")]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _agentLevelService.GetAll();

                var responseData = Mapper.Map<IEnumerable<AgentLevel>, IEnumerable<AgentLevelViewModel>>(model);
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }

        [Route("getbyid/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetById(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _agentLevelService.GetById(id);

                var responseData = Mapper.Map<AgentLevel, AgentLevelViewModel>(model);

                var response = request.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }

        [Route("create")]
        public HttpResponseMessage Post(HttpRequestMessage request, AgentLevelViewModel agentLevelVm)
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
                    AgentLevel newAgentLevel = new AgentLevel();
                    newAgentLevel.UpdateAgentLevel(agentLevelVm);
                    var agentLevelReturn = _agentLevelService.Add(newAgentLevel);
                    _agentLevelService.SaveChanges();
                    response = request.CreateResponse(HttpStatusCode.Created, agentLevelReturn);
                }
                return response;
            });
        }

        [Route("update")]
        public HttpResponseMessage Put(HttpRequestMessage request, AgentLevelViewModel agentLevelVm)
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
                    var postAgentLevelDb = _agentLevelService.GetById(agentLevelVm.Id);
                    postAgentLevelDb.UpdateAgentLevel(agentLevelVm);
                    _agentLevelService.Update(postAgentLevelDb);
                    _agentLevelService.SaveChanges();

                    var responseData = Mapper.Map<AgentLevel, AgentLevelViewModel>(postAgentLevelDb);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }

        [Route("delete")]
        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
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
                    _agentLevelService.Delete(id);
                    _agentLevelService.SaveChanges();
                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                return response;
            });
        }
    }
}
