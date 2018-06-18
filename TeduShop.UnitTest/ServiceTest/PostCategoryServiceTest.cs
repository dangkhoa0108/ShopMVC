using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TeduShop.Data.Infrastructure;
using TeduShop.Data.Repositories;
using TeduShop.Model.Models;
using TeduShop.Service;

namespace TeduShop.UnitTest.ServiceTest
{
    [TestClass]
    public class PostCategoryServiceTest
    {
        private Mock<IPostCategoryRepository> _mockRepositoryMock;
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private IPostCategoryService _categoryService;
        private List<PostCategory> _listCategory;
        [TestInitialize]
        public void Intialize()
        {
            _mockRepositoryMock = new Mock<IPostCategoryRepository>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _categoryService = new PostCategoryService(_mockRepositoryMock.Object, _mockUnitOfWork.Object);
            _listCategory = new List<PostCategory>()
            {
                new PostCategory()
                {
                    ID = 1,
                    Name = "C1",
                    Status = true
                },
                new PostCategory()
                {
                    ID = 2,
                    Name = "C2",
                    Status = true
                },
                new PostCategory()
                {
                    ID = 3,
                    Name = "C3",
                    Status = true
                }
            };

        }
        [TestMethod]
        public void PostCategory_Service_GetAll()
        {
            //Setup method
            _mockRepositoryMock.Setup(m => m.GetAll(null)).Returns(_listCategory);
            //Call Action
            var result = _categoryService.GetAll() as List<PostCategory>;
            //Compare
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count);
        }

        [TestMethod]
        public void PostCategory_Service_Create()
        {
            PostCategory category = new PostCategory
            {
                Name = "Test",
                Alias = "Test",
                Status = true
            };

            _mockRepositoryMock.Setup(m => m.Add(category)).Returns((PostCategory p) => { p.ID = 1;
                return p;
            });
            var result= _categoryService.Add(category);
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.ID);
        }
    }
}
