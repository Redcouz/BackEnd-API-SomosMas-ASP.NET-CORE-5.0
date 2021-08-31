using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OngProject.Core.DTOs;
using OngProject.Core.Interfaces.IServices;
using OngProject.Core.Models;

namespace OngProject.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactsService _contactsService;

        public ContactsController(IContactsService contactsService)
        {
            _contactsService = contactsService;
        }

        [HttpGet]
        public async Task<IEnumerable<ContactsModel>> GetContacts()
        {
            return await _contactsService.GetContacts();

        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] ContactsCreateDto contactsCreateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            try
            {
                var response = await _contactsService.Post(contactsCreateDto);
                return CreatedAtAction("POST", response);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

        }
    }
}
