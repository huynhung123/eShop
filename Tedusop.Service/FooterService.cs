using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tedusop.Common;
using Tedusop.Data.Infrastructure;
using Tedusop.Data.Repositories;
using Tedusop.Model.Models;

namespace Tedusop.Service
{
    public interface IFooterService
    {
        Footer getFooter();
        IEnumerable<Slide> GetSlide();
    }
    public class FooterService : IFooterService
    {
        IFooterRepository _footerRepository;
        ISlideRepository _slideRepository;
        IUnitOfWord _unitOfWord;
        public FooterService(IFooterRepository footerRepository, IUnitOfWord unitOfWord, ISlideRepository slideRepository)
        {
            this._footerRepository = footerRepository;
            this._slideRepository = slideRepository;
            this._unitOfWord = unitOfWord;
        }
        public Footer getFooter()
        {
            return _footerRepository.GetSingleByCondition(x=>x.ID == CommonConstants.Defalsefooter);
        }

        public IEnumerable<Slide> GetSlide()
        {
            return _slideRepository.GetMulti(x=>x.Status); 
        }
    }
}
