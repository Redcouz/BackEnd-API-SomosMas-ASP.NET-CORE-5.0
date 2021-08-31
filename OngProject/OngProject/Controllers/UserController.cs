using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OngProject.Core.DTOs;
using OngProject.Core.DTOs.Auth;
using OngProject.Core.Interfaces.IServices;
using OngProject.Core.Interfaces.IUnitOfWork;
using OngProject.Core.Models;
using OngProject.Core.Services;
using OngProject.Core.Services.Auth;
using OngProject.Infrastructure.Data;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    
    [Produces("application/json")]
    [Authorize]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAuthService _auth;
        public UserController(IUserService userService, IAuthService auth)
        {
            this._userService = userService;
            this._auth = auth;
        }

        // Get /auth/me
        /// <summary>
        /// Obtaining my information with my access token
        /// </summary>
        /// <returns>return the information of the authenticated user</returns>
        /// <response code="200">Returns the user information</response>
        /// <response code="401">Unauthorized user</response>
        /// <response code="404">Not Found</response> 
        [HttpGet("/auth/me")]
        [ProducesResponseType(typeof(UserInfoDto), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<UserInfoDto>> GetUserData()
        {
            try
            {
                string authToken = Request.Headers["Authorization"];
                int userId = _auth.GetUserId(authToken);
                UserInfoDto userModeldto = await _userService.GetUserById(userId);

                return Ok(userModeldto);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // Post /auth/register
        /// <summary>
        /// Registration of new users to the system
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /auth/register
        ///     {
        ///        "firstName": "Administrador",
        ///        "lastName": "Sistema",
        ///        "email": "mailAdmin@gmail.com",
        ///        "password": "123456"
        ///     }
        /// </remarks>
        /// <returns>A new user created with their access token</returns>
        /// <response code="200">Returns the newly created user</response>
        /// <response code="400">Bad Request</response> 
        [AllowAnonymous]
        [HttpPost("/auth/register")]
        [ProducesResponseType(typeof(UserDto), 200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<UserDto>> Register([FromForm] RegisterDTO request)
        {
            try
            {
                var user = await this._auth.register(request);

                if (user != null)
                {
                    return Ok(user);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }


            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }


        // Post /auth/login
        /// <summary>
        /// Login and return access token
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /auth/login
        ///     {
        ///        "email": "mail1@Mail.com",
        ///        "password": "Admin123"
        ///     }
        /// </remarks>
        /// <returns>A user with their access token</returns>
        /// <response code="200">returns a user with his access token</response>
        /// <response code="404">Not found user</response> 
        [AllowAnonymous]
        [HttpPost("/auth/login")]
        [ProducesResponseType(typeof(UserDto), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<UserDto>> Login([FromBody] LoginDTO request)
        {
            var user = await this._auth.login(request);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);

        }

        // Delete /users/10
        /// <summary>
        /// Delete a user from the system
        /// </summary>
        /// <param name="id">User Id</param>
        /// <returns>Message that a user has been successfully deleted</returns>
        /// <response code="200">User deleted successfully</response>
        /// <response code="401">Unauthorized user</response>
        /// <response code="404">Not Found</response> 
        [Authorize]
        [HttpDelete("/users/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(int id)
        {
            if (!_userService.UserExists(id))
                return NotFound();

            bool response = await _userService.DeleteUser(id);

            if (response == true)
            {
                return Ok();
            }
            else
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        // Get /users
        /// <summary>
        /// Get the data of all registered users
        /// </summary>
        /// <returns>returns the information of authenticated users</returns>
        /// <response code="200">Returns the users information</response>
        /// <response code="401">Unauthorized user</response>
        [Authorize(Roles ="Admin")]
        [HttpGet("/users")]
        [ProducesResponseType(typeof(UserModel),200)]
        [ProducesResponseType(401)]
        public async Task<IEnumerable<UserModel>> GetUsers()
        {
            return await _userService.GetUsers();
        }


        // Patch /users/2
        /// <summary>
        /// Update a user's information
        /// </summary>
        /// <param name="id">User Id</param>
        /// <param name="userUpdateDto">DTO updated user information</param>
        /// <returns>returns the updated information of a user</returns>
        /// <response code="200">Return the user information updated</response>
        /// <response code="401">Unauthorized user</response>
        /// <response code="404">User inexistent</response>
        [Authorize]
        [HttpPatch("users/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Put(int id, [FromForm] UserUpdateDto userUpdateDto)
        {
            try
            {
                bool UserExists = _userService.UserExists(id);

                if (!UserExists)
                {
                    return NotFound("User inexistent");
                }
                else
                {
                    var res = await _userService.Put(userUpdateDto, id);

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
