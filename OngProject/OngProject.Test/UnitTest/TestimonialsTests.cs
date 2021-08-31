using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OngProject.Controllers;
using OngProject.Core.DTOs;
using OngProject.Core.Helper.Pagination;
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
    public class TestimonialsControllerTests : BaseTests
    {
        private ApplicationDbContext _context;
        private TestimonialsController testimonialsController;

        [TestInitialize]
        public void Init()
        {
            _context = MakeContext("TestDB");
            IUnitOfWork unitOfWork = new UnitOfWork(_context);
            ImageService image = new ImageService();
            UriPaginationService pagination = new UriPaginationService("http://test");
            TestimonialsService service = new TestimonialsService(unitOfWork, image, pagination);
            testimonialsController = new TestimonialsController(service);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _context.Database.EnsureDeleted();
        }

        [TestMethod]
        public async Task Post_Should_Create_Testimonials_And_Return_Created()
        {

            // Arrange
            var testimonialsTest = new CreateTestimonialsDto()
            {
                Name = "Tests",
                Content = "Testimonial creation test"
            };

            // Act
            var actionResult = await testimonialsController.Post(testimonialsTest);
            var objResult = _context.Testimonials.Count();

            // Assert
            Assert.AreEqual(typeof(CreatedAtActionResult), actionResult.GetType());
            Assert.AreEqual(1, objResult);
        }

        [TestMethod]
        public async Task Post_Should_NotCreate_Testimonials_And_Return_BadRequest()
        {
            // Arrange
            var testimonialsTest = new CreateTestimonialsDto()
            {
                Name = null,
                Content = null
            };

            // Act
            var actionResult = await testimonialsController.Post(testimonialsTest);
            var objResult = _context.Testimonials.Count();

            // Assert
            Assert.AreEqual(typeof(BadRequestObjectResult), actionResult.GetType());
            Assert.AreEqual(0, objResult);
        }

        [TestMethod]
        public async Task Put_Should_Modify_Existing_Testimonials()
        {

            // Arrange
            var testimonialsTest = new TestimonialsModel()
            {
                Name = "Tests",
                Content = "Testimonial creation test",
                Image = null
            };

            _context.Testimonials.Add(testimonialsTest);
            await _context.SaveChangesAsync();

            var testimonialsDto = new CreateTestimonialsDto()
            {
                Name = "Test 1",
                Content = "Testimonial creation test"
            };

            // Act
            var actionResult = await testimonialsController.Put(testimonialsDto, testimonialsTest.Id);
            var value = actionResult.GetType().GetProperty("Value")?.GetValue(actionResult);
            var testimonialsResponse = value as TestimonialsModel;

            // Assert
            Assert.AreEqual(typeof(OkObjectResult), actionResult.GetType());
            Assert.AreEqual(testimonialsTest.Name, testimonialsResponse.Name);
        }

        [TestMethod]
        public async Task Put_Should_NotModify_NonExistent_Testimonials()
        {

            // Arrange
            var testimonialsDto = new CreateTestimonialsDto()
            {
                Name = "Test 1",
                Content = "Testimonial creation test"
            };

            // Act
            var actionResult = await testimonialsController.Put(testimonialsDto, 1);
            var objResult = _context.Testimonials.Count();

            // Assert
            Assert.AreEqual(typeof(NotFoundObjectResult), actionResult.GetType());
            Assert.AreEqual(0, objResult);
        }

        [TestMethod]
        public async Task Delete_Testimonials_That_Should_Exist()
        {

            // Arrange
            var testimonialsTest = new TestimonialsModel()
            {
                Name = "Tests",
                Content = "Testimonial creation test",
                Image = null
            };

            _context.Testimonials.Add(testimonialsTest);
            await _context.SaveChangesAsync();

            // Act
            var testimonials = _context.Testimonials.Single();
            var actionResult = await testimonialsController.Delete(testimonials.Id);

            // Assert
            Assert.AreEqual(typeof(OkResult), actionResult.GetType());

            Assert.AreEqual(true, testimonials.IsDeleted);

        }

        [TestMethod]
        public async Task Delete_Testimonials_Should_Return_404_If_Not_Exist()
        {
            // Act
            var actionResult = await testimonialsController.Delete(1);

            // Assert
            Assert.AreEqual(typeof(NotFoundResult), actionResult.GetType());

        }

        [TestMethod]
        public async Task GetAll_Should_Return_List_Testimonials()
        {
            // Arrange
            for (int i = 0; i < 50; i++)
            {
                _context.Testimonials.Add(new TestimonialsModel() { Name = "Testimonials " + i, Content = "Testimonial creation test" + i, Image = "image" + i + ".jpg" });
            }

            await _context.SaveChangesAsync();

            // Act

            var actionResult = await testimonialsController.GetAll();
            var objResult = _context.Testimonials.Count();

            // Assert
            Assert.AreEqual(typeof(ResponsePagination<GenericPagination<CreateTestimonialsDto>>), actionResult.GetType());
            Assert.AreEqual(50, objResult);
        }
    }

}
