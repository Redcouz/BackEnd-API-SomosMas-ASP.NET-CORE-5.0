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
    [Route("/members")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMemberService _memberService;

        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }


        // Get /members
        /// <summary>
        /// Getting all Members
        /// </summary>
        /// <returns>return the information of all members</returns>
        /// <response code="200">Returns all members information</response>
        /// <response code="401">Unauthorized user</response>
        /// <response code="404">Not Found</response> 
        [HttpGet]
        public async Task<ResponsePagination<GenericPagination<MemberGetDto>>> GetAll(int page, int sizeByPage)
        {
            return await _memberService.GetAll(page, sizeByPage);
        }


        // Post /members/post
        /// <summary>
        /// Create Member
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///      POST /members
        ///      {
        ///         "Name": "NameExample",
        ///         "FacebookUrl": "FacebookExample",
        ///         "InstagramUrl": "InstragramExample",
        ///         "LinkedinUrl": "LinkedinExample",
        ///         "Image": FromFile,
        ///         "Description": "DescriptionExample"
        ///      }
        /// </remarks>
        /// <response code="200">Create Member</response>
        /// <response code="401">Unauthorized user</response>
        /// <response code="400">Bad Request</response> 
        [Authorize]
        [HttpPost]

        public async Task<IActionResult> Post([FromForm] MemberCreateDto memberCreateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            else
            {
                try
                {
                    var response = await _memberService.Post(memberCreateDto);

                    return CreatedAtAction("POST", response);
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }            

        }


        // Delete /members/10
        /// <summary>
        /// Delete Member
        /// </summary>
        /// <param name="id">Member Id</param>
        /// <returns>Member could been successfully deleted</returns>
        /// <response code="200">Member deleted</response>
        /// <response code="401">Unauthorized user</response>
        /// <response code="404">Not Found</response>
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (_memberService.EntityExists(id))
            {

                bool response = await _memberService.Delete(id);

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
        
        // Put /members/put
        /// <summary>
        /// Update a Member by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///      POST /members
        ///      {
        ///         "Name": "NameExample",
        ///         "FacebookUrl": "FacebookExample",
        ///         "InstagramUrl": "InstragramExample",
        ///         "LinkedinUrl": "LinkedinExample",
        ///         "Image": FromFile,
        ///         "Description": "DescriptionExample"
        ///      }
        /// </remarks>
        /// <param name="id">Member Id</param>
        /// <returns>Member could been successfully updated</returns>
        /// <response code="200">Update Member by Id</response>
        /// <response code="401">Unauthorized user</response>
        /// <response code="404">Not Found</response> 
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromForm] MemberUpdateDto memberUpdateDto)
        { 
            try
            {
                bool memberExists = _memberService.EntityExists(id);

                if (!memberExists)
                {
                    return NotFound("member inexistent");
                }
                else
                {
                    var res = await _memberService.Put(memberUpdateDto, id);

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
