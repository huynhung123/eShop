using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tedusop.Model.Abstract
{
    public interface IAudiTable
    {
        DateTime? CreatedDate { set; get; }
        String CreatedBy { set; get; }
        DateTime? UpdatedDate { set; get; }
        String UpdateBy { set; get; }
        String MetaKeyword { set; get; }
        String MetaDescription { set; get; }
        bool Status { set; get; }
    }
}
