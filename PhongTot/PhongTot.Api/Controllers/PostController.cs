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
                var listPost= _postService.GetAll().OrderByDescending(x => x.CreateDate).Take(9);

                //var listPostCategoryVm = Mapper.Map<List<PostCategoryViewModel>>(listCategory);

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listInfo);

                return response;
            });
        }

        [Route("getallpaging")]
        public HttpResponseMessage GetAllPaging(HttpRequestMessage request, string keyword, int page, int pageSize = 20)
        {
            return CreateHttpResponse(request, () =>
            {
                int totalRow = 0;
                var model = _postService.GetAllPaging(keyword);

                totalRow = model.Count();
                var query = model.OrderByDescending(x => x.CreateDate).Skip(page * pageSize).Take(pageSize);

                var paginationSet = new PaginationSet<Info>()
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

        //[Route("search")]
        //[HttpGet]
        //public IHttpActionResult Search([FromUri]InfoSearchModel filterParams)
        //{
        //    var searchResult = _postService.Search(filterParams);
        //    var totalRow = searchResult.Count(); // Actually, we don't need this one.

        //    return Json(new
        //    {
        //        model = searchResult,
        //        totalRow = totalRow
        //    });
        //}

        [Route("search")]
        [HttpGet]
        public HttpResponseMessage Search(HttpRequestMessage request, [FromUri]InfoSearchModel filterParams, int page, string sort = "", int pageSize = 20)
        {
            return CreateHttpResponse(request, () =>
            {
                int totalRow = 0;
                var searchResult = _postService.Search(filterParams);
                switch (sort)
                {
                    case "viewcount":
                        searchResult = searchResult.OrderByDescending(x => x.ViewCount);
                        break;
                    case "province":
                        searchResult = searchResult.OrderByDescending(x => x.Province.name);
                        break;
                    case "price":
                        searchResult = searchResult.OrderBy(x => x.Price);
                        break;
                    default:
                        searchResult = searchResult.OrderByDescending(x => x.CreateDate);
                        break;
                }
                totalRow = searchResult.Count();
                var query = searchResult.Skip(page * pageSize).Take(pageSize);
                var paginationSet = new PaginationSet<Info>()
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
        [Route("getinfobycategory")]
        [HttpGet]
        public HttpResponseMessage GetInfoByCategory(HttpRequestMessage request, int id, int page = 0, string sort = "", int pageSize = 20)
        {
            return CreateHttpResponse(request, () =>
            {
                int totalRow = 0;
                var model = _postService.GetListInfoByCategoryIdPaging(id, page, pageSize, sort, out totalRow);
                var paginationSet = new PaginationSet<Info>()
                {
                    Items = model,
                    Page = page,
                    TotalCount = totalRow,
                    TotalPages = (int)Math.Ceiling((decimal)totalRow / pageSize)
                };
                var response = request.CreateResponse(HttpStatusCode.OK, paginationSet);
                return response;
            });
        }

        [Route("add")]
        [HttpPost]
        public HttpResponseMessage Post(HttpRequestMessage request, Info info)
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
                    var newCourse = _postService.Add(info);

                    response = request.CreateResponse(HttpStatusCode.Created, newCourse);
                }
                return response;
            });
        }

        [Route("update")]
        [HttpPut]
        public HttpResponseMessage Put(HttpRequestMessage request, Info info)
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
                    _postService.Update(info);
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



        [MimeMultipart]
        [Route("images/upload")]
        public HttpResponseMessage Post(HttpRequestMessage request, int infoID)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                var infoOld = _postService.GetById(infoID);
                if (infoOld == null)
                    response = request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid movie.");
                else
                {
                    var uploadPath = HttpContext.Current.Server.MapPath("~/Content/images");

                    var multipartFormDataStreamProvider = new UploadMultipartFormProvider(uploadPath);

                    // Read the MIME multipart asynchronously 
                    Request.Content.ReadAsMultipartAsync(multipartFormDataStreamProvider);

                    string _localFileName = multipartFormDataStreamProvider
                        .FileData.Select(multiPartData => multiPartData.LocalFileName).FirstOrDefault();

                    // Create response
                    FileUploadResult fileUploadResult = new FileUploadResult();
                    fileUploadResult.LocalFilePath = _localFileName;

                    fileUploadResult.FileName = Path.GetFileName(_localFileName);

                    //fileUploadResult.FileLength = new FileInfo(_localFileName).Length;

                    // update database
                    infoOld.Image = fileUploadResult.FileName;
                    _postService.Update(infoOld);
                    _postService.SaveChanges();

                    response = request.CreateResponse(HttpStatusCode.OK, fileUploadResult);
                }

                return response;
            });
        }



        [Route("images/uploadFile")]
        public async Task UploadSingleFile()
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                Request.CreateErrorResponse(HttpStatusCode.UnsupportedMediaType, new NotSupportedException("Media type not supported"));
            }
            var root = HttpContext.Current.Server.MapPath("~/Content/images");
            var dataFolder = HttpContext.Current.Server.MapPath("~/Content/images");
            Directory.CreateDirectory(root);
            var provider = new MultipartFormDataStreamProvider(root);
            var result = await Request.Content.ReadAsMultipartAsync(provider);

            string fileName = string.Empty;
            foreach (MultipartFileData fileData in provider.FileData)
            {
                fileName = fileData.Headers.ContentDisposition.FileName;
                if (fileName.StartsWith("\"") && fileName.EndsWith("\""))
                {
                    fileName = fileName.Trim('"');
                }
                if (fileName.Contains(@"/") || fileName.Contains(@"\"))
                {
                    fileName = result.FormData["model"] + "_"
                              + Path.GetFileName(fileName);
                }
                if (File.Exists(Path.Combine(dataFolder, fileName)))
                    File.Delete(Path.Combine(dataFolder, fileName));
                File.Move(fileData.LocalFileName, Path.Combine(dataFolder, fileName));
                File.Delete(fileData.LocalFileName);
            }

            Request.CreateResponse(HttpStatusCode.OK, new { fileName = fileName });
        }
    }
}
