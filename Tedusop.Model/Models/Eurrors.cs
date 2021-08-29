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
    [Table("Eurrors")]
    public class Eurrors
    {
        [Key]
        public int ID { set; get; }
        public String Message { set; get; }
        public String StackTrace { set; get; }
        public DateTime CreatedDate { set; get; }
    }
}
