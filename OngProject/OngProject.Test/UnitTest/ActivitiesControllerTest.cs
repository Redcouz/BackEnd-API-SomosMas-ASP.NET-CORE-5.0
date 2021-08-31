using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OngProject.Controllers;
using OngProject.Core.DTOs;
using OngProject.Core.Interfaces.IUnitOfWork;
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
using System.Threading.Tasks;

namespace OngProject.Test.UnitTest
{
    [TestClass]
    public class ActivitiesControllerTests : BaseTests
    {
        private ApplicationDbContext _context;
        private ActivitiesController activitiesController;

        [TestInitialize]
        public void Init()
        {
            _context = MakeContext("TestDB");
            IUnitOfWork unitOfWork = new UnitOfWork(_context);
            ImageService image = new ImageService();
            ActivitiesService service = new ActivitiesService(unitOfWork, image);
            activitiesController = new ActivitiesController(service);
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
        public async Task Post_Should_Create_Activities_Return_Created()
        {

            // Arrange
            var activitiesTest = new ActivitiesCreateDto()
            {
                Name = "Tests",
                Image = CreateImage(),
                Content = "Activities Test"
            };

            // Act
            var actionResult = await activitiesController.Post(activitiesTest);
            var objResult = _context.Activities.Count();

            // Assert
            Assert.AreEqual(typeof(CreatedAtActionResult), actionResult.GetType());
            Assert.AreEqual(1, objResult);
        }

        [TestMethod]
        public async Task Post_Should_NotCreate_Activities_Return_BadRequest()
        {

            // Arrange
            var activitiesTest = new ActivitiesCreateDto()
            {
                Name = "Tests",
                Image = null,
                Content = "Activities Test"
            };

            // Act
            var actionResult = await activitiesController.Post(activitiesTest);
            var objResult = _context.Activities.Count();

            // Assert
            Assert.AreEqual(typeof(BadRequestObjectResult), actionResult.GetType());
            Assert.AreEqual(0, objResult);
        }

        [TestMethod]
        public async Task Put_Should_Modify_Activities()
        {

            // Arrange
            var activitiesTest = new ActivitiesModel()
            {
                Name = "Tests",
                Image = CreateImage().ToString(),
                Content = "Activities Test"
            };

            _context.Activities.Add(activitiesTest);
            await _context.SaveChangesAsync();

            var activitiesDto = new ActivitiesUpdateDto()
            {
                Name = "Tests",
                Image = CreateImage(),
                Content = "Activities Test"
            };

            // Act
            var actionResult = await activitiesController.Update(activitiesDto, activitiesTest.Id);
            var value = actionResult.GetType().GetProperty("Value")?.GetValue(actionResult);
            var activitiesResponse = value as ActivitiesModel;

            // Assert
            Assert.AreEqual(typeof(OkObjectResult), actionResult.GetType());
            Assert.AreEqual(activitiesTest.Name, activitiesResponse.Name);
        }

        [TestMethod]
        public async Task Put_Should_NotModify_NonExistent_Category()
        {

            // Arrange
            var activitiesDto = new ActivitiesUpdateDto()
            {
                Name = "Tests",
                Image = CreateImage(),
                Content = "Activities Test"
            };

            // Act
            var actionResult = await activitiesController.Update(activitiesDto, 1);
            var objResult = _context.Activities.Count();

            // Assert
            Assert.AreEqual(typeof(NotFoundObjectResult), actionResult.GetType());
            Assert.AreEqual(0, objResult);
        }
    }
}
