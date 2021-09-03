using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tedusop.Model.Models;
using Tedusop.Data.Infrastructure;

namespace Tedusop.Data.Repositories
{
    public interface IproductRepository : IRepository<Product>{ }
    public  class ProductRepository : RepositoryBase<Product>,IproductRepository
    {
        public ProductRepository(IDbFactory dbFactory) : base(dbFactory) { }
    }
}
