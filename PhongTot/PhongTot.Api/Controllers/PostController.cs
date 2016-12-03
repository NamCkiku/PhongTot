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
    [RoutePrefix("api/post")]
    public class PostController : ApiControllerBase
    {
        IPostService _postService;
        public PostController(IErrorService errorService, IPostService postService) : base(errorService)
        {
            this._postService = postService;
        }
        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var listPost = _postService.GetAll().OrderByDescending(x => x.CreateDate).Take(6);

                //var listPostCategoryVm = Mapper.Map<List<PostCategoryViewModel>>(listCategory);

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listPost);

                return response;
            });
        }
        [Route("reatedpost")]
        public HttpResponseMessage GetReatedPost(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var listPost = _postService.GetReatedPost(id, 6).OrderByDescending(x => x.CreateDate).Take(6);

                //var listPostCategoryVm = Mapper.Map<List<PostCategoryViewModel>>(listCategory);

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listPost);

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
                var model = _postService.GetAllPaging(filterParams, page, pageSize, out totalRow);
                var query = model.OrderByDescending(x => x.CreateDate);

                var paginationSet = new PaginationSet<Post>()
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
                var model = _postService.GetById(id);
                var response = request.CreateResponse(HttpStatusCode.OK, model);

                return response;
            });
        }
        [Authorize]
        [Route("add")]
        [HttpPost]
        public HttpResponseMessage Post(HttpRequestMessage request, Post post)
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
                    var newCourse = _postService.Add(post);
                    _postService.SaveChanges();
                    response = request.CreateResponse(HttpStatusCode.Created, newCourse);
                }
                return response;
            });
        }
        [Authorize]
        [Route("update")]
        [HttpPut]
        public HttpResponseMessage Put(HttpRequestMessage request, Post post)
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
                    _postService.Update(post);
                    _postService.SaveChanges();
                    response = request.CreateResponse(HttpStatusCode.OK);


                }
                return response;
            });
        }
        [Authorize]
        [Route("delete")]
        [HttpDelete]
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
                    _postService.Delete(id);
                    _postService.SaveChanges();
                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }
    }
}
