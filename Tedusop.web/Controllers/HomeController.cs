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
        IFooterService _footerService;
        public HomeController(IProducCategoryService producCategoryService, IFooterService footerSerVice)
        {

            this._producCategoryService = producCategoryService;
            this._footerService = footerSerVice;
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View();
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
            var mode = _producCategoryService.GetAll();
            var listCategory = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(mode);
            return PartialView(listCategory);
        }
    }
}