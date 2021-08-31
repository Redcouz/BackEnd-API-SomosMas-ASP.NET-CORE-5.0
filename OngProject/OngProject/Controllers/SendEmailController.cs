using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OngProject.Core.Interfaces.IServices.SendEmail;
using Microsoft.AspNetCore.Authorization;

namespace OngProject.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class SendEmailController : ControllerBase
    {
        private readonly ISendEmailService _sendEmailService;

        public SendEmailController(ISendEmailService sendEmailService)
        {
            _sendEmailService = sendEmailService;
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> sendEmail(string email)
        {
            bool resp = await _sendEmailService.send(email);

           if(resp)
                return Ok();
            else
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }
    }
}
