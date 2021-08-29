using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tedusop.Model.Models;
using Tedusop.Data.Repositories;
using Tedusop.Data.Infrastructure;

namespace Tedusop.Service
{
    public  interface IEurrorsService
    {
        Eurrors Create(Eurrors eurrors);
        void save();
    }
    public class EurrorsService : IEurrorsService
    {
        IEurrorsRepository _eurrorsRepository;
        IUnitOfWord _uintOfword;
        public EurrorsService(IEurrorsRepository eurrorsRepository, IUnitOfWord unitOfWord)
        {
            this._eurrorsRepository = eurrorsRepository;
            this._uintOfword = unitOfWord;
        }
        public Eurrors Create(Eurrors eurrors)
        {
            return _eurrorsRepository.Add(eurrors);
        }

        public void save()
        {
            _uintOfword.Commit();
        }
    }
}
