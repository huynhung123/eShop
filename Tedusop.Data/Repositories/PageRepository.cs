using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tedusop.Data.Infrastructure;
using Tedusop.Model.Models;

namespace Tedusop.Data.Repositories
{
    public interface IpageRepository : IRepository<Page> { }
    class PageRepository : RepositoryBase<Page>,IpageRepository
    {
        public PageRepository(IDbFactory dbFactory) : base(dbFactory) { }
    }
}
