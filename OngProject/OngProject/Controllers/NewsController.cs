using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OngProject.Core.Interfaces.IServices;
using OngProject.Core.Interfaces;
using OngProject.Infrastructure.Data;
using OngProject.Core.DTOs;
using Microsoft.AspNetCore.Authorization;
using OngProject.Core.Models;
using OngProject.Core.Helper.Pagination;

namespace OngProject.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("/news")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewsService _inewsService;
        
        public NewsController(INewsService inewsService)

        {
            _inewsService = inewsService;

        }

        // Get /news/id
        /// <summary>
        /// Getting the news by id
        /// </summary>
        /// <returns>return the information of news</returns>
        /// <response code="200">Returns the news information</response>
        /// <response code="401">Unauthorized user</response>
        /// <response code="404">Not Found</response> 
        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (!_inewsService.NewsExists(id))
                return NotFound();

            var response = await _inewsService.GetById(id);
            return Ok(response);
        }


        // Post /news/post
        /// <summary>
        /// Create a news
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /news
        ///     {
        ///        "Name": "TestName",
        ///        "Content": "TestContent"
        ///        "Image": FromFile
        ///        "CategoryId": 1
        ///     }
        /// </remarks>
        /// <response code="200">Create a news</response>
        /// <response code="401">Unauthorized user</response>
        /// <response code="400">Bad Request</response> 
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] NewsDto newsCreateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            try
            {
                var response = await _inewsService.Post(newsCreateDto);

                return CreatedAtAction("POST", response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }


        // Delete /news/10
        /// <summary>
        /// Delete a news from the system
        /// </summary>
        /// <param name="id">News Id</param>
        /// <returns>Message that a news has been successfully deleted</returns>
        /// <response code="200">News deleted successfully</response>
        /// <response code="401">Unauthorized user</response>
        /// <response code="404">Not Found</response>
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (_inewsService.NewsExists(id))
            {
                bool result = await _inewsService.Delete(id);
                if (result)
                    return Ok();
                else
                    return BadRequest(StatusCodes.Status500InternalServerError);
            }
            else
                return NotFound();
        }


        // Get /news
        /// <summary>
        /// Getting all the news for pages
        /// </summary>
        /// <returns>return the information of news</returns>
        /// <response code="200">Returns the news information</response>
        /// <response code="401">Unauthorized user</response>
        /// <response code="404">Not Found</response> 
        [HttpGet]
        public async Task<ResponsePagination<GenericPagination<NewsModel>>> GetAll(int page = 1, int sizeByPage = 10)
        {
             return await _inewsService.GetAll(page, sizeByPage);
        }


        // Put /news/put
        /// <summary>
        /// Update a news for id
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /news/id
        ///     {
        ///        "Name": "TestName",
        ///        "Content": "TestContent"
        ///        "Image": FromFile
        ///        "CategoryId": 1
        ///     }
        /// </remarks>
        /// <param name="id">News Id</param>
        /// <response code="200">Update a news</response>
        /// <response code="401">Unauthorized user</response>
        /// <response code="404">Not Found</response> 
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromForm] NewsUpdateDto newsUpdateDto)
        {
            try
            {
                bool newsExists = _inewsService.NewsExists(id);

                if (!newsExists)
                {
                    return NotFound("News Doesn't Exists");
                }
                else
                {
                    var res = await _inewsService.Put(newsUpdateDto, id);

                    return Ok(res);

                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
