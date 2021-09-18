using ERP.Areas.Owners.Data;
using ERP.Areas.Owners.Models;
using ERP.Areas.Owners.Models.Identity;
using ERP.Models;
using ERP.UnitOfWork;
using ERP.Utilities;
using ERP.Utilities.Services;
using ERP.Utilities.Services.EmailService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ERP.Areas.Owners.Controllers
{
    [Area("Owners")]
    [Route("api/[Area]/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public OwnerUserManager OwnerManager { get; set; }
        public OwnerRoleManager RoleManager { get; set; }
        public ITokenService TokenService { get; }
        public IUnitOfWork_Owners OwnersUnitOfWork { get; }
        public DbContextOptions<OwnersDbContext> DbOptions { get; }
        public OwnerSignInManager OwnerSigninManager { get; }
        public IMailService MailService { get; }
        public Constants Constants { get; set; }

        public AccountController(OwnerUserManager ownerManager, ITokenService tokenService, Constants constants,
            IUnitOfWork_Owners ownersUnitOfWork, DbContextOptions<OwnersDbContext> dbOptions,
            OwnerSignInManager ownerSigninManager, IMailService mailService, OwnerRoleManager roleManager)
        {
            OwnerManager = ownerManager;
            TokenService = tokenService;
            Constants = constants;
            OwnersUnitOfWork = ownersUnitOfWork;
            DbOptions = dbOptions;
            OwnerSigninManager = ownerSigninManager;
            MailService = mailService;
            RoleManager = roleManager;
        }

        // GET: api/<AccountController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AccountController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AccountController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] OwnerRegister Register)
        {
            if (ModelState.IsValid)
            {
                var Owner = new Owner() { Email = Register.Email, UserName = Register.UserName };
                var result = await OwnerManager.CreateAsync(Owner, Register.Password);
                if (result.Succeeded)
                {
                    var User = await OwnerManager.FindByEmailAsync(Register.Email);
                    if (!await RoleManager.RoleExistsAsync(Constants.Employee_Role)) 
                        await RoleManager.CreateAsync(new OwnerRole(Constants.Employee_Role));
                    
                    var roleResult = await OwnerManager.AddToRoleAsync(User, Constants.Employee_Role);
                    if (!roleResult.Succeeded) 
                        return BadRequest(new { status= Constants.RolenameAddtion_statuCode, error = Constants.RolenameAddtion_ErrorMessage });
                    var code = await OwnerManager.GenerateEmailConfirmationTokenAsync(User);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var param = new Dictionary<string, string>
                    {
                        {"token", code },
                        {"email", Register.Email }
                    };
                    var callbackUrl = QueryHelpers.AddQueryString(Register.ClientUrl, param);
                    
                    var mailRequest = new MailRequest();
                    mailRequest.ToEmail = Register.Email;
                    mailRequest.Subject = Constants.ConfirmationEmail_Subject;
                    mailRequest.Body = Constants.ConfirmationEmail_Body(HtmlEncoder.Default.Encode(callbackUrl));
                    MailService.SendEmail(mailRequest);

                    
                    return Ok();
                }
                return BadRequest(new { status= Constants.ResultStatus_statuCode, error = result.Errors });
            }
            return BadRequest(new { status = Constants.ModelState_statuCode, error = ModelState });
        }

        // POST api/<AccountController>/OwnerLogin
        [HttpPost(nameof(OwnerLogin))]
        public async Task<ActionResult<OwnerWithToken>> OwnerLogin([FromBody] OwnerLogin ownerLogin)
        {
            if (ModelState.IsValid)
            {
                //Get user From Users table
                var user = OwnerManager.Users.SingleOrDefault(x => x.Email == ownerLogin.Email);
                if (user == null) return Unauthorized(new { status = Constants.NullUser_statuCode, error = Constants.NullUser_ErrorMessage });
                //Sign In User
                var ConfimEmailResult = await OwnerManager.IsEmailConfirmedAsync(user);
                if (!ConfimEmailResult) return Unauthorized(new { status = Constants.EmailConfirmation_StatusCode, error = Constants.Emailconfirmation_ErrorMessage });
                var result = await OwnerSigninManager.CheckPasswordSignInAsync(user, ownerLogin.Password, false);

                if (result.Succeeded) 
                    return new OwnerWithToken { 
                        Username = user.UserName, 
                        Token = TokenService.CreateOwnerToken(user),
                        Roles = (List<string>)await OwnerManager.GetRolesAsync(user)
                    };
                else return Unauthorized(new { status = Constants.WrongPassword_StatusCode, error = Constants.WrongPassword_ErrorMessage });
            }
            return BadRequest(new { status = Constants.ModelState_statuCode, error = ModelState });
        }
        [HttpPost(nameof(EmailConfirmation))]
        public async Task<IActionResult> EmailConfirmation([FromBody] EmailConfirmationModel emailConfirmationModel)
        {
            var user = await OwnerManager.FindByEmailAsync(emailConfirmationModel.email);
            if (user == null)
                return BadRequest(new { status = Constants.NullUser_statuCode, error = Constants.NullUser_ErrorMessage });
            if (await OwnerManager.IsEmailConfirmedAsync(user))
                return BadRequest(new { status = Constants.Email_Is_Confirmed_statuCode, error = Constants.Email_Is_Confirmed_ErrorMessage });
            var token = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(emailConfirmationModel.token));
            var confirmResult = await OwnerManager.ConfirmEmailAsync(user, token);
            if (!confirmResult.Succeeded)
                return BadRequest(new { status = Constants.EmailConfirmResult_statuCode, error = confirmResult.Errors });
            return StatusCode(201);
        }
        // Post api/<AccountController>/SendConfirmationAgain
        [HttpPost(nameof(SendConfirmationAgain))]
        public async Task<IActionResult> SendConfirmationAgain([FromBody] SendEmailConfirmationAgian sendEmailConfirmationAgian)
        { 
            var user = await OwnerManager.FindByEmailAsync(sendEmailConfirmationAgian.Email);
            if (user == null)
                return BadRequest(new { status = Constants.NullUser_statuCode, error = Constants.NullUser_ErrorMessage });
            if (await OwnerManager.IsEmailConfirmedAsync(user))
                return BadRequest(new { status = Constants.Email_Is_Confirmed_statuCode, error = Constants.Email_Is_Confirmed_ErrorMessage });
            var code = await OwnerManager.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            var param = new Dictionary<string, string>
                    {
                        {"token", code },
                        {"email", sendEmailConfirmationAgian.Email }
                    };
            var callbackUrl = QueryHelpers.AddQueryString(sendEmailConfirmationAgian.ClientUrl, param);

            var mailRequest = new MailRequest();
            mailRequest.ToEmail = sendEmailConfirmationAgian.Email;
            mailRequest.Subject = Constants.ConfirmationEmail_Subject;
            mailRequest.Body = Constants.ConfirmationEmail_Body(HtmlEncoder.Default.Encode(callbackUrl));
            MailService.SendEmail(mailRequest);
            return Ok();
        }

        // Post api/<AccountController>/ForgetPassword
        [HttpPost(nameof(ForgetPassword))]
        public async Task<IActionResult> ForgetPassword([FromBody] ForgetPasswordModel ForgetPasswordModel)
        {
            var user = await OwnerManager.FindByEmailAsync(ForgetPasswordModel.Email);
            if (user == null)
                return BadRequest(new { status = Constants.NullUser_statuCode, error = Constants.NullUser_ErrorMessage });
            var code = await OwnerManager.GeneratePasswordResetTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            var param = new Dictionary<string, string>
                    {
                        {"token", code },
                        {"email", ForgetPasswordModel.Email }
                    };
            var callbackUrl = QueryHelpers.AddQueryString(ForgetPasswordModel.ClientUrl, param);

            var mailRequest = new MailRequest();
            mailRequest.ToEmail = ForgetPasswordModel.Email;
            mailRequest.Subject = Constants.ResetPassword_Subject;
            mailRequest.Body = Constants.ResetEmail_Body(HtmlEncoder.Default.Encode(callbackUrl));
            MailService.SendEmail(mailRequest);
            return Ok();
        }

        // Post api/<AccountController>/ResetPassword
        [HttpPost(nameof(ResetPassword))]
        public async Task<IActionResult> ResetPassword([FromBody] OwnerResetPasswordModel OwnerResetPasswordModel)
        {
            var user = await OwnerManager.FindByEmailAsync(OwnerResetPasswordModel.email);
            if (user == null)
                return BadRequest(new { status = Constants.NullUser_statuCode, error = Constants.NullUser_ErrorMessage });
            var token = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(OwnerResetPasswordModel.token));
            var confirmResult = await OwnerManager.ResetPasswordAsync(user, token, OwnerResetPasswordModel.Password);
            if (!confirmResult.Succeeded)
                return BadRequest(new { status = Constants.ResetPassword_statuCode, error = confirmResult.Errors });
            return StatusCode(201);
        }
        // PUT api/<AccountController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AccountController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
