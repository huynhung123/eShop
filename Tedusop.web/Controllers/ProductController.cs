using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
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
            var product = _productService.GetById(id);
            var ProductViewModel = Mapper.Map<Product, ProductViewModel>(product);
            var productReated = _productService.GetReadtedProducts(id, 6);
            ViewBag.productReated = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(productReated);

           
            List<String> listImg = new JavaScriptSerializer().Deserialize<List<String>>(ProductViewModel.MoreImages);
            ViewBag.moreIMG = listImg;
            return View(ProductViewModel);
        }
        public ActionResult Category(int id, int page = 1, String sort = "")
        {
            int pageSize = int.Parse(ConfigHelper.GetByKey("pageSize"));
            int totalRow = 0;

            var productModel = _productService.GetListProductByCategoryIdPaging(id, page, pageSize, sort, out totalRow);
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
        public ActionResult Seach(String name, int page = 1, String sort = "")
        {
            int pageSize = int.Parse(ConfigHelper.GetByKey("pageSize"));
            int totalRow = 0;

            var productModel = _productService.Seach(name, page, pageSize, sort, out totalRow);
            var productViewModel = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(productModel);
            int totalPage = (int)Math.Ceiling((double)totalRow / pageSize);

            ViewBag.name = name;

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
        public JsonResult GetListProductByName(String name)
        {
            var model = _productService.GetListProductByName(name);
            return Json(new
            {
                data = model
            }, JsonRequestBehavior.AllowGet);

        }
    }
}