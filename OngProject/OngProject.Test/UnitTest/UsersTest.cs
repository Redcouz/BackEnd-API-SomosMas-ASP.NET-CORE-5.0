using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OngProject.Controllers;
using OngProject.Core.DTOs;
using OngProject.Core.Interfaces.IServices;
using OngProject.Core.Interfaces.IServices.AWS;
using OngProject.Core.Interfaces.IServices.SendEmail;
using OngProject.Core.Interfaces.IUnitOfWork;
using OngProject.Core.Models;
using OngProject.Core.Services;
using OngProject.Core.Services.Auth;
using OngProject.Core.Services.AWS;
using OngProject.Core.Services.SendEmail;
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
    public class UsersTest : BaseTests
    {
        private UserController userController;
        private IConfiguration _config;
        private ApplicationDbContext _context;

        [TestInitialize]
        public void Init()
        {
            _context = MakeContext("TestDb");
            IUnitOfWork unitOfWork = new UnitOfWork(_context);
            IImagenService imagenService = new ImageService();
            IAuthService authService = new AuthService(unitOfWork, _config, imagenService, null);            

            UserService userService = new UserService(unitOfWork, imagenService);
            userController = new UserController(userService, authService);
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
        public async Task GetUser_ShouldGetAllUsers()
        {
            //Arrange

            for (int i = 1; i < 15; i++)
            {
                _context.Users.Add(new UserModel()
                {
                    Id = i,
                    firstName = "FirstName" + i,
                    lastName = "LastName" + i,
                    email = $"mail{i}Alkemy.com",
                    password = "password" + i,
                    photo = "photo" + i,
                    roleId = 1
                });
            }

            await _context.SaveChangesAsync();

            //Act

            var response = await userController.GetUsers();

            //Assert

            Assert.AreEqual(14, _context.Users.Count());

        }
        [TestMethod]
        public async Task GetUser_ShouldReturnNull()
        {
            //Arrange

            //Act

            var response = await userController.GetUsers();

            //Assert

            Assert.AreEqual(0, _context.Users.Count());
        }

        [TestMethod]
        public async Task Patch_ShouldModifyExistingUser()
        {
            //Arrange
            var userTest = new UserModel()
            {
                firstName = "FirstName",
                lastName = "LastName",
                photo = "Photo"
            };

            _context.Users.Add(userTest);
            await _context.SaveChangesAsync();

            var userDto = new UserUpdateDto()
            {
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                Photo = CreateImage()
            };

            //Act
            var actionResult = await userController.Put(userTest.Id, userDto);
            var value = actionResult.GetType().GetProperty("Value")?.GetValue(actionResult);
            var userResponse = value as UserModel;

            //Assert
            Assert.AreEqual(typeof(OkObjectResult), actionResult.GetType());
            Assert.AreEqual(userTest.firstName, userResponse.firstName);
        }

        [TestMethod]
        public async Task Patch_ShouldNotModifyNonExistentUser()
        {

            // Arrange
            var userDto = new UserUpdateDto()
            {
                FirstName = "Test 1",
                LastName = "This is a user update test",
                Photo = CreateImage()
            };

            // Act
            var actionResult = await userController.Put(1, userDto);
            var objResult = _context.Users.Count();

            // Assert
            Assert.AreEqual(typeof(NotFoundObjectResult), actionResult.GetType());
            Assert.AreEqual(0, objResult);
        }

        [TestMethod]
        public async Task DeleteUser_ShouldExistInTheDb()
        {

            // Arrange
            var userTest = new UserModel()
            {
                firstName = "FirstName",
                lastName = "LastName",
                photo = "Photo"
            };

            _context.Users.Add(userTest);
            await _context.SaveChangesAsync();

            // Act
            var user = _context.Users.Single();
            var actionResult = await userController.Delete(user.Id);

            // Assert
            Assert.AreEqual(typeof(OkResult), actionResult.GetType());

            Assert.AreEqual(true, user.IsDeleted);
        }

        [TestMethod]
        public async Task DeleteUser_ShouldReturn404IfNotExistInTheBD()
        {
            // Act

            var actionResult = await userController.Delete(1);

            // Assert
            Assert.AreEqual(typeof(NotFoundResult), actionResult.GetType());

        }
    }
}
