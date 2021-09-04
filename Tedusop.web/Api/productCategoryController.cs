﻿using System;
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
    [RoutePrefix("api/product1")]
    public class productCategoryController : ApiControllerBase
    {

        private readonly IProducCategoryService _producCategoryService;

        public productCategoryController(IProducCategoryService producCategoryService)
        {
            this._producCategoryService = producCategoryService;

        }


        [Route("getallParents")]
        [HttpGet]
        // GET api/<controller>
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {

                var listCategory = _producCategoryService.GetAll();
                var listcategoryVm = Mapper.Map<List<ProductCategoryViewModel>>(listCategory);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listcategoryVm);
                return response;
            });
        }




        [Route("getall")]
        [HttpGet]
        // GET api/<controller>
        public HttpResponseMessage Get(HttpRequestMessage request, String keyword, int page, int pageSize = 20)
        {
            return CreateHttpResponse(request, () =>
            {

                int totalRow = 0;

                var listCategory = _producCategoryService.GetMutip(keyword);
                totalRow = listCategory.Count();

                var query = listCategory.OrderByDescending(x => x.CreatedDate).Skip(page * pageSize).Take(pageSize);
                var listcategoryVm = Mapper.Map<List<ProductCategoryViewModel>>(query);

                #region phantrang   
                var paginationSet = new PaginationSet<ProductCategoryViewModel>()
                {
                    Items = listcategoryVm,
                    Page = page,
                    TotalCuont = totalRow,
                    TotalPage = (int)Math.Ceiling((decimal)totalRow / pageSize)

                };
                #endregion
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, paginationSet);
                return response;
            });
        }
        [Route("Created")]
        [HttpPost]
        public HttpResponseMessage Created(HttpRequestMessage request, ProductCategoryViewModel productCategoryViewModel)
        {

            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage reppnse = null;

                if (!ModelState.IsValid)
                {
                    reppnse = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var newproductCategory = new ProductCategory();
                    newproductCategory.updateProductCategory(productCategoryViewModel);

                    _producCategoryService.Add(newproductCategory);
                    _producCategoryService.save();

                    var responData = Mapper.Map<ProductCategory, ProductCategoryViewModel>(newproductCategory);
                    reppnse = request.CreateResponse(HttpStatusCode.Created, responData);
                }

                return reppnse;
            });
        }
    }
}