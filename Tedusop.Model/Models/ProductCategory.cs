using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tedusop.Model.Abstract;

namespace Tedusop.Model.Models
{
    [Table("ProductCategorys")]
    public class ProductCategory : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }
        [Required]
        public String Name { set; get; }
        [Required]
        public String Alias { set; get; }
        public String Description { set; get; }
        public int? parentID { set; get; }
        public int? DisplayOder { set; get; }
        public String Image { set; get; }
        public bool? HomeFlang { set; get; }

        public virtual IEnumerable<Product> Products { set; get; }
    }
}
