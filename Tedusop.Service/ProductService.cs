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
        IEnumerable<Product> GetListProductByCategoryIdPaging(int categoryId, int page, int pageSize, String sort, out int totalRow);
        IEnumerable<Product> Seach(String keyword, int page, int pageSize, String sort, out int totalRow);
        IEnumerable<String> GetListProductByName(String name);
        IEnumerable<Product> GetReadtedProducts(int id, int top);
        void Save();
        IEnumerable<Tag> GetListTagByProductId(int id);
        Tag getTag(String tagID);
        void IncreaseView(int id);
        IEnumerable<Product> GetListProductByTag(String tagId, int page, int pageSize, out int totalRow);
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
                //xoa het tag product trước
                //var tag = _productTagRepository.GetByProductId(product);
                //_productTagRepository.Delete(tag)
                //them tag product
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
            //trước khi xóa check có product trong bang tag ko, neu co thì xóa tag ttriowcs rồi xóa sp
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

        public IEnumerable<Product> GetListProductByCategoryIdPaging(int categoryId, int page, int pageSize, String sort, out int totalRow)
        {
            var query = _productRepository.GetMulti(x => x.Status && x.CategoryId == categoryId);
            switch (sort)
            {
                case "new":
                    query = query.OrderByDescending(x => x.CreatedDate);
                    break;
                case "popular":
                    query = query.OrderByDescending(x => x.ViewCuont);
                    break;
                case "discount":
                    query = query.OrderByDescending(x => x.PromotionPrice.HasValue);
                    break;
                case "price":
                    query = query.OrderBy(x => x.Price);
                    break;
                default:
                    query = query.OrderByDescending(x => x.CreatedDate);
                    break;
            }
            totalRow = query.Count();

            return query.Skip((page - 1) * pageSize).Take(pageSize);
        }

        public IEnumerable<String> GetListProductByName(string name)
        {
            return _productRepository.GetMulti(x => x.Status && x.Name.Contains(name)).Select(y => y.Name);
        }

        public IEnumerable<Product> GetListProductByTag(String tagId, int page, int pageSize, out int totalRow)
        {
            var model = _productRepository.GetMulti(x => x.Status && x.Productag.Count(y => y.ProductID == x.Id) > 0, new String[] { "Productcategory", "Producttag" });
            totalRow = model.Count();
            return model.OrderByDescending(x => x.CreatedDate).Skip((page - 1) * pageSize).Take(pageSize);
        }

        public IEnumerable<Tag> GetListTagByProductId(int id)
        {
            return _productTagRepository.GetMulti(x => x.ProductID == id, new string[] { "Tag" }).Select(y => y.Tag);
        }

        public IEnumerable<Product> GetMutip(string keyWord)
        {
            if (!String.IsNullOrEmpty(keyWord))
                return _productRepository.GetMulti(x => x.Name.Contains(keyWord) || x.Description.Contains(keyWord));
            else
                return _productRepository.GetAll();
        }

        public IEnumerable<Product> GetReadtedProducts(int id, int top)
        {
            var product = _productRepository.GetSingleById(id);
            return _productRepository.GetMulti(x => x.Status && x.Id != id && x.CategoryId == product.CategoryId).OrderByDescending(y => y.CreatedDate).Take(top);
        }

        public Tag getTag(string tagID)
        {
            return _tagRepository.GetSingleByCondition(x => x.ID == tagID);
        }

        public IEnumerable<Product> HotlasterProduct(int Top)
        {
            return _productRepository.GetMulti(x => x.Status && x.HotFlang == true).OrderByDescending(x => x.CreatedDate).Take(3);
        }

        public void IncreaseView(int id)
        {
            var product = _productRepository.GetSingleById(id);

            if (product.ViewCuont.HasValue)
            {
                product.ViewCuont += 1;
            }
            else
            {
                product.ViewCuont = 1;
            }
        }

        public void Save()
        {
            _uintOfWword.Commit();
        }

        public IEnumerable<Product> Seach(string keyword, int page, int pageSize, string sort, out int totalRow)
        {
            var query = _productRepository.GetMulti(x => x.Status && x.Name.Contains(keyword));
            switch (sort)
            {
                case "new":
                    query = query.OrderByDescending(x => x.CreatedDate);
                    break;
                case "popular":
                    query = query.OrderByDescending(x => x.ViewCuont);
                    break;
                case "discount":
                    query = query.OrderByDescending(x => x.PromotionPrice.HasValue);
                    break;
                case "price":
                    query = query.OrderBy(x => x.Price);
                    break;
                default:
                    query = query.OrderByDescending(x => x.CreatedDate);
                    break;
            }
            totalRow = query.Count();

            return query.Skip((page - 1) * pageSize).Take(pageSize);
        }

        public void Update(Product product)
        {
            _productRepository.Update(product);


            if (!String.IsNullOrEmpty(product.Tags))
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
            else
            {
                var producttag = _productTagRepository.GetMulti(x => x.ProductID == product.Id);

                foreach (var producT in producttag)
                {
                    var tag = _tagRepository.GetSingle(producT.TagID);
                    _tagRepository.Delete(tag);
                }

            }

        }
    }
}
