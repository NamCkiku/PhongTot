using PhongTot.Api.Infrastructure.Core;
using PhongTot.Api.Models.ViewModel;
using PhongTot.Entities.Models;
using PhongTot.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PhongTot.Api.Infrastructure.Extensions;
using AutoMapper;

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

        [Route("getallpaging")]
        [HttpGet]
        public HttpResponseMessage GetAllPaging(HttpRequestMessage request, string keyword, int page, int pageSize = 20)
        {
            return CreateHttpResponse(request, () =>
            {
                int totalRow = 0;
                var model = _postService.GetAllPaging(keyword);

                totalRow = model.Count();
                var query = model.OrderByDescending(x => x.CreateDate).Skip(page * pageSize).Take(pageSize);

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
        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request,PostViewModel postVm)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if(!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var newPost = new Post();
                    newPost.UpdatePost(postVm);
                    _postService.Add(newPost);
                    _postService.SaveChanges();
                    var responseData = Mapper.Map<Post, PostViewModel>(newPost);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                    
                }
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

                    response = request.CreateResponse(HttpStatusCode.Created, newCourse);
                }
                return response;
            });
        }

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
