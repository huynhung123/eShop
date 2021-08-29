using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tedusop.Model.Models
{
    [Table("MenuGroups")]
    public class MenuGroup
    {
         [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }
        [Required]
        [MaxLength(50)]
        public String Name { set; get; }
        public virtual IEnumerable<Menu> Menus { set; get; }
    }
}
