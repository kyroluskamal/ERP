using ERP.Data;
using ERP.Models;
using ERP.Utilities.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Data.Identity;
using ERP.Areas.Tenants.Models;
using ERP.Areas.Tenants.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Infrastructure;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Data.Entity;
using System.Diagnostics;
using ERP.UnitOfWork;
using ERP.Utilities.Services.EmailService;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using System.Text.Encodings.Web;
using ERP.Utilities;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        public ApplicationUserManager UserManager { get; set; }
        public ITokenService TokenService { get; set; }
        public IUnitOfWork_Tenants TenantsUnitOfWork { get; set; }
        public ApplicationUserSignIngManager ApplicationUserSignIngManager { get; }
        public IMailService MailService { get; }
        public IUnitOfWork_ApplicationUser ClientUnitOfWork { get; set; }
        public DbContextOptions<ApplicationDbContext> DbOptions;
        public Constants Constants { get; set; }
        public ApplicationUserRoleManager RoleManager { get; set; }
        //...........................Constructor........................
        public IdentityController(
            ApplicationUserManager userManager, ITokenService tokenService, Constants constants,
            IUnitOfWork_Tenants tenantsUnitOfWork, IUnitOfWork_ApplicationUser clientUnitOfWork,
            DbContextOptions<ApplicationDbContext> dbOptions, ApplicationUserRoleManager roleManager,
            ApplicationUserSignIngManager applicationUserSignIngManager, IMailService mailService)
        {
            UserManager = userManager;
            TokenService = tokenService;
            Constants = constants;
            TenantsUnitOfWork = tenantsUnitOfWork;
            ClientUnitOfWork = clientUnitOfWork;
            DbOptions = dbOptions;
            RoleManager = roleManager;
            ApplicationUserSignIngManager = applicationUserSignIngManager;
            MailService = mailService;
        }

        // GET: api/<IdentityController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<IdentityController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<IdentityController>/
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ClientRegister clientRegister)
        {
            if (ModelState.IsValid)
            {
                var tenantbyEmail = TenantsUnitOfWork.Tenants.TenantByEmail(clientRegister.Email);
                var tenantbyUsername = TenantsUnitOfWork.Tenants.TenantByUsername(clientRegister.UserName);
                var tenantbySubdomain = TenantsUnitOfWork.Tenants.TenantBySubdomain(clientRegister.Subdomain.ToLower());
                if (tenantbyEmail != null && tenantbySubdomain != null && tenantbyUsername != null)
                    return BadRequest(new
                    {
                        status = "Exsiting_Subdomain_Mail_UserName", 
                        error= "Do you try to create an account with the same Email, Username and Subdomain?. " +
                        "you can login or reset your password if you have forgetton it"
                    });
                else if(tenantbyEmail != null && tenantbySubdomain != null && tenantbyUsername == null)
                    return BadRequest(new
                    {
                        status = "Exsiting_Subdomain_Mail",
                        error = "Email and Subdomain both are already exists"
                    });
                else if(tenantbyEmail != null && tenantbySubdomain == null && tenantbyUsername != null)
                    return BadRequest(new
                    {
                        status = "Exsiting_Mail_Username",
                        error = "Email and Username both are already exists"
                    });
                else if(tenantbyEmail == null && tenantbySubdomain != null && tenantbyUsername != null)
                    return BadRequest(new
                    {
                        status = "Exsiting_Subdomain_Username",
                        error = "subdomain and Username both are already exists"
                    });
                else if (tenantbyEmail != null && tenantbySubdomain == null && tenantbyUsername == null)
                    return BadRequest(new {
                        status = "Exsiting_Mail", 
                        error = "This Email is already taken"
                    });
                else if (tenantbyEmail == null && tenantbySubdomain == null && tenantbyUsername != null)
                    return BadRequest(new {
                        status = "Exsiting_Username",
                        error = "This Username Is already taken"
                    });
                else if (tenantbyEmail == null && tenantbySubdomain != null && tenantbyUsername == null)
                    return BadRequest(new
                    {
                        status = "Exsiting_Subdomain",
                        error = "Subdomain name is already taken.Please,Choose another one"
                    });
                var Tenant = new TenantsInfo() {
                    CompanyName = clientRegister.CompanyName,
                    Subdomain = clientRegister.Subdomain.ToLower(),
                    Username = clientRegister.UserName,
                    Email = clientRegister.Email,
                    ConnectionString = $"Server=(localdb)\\mssqllocaldb;Database={clientRegister.Subdomain};Trusted_Connection=True;MultipleActiveResultSets=true"
                };      
                 TenantsUnitOfWork.Tenants.Add(Tenant);
                 
                 ClientUnitOfWork.SetConnectionString(Tenant.ConnectionString);

                var User = new ApplicationUser() { 
                    Email = clientRegister.Email, UserName = clientRegister.UserName,
                    FirstName = clientRegister.FirstName, LastName=clientRegister.LastName
                };
                var result = await UserManager.CreateAsync(User, clientRegister.Password);
                if (result.Succeeded)
                {
                    TenantsUnitOfWork.Save();
                    var user = await UserManager.FindByEmailAsync(clientRegister.Email);
                    if (!await RoleManager.RoleExistsAsync(Constants.Employee_Role)) 
                        await RoleManager.CreateAsync(new ApplicationUserRole(Constants.Admin_Role));
                    
                    var roleResult = await UserManager.AddToRoleAsync(user, Constants.Admin_Role);
                    if (!roleResult.Succeeded) 
                        return BadRequest(new { status= Constants.RolenameAddtion_statuCode, error = Constants.RolenameAddtion_ErrorMessage });
                    var code = await UserManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var param = new Dictionary<string, string>
                    {
                        {"token", code },
                        {"email", clientRegister.Email }
                    };
                    var callbackUrl = QueryHelpers.AddQueryString(clientRegister.ClientUrl, param);
                    var mailRequest = new MailRequest();
                    mailRequest.ToEmail = clientRegister.Email;
                    mailRequest.Subject = Constants.ConfirmationEmail_Subject;
                    mailRequest.Body = Constants.ConfirmationEmail_Body(HtmlEncoder.Default.Encode(callbackUrl));
                    MailService.SendEmail(mailRequest);
                    
                    return Ok();
                }
                return BadRequest(new { status = Constants.ResultStatus_statuCode, error = result.Errors });
            }
            return BadRequest(new { status = Constants.ModelState_statuCode, error = ModelState });
        }
        // POST api/<IdentityController>/LoginMainDomain
        [HttpPost(nameof(LoginMainDomain))]
        public async Task<ActionResult<UserWithToken>> LoginMainDomain([FromBody] ClientLogin clientLogin)
        {
            if (ModelState.IsValid) { 
                //Get ConnectionString From Tenant Db
                var tenant = TenantsUnitOfWork.Tenants.TenantByEmail(clientLogin.Email);

                if (tenant == null) return BadRequest(new { status = Constants.NullTenant_ErrorMessage, error = Constants.NullTenant_ErrorMessage});
                //Connect to the correct Db based on the Connectionstring
                ClientUnitOfWork.SetConnectionString(tenant.ConnectionString);
                //Get user From Users table
                var user = UserManager.Users.SingleOrDefault(x => x.Email == clientLogin.Email);
                if (user == null) return Unauthorized(new { status = Constants.NullUser_statuCode, error = Constants.NullUser_ErrorMessage });
                //Sign In User
                if (!await UserManager.IsEmailConfirmedAsync(user)) return Unauthorized(new { status = Constants.EmailConfirmation_StatusCode, error = Constants.Emailconfirmation_ErrorMessage });
                var result = await ApplicationUserSignIngManager.CheckPasswordSignInAsync(user, clientLogin.Password, false);
                if (result.Succeeded)
                {
                    return new UserWithToken { 
                        Username = user.UserName, 
                        Token = TokenService.CreateClientToken(user),
                        Roles = (List<string>)await UserManager.GetRolesAsync(user)

                    };
                }
                else return Unauthorized(new { status = Constants.WrongPassword_StatusCode, error = Constants.WrongPassword_ErrorMessage});
            }
            return BadRequest(new { status = Constants.ModelState_statuCode, error = ModelState });
        }
        // POST api/<IdentityController>/EmailConfirmation
        [HttpPost(nameof(EmailConfirmation))]
        public async Task<IActionResult> EmailConfirmation([FromBody] EmailConfirmationModel emailConfirmationModel)
        {
            var tenantbyEmail = TenantsUnitOfWork.Tenants.TenantByEmail(emailConfirmationModel.email);
            if (tenantbyEmail == null) return BadRequest(new { status = Constants.NullTenant_ErrorMessage, error = Constants.NullTenant_ErrorMessage });
            ClientUnitOfWork .SetConnectionString(tenantbyEmail.ConnectionString);
            var user = await UserManager.FindByEmailAsync(emailConfirmationModel.email);
            if (user == null)
                return BadRequest(new { status = Constants.NullUser_statuCode, error = Constants.NullUser_ErrorMessage });
            if (await UserManager.IsEmailConfirmedAsync(user))
                return BadRequest(new { status = Constants.Email_Is_Confirmed_statuCode, error = Constants.Email_Is_Confirmed_ErrorMessage });
            var token = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(emailConfirmationModel.token));
            var confirmResult = await UserManager.ConfirmEmailAsync(user, token);
            if (!confirmResult.Succeeded)
                return BadRequest(new { status = Constants.EmailConfirmResult_statuCode, error = confirmResult.Errors });
            return StatusCode(201);
        }
        // POST api/<IdentityController>/SendConfirmationAgain
        [HttpPost(nameof(SendConfirmationAgain))]
        public async Task<IActionResult> SendConfirmationAgain([FromBody] SendEmailConfirmationAgian sendEmailConfirmationAgian)
        {
            var tenantbyEmail = TenantsUnitOfWork.Tenants.TenantByEmail(sendEmailConfirmationAgian.Email);
            if (tenantbyEmail == null) return BadRequest(new { status = Constants.NullTenant_ErrorMessage, error = Constants.NullTenant_ErrorMessage });
            ClientUnitOfWork.SetConnectionString(tenantbyEmail.ConnectionString);
            var user = await UserManager.FindByEmailAsync(sendEmailConfirmationAgian.Email);
            if (user == null)
                return BadRequest(new { status= Constants.NullUser_statuCode, error=Constants.NullUser_ErrorMessage});
            if (await UserManager.IsEmailConfirmedAsync(user))
                return BadRequest(new { status = Constants.Email_Is_Confirmed_statuCode, error = Constants.Email_Is_Confirmed_ErrorMessage });
            var code = await UserManager.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            var param = new Dictionary<string, string>
                    {
                        {"token", code },
                        {"email", sendEmailConfirmationAgian.Email }
                    };
            var callbackUrl = QueryHelpers.AddQueryString(sendEmailConfirmationAgian.ClientUrl, param);
            //var callbackUrl = Url.RouteUrl(.Page(
            //    "/emailconfirmation",
            //    pageHandler: null,
            //    values: new { userId = User.Id, code = code },
            //    protocol: Request.Scheme);
            var mailRequest = new MailRequest();
            mailRequest.ToEmail = sendEmailConfirmationAgian.Email;
            mailRequest.Subject = Constants.ConfirmationEmail_Subject;
            mailRequest.Body = Constants.ConfirmationEmail_Body(HtmlEncoder.Default.Encode(callbackUrl));
            MailService.SendEmail(mailRequest);
            return Ok();
        }
        // POST api/<IdentityController>/ForgetPassword
        [HttpPost(nameof(ForgetPassword))]
        public async Task<IActionResult> ForgetPassword([FromBody] ClientForgetPasswordModel ForgetPasswordModel)
        {
            var tenantbyEmail = TenantsUnitOfWork.Tenants.TenantByEmail(ForgetPasswordModel.Email);
            if (tenantbyEmail == null) return BadRequest(new { status = Constants.NullTenant_ErrorMessage, error = Constants.NullTenant_ErrorMessage });
            ClientUnitOfWork.SetConnectionString(tenantbyEmail.ConnectionString);
            var user = await UserManager.FindByEmailAsync(ForgetPasswordModel.Email);
            if (user == null)
                return BadRequest(new { status = Constants.NullUser_statuCode, error = Constants.NullUser_ErrorMessage });
            var code = await UserManager.GeneratePasswordResetTokenAsync(user);
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
        // Post api/<IdentityController>/ResetPassword
        [HttpPost(nameof(ResetPassword))]
        public async Task<IActionResult> ResetPassword([FromBody] ClientResetPasswordModel ResetPasswordModel)
        {
            if (ModelState.IsValid)
            {
                var tenantbyEmail = TenantsUnitOfWork.Tenants.TenantByEmail(ResetPasswordModel.email);
                if (tenantbyEmail == null) return BadRequest(new { status = Constants.NullTenant_ErrorMessage, error = Constants.NullTenant_ErrorMessage });
                ClientUnitOfWork.SetConnectionString(tenantbyEmail.ConnectionString);
                var user = await UserManager.FindByEmailAsync(ResetPasswordModel.email);
                if (user == null)
                    return BadRequest(new { status = Constants.NullUser_statuCode, error = Constants.NullUser_ErrorMessage });
                var token = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(ResetPasswordModel.token));
                var confirmResult = await UserManager.ResetPasswordAsync(user, token, ResetPasswordModel.Password);
                if (!confirmResult.Succeeded)
                    return BadRequest(new { status = Constants.ResetPassword_statuCode, error = confirmResult.Errors });
                return StatusCode(201);
            }
            return BadRequest(new { status = Constants.ModelState_statuCode, error = ModelState });
        }

        
    // PUT api/<IdentityController>/5
    [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<IdentityController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
