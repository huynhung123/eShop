using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tedusop.Model.Models;
using Tedusop.Data.Infrastructure;

namespace Tedusop.Data.Repositories
{
    public interface IPostCategoryRepository : IRepository<PostCategory>{ }
    public class PostCategoryRepository : RepositoryBase<PostCategory>,IPostCategoryRepository
    {
        public PostCategoryRepository(IDbFactory dbFactory) : base(dbFactory) { }
    }
}
