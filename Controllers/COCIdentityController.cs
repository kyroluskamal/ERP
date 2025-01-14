﻿using ERP.Areas.Tenants.Models;
using ERP.Data;
using ERP.Data.Identity;
using ERP.Models;
using ERP.UnitOfWork;
using ERP.Utilities;
using ERP.Utilities.Services;
using ERP.Utilities.Services.EmailService;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class COCIdentityController : ControllerBase
    {
        public ApplicationUserManager UserManager { get; set; }
        public ITokenService TokenService { get; set; }
        public IUnitOfWork_Tenants TenantsUnitOfWork { get; set; }
        public ApplicationUserSignIngManager ApplicationUserSignIngManager { get; }
        public Utilities.Services.AuthenticationService Authentication { get; }
        public IMailService MailService { get; }
        public IAntiforgery Antiforgery { get; }
        public IUnitOfWork_ApplicationUser ClientUnitOfWork { get; set; }
        public DbContextOptions<ApplicationDbContext> DbOptions;
        public Constants Constants { get; set; }
        public ApplicationUserRoleManager RoleManager { get; set; }
        //...........................Constructor........................
        public COCIdentityController(
            ApplicationUserManager userManager, ITokenService tokenService, Constants constants,
            IUnitOfWork_Tenants tenantsUnitOfWork, IUnitOfWork_ApplicationUser clientUnitOfWork,
            DbContextOptions<ApplicationDbContext> dbOptions, ApplicationUserRoleManager roleManager,
            ApplicationUserSignIngManager applicationUserSignIngManager, Utilities.Services.AuthenticationService authentication,
            IMailService mailService, IAntiforgery antiforgery)
        {
            UserManager = userManager;
            TokenService = tokenService;
            Constants = constants;
            TenantsUnitOfWork = tenantsUnitOfWork;
            ClientUnitOfWork = clientUnitOfWork;
            DbOptions = dbOptions;
            RoleManager = roleManager;
            ApplicationUserSignIngManager = applicationUserSignIngManager;
            Authentication = authentication;
            MailService = mailService;
            Antiforgery = antiforgery;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ClientRegister clientRegister)
        {
            if (ModelState.IsValid)
            {
                var tenantbyEmail = await TenantsUnitOfWork.Tenants.TenantByEmailAsync(clientRegister.Email);
                var tenantbyUsername = await TenantsUnitOfWork.Tenants.TenantByUsernameAsync(clientRegister.UserName);
                var tenantbySubdomain = await TenantsUnitOfWork.Tenants.TenantBySubdomainAsync(clientRegister.Subdomain.ToLower());
                if (tenantbyEmail != null && tenantbySubdomain != null && tenantbyUsername != null)
                    return BadRequest(new
                    {
                        status = "Exsiting_Subdomain_Mail_UserName",
                        error = "Do you try to create an account with the same Email, Username and Subdomain?. " +
                        "you can login or reset your password if you have forgetton it"
                    });
                else if (tenantbyEmail != null && tenantbySubdomain != null && tenantbyUsername == null)
                    return BadRequest(new
                    {
                        status = "Exsiting_Subdomain_Mail",
                        error = "Email and Subdomain both are already exists"
                    });
                else if (tenantbyEmail != null && tenantbySubdomain == null && tenantbyUsername != null)
                    return BadRequest(new
                    {
                        status = "Exsiting_Mail_Username",
                        error = "Email and Username both are already exists"
                    });
                else if (tenantbyEmail == null && tenantbySubdomain != null && tenantbyUsername != null)
                    return BadRequest(new
                    {
                        status = "Exsiting_Subdomain_Username",
                        error = "subdomain and Username both are already exists"
                    });
                else if (tenantbyEmail != null && tenantbySubdomain == null && tenantbyUsername == null)
                    return BadRequest(new
                    {
                        status = "Exsiting_Mail",
                        error = "This Email is already taken"
                    });
                else if (tenantbyEmail == null && tenantbySubdomain == null && tenantbyUsername != null)
                    return BadRequest(new
                    {
                        status = "Exsiting_Username",
                        error = "This Username Is already taken"
                    });
                else if (tenantbyEmail == null && tenantbySubdomain != null && tenantbyUsername == null)
                    return BadRequest(new
                    {
                        status = "Exsiting_Subdomain",
                        error = "Subdomain name is already taken.Please,Choose another one"
                    });
                var Tenant = new TenantsInfo()
                {
                    CompanyName = clientRegister.CompanyName,
                    Subdomain = clientRegister.Subdomain.ToLower(),
                    Username = clientRegister.UserName,
                    Email = clientRegister.Email,
                    ConnectionString = $"Server=(localdb)\\mssqllocaldb;Database={clientRegister.Subdomain};Trusted_Connection=True;MultipleActiveResultSets=true"
                };
                await TenantsUnitOfWork.Tenants.AddAsync(Tenant);

                await ClientUnitOfWork.SetConnectionStringAsync(Tenant.ConnectionString);

                var User = new ApplicationUser()
                {
                    Email = clientRegister.Email,
                    UserName = clientRegister.UserName,
                    IsClientOrStaffOrBoth = (int)Constants.IsClientOrStaffOrBoth.Client_COC
                };
                var result = await UserManager.CreateAsync(User, clientRegister.Password);
                if (result.Succeeded)
                {
                    await TenantsUnitOfWork.SaveAsync();
                    var user = await UserManager.FindByEmailAsync(clientRegister.Email);
                    if (!await RoleManager.RoleExistsAsync(Constants.Admin_Role))
                        await RoleManager.CreateAsync(new ApplicationUserRole(Constants.Admin_Role));

                    var roleResult = await UserManager.AddToRoleAsync(user, Constants.Admin_Role);
                    if (!roleResult.Succeeded)
                        return BadRequest(new { status = Constants.RolenameAddtion_statuCode, error = Constants.RolenameAddtion_ErrorMessage });
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
            return BadRequest(Constants.ModelState_ERROR_Response(ModelState));
        }
        // POST api/<IdentityController>/LoginMainDomain
        [HttpPost(nameof(Login_COC))]
        [AllowAnonymous]
        public async Task<ActionResult<UserWithToken>> Login_COC([FromBody] ClientLogin clientLogin)
        {
            if (ModelState.IsValid)
            {
                //Get ConnectionString From Tenant Db
                var tenant = await TenantsUnitOfWork.Tenants.TenantBySubdomainAsync(clientLogin.Subdomain);
                if (tenant == null) return BadRequest(Constants.NullTentant_Error_Response());
                var user = await Authentication.AuthenticateClients(clientLogin, tenant);
                if (user == null) return Unauthorized(Constants.NullUser_Error_Response());
                //Sign In User
                if (!await UserManager.IsEmailConfirmedAsync(user)) return Unauthorized(Constants.EmailConfirmation_Error_Response());
                var claimPrincipal = HttpContext.User = await ApplicationUserSignIngManager.CreateUserPrincipalAsync(user);
                
                await Request.HttpContext.SignInAsync(IdentityConstants.ApplicationScheme, claimPrincipal);
               
                if (user.WrongPassowrd == false)
                {
                    return new UserWithToken
                    {
                        Username = user.UserName,
                        Token = user.Token,
                        Roles = (List<string>)await UserManager.GetRolesAsync(user),
                        Subdomain = tenant.Subdomain
                    };
                }
                else return Unauthorized(Constants.WrongPassword_Error_Response());
            }
            return BadRequest(Constants.ModelState_ERROR_Response(ModelState));
        }
        // POST api/<IdentityController>/EmailConfirmation
        [HttpPost(nameof(EmailConfirmation))]
        public async Task<IActionResult> EmailConfirmation([FromBody] EmailConfirmationModel emailConfirmationModel)
        {
            var tenantbyEmail = await TenantsUnitOfWork.Tenants.TenantByEmailAsync(emailConfirmationModel.email);
            if (tenantbyEmail == null) return BadRequest(Constants.NullTentant_Error_Response());
            await ClientUnitOfWork.SetConnectionStringAsync(tenantbyEmail.ConnectionString);
            var user = await UserManager.FindByEmailAsync(emailConfirmationModel.email);
            if (user == null)
                return BadRequest(Constants.NullUser_Error_Response());
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
            var tenantbyEmail = await TenantsUnitOfWork.Tenants.TenantByEmailAsync(sendEmailConfirmationAgian.Email);
            if (tenantbyEmail == null) return BadRequest(Constants.NullTentant_Error_Response());
            await ClientUnitOfWork.SetConnectionStringAsync(tenantbyEmail.ConnectionString);
            var user = await UserManager.FindByEmailAsync(sendEmailConfirmationAgian.Email);
            if (user == null)
                return BadRequest(Constants.NullUser_Error_Response());
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
            var tenantbyEmail = TenantsUnitOfWork.Tenants.TenantByEmailAsync(ForgetPasswordModel.Email);
            if (tenantbyEmail == null) return BadRequest(Constants.NullTentant_Error_Response());
            await ClientUnitOfWork.SetConnectionStringAsync(tenantbyEmail.GetAwaiter().GetResult().ConnectionString);
            var user = await UserManager.FindByEmailAsync(ForgetPasswordModel.Email);
            if (user == null)
                return BadRequest(Constants.NullUser_Error_Response());
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
                var tenantbyEmail = await TenantsUnitOfWork.Tenants.TenantByEmailAsync(ResetPasswordModel.email);
                if (tenantbyEmail == null) return BadRequest(Constants.NullTentant_Error_Response());
                await ClientUnitOfWork.SetConnectionStringAsync(tenantbyEmail.ConnectionString);
                var user = await UserManager.FindByEmailAsync(ResetPasswordModel.email);
                if (user == null)
                    return BadRequest(Constants.NullUser_Error_Response());
                var token = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(ResetPasswordModel.token));
                var confirmResult = await UserManager.ResetPasswordAsync(user, token, ResetPasswordModel.Password);
                if (!confirmResult.Succeeded)
                    return BadRequest(new { status = Constants.ResetPassword_statuCode, error = confirmResult.Errors });
                return StatusCode(201);
            }
            return BadRequest(Constants.ModelState_ERROR_Response(ModelState));
        }

        [HttpGet(nameof(IsTenantFound))]
        public async Task<IActionResult> IsTenantFound(string subdomain)
        {
            if (!CheckManuallyChanged_Subdomain(subdomain))
            {
                return BadRequest(Constants.HackTrying_Error_Response());
            }
            var Tenant = await TenantsUnitOfWork.Tenants.TenantBySubdomainAsync(subdomain);
            if (Tenant == null)
                return BadRequest(Constants.NullTentant_Error_Response());
            return Ok();
        }
        [HttpGet(nameof(LoggOut))]
        public async Task<IActionResult> LoggOut()
        {
            await Request.HttpContext.SignOutAsync();
            HttpContext.User = null;
            return Ok();
        }
        //HelperMedthod
        private bool CheckManuallyChanged_Subdomain(string subdomain)
        {
            return subdomain == HttpContext.Request.Host.Host.Split('.')[0];
        }
    }
}
