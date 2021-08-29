﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tedusop.Data.Repositories;
using Tedusop.Model.Models;
using Tedusop.Data.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

namespace Tedusop.Service
{
    public  interface IProducCategoryService
    {
        ProductCategory Add(ProductCategory post);
        void Update(ProductCategory post);
        void Delete(int id);
        IEnumerable<ProductCategory> GetAll();
        ProductCategory GetByid(int id);
        IEnumerable<ProductCategory> GetAllPaging(int page, int pageSize, out int totalRow);
        IEnumerable<ProductCategory> GetAllByTagPaging(String tag, int page, int pageSize, out int totalRow);
        void SaveChanges();
    }
    public  class ProducCategoryService : IProducCategoryService
    {
        IProductCategoryRepository _productCategoryRepository;
        IUnitOfWord _unitOfWord;
        public ProducCategoryService(IProductCategoryRepository productCategoryRepository, IUnitOfWord unitOfWord)
        {
            this._productCategoryRepository = productCategoryRepository;
            this._unitOfWord = unitOfWord;
        }

        public ProductCategory Add(ProductCategory post)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductCategory> GetAll()
        {
            return _productCategoryRepository.GetAll();
        }

        public IEnumerable<ProductCategory> GetAllByTagPaging(string tag, int page, int pageSize, out int totalRow)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductCategory> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            throw new NotImplementedException();
        }

        public ProductCategory GetByid(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Update(ProductCategory post)
        {
            throw new NotImplementedException();
        }
    }
}