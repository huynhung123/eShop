using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tedusop.Data.Repositories;
using Tedusop.Data.Infrastructure;
using Tedusop.Model.Models;

namespace Tedusop.Test.repositoryTest
{
    [TestClass]
      public class ProductcategoryTest
    {
        IDbFactory dbFactory;
        IProductCategoryRepository objRepository;
        IUnitOfWord unitOfWork;

        [TestInitialize]
        public void Initialize()
        {
            dbFactory = new DbFactory();
            objRepository = new ProductCategoryRepository(dbFactory);
            unitOfWork = new UnitOfWork(dbFactory);
        }
        [TestMethod]
        public void PostCategory_Repository_Create()
        {
            ProductCategory category = new ProductCategory();
            category.Name = "Test category";
            category.Alias = "Test-category";
            category.Status = true;

            var result = objRepository.Add(category);
            unitOfWork.Commit();

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.ID);
        }
    }
}
