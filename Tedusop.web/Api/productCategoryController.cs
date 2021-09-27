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
using System.Web.Script.Serialization;

namespace Tedusop.web.Api
{
    [RoutePrefix("api/product1")]
    [Authorize]
    public class productCategoryController : ApiControllerBase
    {

        private readonly IProducCategoryService _producCategoryService;
        private IEurrorsService _errorService;
        public productCategoryController(IProducCategoryService producCategoryService, IEurrorsService errorService) : base(errorService)
        {
            this._producCategoryService = producCategoryService;
            this._errorService = errorService;

        }



        [Route("getall")]
        [HttpGet]
        [Authorize]
        // GET api/<controller>
        public HttpResponseMessage Get(HttpRequestMessage request, String keyword, int page, int pageSize = 20)
        {
            return CreateHttpResponse(request, () =>
            {

                int totalRow = 0;

                var listCategory = _producCategoryService.GetMutip(keyword);
                totalRow = listCategory.Count();

                var query = listCategory.OrderBy(x => x.ID).Skip(page * pageSize).Take(pageSize);
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




        [Route("getallParents")]
        [HttpGet]
        [Authorize]
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


        [Route("Created")]
        [HttpPost]
        [Authorize]
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




        [Route("GetbyId/{id:int}")]
        [HttpGet]
        [Authorize]
        // GET api/<controller>
        public HttpResponseMessage GetByID(HttpRequestMessage request,int id)
        {
            return CreateHttpResponse(request, () =>
            {

                var listCategory = _producCategoryService.GetByid(id);
                var listcategoryVm = Mapper.Map<ProductCategory, ProductCategoryViewModel>(listCategory);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listcategoryVm);
                return response;
            });
        }



        [Route("update")]
        [HttpPut]
        [Authorize]
        public HttpResponseMessage Update(HttpRequestMessage request, ProductCategoryViewModel productCategoryViewModel)
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
                    var newproductCategory = _producCategoryService.GetByid(productCategoryViewModel.ID);
                    newproductCategory.updateProductCategory(productCategoryViewModel);

                    _producCategoryService.Update(newproductCategory);
                    _producCategoryService.save();

                    var responData = Mapper.Map<ProductCategory, ProductCategoryViewModel>(newproductCategory);
                    reppnse = request.CreateResponse(HttpStatusCode.Created, responData);
                }

                return reppnse;
            });
        }

        //xoa 1 san pham

        [Route("delete")]
        [HttpDelete]
        [Authorize]
        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
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
                    var newproductCategory = _producCategoryService.Delete(id);
                   
                    _producCategoryService.save();

                    var responData = Mapper.Map<ProductCategory, ProductCategoryViewModel>(newproductCategory);
                    reppnse = request.CreateResponse(HttpStatusCode.Created, responData);
                }

                return reppnse;
            });
        }

        /// xóa nhiều sản phẩm
        [Route("deletemulti")]
        [HttpDelete]
        [Authorize]
        public HttpResponseMessage DeleteMuti(HttpRequestMessage request, String checkProduct)
        {
            return CreateHttpResponse(request, () => {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var lisproduct = new JavaScriptSerializer().Deserialize<List<int>>(checkProduct);
                    foreach (var item in lisproduct)
                    {
                        _producCategoryService.Delete(item);
                    
                    }
                    _producCategoryService.save();
                    response = request.CreateResponse(HttpStatusCode.OK, lisproduct.Count);
                }
                return response;

            });
          
        }
        

    }
}