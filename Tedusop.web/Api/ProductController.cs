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
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var lisProduct = _productService.GetAll();
                var lisProductVM = Mapper.Map<List<ProductViewModel>>(lisProduct);
                HttpResponseMessage repose = request.CreateResponse(HttpStatusCode.OK, lisProductVM);

                return repose;
            });
        }


    }
}
