using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tedusop.web.Models
{
    public class ProductCategoryViewModel
    {
        public int ID { set; get; }
    
        public String Name { set; get; }
      
        public String Alias { set; get; }
        public String Description { set; get; }
        public int? parentID { set; get; }
        public int? DisplayOder { set; get; }
        public String Image { set; get; }
        public bool? HomeFlang { set; get; }

        public DateTime? CreatedDate { set; get; }
     
        public String CreatedBy { set; get; }
        public DateTime? UpdatedDate { set; get; }
      
        public String UpdateBy { set; get; }
     
        public String MetaKeyword { set; get; }
    
        public String MetaDescription { set; get; }
        public bool Status { set; get; }
        public virtual IEnumerable<ProductViewModel> Products { set; get; }

    }
}