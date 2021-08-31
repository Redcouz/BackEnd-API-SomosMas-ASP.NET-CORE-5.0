using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OngProject.Core.DTOs;
using OngProject.Core.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    [ApiController]
    [Route("/organizations")]
    public class OrganizationController : ControllerBase
    {
        private readonly IOrganizationService _organizationService;

        public OrganizationController(IOrganizationService organizationService)
        {
            _organizationService = organizationService;
        }
        
        [HttpGet("public/{id}")]
        public async Task<OrganizationDto> GetById(int id)
        {
           return await _organizationService.GetOrganizationWithSlides (id);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("public")]
        public async Task<IActionResult> Update([FromForm] OrganizationUpdateDto organizationUpdateDto)
        {
            try
            {
                {
                    var res = await _organizationService.Update(organizationUpdateDto);

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
