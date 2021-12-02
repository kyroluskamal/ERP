using ERP.Areas.Tenants.Models;
using ERP.Data;
using ERP.Data.Identity;
using ERP.Models;
using ERP.UnitOfWork;
using ERP.Utilities;
using ERP.Utilities.Services;
using ERP.Utilities.Services.EmailService;
using ERP.Models.COCs;
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
using System;

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
        public Utilities.Services.AuthenticationService Authentication { get; }
        public IMailService MailService { get; }
        public IAntiforgery Antiforgery { get; }
        public IUnitOfWork_ApplicationUser ClientUnitOfWork { get; set; }
        public DbContextOptions<ApplicationDbContext> DbOptions;
        public Constants Constants { get; set; }
        public ApplicationUserRoleManager RoleManager { get; set; }
        //...........................Constructor........................
        public IdentityController(
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

        // POST api/<IdentityController>/
        [HttpPost]
        [AllowAnonymous]
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
                    IsClientOrStaffOrBoth = (int)Constants.IsClientOrStaffOrBoth.Owner
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
                        return BadRequest(Constants.RolenameAddtion_ERROR_Response());
                    var code = await UserManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var param = new Dictionary<string, string>
                    {
                        {"token", code },
                        {"email", clientRegister.Email }
                    };
                    var callbackUrl = QueryHelpers.AddQueryString(clientRegister.ClientUrl, param);
                    var mailRequest = new MailRequest
                    {
                        ToEmail = clientRegister.Email,
                        Subject = Constants.ConfirmationEmail_Subject,
                        Body = Constants.ConfirmationEmail_Body(HtmlEncoder.Default.Encode(callbackUrl))
                    };
                    MailService.SendEmail(mailRequest);

                    return Ok();
                }
                return BadRequest(new { status = Constants.ResultStatus_statuCode, error = result.Errors });
            }
            return BadRequest(Constants.ModelState_ERROR_Response(ModelState));
        }
        
        [HttpPost(nameof(Register_COC))]
        [AllowAnonymous]
        public async Task<IActionResult> Register_COC(ApplicationUser COC)
        {
            var tenant = await TenantsUnitOfWork.Tenants.TenantBySubdomainAsync(COC.Subdomain.ToLower());
            if (tenant == null) return BadRequest(Constants.NullTentant_Error_Response());

            if (ModelState.IsValid)
            {
                ApplicationUser newUser = new()
                {
                    Email = COC.Email,
                    UserName = COC.UserName,
                    PhoneNumber = COC.PhoneNumber,
                    IsClientOrStaffOrBoth = (int)Constants.IsClientOrStaffOrBoth.Client_COC
                };
                COC NewClient = new()
                {
                    ClientType = Convert.ToBoolean(Constants.ClientType.Individual),
                    CreditLimit = 0,
                    CreditPeriodLimit =0,
                };
                var UserCreationResult = await UserManager.CreateAsync(newUser, COC.PasswordHash);
                if (UserCreationResult.Succeeded)
                {
                    await TenantsUnitOfWork.SaveAsync();
                    var user = await UserManager.FindByEmailAsync(COC.Email);
                    if (!await RoleManager.RoleExistsAsync(Constants.Client_Role))
                        await RoleManager.CreateAsync(new ApplicationUserRole(Constants.Client_Role));

                    var roleResult = await UserManager.AddToRoleAsync(user, Constants.Client_Role);
                    if (!roleResult.Succeeded)
                        return BadRequest(Constants.RolenameAddtion_ERROR_Response());
                    var code = await UserManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var param = new Dictionary<string, string>
                    {
                        {"token", code },
                        {"email", COC.Email }
                    };
                    var callbackUrl = QueryHelpers.AddQueryString(COC.ClientUrl, param);
                    var mailRequest = new MailRequest
                    {
                        ToEmail = COC.Email,
                        Subject = Constants.ConfirmationEmail_Subject,
                        Body = Constants.ConfirmationEmail_Body(HtmlEncoder.Default.Encode(callbackUrl))
                    };
                    MailService.SendEmail(mailRequest);

                    return Ok();
                }
                return BadRequest(new { status = Constants.ResultStatus_statuCode, error = UserCreationResult.Errors });
            }
            else
            {
                return BadRequest(Constants.ModelState_ERROR_Response(ModelState));
            }

        }
        // POST api/<IdentityController>/LoginMainDomain
        [HttpPost]
        [Route("LoginMainDomain")]
        [AllowAnonymous]
        public async Task<ActionResult<ClientWithToken>> LoginMainDomain([FromBody] ClientLogin clientLogin)
        {
            if (ModelState.IsValid)
            {
                TenantsInfo tenant = null;
                if(clientLogin.IsCOC==false)
                //Get ConnectionString From Tenant Db
                    tenant = await TenantsUnitOfWork.Tenants.TenantByEmailAsync(clientLogin.Email);
                else if(clientLogin.IsCOC==true)
                    tenant = await TenantsUnitOfWork.Tenants.TenantBySubdomainAsync(clientLogin.Subdomain);
                
                if (tenant == null) return BadRequest(Constants.NullTentant_Error_Response());
                var user = await Authentication.AuthenticateClients(clientLogin, tenant);
                if (user == null) return Unauthorized(Constants.NullUser_Error_Response());
                //Sign In User
                if (!await UserManager.IsEmailConfirmedAsync(user)) return Unauthorized(Constants.EmailConfirmation_Error_Response());
                var claimPrincipal = HttpContext.User = await ApplicationUserSignIngManager.CreateUserPrincipalAsync(user);
                
                await Request.HttpContext.SignInAsync(IdentityConstants.ApplicationScheme, claimPrincipal);
                Debug.WriteLine(user.UserRole);
                if (user.WrongPassowrd == false)
                {
                    return new ClientWithToken
                    {
                        UserId = user.Id,
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
            TenantsInfo tenant = null;
            if (emailConfirmationModel.IsCOC == false)
                //Get ConnectionString From Tenant Db
                tenant = await TenantsUnitOfWork.Tenants.TenantByEmailAsync(emailConfirmationModel.email);
            else if (emailConfirmationModel.IsCOC == true)
                tenant = await TenantsUnitOfWork.Tenants.TenantBySubdomainAsync(emailConfirmationModel.Subdomain);

            if (tenant == null) return BadRequest(Constants.NullTentant_Error_Response());
            await ClientUnitOfWork.SetConnectionStringAsync(tenant.ConnectionString);
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
            TenantsInfo tenant = null;
            if (sendEmailConfirmationAgian.IsCOC == false)
                //Get ConnectionString From Tenant Db
                tenant = await TenantsUnitOfWork.Tenants.TenantByEmailAsync(sendEmailConfirmationAgian.Email);
            else if (sendEmailConfirmationAgian.IsCOC == true)
                tenant = await TenantsUnitOfWork.Tenants.TenantBySubdomainAsync(sendEmailConfirmationAgian.Subdomain);

            if (tenant == null) return BadRequest(Constants.NullTentant_Error_Response());
            await ClientUnitOfWork.SetConnectionStringAsync(tenant.ConnectionString);
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
            var mailRequest = new MailRequest
            {
                ToEmail = sendEmailConfirmationAgian.Email,
                Subject = Constants.ConfirmationEmail_Subject,
                Body = Constants.ConfirmationEmail_Body(HtmlEncoder.Default.Encode(callbackUrl))
            };
            MailService.SendEmail(mailRequest);
            return Ok();
        }
        // POST api/<IdentityController>/ForgetPassword
        [HttpPost(nameof(ForgetPassword))]
        public async Task<IActionResult> ForgetPassword([FromBody] ClientForgetPasswordModel ForgetPasswordModel)
        {
            TenantsInfo tenant = null;
            if (ForgetPasswordModel.IsCOC == false)
                //Get ConnectionString From Tenant Db
                tenant = await TenantsUnitOfWork.Tenants.TenantByEmailAsync(ForgetPasswordModel.Email);
            else if (ForgetPasswordModel.IsCOC == true)
                tenant = await TenantsUnitOfWork.Tenants.TenantBySubdomainAsync(ForgetPasswordModel.Subdomain);

            if (tenant == null) return BadRequest(Constants.NullTentant_Error_Response());
            await ClientUnitOfWork.SetConnectionStringAsync(tenant.ConnectionString);
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

            var mailRequest = new MailRequest
            {
                ToEmail = ForgetPasswordModel.Email,
                Subject = Constants.ResetPassword_Subject,
                Body = Constants.ResetEmail_Body(HtmlEncoder.Default.Encode(callbackUrl))
            };
            MailService.SendEmail(mailRequest);
            return Ok();
        }
        // Post api/<IdentityController>/ResetPassword
        [HttpPost(nameof(ResetPassword))]
        public async Task<IActionResult> ResetPassword([FromBody] ClientResetPasswordModel ResetPasswordModel)
        {
            if (ModelState.IsValid)
            {
                TenantsInfo tenant = null;
                if (ResetPasswordModel.IsCOC == false)
                    //Get ConnectionString From Tenant Db
                    tenant = await TenantsUnitOfWork.Tenants.TenantByEmailAsync(ResetPasswordModel.email);
                else if (ResetPasswordModel.IsCOC == true)
                    tenant = await TenantsUnitOfWork.Tenants.TenantBySubdomainAsync(ResetPasswordModel.Subdomain);

                if (tenant == null) return BadRequest(Constants.NullTentant_Error_Response());
                await ClientUnitOfWork.SetConnectionStringAsync(tenant.ConnectionString);
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
