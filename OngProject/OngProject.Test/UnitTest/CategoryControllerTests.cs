using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OngProject.Controllers;
using OngProject.Core.DTOs;
using OngProject.Core.Interfaces.IUnitOfWork;
using OngProject.Core.Mapper;
using OngProject.Core.Models;
using OngProject.Core.Services;
using OngProject.Core.Services.AWS;
using OngProject.Core.Services.UriPagination;
using OngProject.Infrastructure;
using OngProject.Infrastructure.Data;
using OngProject.Test.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OngProject.Test.UnitTest
{
    [TestClass]
    public class CategoryControllerTests: BaseTests
    {
        private ApplicationDbContext _context;
        private CategoryController categoryController;

        [TestInitialize]
        public void Init()
        {
            _context = MakeContext("TestDB");
            IUnitOfWork unitOfWork = new UnitOfWork(_context);
            ImageService image = new ImageService();
            UriPaginationService pagination = new UriPaginationService("http://test");
            CategoryService service = new CategoryService(unitOfWork, image, pagination);
            categoryController = new CategoryController(service);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _context.Database.EnsureDeleted();
        }

        public IFormFile CreateImage()
        {
            var stream = File.OpenRead(@"..\..\..\UnitTest\Image\Captura1.PNG");
            var file = new FormFile(stream, 0, stream.Length, null, Path.GetFileName(stream.Name))
            {
                Headers = new HeaderDictionary(),
                ContentType = "image/png"
            };

            return file;
        }

        [TestMethod]
        public async Task Post_Should_Create_Category_And_Return_Created()
        {

            // Arrange
            var categoryTest = new CategoryCreateDto() { 
                Name = "Tests", 
                Description = "this is a category insertion test", 
                Image = CreateImage()
            };

            // Act
            var actionResult = await categoryController.Post(categoryTest);
            var objResult = _context.Categories.Count();

            // Assert
            Assert.AreEqual(typeof(CreatedAtActionResult), actionResult.GetType());
            Assert.AreEqual(1, objResult);
        }

        [TestMethod]
        public async Task Post_Should_NotCreate_Category_And_Return_BadRequest()
        {

            // Arrange
            var categoryTest = new CategoryCreateDto()
            {
                Name = "Tests",
                Description = "this is a category insertion test",
                Image = null
            };

            // Act
            var actionResult = await categoryController.Post(categoryTest);
            var objResult = _context.Categories.Count();

            // Assert
            Assert.AreEqual(typeof(BadRequestObjectResult), actionResult.GetType());
            Assert.AreEqual(0, objResult);
        }

        [TestMethod]
        public async Task Put_Should_Modify_Existing_Category()
        {

            // Arrange
            var categoryTest = new CategoryModel()
            {
                Name = "Tests",
                Description = "this is a category insertion test",
                Image = null
            };

            _context.Categories.Add(categoryTest);
            await _context.SaveChangesAsync();

            var categoryDto = new CategoryCreateDto()
            {
                Name = "Test 1",
                Description = "This is a category update test",
                Image = CreateImage()
            };

            // Act
            var actionResult = await categoryController.Put(categoryDto, categoryTest.Id);
            var value = actionResult.GetType().GetProperty("Value")?.GetValue(actionResult);
            var categoryResponse = value as CategoryModel;

            // Assert
            Assert.AreEqual(typeof(OkObjectResult), actionResult.GetType());
            Assert.AreEqual(categoryTest.Name, categoryResponse.Name);
        }

        [TestMethod]
        public async Task Put_Should_NotModify_NonExistent_Category()
        {

            // Arrange
            var categoryDto = new CategoryCreateDto()
            {
                Name = "Test 1",
                Description = "This is a category update test",
                Image = CreateImage()
            };

            // Act
            var actionResult = await categoryController.Put(categoryDto, 1);
            var objResult = _context.Categories.Count();

            // Assert
            Assert.AreEqual(typeof(NotFoundObjectResult), actionResult.GetType());
            Assert.AreEqual(0, objResult);
        }

        [TestMethod]
        public async Task GetById_Should_Return_category_FromTheDb()
        {
            // Arrange
            var categoryTest = new CategoryModel()
            {
                Name = "Category 1",
                Description = "this is a category insertion test",
                Image = null
            };

            _context.Categories.Add(categoryTest);
            await _context.SaveChangesAsync();

            // Act
            var category = _context.Categories.Single();
            var actionResult = await categoryController.GetById(category.Id);

            // Assert
            Assert.IsNotNull(actionResult);
            Assert.AreEqual(typeof(OkObjectResult), actionResult.GetType());

            var value = actionResult.GetType().GetProperty("Value")?.GetValue(actionResult);
            var categoryResponse =  value as CategoryModel;

            Assert.AreEqual(category.Name, categoryResponse.Name);
        }

        [TestMethod]
        public async Task GetById_Should_Return_404_If_Not_Exist_InTheBD()
        {
            // Act

            var actionResult = await categoryController.GetById(1);

            // Assert
            Assert.AreEqual(typeof(NotFoundResult), actionResult.GetType());

        }

        [TestMethod]
        public async Task Delete_Category_That_Should_Exist_InTheDb()
        {

            // Arrange
            var categoryTest = new CategoryModel()
            {
                Name = "Tests",
                Description = "this is a category insertion test",
                Image = null
            };

            _context.Categories.Add(categoryTest);
            await _context.SaveChangesAsync();

            // Act
            var category = _context.Categories.Single();
            var actionResult = await categoryController.Delete(category.Id);

            // Assert
            Assert.AreEqual(typeof(OkResult), actionResult.GetType());

            Assert.AreEqual(true, category.IsDeleted);

        }

        [TestMethod]
        public async Task Delete_Category_Should_Return_404_If_Not_Exist_InTheBD()
        {
            // Act

            var actionResult = await categoryController.Delete(1);

            // Assert
            Assert.AreEqual(typeof(NotFoundResult), actionResult.GetType());

        }

        [TestMethod]
        public async Task GetAll_Should_Return_List_Categories()
        {

            // Arrange
            for (int i= 0; i < 55; i++)
            {
                _context.Categories.Add(new CategoryModel() { Name = "Category "+ i, Description = "This is the category "+ i, Image = "image"+i+".jpg" });
            }

            await _context.SaveChangesAsync();

            // Act

            var actionResult = await categoryController.GetAll();
            var objResult = _context.Categories.Count();

            // Assert
            Assert.AreEqual(55, objResult);

        }
    }

}
