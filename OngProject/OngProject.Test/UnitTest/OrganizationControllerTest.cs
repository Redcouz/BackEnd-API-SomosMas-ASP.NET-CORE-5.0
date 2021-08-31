using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OngProject.Controllers;
using OngProject.Core.DTOs;
using OngProject.Core.Interfaces.IServices;
using OngProject.Core.Interfaces.IUnitOfWork;
using OngProject.Core.Mapper;
using OngProject.Core.Models;
using OngProject.Core.Services;
using OngProject.Infrastructure;
using OngProject.Infrastructure.Data;
using OngProject.Test.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OngProject.Test.UnitTest
{
    [TestClass]
    public class OrganizationControllerTests : BaseTests
    {
        private readonly ApplicationDbContext _context;
        private readonly OrganizationController organizationController;
        public OrganizationControllerTests()
        {
            _context = MakeContext("TestsDB");
            IUnitOfWork unitofWork = new UnitOfWork(_context);
            IOrganizationService organizationService = new OrganizationService(unitofWork);
            organizationController = new OrganizationController(organizationService);
        }

        [TestMethod]
        public async Task GetById_ShouldOrganizationForId()
        {
            //Arrange
            int id = 1;
            _context.Organizations.Add(new OrganizationModel()
            {
                Name = "Test1",
                Image = null,
                Email = "Test1",
                WelcomeText = "Probando metodo"
            });
            _context.Organizations.Add(new OrganizationModel()
            {
                Name = "Test2",
                Image = null,
                Email = "Test2",
                WelcomeText = "Probando metodo2"
            });

            //Act
            var actual = await organizationController.GetById(id);
            var expected = "Test1";

            //Assert
            Assert.AreEqual(actual.Name, expected);

        }

        [TestMethod]
        public async Task GetById_ShouldOrganizationForId_ReturnNullIfItDoesntExist()
        {
            //Arrange
            int id = 5;
            _context.Organizations.Add(new OrganizationModel()
            {
                Name = "Test1",
                Image = null,
                Email = "Test1",
                WelcomeText = "Probando metodo"
            });
            _context.Organizations.Add(new OrganizationModel()
            {
                Name = "Test2",
                Image = null,
                Email = "Test2",
                WelcomeText = "Probando metodo2"
            });
            
            //Act
            var actual = await organizationController.GetById(id);

            //Assert
            Assert.IsNull(actual);

        }

        [TestMethod]
        public async Task Update_ShouldModifyElement()
        {
            //Arrange
            int id = 1;
            var mapper = new EntityMapper();
            _context.Organizations.Add(new OrganizationModel()
            {
                Id = 1,
                Name = "Test1",
                Image = null,
                Email = "Test1",
                WelcomeText = "Probando metodo"
            });
            _context.Organizations.Add(new OrganizationModel()
            {
                Id = 2,
                Name = "Test2",
                Image = null,
                Email = "Test2",
                WelcomeText = "Probando metodo2"
            });

            //Act
            var organizationBefore = organizationController.GetById(id);
            var organizationModelModified = new OrganizationModel()
            {
                Id = organizationBefore.Id,
                Name = "TestModified",
                WelcomeText = "Modificando Organizacion"
            };
            var organizationModified = mapper.FromOrganizationToOrganizationUpdateDto(organizationModelModified);
            await organizationController.Update(organizationModified);
            var organizationAfter = organizationController.GetById(id);
            var result = organizationAfter.Result;

            //Assert
            Assert.AreEqual(result.Name, organizationModified.Name);
        }

    }
}