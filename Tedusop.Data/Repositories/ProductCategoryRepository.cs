using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tedusop.Data.Infrastructure;
using Tedusop.Model.Models;

namespace Tedusop.Data.Repositories
{
    public interface IProductCategoryRepository : IRepository<ProductCategory> { }
    public  class ProductCategoryRepository : RepositoryBase<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(IDbFactory dbFactory) : base(dbFactory) { }
    }
}
