using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OngProject.Core.DTOs;
using OngProject.Core.Helper.Pagination;
using OngProject.Core.Interfaces;
using OngProject.Core.Mapper;
using OngProject.Core.Models;

namespace OngProject.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _iCategoryService;

        public CategoryController(ICategoryService iCategoryService)
        { 
            _iCategoryService = iCategoryService;
        }

        /// <summary>
        /// Delete a Category from system 
        /// </summary>
        /// <param name="id">Category Id</param>
        /// <returns>Returns a message that a category was removed</returns>
        /// <response code="200">Category deleted successfully</response>
        /// <response code="401">Unauthorized user</response>
        /// <response code="404">Not Found</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(int id)
        {
            if (_iCategoryService.EntityExists(id))
            {

                bool response = await _iCategoryService.Delete(id);

                if (response == true)
                {
                    return Ok();
                }
                else
                {
                    return new StatusCodeResult(StatusCodes.Status500InternalServerError);
                }

            }
            else
                return NotFound();
        }

        /// <summary>
        /// Get a category by id
        /// </summary>
        /// <returns>return a category by id</returns>
        /// <response code="200">Returns the category information</response>
        /// <response code="401">Unauthorized user</response>
        /// <response code="404">Not Found</response> 
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetById(int id)
        {
            if (!_iCategoryService.EntityExists(id))
                return NotFound();

            var category = await _iCategoryService.GetById(id);
            return Ok(category);
        }

        /// <summary>
        /// Getting all categories paginated
        /// </summary>
        /// <returns>return the information of all categories</returns>
        /// <response code="200">Returns the categories information</response>
        /// <response code="401">Unauthorized user</response>
        /// <response code="404">Not Found</response> 
        [HttpGet]
        [ProducesResponseType(typeof(CategoryDto), 200)]
        [ProducesResponseType(404)]
        public async Task<ResponsePagination<GenericPagination<CategoryDto>>> GetAll(int page = 1, int sizeByPage = 10)
        {
            return await _iCategoryService.GetAll(page, sizeByPage);
        }

        /// <summary>
        /// Create a category
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /category
        ///     {
        ///        "Name": "TestName",
        ///        "Description": "TestDescription"
        ///        "Image": FromFile
        ///     }
        /// </remarks>
        /// <response code="200">Create a category</response>
        /// <response code="401">Unauthorized user</response>
        /// <response code="400">Bad Request</response>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Post([FromForm] CategoryCreateDto categoryCreateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            try
            {
                var response = await _iCategoryService.Post(categoryCreateDto);

                return CreatedAtAction("POST", response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        /// <summary>
        /// Update a category for id
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /category/id
        ///     {
        ///        "Name": "TestName",
        ///        "Description": "TestDescription"
        ///        "Image": FromFile
        ///     }
        /// </remarks>
        /// <param name="id">Category Id</param>
        /// <response code="200">Update a category</response>
        /// <response code="401">Unauthorized user</response>
        /// <response code="404">Not Found</response>
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Put([FromForm] CategoryCreateDto updateCategoryDto, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }                
            try
            {
                var categoryExists = await _iCategoryService.GetById(id);

                if(categoryExists == null) 
                {
                    return NotFound("category inexistent");
                }
                else
                {
                    var res = await _iCategoryService.Put(updateCategoryDto, id);
                    
                    return Ok(res);

                }                
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

    }
}
