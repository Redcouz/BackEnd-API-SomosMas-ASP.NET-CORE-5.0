using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OngProject.Core.DTOs;
using OngProject.Core.Helper.Pagination;
using OngProject.Core.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("/testimonials")]
    [ApiController]
    public class TestimonialsController : Controller
    {
        private readonly ITestimonialsService _testimonialsService;

        public TestimonialsController(ITestimonialsService testimonialsService)
        {
            _testimonialsService = testimonialsService;
        }

        //Delete testimonials/{id}
        /// <summary>
        /// Soft Delete of a testimonial
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Confirmation that the testimonial has been succesfully deleted</returns>
        /// <response code = "200">Confirmation of the action</response>
        /// <response code = "500">Internar server Error</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (_testimonialsService.EntityExist(id) == true)
            {
                bool response = await _testimonialsService.Delete(id);
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
            {
                return NotFound();
            }
        }

        //Post /testimonials
        /// <summary>
        /// Creates and saves a new testimonial
        /// </summary>
        /// <param name="testimonialsCreateDto"></param>
        /// <returns>Confirmation and model of the created testimonial</returns>
        /// <response code = "201">Returns the model created</response>
        /// <response code = "400">Bad Request</response>
        [Authorize (Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] CreateTestimonialsDto testimonialsCreateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            try
            {
                var response = await _testimonialsService.Post(testimonialsCreateDto);

                return CreatedAtAction("POST", response);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

        }

        //Get /testimonials
        /// <summary>
        /// Returns a paginated list of all active testimonials
        /// </summary>
        /// <param name="page"></param>
        /// <param name="sizeByPage"></param>
        /// <returns>All testimonials</returns> 
        [HttpPut("{id}")]

        public async Task<IActionResult> Put([FromForm] CreateTestimonialsDto updateTestimonialsDto, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                var testimonialsExists = await _testimonialsService.GetById(id);

                if (testimonialsExists == null)
                {
                    return NotFound("testimonial inexistent");
                }
                else
                {
                    var res = await _testimonialsService.Put(updateTestimonialsDto, id);

                    return Ok(res);

                }
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet]
        public async Task<ResponsePagination<GenericPagination<CreateTestimonialsDto>>> GetAll(int page = 1, int sizeByPage = 10)
        {
            return await _testimonialsService.GetAll(page, sizeByPage);
        }

    }
}
