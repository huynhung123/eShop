using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tedusop.Model.Models;
using Tedusop.Service;
using Tedusop.web.Models;

namespace Tedusop.web.Controllers
{
    public class HomeController : Controller
    {
        IProducCategoryService _producCategoryService;
        IProductService _productService;
        IFooterService _footerService;
        public HomeController(IProducCategoryService producCategoryService, IProductService productService, IFooterService footerSerVice)
        {

            this._producCategoryService = producCategoryService;
            this._footerService = footerSerVice;
            this._productService = productService;
        }
        // GET: Admin
        public ActionResult Index()
        
        {
            var modelslide = _footerService.GetSlide();
            var slideDfalse = Mapper.Map<IEnumerable<Slide>, IEnumerable<SlideViewModel>>(modelslide);
            

            var LaterProduct = _productService.GetLastertProduct(3);
            var LasterProductViewMD = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(LaterProduct);

            var HotProduct = _productService.HotlasterProduct(3);
            var HotProductViewMD = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(HotProduct);

            var homeViewModel = new HomeViewModel();
            homeViewModel.SlideDefalse = slideDfalse;
            homeViewModel.LastestProduct = LasterProductViewMD;
            homeViewModel.HotProduct = HotProductViewMD;
            return View(homeViewModel);
        }
        [ChildActionOnly]
        public ActionResult Footer()
        {
            var modelFooter = _footerService.getFooter();
            var footerDefalse = Mapper.Map<Footer, FooterViewModel>(modelFooter);
            return PartialView(footerDefalse);        
        }
        [ChildActionOnly]
        public ActionResult Header()
        {
            return PartialView();
        }
        public ActionResult category()
        {
            var mode = _producCategoryService.GetAllMenu();
            var listCategory = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(mode);
            return PartialView(listCategory);
        }
    }
}