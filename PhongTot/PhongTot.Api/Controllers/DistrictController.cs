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
    [RoutePrefix("api/district")]
    public class DistrictController : ApiControllerBase
    {
        private readonly IDistrictidService _districtService;
        public DistrictController(IErrorService errorService, IDistrictidService districtService) : base(errorService)
        {
            this._districtService = districtService;
        }
        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var listDistrict = _districtService.GetAll().OrderBy(x => x.name);

                //var listPostCategoryVm = Mapper.Map<List<PostCategoryViewModel>>(listCategory);

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listDistrict);

                return response;
            });
        }
        [Route("getallbyprovince/{id:int}")]
        public HttpResponseMessage GetAllByProvince(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var listDistrict = _districtService.GetAllByProvince(id).OrderBy(x => x.name);

                //var listPostCategoryVm = Mapper.Map<List<PostCategoryViewModel>>(listCategory);

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listDistrict);

                return response;
            });
        }
    }
}
