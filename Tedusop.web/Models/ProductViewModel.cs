using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tedusop.web.Models
{
    public class ProductViewModel
    {
       
        public int Id { set; get; }
        public String Name { set; get; }
     
        public String Alias { set; get; }

        public int CategoryId { set; get; }
        public String Image { set; get; }
     
        public String MoreImages { set; get; }
        public decimal Price { set; get; }
        public decimal? PromotionPrice { set; get; }
        public int? Warranty { set; get; }
        public String Description { set; get; }
        public String Content { set; get; }

        public bool? HomeFlang { set; get; }
        public bool? HotFlang { set; get; }
        public int? ViewCuont { set; get; }

        public DateTime? CreatedDate { set; get; }
      
        public String CreatedBy { set; get; }
        public DateTime? UpdatedDate { set; get; }
       
        public String UpdateBy { set; get; }
     
        public String MetaKeyword { set; get; }
       
        public String MetaDescription { set; get; }
        public bool Status { set; get; }

        public virtual ProductCategoryViewModel ProductCategory { set; get; }

    }
}