using ERP.Areas.Owners.Data;
using ERP.Areas.Owners.Models;
using ERP.Areas.Owners.Models.Identity;
using ERP.UnitOfWork;
using ERP.Utilities;
using ERP.Utilities.Services;
using ERP.Utilities.Services.EmailService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP.Areas.Owners.Controllers
{
    [Area("Owners")]
    [Route("api/[Area]/[controller]")]
    [ApiController]
    public class GeneralsController : ControllerBase
    {
        public OwnerUserManager OwnerManager { get; set; }
        public OwnerRoleManager RoleManager { get; set; }
        public ITokenService TokenService { get; }
        public IUnitOfWork_Owners OwnersUnitOfWork { get; }
        public DbContextOptions<OwnersDbContext> DbOptions { get; }
        public OwnerSignInManager OwnerSigninManager { get; }
        public IMailService MailService { get; }
        public Constants Constants { get; set; }

        public GeneralsController(OwnerUserManager ownerManager, ITokenService tokenService, Constants constants,
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

        [HttpGet(nameof(GetCountries))]
        [AllowAnonymous]
        public async Task<ActionResult<List<Country>>> GetCountries()
        {
            return await OwnersUnitOfWork.Countries.GetAllAsync();
        }

    }
}
