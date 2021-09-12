using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tedusop.Data.Repositories;
using Tedusop.Model.Models;
using Tedusop.Data.Infrastructure;

namespace Tedusop.Service
{
    public interface IProductService
    {
        Product Add(Product product);
        void Update(Product product);
        Product Delete(int id);
        IEnumerable<Product> GetAll();
        IEnumerable<Product> GetMutip(String keyWord);
        Product GetById(int id);
        IEnumerable<Product> GetAllPaging(int page, int pageSize, out int totalRow);
        IEnumerable<Product> GetAllByTagPaging(String Tag, int page, int pageSize, out int totalRow);
        void Save();
    }
    public class ProductService : IProductService
    {
        IproductRepository _productRepository;
        IUnitOfWord _uintOfWword;
        public ProductService(IproductRepository productRepository, IUnitOfWord unitOfWord)
        {
            this._productRepository = productRepository;
            this._uintOfWword = unitOfWord;
        
        }

        public Product Add(Product product)
        {
            return _productRepository.Add(product);
        }

        public Product Delete(int id)
        {
            return _productRepository.Delete(id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public IEnumerable<Product> GetAllByTagPaging(string Tag, int page, int pageSize, out int totalRow)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            throw new NotImplementedException();
        }

        public Product GetById(int id)
        {
            return _productRepository.GetSingleById(id);
        }

        public IEnumerable<Product> GetMutip(string keyWord)
        {
            if (!String.IsNullOrEmpty(keyWord))
                return _productRepository.GetMulti(x => x.Name.Contains(keyWord) || x.Description.Contains(keyWord));
            else
                return _productRepository.GetAll();
        }

        public void Save()
        {
            _uintOfWword.Commit();
        }

        public void Update(Product product)
        {
            _productRepository.Update(product);
        }
    }
}
