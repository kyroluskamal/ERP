using ERP.Utilities.Services.EmailService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Controllers
{
    public class EmailSenderController : ControllerBase
    {

        public IMailService _mailService;
        public EmailSenderController(IMailService mailService)
        {
            _mailService = mailService;
        }

        [HttpPost("Send")]
        public IActionResult Send([FromForm] MailRequest request)
        {
            try
            {
                _mailService.SendEmail(request);
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
