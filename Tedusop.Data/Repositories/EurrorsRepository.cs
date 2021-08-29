using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tedusop.Model.Models;
using Tedusop.Data.Infrastructure;

namespace Tedusop.Data.Repositories
{
    public interface IEurrorsRepository : IRepository<Eurrors>
    { 
    
    }
     public class EurrorsRepository: RepositoryBase<Eurrors>,IEurrorsRepository
    {
        public EurrorsRepository(IDbFactory dbFactory) : base(dbFactory) 
        {
        }
    }
}
