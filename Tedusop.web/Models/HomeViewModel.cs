using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tedusop.web.Models
{
    public class HomeViewModel
    {
        public IEnumerable<SlideViewModel> SlideDefalse { set; get; }
        public IEnumerable<ProductViewModel> LastestProduct { set; get; }
        public IEnumerable<ProductViewModel> HotProduct { set; get; }
    }
}