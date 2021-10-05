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

        public HomeController(IProducCategoryService producCategoryService)
        {

            this._producCategoryService = producCategoryService;
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        [ChildActionOnly]
        public ActionResult Footer()
        {
            return PartialView("footer");        
        }
        [ChildActionOnly]
        public ActionResult Header()
        {
            return PartialView();
        }
        public ActionResult category()
        {
            var model = _producCategoryService.GetAll();
            var listCategory = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(model);
            return PartialView(listCategory);
        }
    }
}