using PhongTot.Api.Infrastructure.Core;
using PhongTot.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PhongTot.Api.Controllers
{
    [RoutePrefix("api/ward")]
    public class WardController : ApiControllerBase
    {
        private readonly IWardidService _wardService;
        public WardController(IErrorService errorService, IWardidService wardService) : base(errorService)
        {
            this._wardService = wardService;
        }
        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var listWard = _wardService.GetAll();

                //var listPostCategoryVm = Mapper.Map<List<PostCategoryViewModel>>(listCategory);

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listWard);

                return response;
            });
        }
        [Route("getallbydistrict/{id:int}")]
        public HttpResponseMessage GetAllByProvince(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var listWard = _wardService.GetAllByDistrict(id);

                //var listPostCategoryVm = Mapper.Map<List<PostCategoryViewModel>>(listCategory);

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listWard);

                return response;
            });
        }
    }
}
