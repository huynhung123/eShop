using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tedusop.web.infrastructure.core;
using Tedusop.Data.Repositories;
using Tedusop.Data.Infrastructure;
using Tedusop.Service;
using Tedusop.Model.Models;
using AutoMapper;
using Tedusop.web.Models;
using Tedusop.web.infrastructure.extensions;

namespace Tedusop.web.Api
{
    [RoutePrefix("api/postcategory")]
    public class PostCategoryController : ApiControllerBase
    {
        IpostCategoryService _postCategoryService;
        private IEurrorsService _errorService;
        public PostCategoryController(IpostCategoryService postCategyService, IEurrorsService errorService) :base(errorService)
        {
            this._postCategoryService = postCategyService;
            this._errorService = errorService;
        }

        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {

                var listCategory = _postCategoryService.GetAll();
                var listcategoryVm = Mapper.Map<List<PostCategoryViewModel>>(listCategory);

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listcategoryVm);
                return response;
            });
        }
        [Route("Add")]
        public HttpResponseMessage Post(HttpRequestMessage request, PostCategoryViewModel postCategoryVM)
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
                    PostCategory postCategory = new PostCategory();
                    postCategory.UpdatePostCategory(postCategoryVM);
                    _postCategoryService.Add(postCategory);
                    _postCategoryService.saveChange();
                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                return response;
            });
        }
        [Route("update")]
        public HttpResponseMessage Put(HttpRequestMessage request, PostCategoryViewModel postCategoryVM)
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
                    var PostCategory = _postCategoryService.GetById(postCategoryVM.ID);
                    PostCategory.UpdatePostCategory(postCategoryVM);
                    _postCategoryService.UpDate(PostCategory);
                    _postCategoryService.saveChange();

                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                return response;
            });
        }
        [Route("Delete")]
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
                    _postCategoryService.Delete(id);
                    _postCategoryService.saveChange();
                    response = request.CreateResponse(HttpStatusCode.OK);
                }

                return response;
            });
        }
    }
}