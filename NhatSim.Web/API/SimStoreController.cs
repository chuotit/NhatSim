using System.Collections.Generic;
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
    [RoutePrefix("api/simStore")]
    [Authorize]
    public class SimStoreController : ApiControllerBase
    {
        private ISimStoreService _simStoreService;

        public SimStoreController(IErrorService errorService, ISimStoreService simStoreService)
            : base(errorService)
        {
            this._simStoreService = simStoreService;
        }

        [Route("getall")]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _simStoreService.GetAll();
                var responseData = Mapper.Map<IEnumerable<SimStore>, IEnumerable<SimStoreViewModel>>(model);
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }

        [Route("getbyid/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetById(HttpRequestMessage request, string id)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _simStoreService.GetById(id);

                var responseData = Mapper.Map<SimStore, SimStoreViewModel>(model);
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }

        [Route("create")]
        public HttpResponseMessage Post(HttpRequestMessage request, SimStoreViewModel simStoreVm)
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
                    SimStore newSimStore = new SimStore();
                    newSimStore.UpdateSimStore(simStoreVm);
                    var simStoreReturn = _simStoreService.Add(newSimStore);
                    _simStoreService.SaveChanges();
                    response = request.CreateResponse(HttpStatusCode.Created, simStoreReturn);
                }
                return response;
            });
        }

        [Route("update")]
        public HttpResponseMessage Put(HttpRequestMessage request, SimStoreViewModel simStoreVm)
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
                    var postSimStoreDb = _simStoreService.GetById(simStoreVm.SimId);
                    postSimStoreDb.UpdateSimStore(simStoreVm);
                    _simStoreService.Update(postSimStoreDb);
                    _simStoreService.SaveChanges();

                    var responseData = Mapper.Map<SimStore, SimStoreViewModel>(postSimStoreDb);
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
                    _simStoreService.Delete(id);
                    _simStoreService.SaveChanges();
                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                return response;
            });
        }
    }
}