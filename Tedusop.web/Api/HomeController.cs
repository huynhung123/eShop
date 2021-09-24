using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tedusop.web.infrastructure.core;
using Tedusop.Service;

namespace Tedusop.web.Api
{
    [RoutePrefix("api/home")]
    [Authorize]
    public class HomeController : ApiControllerBase
    {
        IEurrorsService _eurrorsService;
        public HomeController(IEurrorsService eurrorsService) : base(eurrorsService)
        {
            this._eurrorsService = eurrorsService;
        }
        [Route("TestMethod")]
        [HttpGet]
       
        public String TestMethod()
        {
            return "helr tedu";
        
        }
    }
}
