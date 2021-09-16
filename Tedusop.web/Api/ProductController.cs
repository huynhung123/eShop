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
        // lay toan bo san pham
        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage Get(HttpRequestMessage request, int page, int pageSize = 3)
        {
            return CreateHttpResponse(request, () =>
            {
                int totalRow = 0;
                
                var lisProduct = _productService.GetAll();
                totalRow = lisProduct.Count();
                var query = lisProduct.OrderByDescending(x => x.CreatedDate).Skip(page * pageSize).Take(pageSize);
                var lisProductVM = Mapper.Map<List<ProductViewModel>>(lisProduct);

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


    }
}
