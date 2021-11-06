using ERP.Utilities.Services.EmailService;
using Microsoft.AspNetCore.Mvc;
using System;

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
