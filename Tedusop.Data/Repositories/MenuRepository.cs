using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tedusop.Data.Infrastructure;
using Tedusop.Model.Models;

namespace Tedusop.Data.Repositories
{
    public interface IMenuRepository :IRepository<Menu> { }
    public class MenuRepository : RepositoryBase<Menu>, IMenuRepository
    {
        public MenuRepository(IDbFactory dbFactory) : base(dbFactory) { }
    }
}
