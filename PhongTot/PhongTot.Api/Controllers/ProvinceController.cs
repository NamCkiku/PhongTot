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
    [RoutePrefix("api/province")]
    public class ProvinceController : ApiControllerBase
    {
        private readonly IProvinceService _provinceService;
        public ProvinceController(IErrorService errorService, IProvinceService provinceService) : base(errorService)
        {
            this._provinceService = provinceService;
        }
        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var listInfo = _provinceService.GetAll().OrderBy(x=>x.name);

                //var listPostCategoryVm = Mapper.Map<List<PostCategoryViewModel>>(listCategory);

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listInfo);

                return response;
            });
        }
    }
}
