using PhongTot.Api.Infrastructure.Core;
using PhongTot.Entities.Models;
using PhongTot.Entities.ModelView;
using PhongTot.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PhongTot.Api.Controllers
{
    [RoutePrefix("api/categoryinfo")]
    public class CategoryInfoController : ApiControllerBase
    {
        private readonly ICategoryInfoService _categoryInfoService;
        public CategoryInfoController(IErrorService errorService, ICategoryInfoService categoryInfoService) : base(errorService)
        {
            this._categoryInfoService = categoryInfoService;
        }
        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var listInfo = _categoryInfoService.GetAll();

                //var listPostCategoryVm = Mapper.Map<List<PostCategoryViewModel>>(listCategory);

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listInfo);

                return response;
            });
        }
        [Authorize]
        [Route("getallpaging")]
        [HttpGet]
        public HttpResponseMessage GetAllPaging(HttpRequestMessage request, [FromUri]SearchViewModel filterParams, int page, int pageSize = 20)
        {
            return CreateHttpResponse(request, () =>
            {
                int totalRow = 0;
                var model = _categoryInfoService.GetAllPaging(filterParams,page,pageSize, out totalRow);
                var query = model.OrderByDescending(x => x.CreatedDate);

                var paginationSet = new PaginationSet<CategoryInfo>()
                {
                    Items = query,
                    Page = page,
                    TotalCount = totalRow,
                    TotalPages = (int)Math.Ceiling((decimal)totalRow / pageSize)
                };
                var response = request.CreateResponse(HttpStatusCode.OK, paginationSet);
                return response;
            });
        }
        [Route("getbyid/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetById(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _categoryInfoService.GetById(id);
                var response = request.CreateResponse(HttpStatusCode.OK, model);

                return response;
            });
        }

        [Route("getinfobycategory")]
        public HttpResponseMessage GetInfoByCategory(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var listInfo = _categoryInfoService.GetInfoByCategory(4);

                //var listPostCategoryVm = Mapper.Map<List<PostCategoryViewModel>>(listCategory);

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listInfo);

                return response;
            });
        }
        [Route("add")]
        public HttpResponseMessage Post(HttpRequestMessage request, CategoryInfo categoryinfo)
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
                    var newCategoryInfo = _categoryInfoService.Add(categoryinfo);
                    _categoryInfoService.SaveChanges();

                    response = request.CreateResponse(HttpStatusCode.Created, newCategoryInfo);
                }
                return response;
            });
        }

        [Route("update")]
        public HttpResponseMessage Put(HttpRequestMessage request, CategoryInfo categoryinfo)
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
                    _categoryInfoService.Update(categoryinfo);
                    _categoryInfoService.SaveChanges();

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
                if (!ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    _categoryInfoService.Delete(id);
                    _categoryInfoService.SaveChanges();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }
    }
}
