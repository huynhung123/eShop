using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tedusop.Data.Repositories;
using Tedusop.Model.Models;
using Tedusop.Data.Infrastructure;
using Tedusop.Common;
namespace Tedusop.Service
{
    public interface IProductService
    {
        Product Add(Product product);
        void Update(Product product);
        Product Delete(int id);
        IEnumerable<Product> GetAll();
        IEnumerable<Product> GetMutip(String keyWord);
        IEnumerable<Product> GetLastertProduct(int Top);
        IEnumerable<Product> HotlasterProduct(int Top);
        Product GetById(int id);
        IEnumerable<Product> GetAllPaging(int page, int pageSize, out int totalRow);
        IEnumerable<Product> GetAllByTagPaging(String Tag, int page, int pageSize, out int totalRow);
        IEnumerable<Product> GetListProductByCategoryIdPaging(int categoryId, int page, int pageSize, out int totalRow);
        void Save();
    }
    public class ProductService : IProductService
    {
        private IproductRepository _productRepository;
        private ITagRepository _tagRepository;
        private IProductTagRepository _productTagRepository;
        IUnitOfWord _uintOfWword;
        public ProductService(IproductRepository productRepository, ITagRepository tagRepository, IProductTagRepository productTagRepository, IUnitOfWord unitOfWord)
        {
            this._productRepository = productRepository;
            this._productTagRepository = productTagRepository;
            this._tagRepository = tagRepository;


            this._uintOfWword = unitOfWord;

        }

        public Product Add(Product product)
        {
            var productadd = _productRepository.Add(product);
            _uintOfWword.Commit();

            if (!String.IsNullOrEmpty(productadd.Tags))
            {
                String[] Tangsp = product.Tags.Split(',');
                for (var i = 0; i < Tangsp.Length; i++)
                {
                    var tagID = StringHelper.ToUnsignString(Tangsp[i]);
                    if (_tagRepository.Count(x => x.ID == tagID) == 0)
                    {
                        Tag tag = new Tag();
                        tag.ID = tagID;
                        tag.Name = Tangsp[i];
                        tag.Type = CommonConstants.ProductTag;
                        _tagRepository.Add(tag);
                    }

                    ProductTag productTag = new ProductTag();
                    productTag.TagID = tagID;
                    productTag.ProductID = product.Id;
                    _productTagRepository.Add(productTag);
                }
            }


            return productadd;
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

        public IEnumerable<Product> GetLastertProduct(int Top)
        {
            return _productRepository.GetMulti(x => x.Status).OrderByDescending(x => x.CreatedDate).Take(3);
        }

        public IEnumerable<Product> GetListProductByCategoryIdPaging(int categoryId, int page, int pageSize, out int totalRow)
        {
            var query = _productRepository.GetMulti(x => x.Status).OrderBy(x=>x.CategoryId==categoryId);

            totalRow = query.Count();

            return query.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }

        public IEnumerable<Product> GetMutip(string keyWord)
        {
            if (!String.IsNullOrEmpty(keyWord))
                return _productRepository.GetMulti(x => x.Name.Contains(keyWord) || x.Description.Contains(keyWord));
            else
                return _productRepository.GetAll();
        }

        public IEnumerable<Product> HotlasterProduct(int Top)
        {
            return _productRepository.GetMulti(x => x.Status && x.HotFlang == true).OrderByDescending(x => x.CreatedDate).Take(3);
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
