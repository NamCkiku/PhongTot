using Newtonsoft.Json.Linq;
using PhongTot.Api.Infrastructure.Core;
using PhongTot.Entities.Models;
using PhongTot.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PhongTot.Api.Controllers
{
    [Authorize]
    [RoutePrefix("api/syspara")]
    public class SysParaController : ApiControllerBase
    {
        private readonly ISysParaService _sysPaService;
        public SysParaController(IErrorService errorService, ISysParaService sysPaService) : base(errorService)
        {
            this._sysPaService = sysPaService;
        }
        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var syspara = _sysPaService.GetAll();
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, syspara);
                return response;
            });
        }

        [Authorize]
        [Route("update")]
        [HttpPut]
        public HttpResponseMessage Put(HttpRequestMessage request, string lstSysparam)
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
                    var arrItem = JArray.Parse(lstSysparam);
                    List<SysPara> lst = new List<SysPara>();
                    foreach (var item in arrItem)
                    {
                        SysPara oSysPara = new SysPara();
                        oSysPara.Field = item["Field"].ToString();
                        oSysPara.Value = ((bool)item["Value"] == true) ? "1" : "0";
                        lst.Add(oSysPara);
                    }
                    if (lst != null && lst.Count > 0)
                    {
                        if (_sysPaService.UpdateListSystemPara(lst))
                        {
                            IEnumerable<SysPara> listPara = _sysPaService.GetAll();
                            response = request.CreateResponse(HttpStatusCode.OK, listPara);
                        }
                    }
                    response = request.CreateResponse(HttpStatusCode.OK);


                }
                return response;
            });
        }
    }
}
