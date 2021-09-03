using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tedusop.Model.Models;
using Tedusop.Data.Infrastructure;

namespace Tedusop.Data.Repositories
{
    public interface IPostTagRepository : IRepository<PostTag> { }
    public  class PostTagRepository:RepositoryBase<PostTag>,IPostTagRepository
    {
        public PostTagRepository(IDbFactory dbFactory) : base(dbFactory) { }
    }
}
