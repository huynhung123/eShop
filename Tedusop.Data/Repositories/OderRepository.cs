using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tedusop.Model.Models;
using Tedusop.Data.Infrastructure;

namespace Tedusop.Data.Repositories
{
    public interface IOderRepository : IRepository<Order> { }
    public  class OderRepository :RepositoryBase<Order>, IOderRepository
    {
        public OderRepository(IDbFactory dbFactory) : base(dbFactory) { }
    }
}
