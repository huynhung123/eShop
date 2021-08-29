using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tedusop.Model.Models;
using Tedusop.Data.Infrastructure;

namespace Tedusop.Data.Repositories
{
    public interface IPostRepository : IRepository<Post> 
    {
        IEnumerable<Post> GetAllByTag(String tag, int PageIndex, int pagesize, out int totalRow);
             

    }
    public class PostRepository:RepositoryBase<Post>,IPostRepository
    {
        public PostRepository(IDbFactory dbFactory) : base(dbFactory) { }

        public IEnumerable<Post> GetAllByTag(string tag, int PageIndex, int pagesize, out int totalRow)
        {
            var query = from p in DbContext.Posts
                        join pt in DbContext.PostTags
                        on p.ID equals pt.PostID
                        where pt.TagID == tag
                        select p;
            totalRow = query.Count();
            query = query.Skip((PageIndex - 1) * pagesize).Take(pagesize);
            return query;
        }
    }
}
