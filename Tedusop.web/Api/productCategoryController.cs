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
    [RoutePrefix("api/product1")]
    public class productCategoryController : ApiControllerBase
    {

        private readonly IProducCategoryService _producCategoryService;

        public productCategoryController(IProducCategoryService producCategoryService)
        {
            this._producCategoryService = producCategoryService;

        }
        [Route("getall")]
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
                    TotalCuont=totalRow,
                    TotalPage=(int)Math.Ceiling((decimal)totalRow/pageSize)

                };
                #endregion
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, paginationSet);
                return response;
            });
        }
    }
}