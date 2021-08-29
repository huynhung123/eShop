﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tedusop.Data.Infrastructure;
using Tedusop.Model.Models;

namespace Tedusop.Data.Repositories
{
    public interface ISupportOnlineRepository : IRepository<SupportOnline> { }
    public  class SupportOnlineRepository:RepositoryBase<SupportOnline>,ISupportOnlineRepository
    {
        public SupportOnlineRepository(DbFactory dbFactory) : base(dbFactory) { }
    }
}