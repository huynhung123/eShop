using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Tedusop.Model.Abstract;

namespace Tedusop.Model.Models
{
    [Table("Products")]
    public class Product : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; }
        public String Name { set; get; }
        [Required]
        public String Alias { set; get; }
        
        public int CategoryId { set; get; }
        public String Image { set; get; }
        [Column (TypeName ="xml")]
        public String MoreImages { set; get; }
        public decimal Price { set; get; }
        public decimal? PromotionPrice { set; get; }
        public int? Warranty { set; get; }
        public String Description { set; get; }
        public String Content { set; get; }

        public bool? HomeFlang { set; get; }
        public bool? HotFlang { set; get; }
        public int? ViewCuont { set; get; }

        public String Tags { set; get; }
        public int Quantity { set; get; }

        [ForeignKey("CategoryId")]
        public virtual ProductCategory ProductCategory { set; get; }
    }
}
