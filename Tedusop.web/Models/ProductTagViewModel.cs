using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tedusop.Model.Models;

namespace Tedusop.web.Models
{
    public class ProductTagViewModel
    {
       
        public int ProductID { set; get; }

       
        public string TagID { set; get; }

        public virtual ProductViewModel Product { set; get; }

      
        public virtual TagViewModel Tag { set; get; }

    }
}