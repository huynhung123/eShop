using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Tedusop.web.infrastructure.core
{
    public class PaginationSet<T>
    {
        public int Page { get; set; }
        public int Count {

            get {
                // khac null tra ve slg Item neu null tra ve 0
                return (Items != null) ? Items.Count() : 0;
            }
        }
        public int TotalPage { get; set; }
        public int TotalCuont { get; set; }
        public int MaxPage { set; get; }

        public IEnumerable<T> Items { get; set; }
    }
}