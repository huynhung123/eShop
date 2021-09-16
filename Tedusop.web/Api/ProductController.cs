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

namespace Tedusop.web.Api
{
    [RoutePrefix("api/product")]
    public class ProductController : ApiControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            this._productService = productService;

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
                var query = lisProduct.OrderByDescending(x => x.CreatedDate).Skip(page * pageSize).Take(pageSize);
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


    }
}
