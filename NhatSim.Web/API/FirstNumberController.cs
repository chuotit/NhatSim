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
    [RoutePrefix("api/firstnumber")]
    public class FirstNumberController : ApiControllerBase
    {
        private IFirstNumberService _firstNumberService;

        public FirstNumberController(IErrorService errorService, IFirstNumberService firstNumberService)
            : base(errorService)
        {
            this._firstNumberService = firstNumberService;
        }

        [Route("getall")]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _firstNumberService.GetAll();

                var responseData = Mapper.Map<IEnumerable<FirstNumber>, IEnumerable<FirstNumberViewModel>>(model);
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }

        [Route("getfirstnumberbyid/{id}")]
        [HttpGet]
        public HttpResponseMessage GetFirstNumberById(HttpRequestMessage request, string id)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _firstNumberService.GetById(id);

                var responseData = Mapper.Map<FirstNumber, FirstNumberViewModel>(model);
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }

        [Route("getfirstnumberbynetwork/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetFirstNumberByNetwork(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _firstNumberService.GetByNetwork(id);

                var responseData = Mapper.Map<IEnumerable<FirstNumber>, IEnumerable<FirstNumberViewModel>>(model);
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }

        [Route("create")]
        public HttpResponseMessage Post(HttpRequestMessage request, FirstNumberViewModel firstNumberVm)
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
                    FirstNumber newFirstNumber = new FirstNumber();
                    newFirstNumber.UpdateFirstNumber(firstNumberVm);
                    var firstNumberReturn = _firstNumberService.Add(newFirstNumber);
                    _firstNumberService.SaveChanges();
                    response = request.CreateResponse(HttpStatusCode.Created, firstNumberReturn);
                }
                return response;
            });
        }

        [Route("update")]
        public HttpResponseMessage Put(HttpRequestMessage request, FirstNumberViewModel firstNumberVm)
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
                    var postFirstNumberDb = _firstNumberService.GetById(firstNumberVm.Id);
                    postFirstNumberDb.UpdateFirstNumber(firstNumberVm);
                    _firstNumberService.Update(postFirstNumberDb);
                    _firstNumberService.SaveChanges();

                    var responseData = Mapper.Map<FirstNumber, FirstNumberViewModel>(postFirstNumberDb);
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
                    _firstNumberService.Delete(id);
                    _firstNumberService.SaveChanges();
                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                return response;
            });
        }
    }
}
