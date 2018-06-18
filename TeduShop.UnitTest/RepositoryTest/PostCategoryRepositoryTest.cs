using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeduShop.Data.Infrastructure;
using TeduShop.Data.Repositories;
using TeduShop.Model.Models;

namespace TeduShop.UnitTest.RepositoryTest
{
    [TestClass]
    public class PostCategoryRepositoryTest
    {
        private IDbFactory _dbFactory;
        private IPostCategoryRepository _objPostCategoryRepository;
        private IUnitOfWork _unitOfWork;
        [TestInitialize]
        public void Initalize()
        {
            _dbFactory = new DbFactory();
            _objPostCategoryRepository = new PostCategoryRepository(_dbFactory);
            _unitOfWork = new UnitOfWork(_dbFactory);
        }
        [TestMethod]
        public void PostCategory_Repository_Create()
        {
            PostCategory category = new PostCategory
            {
                Name = "Test Category",
                Alias = "Test_Category",
                Status = true
            };
            var result = _objPostCategoryRepository.Add(category);
            _unitOfWork.Commit();

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.ID);
        }
        [TestMethod]
        public void PostCategory_Repository_GetAll()
        {
            var list = _objPostCategoryRepository.GetAll().ToList();
            Assert.AreEqual(1, list.Count);
        }
    }
}
