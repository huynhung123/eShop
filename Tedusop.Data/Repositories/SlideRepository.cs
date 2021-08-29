using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tedusop.Model.Models;
using Tedusop.Data.Infrastructure;

namespace Tedusop.Data.Repositories
{
    public interface ISlideRepository : IRepository<Slide> { }
    public  class SlideRepository:RepositoryBase<Slide>,ISlideRepository
    {
        public SlideRepository(DbFactory dbFactory) : base(dbFactory) { }
    }
}
