using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tedusop.web.infrastructure.core;
using Tedusop.Service;
using AutoMapper;
using Tedusop.web.Models;
using Tedusop.Model.Models;
using System.Web.Script.Serialization;
using Tedusop.web.infrastructure.extensions;

namespace Tedusop.web.Api
{
    [RoutePrefix("api/product")]
    [Authorize]
    public class ProductController : ApiControllerBase
    {
        private readonly IProductService _productService;
        private IEurrorsService _errorService;
        public ProductController(IProductService productService, IEurrorsService errorService) : base(errorService)
        {
            this._productService = productService;
            this._errorService = errorService;

        }
        // lay toan bo san pham, tim kiem, phan trang
        [Route("getall")]
        [HttpGet]

        public HttpResponseMessage Get(HttpRequestMessage request, string keyWord, int page, int pageSize = 20)
        {
            return CreateHttpResponse(request, () =>
            {
                int totalRow = 0;

                var lisProduct = _productService.GetMutip(keyWord);
                totalRow = lisProduct.Count();
                var query = lisProduct.OrderBy(x => x.Id).Skip(page * pageSize).Take(pageSize);
                var lisProductVM = Mapper.Map<List<ProductViewModel>>(query);

                var paginationSet = new PaginationSet<ProductViewModel>()
                {
                    Items = lisProductVM,
                    Page = page,
                    TotalCuont = totalRow,
                    TotalPage = (int)Math.Ceiling((decimal)totalRow / pageSize)
                };

                HttpResponseMessage repose = request.CreateResponse(HttpStatusCode.OK, paginationSet);

                return repose;
            });
        }
        /// get all parenID
        [Route("getallparenID")]
        [HttpGet]

        public HttpResponseMessage GetAllParenID(HttpRequestMessage reques)
        {

            return CreateHttpResponse(reques, () =>
            {
                HttpResponseMessage reponse = null;
                var lisparenId = _productService.GetAll();
                var lisparenIdVm = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(lisparenId);
                reponse = reques.CreateResponse(HttpStatusCode.OK, lisparenIdVm);

                return reponse;
            });


        }


        // xoa san pham
        [Route("delete")]
        [HttpDelete]

        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage reponse = null;
                if (!ModelState.IsValid)
                {
                    reponse = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var newproduct = _productService.Delete(id);
                    _productService.Save();

                    var product = Mapper.Map<Product, ProductViewModel>(newproduct);
                    reponse = request.CreateResponse(HttpStatusCode.Created, product);
                }

                return reponse;

            });


        }

        /// xoa nhieu san pham
        [Route("deleteMulti")]
        [HttpDelete]

        public HttpResponseMessage DeleteMuti(HttpRequestMessage request, String chekProduct)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var lisproduct = new JavaScriptSerializer().Deserialize<List<int>>(chekProduct);
                    foreach (var item in lisproduct)
                    {

                        _productService.Delete(item);
                    }
                    _productService.Save();
                    response = request.CreateResponse(HttpStatusCode.OK, lisproduct.Count);
                }
                return response;

            });


        }

        /// them san pham
        [Route("Created")]
        [HttpPost]

        public HttpResponseMessage Post(HttpRequestMessage reques, ProductViewModel productVM)
        {
            return CreateHttpResponse(reques, () =>
            {
                HttpResponseMessage reponse = null;
                if (!ModelState.IsValid)
                {
                    reponse = reques.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var product = new Product();
                    product.UpdateProduct(productVM);

                    _productService.Add(product);
                    _productService.Save();

                    var reponseData = Mapper.Map<Product, ProductViewModel>(product);
                    reponse = reques.CreateResponse(HttpStatusCode.Created, reponseData);
                }
                return reponse;
            });

        }

        // lay san pham theo ID
        [Route("GetbyId/{id:int}")]
        [HttpGet]

        public HttpResponseMessage GetByID(HttpRequestMessage reques, int id)
        {
            return CreateHttpResponse(reques, () =>
            {
                HttpResponseMessage response = null;
                var producTD = _productService.GetById(id);
                var productIDVM = Mapper.Map<Product, ProductViewModel>(producTD);
                response = reques.CreateResponse(HttpStatusCode.OK, productIDVM);
                return response;
            });
        }

        /// Cpa nhat san pham
        [Route("update")]
        [HttpPut]

        public HttpResponseMessage Update(HttpRequestMessage request, ProductViewModel productView)
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
                    var productUD = _productService.GetById(productView.Id);
                    productUD.UpdateProduct(productView);

                    _productService.Update(productUD);
                    _productService.Save();

                    var responData = Mapper.Map<Product, ProductViewModel>(productUD);
                    reppnse = request.CreateResponse(HttpStatusCode.Created, responData);
                }

                return reppnse;
            });
        }
    }
}
