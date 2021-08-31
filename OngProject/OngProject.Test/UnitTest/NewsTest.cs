using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OngProject.Controllers;
using OngProject.Core.DTOs;
using OngProject.Core.Interfaces.IServices;
using OngProject.Core.Interfaces.IServices.AWS;
using OngProject.Core.Interfaces.IServices.IUriPaginationService;
using OngProject.Core.Interfaces.IUnitOfWork;
using OngProject.Core.Models;
using OngProject.Core.Services;
using OngProject.Core.Services.AWS;
using OngProject.Core.Services.UriPagination;
using OngProject.Infrastructure;
using OngProject.Infrastructure.Data;
using OngProject.Test.Helper;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace OngProject.Test.UnitTest
{
    [TestClass]
    public class NewsControllerTest : BaseTests
    {
        private ApplicationDbContext _context;
        private NewsController newsController;

        [TestInitialize]
        public void MakeArrange()
        {
            _context = MakeContext("TestsDB");
            IUnitOfWork unitofWork = new UnitOfWork(_context);
            IUriPaginationService uriPaginationService = new UriPaginationService("https://test/");
            IImagenService imagenService = new ImageService();

            INewsService newsService = new NewsService(unitofWork, imagenService, uriPaginationService);
            newsController = new NewsController(newsService);

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

        public NewsModel InsertModelInContext()
        {
            NewsModel newsModel = new NewsModel();
            newsModel.Name = "informe 23/8";
            newsModel.Content = "contenido de la novedad";
            newsModel.Image = "imagen_news";  // model invalid
            newsModel.CategoryId = 1;
            newsModel.CreatedAt = DateTime.Today;
            _context.News.Add(newsModel);
            _context.SaveChanges();

            return newsModel;
        }


        [TestMethod]
        public async Task Post_ShouldCreateNews_ReturnOkResult()
        {
            //ARRANGER         
            NewsDto newsDto = new NewsDto();
            newsDto.Name = "informe 23/8";
            newsDto.Content = "contenido de la novedad";
            newsDto.Image = CreateImage();
            newsDto.CategoryId = 1;

            //ACT
            var result = await newsController.Post(newsDto);
            var objResult = _context.News.Count();

            //ASSERT 
            Assert.AreEqual(typeof(CreatedAtActionResult), result.GetType());
            Assert.AreEqual(1, objResult);
        }

        [TestMethod]
        public async Task Post_ShouldNotCreateNews_ReturnBadRequest_image_invalid()
        {
            //ARRANGER         
            var stream = File.OpenRead(@"..\..\..\UnitTest\Image\TextFile1.txt");
            var file = new FormFile(stream, 0, stream.Length, null, Path.GetFileName(stream.Name))
            {
                Headers = new HeaderDictionary(),
                ContentType = "application/text"
            };

            NewsDto newsDto = new NewsDto();
            newsDto.Name = "informe 23/8";
            newsDto.Content = "contenido de la novedad";
            newsDto.Image = file;
            newsDto.CategoryId = 1;

            //ACT
            var result = await newsController.Post(newsDto);
            var objResult = _context.News.Count();

            //ASSERT 
            Assert.AreEqual(typeof(BadRequestObjectResult), result.GetType());
            Assert.AreEqual(0, objResult);
        }


        [TestMethod]
        public async Task Post_ShouldNotCreateNews_ReturnBadRequest_image_null()
        {
            //ARRANGER
            NewsDto newsDto = new NewsDto();
            newsDto.Name = "informe 23/8";
            newsDto.Content = "contenido de la novedad";
            newsDto.Image = null;  // model invalid
            newsDto.CategoryId = 1;

            //ACT
            var result = await newsController.Post(newsDto);
            var objResult = _context.News.Count();

            //ASSERT 
            Assert.AreEqual(typeof(BadRequestObjectResult), result.GetType());
            Assert.AreEqual(0, objResult);
        }


        [TestMethod]
        public async Task GetById_ShouldGetAndOk()
        {
            //ARRANGE
            InsertModelInContext();
            int id = 1;
            var expected = typeof(OkObjectResult);

            //ACT
            var result = newsController.GetById(id);

            //ASSERT
            Assert.AreEqual(expected, result.Result.GetType());
        }

        [TestMethod]
        public async Task GetById_ShouldGetNoFound_Id_Inexistente()
        {
            //ARRANGE
            int id = 2000;
            var expected = typeof(NotFoundResult);
            //ACT
            var result = newsController.GetById(id);

            //ASSERT
            Assert.AreEqual(expected, result.Result.GetType());
        }

        [TestMethod]
        public async Task Delete_shouldGetOk()
        {
            //ARRANGE
            int id = 1;
            InsertModelInContext();
            var expected = typeof(OkResult);
            //act
            var result = newsController.Delete(id);

            //assert
            Assert.AreEqual(expected, result.Result.GetType());
        }


        [TestMethod]
        public async Task Delete_shouldReturnNotFound()
        {
            //ARRANGE
            int id = 100;
            InsertModelInContext();
            var expected = typeof(NotFoundResult);
            //act
            var result = newsController.Delete(id);

            //assert
            Assert.AreEqual(expected, result.Result.GetType());
        }

        [TestMethod]
        public async Task GetAll_shouldReturnCountList()
        {
            //asert
            var resultExpected = typeof(OkResult);
            NewsModel[] data = new NewsModel[13];
            for (int i = 0; i < data.Count(); i++)
            {
                data[i] = InsertModelInContext();
            }

            //act
            var cantResult = newsController.GetAll().Result.TotalRecords;

            //assert
            Assert.AreEqual(data.Count(),cantResult);   
        }

        [TestMethod]
        public async Task Put_shouldReturnOk()
        {
            //ARRANGE
            NewsModel newsModel = InsertModelInContext();
            NewsUpdateDto newsUpdateDto = new NewsUpdateDto();
            newsUpdateDto.Name = "informe modificado 23/8";
            var resultExpected = typeof(OkObjectResult);

            //ACT
            IActionResult result = newsController.Put(1, newsUpdateDto).Result;
            OkObjectResult okResult = result as OkObjectResult;
            NewsModel newsModelResult = (NewsModel)okResult.Value;

            //ASSERT
            Assert.AreEqual(resultExpected, result.GetType()); //return ok
            Assert.AreEqual("informe modificado 23/8", newsModelResult.Name); //return name modified
        }

        [TestMethod]
        public async Task Put_shouldReturnNotFound()
        {
            //ARRANGE
            NewsModel newsModel = InsertModelInContext();
            NewsUpdateDto newsUpdateDto = new NewsUpdateDto();
            newsUpdateDto.Name = "informe modificado 23/8";
            var resultExpected = typeof(NotFoundObjectResult);
            int id = 2000; //no existe ese id
            //ACT
            IActionResult result = newsController.Put(id, newsUpdateDto).Result;

            //ASSERT
            Assert.AreEqual(resultExpected, result.GetType()); 
        }

        [TestCleanup]
        public void Cleanup()
        {
            _context.Database.EnsureDeleted();
        }


    }
}
