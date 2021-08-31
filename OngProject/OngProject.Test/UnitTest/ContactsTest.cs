using OngProject.Test.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OngProject.Controllers;
using OngProject.Core.DTOs;
using OngProject.Core.Interfaces.IServices;
using OngProject.Core.Interfaces.IServices.SendEmail;
using OngProject.Core.Interfaces.IUnitOfWork;
using OngProject.Core.Models;
using OngProject.Core.Services;
using OngProject.Core.Services.SendEmail;
using OngProject.Infrastructure;
using OngProject.Infrastructure.Data;

namespace OngProject.Test.UnitTest
{
    [TestClass]
    public class ContactsTest : BaseTests
    {
        private ContactsController contactsController;
        private IConfiguration _config;
        private ApplicationDbContext _context;

        [TestInitialize]
        public void Init()
        {
            _context = MakeContext("TestDb");
            IUnitOfWork unitOfWork = new UnitOfWork(_context);


            var builder = new ConfigurationBuilder().AddJsonFile($"appsettings.json", optional: false);
            _config = builder.Build();

            IOrganizationService orgService = new OrganizationService(unitOfWork);
            ISendEmailService sendMailService = new SendEmailService(_config, orgService);


            ContactsService contactService = new ContactsService(unitOfWork, sendMailService);
            contactsController = new ContactsController(contactService);
        }
        [TestCleanup]
        public void Cleanup()
        {
            _context.Database.EnsureDeleted();
        }

        [TestMethod]
        public async Task PostContact_InvalidMail_ShouldReturnError()
        {

            //Arrange

            ContactsCreateDto contact = new ContactsCreateDto()
            {
                Email = "mail1**alkemy.com",
                Message = "Message 1",
                Name = "Name 1",
                Phone = 321654987
            };


            //Act

            var response = await contactsController.Post(contact);
            var result = response as CreatedAtActionResult;

            //Assert

            Assert.AreEqual(typeof(CreatedAtActionResult), result.GetType());
        }

        [TestMethod]
        public async Task GetContanct_ShouldGetAllContacts()
        {
            //Arrange

            Random rPhone = new Random();

            for (int i = 1; i < 20; i++)
            {
                _context.Contacts.Add(new ContactsModel()
                {
                    Id = i,
                    Name = "Name " + i,
                    Phone = rPhone.Next(11111111, 99999999),
                    Email = "mail{0}@Alkemy.com",
                    Message = "Test messaje " + i,
                    CreatedAt = DateTime.Now,
                    IsDeleted = false
                });
            }

            await _context.SaveChangesAsync();

            //Act

            var response = await contactsController.GetContacts();

            //Assert

            Assert.AreEqual(19, _context.Contacts.Count());
        }

        [TestMethod]

        public async Task GetContacts_ShouldReturnNull()
        {
            //Arrange

            //Act

            var response = await contactsController.GetContacts();

            //Assert

            Assert.AreEqual(0, _context.Contacts.Count());
        }




        [TestMethod]
        public async Task Post_ShouldCreateContact()
        {
            //Arrange

            ContactsCreateDto contact = new ContactsCreateDto()
            {
                Email = "Mail1@Alkemy.com",
                Message = "Message 1",
                Name = "Name 1",
                Phone = 321654987
            };

            //Act

            var response = await contactsController.Post(contact);
            var result = response as CreatedAtActionResult;

            //Assert

            Assert.AreEqual(1, _context.Contacts.Count());
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public async Task Post_IvalidContact_ShouldNotCreateContact()
        {
            //Arrange
            ContactsCreateDto contact = new ContactsCreateDto();
            contact = null;
            //Act

            var response = await contactsController.Post(contact);
            var result = response as StatusCodeResult;

            //Assert

            Assert.AreEqual(400, result.StatusCode);
        }
    }
}
