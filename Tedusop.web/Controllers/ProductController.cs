using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tedusop.Common;
using Tedusop.Model.Models;
using Tedusop.Service;
using Tedusop.web.infrastructure.core;
using Tedusop.web.Models;

namespace Tedusop.web.Controllers
{
    public class ProductController : Controller
    {
        IProductService _productService;
        IProducCategoryService _productCategoryService;
        public ProductController(IProductService productService, IProducCategoryService producCategoryService)
        {
            this._productService = productService;
            this._productCategoryService = producCategoryService;
        }
        // GET: Product
        public ActionResult Detail(int id)
        {

            return View();
        }
        public ActionResult Category(int id, int page = 1)
        {
            int pageSize = int.Parse(ConfigHelper.GetByKey("pageSize"));
            int totalRow = 0;
           
            var productModel = _productService.GetListProductByCategoryIdPaging(id, page, pageSize, out totalRow);
            var productViewModel = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(productModel);
            int totalPage = (int)Math.Ceiling((double)totalRow / pageSize);
            var category = _productCategoryService.GetByid(id);
            ViewBag.category = Mapper.Map<ProductCategory, ProductCategoryViewModel>(category);

            var PaginationSet = new PaginationSet<ProductViewModel>()
            {
                Items = productViewModel,
                MaxPage = int.Parse(ConfigHelper.GetByKey("MaxPage")),
                Page = page,
                TotalCuont = totalRow,
                TotalPage = totalPage
            };
            return View(PaginationSet);
        }
    }
}