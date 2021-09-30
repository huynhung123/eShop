using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tedusop.web.Controllers
{
    public class HomeController : Controller
    {
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
            return PartialView();
        }
    }
}