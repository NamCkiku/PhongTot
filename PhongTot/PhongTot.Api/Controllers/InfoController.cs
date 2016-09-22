using PhongTot.Api.Infrastructure.Core;
using PhongTot.Entities.Models;
using PhongTot.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace PhongTot.Api.Controllers
{
    [RoutePrefix("api/info")]
    public class InfoController : ApiControllerBase
    {
        IInfoService _infoService;
        public InfoController(IErrorService errorService, IInfoService infoService) : base(errorService)
        {
            this._infoService = infoService;
        }
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var listInfo = _infoService.GetAll();

                //var listPostCategoryVm = Mapper.Map<List<PostCategoryViewModel>>(listCategory);

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listInfo);

                return response;
            });
        }

        [Route("add")]
        public HttpResponseMessage Post(HttpRequestMessage request, Info info)
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
                    var newCourse = _infoService.Add(info);
                    _infoService.SaveChanges();

                    response = request.CreateResponse(HttpStatusCode.Created, newCourse);
                }
                return response;
            });
        }

        [Route("update")]
        public HttpResponseMessage Put(HttpRequestMessage request, Info info)
        {
            return CreateHttpResponse(request, () => {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    _infoService.Update(info);
                    _infoService.SaveChanges();

                    response = request.CreateResponse(HttpStatusCode.OK);


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
                    _infoService.Delete(id);
                    _infoService.SaveChanges();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }
    }
}
