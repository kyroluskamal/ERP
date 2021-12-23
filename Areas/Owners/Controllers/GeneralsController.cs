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
        [HttpGet(nameof(GetCurrencies))]
        [AllowAnonymous]
        public async Task<ActionResult<List<Currency>>> GetCurrencies()
        {
            return await OwnersUnitOfWork.Currencies.GetAllAsync();
        }

        private async Task FillinCurrencies()
        {
            Currency[] Currenies = new Currency[]
            {
                new Currency(){CurrencyName ="Albania Lek", CurrencyCode = "ALL", CurrencySymbol= "Lek" },
                new Currency(){CurrencyName = "Afghanistan Afghani", CurrencyCode = "AFN", CurrencySymbol= "؋"},
                new Currency(){CurrencyName = "Argentina Peso" , CurrencyCode = "ARS", CurrencySymbol=	"$"},
                new Currency(){CurrencyName ="Aruba Guilder", CurrencyCode =   "AWG" , CurrencySymbol="ƒ"},
                new Currency(){CurrencyName ="Australia Dollar" , CurrencyCode =   "AUD", CurrencySymbol=	"$"},
                new Currency(){CurrencyName ="Azerbaijan Manat" , CurrencyCode =   "AZN", CurrencySymbol=	"₼"},
                new Currency(){CurrencyName ="Bahamas Dollar", CurrencyCode =  "BSD", CurrencySymbol=	"$"},
                new Currency(){CurrencyName ="Barbados Dollar", CurrencyCode = "BBD", CurrencySymbol=	"$"},
                new Currency(){CurrencyName ="Belarus Ruble", CurrencyCode =   "BYN" , CurrencySymbol="Br"},
                new Currency(){CurrencyName ="Belize Dollar" , CurrencyCode =  "BZD" , CurrencySymbol="BZ$"},
                new Currency(){CurrencyName ="Bermuda Dollar" , CurrencyCode = "BMD", CurrencySymbol=	"$"},
                new Currency(){CurrencyName ="Bolivia Bolíviano"  , CurrencyCode = "BOB", CurrencySymbol=	"$b"},
                new Currency(){CurrencyName ="Bosnia and Herzegovina Convertible Mark" , CurrencyCode ="BAM" , CurrencySymbol="KM"},
                new Currency(){CurrencyName ="Botswana Pula" , CurrencyCode =  "BWP", CurrencySymbol= "P"},
                new Currency(){CurrencyName ="Bulgaria Lev" , CurrencyCode =   "BGN" , CurrencySymbol="лв"},
                new Currency(){CurrencyName ="Brazil Real", CurrencyCode = "BRL" , CurrencySymbol="R$"},
                new Currency(){CurrencyName ="Brunei Darussalam Dollar" , CurrencyCode =   "BND", CurrencySymbol=	"$"},
                new Currency(){CurrencyName ="Cambodia Riel"  , CurrencyCode = "KHR", CurrencySymbol=	"៛"},
                new Currency(){CurrencyName ="Canada Dollar" , CurrencyCode =  "CAD"	, CurrencySymbol="$"},
                new Currency(){CurrencyName ="Cayman Islands Dollar" , CurrencyCode =  "KYD", CurrencySymbol=	"$"},
                new Currency(){CurrencyName ="Chile Peso" , CurrencyCode = "CLP", CurrencySymbol=	"$"},
                new Currency(){CurrencyName ="China Yuan Renminbi", CurrencyCode = "CNY", CurrencySymbol=	"¥"},
                new Currency(){CurrencyName ="Colombia Peso" , CurrencyCode =  "COP", CurrencySymbol=	"$"},
                new Currency(){CurrencyName ="Costa Rica Colon" , CurrencyCode =   "CRC", CurrencySymbol=	"₡"},
                new Currency(){CurrencyName ="Croatia Kuna"  , CurrencyCode =  "HRK" , CurrencySymbol="kn"},
                new Currency(){CurrencyName ="Cuba Peso", CurrencyCode =   "CUP", CurrencySymbol=	"₱"},
                new Currency(){CurrencyName ="Czech Republic Koruna" , CurrencyCode =  "CZK", CurrencySymbol= "Kč"},
                new Currency(){CurrencyName ="Denmark Krone", CurrencyCode =   "DKK", CurrencySymbol= "kr"},
                new Currency(){CurrencyName ="Dominican Republic Peso", CurrencyCode = "DOP", CurrencySymbol= "RD$"},
                new Currency(){CurrencyName ="East Caribbean Dollar", CurrencyCode =   "XCD", CurrencySymbol=	"$"},
                new Currency(){CurrencyName ="Egyptian Pound", CurrencyCode = "EGP"	, CurrencySymbol="£"},
                new Currency(){CurrencyName ="El Salvador Colon"  , CurrencyCode = "SVC"	, CurrencySymbol="$"},
                new Currency(){CurrencyName ="Euro Member Countries" , CurrencyCode =  "EUR", CurrencySymbol=	"€"},
                new Currency(){CurrencyName ="Falkland Islands (Malvinas) Pound" , CurrencyCode =  "FKP", CurrencySymbol=	"£"},
                new Currency(){CurrencyName ="Fiji Dollar", CurrencyCode = "FJD", CurrencySymbol=	"$"},
                new Currency(){CurrencyName ="Ghana Cedi" , CurrencyCode = "GHS", CurrencySymbol=	"¢"},
                new Currency(){CurrencyName ="Gibraltar Pound", CurrencyCode = "GIP"	, CurrencySymbol="£"},
                new Currency(){CurrencyName ="Guatemala Quetzal", CurrencyCode =   "GTQ", CurrencySymbol= "Q"},
                new Currency(){CurrencyName ="Guernsey Pound" , CurrencyCode = "GGP", CurrencySymbol=	"£"},
                new Currency(){CurrencyName ="Guyana Dollar" , CurrencyCode =  "GYD"	, CurrencySymbol="$"},
                new Currency(){CurrencyName ="Honduras Lempira "  , CurrencyCode = "HNL", CurrencySymbol= "L"},
                new Currency(){CurrencyName ="Hong Kong Dollar" , CurrencyCode =   "HKD", CurrencySymbol=	"$"},
                new Currency(){CurrencyName ="Hungary Forint" , CurrencyCode = "HUF" , CurrencySymbol="Ft"},
                new Currency(){CurrencyName ="Iceland Krona " , CurrencyCode = "ISK", CurrencySymbol= "kr"},
                new Currency(){CurrencyName ="India Rupee", CurrencyCode = "INR", CurrencySymbol=	"₹"},
                new Currency(){CurrencyName ="Indonesia Rupiah " , CurrencyCode =  "IDR", CurrencySymbol= "Rp"},
                new Currency(){CurrencyName ="Iran Rial" , CurrencyCode =  "IRR", CurrencySymbol=	"﷼"},
                new Currency(){CurrencyName ="Isle of Man Pound" , CurrencyCode =  "IMP", CurrencySymbol=	"£"},
                new Currency(){CurrencyName ="Israel Shekel " , CurrencyCode = "ILS", CurrencySymbol=	"₪"},
                new Currency(){CurrencyName ="Jamaica Dollar" , CurrencyCode = "JMD", CurrencySymbol= "J$"},
                new Currency(){CurrencyName ="Japan Yen" , CurrencyCode =  "JPY", CurrencySymbol=	"¥"},
                new Currency(){CurrencyName ="Jersey Pound" , CurrencyCode =   "JEP"	, CurrencySymbol="£"},
                new Currency(){CurrencyName ="Kazakhstan Tenge" , CurrencyCode =   "KZT", CurrencySymbol= "лв"},
                new Currency(){CurrencyName ="Korea (North) Won" , CurrencyCode =  "KPW", CurrencySymbol=	"₩"},
                new Currency(){CurrencyName ="Kyrgyzstan Som"  , CurrencyCode ="KGS" , CurrencySymbol="лв"},
                new Currency(){CurrencyName ="Laos Kip"  , CurrencyCode =  "LAK", CurrencySymbol=	"₭"},
                new Currency(){CurrencyName ="Lebanon Pound" , CurrencyCode =  "LBP", CurrencySymbol=	"£"},
                new Currency(){CurrencyName ="Liberia Dollar"  , CurrencyCode ="LRD", CurrencySymbol=	"$"},
                new Currency(){CurrencyName ="Macedonia Denar", CurrencyCode = "MKD" , CurrencySymbol="ден"},
                new Currency(){CurrencyName ="Malaysia Ringgit"  , CurrencyCode =  "MYR" , CurrencySymbol="RM"},
                new Currency(){CurrencyName ="Mauritius Rupee", CurrencyCode = "MUR", CurrencySymbol=	"₨"},
                new Currency(){CurrencyName ="Mexico Peso" , CurrencyCode ="MXN", CurrencySymbol=	"$"},
                new Currency(){CurrencyName ="Mongolia Tughrik"  , CurrencyCode =  "MNT", CurrencySymbol=	"₮"},
                new Currency(){CurrencyName ="Moroccan-dirham", CurrencyCode = "MNT" , CurrencySymbol= "د.إ"},
                new Currency(){CurrencyName ="Mozambique Metical" , CurrencyCode = "MZN", CurrencySymbol= "MT"},
                new Currency(){CurrencyName ="Namibia Dollar" , CurrencyCode = "NAD", CurrencySymbol=	"$"},
                new Currency(){CurrencyName ="Nepal Rupee" , CurrencyCode ="NPR", CurrencySymbol=	"₨"},
                new Currency(){CurrencyName ="Netherlands Antilles Guilder"  , CurrencyCode = "ANG", CurrencySymbol= "ƒ"},
                new Currency(){CurrencyName ="New Zealand Dollar" , CurrencyCode = "NZD"	, CurrencySymbol="$"},
                new Currency(){CurrencyName ="Nicaragua Cordoba" , CurrencyCode =  "NIO", CurrencySymbol= "C$"},
                new Currency(){CurrencyName ="Nigeria Naira"  , CurrencyCode = "NGN", CurrencySymbol=	"₦"},
                new Currency(){CurrencyName ="Norway Krone"  , CurrencyCode =  "NOK", CurrencySymbol= "kr"},
                new Currency(){CurrencyName ="Oman Rial"  , CurrencyCode = "OMR"	, CurrencySymbol="﷼"},
                new Currency(){CurrencyName ="Pakistan Rupee" , CurrencyCode = "PKR", CurrencySymbol=	"₨"},
                new Currency(){CurrencyName ="Panama Balboa" , CurrencyCode =  "PAB", CurrencySymbol= "B/."},
                new Currency(){CurrencyName ="Paraguay Guarani " , CurrencyCode =  "PYG", CurrencySymbol= "Gs"},
                new Currency(){CurrencyName ="Peru Sol"  , CurrencyCode =  "PEN", CurrencySymbol= "S/."},
                new Currency(){CurrencyName ="Philippines Peso"  , CurrencyCode =  "PHP", CurrencySymbol=	"₱"},
                new Currency(){CurrencyName ="Poland Zloty "  , CurrencyCode = "PLN" , CurrencySymbol="zł"},
                new Currency(){CurrencyName ="Qatar Riyal", CurrencyCode = "QAR", CurrencySymbol=	"﷼"},
                new Currency(){CurrencyName ="Romania Leu", CurrencyCode = "RON" , CurrencySymbol= "lei"},
                new Currency(){CurrencyName ="Russia Ruble " , CurrencyCode =  "RUB", CurrencySymbol=	"₽"},
                new Currency(){CurrencyName ="Saint Helena Pound" , CurrencyCode = "SHP", CurrencySymbol=	"£"},
                new Currency(){CurrencyName ="Saudi Arabia Riyal"  , CurrencyCode ="SAR", CurrencySymbol=	"﷼"},
                new Currency(){CurrencyName ="Serbia Dinar"   , CurrencyCode = "RSD", CurrencySymbol= "Дин."},
                new Currency(){CurrencyName ="Seychelles Rupee"  , CurrencyCode =  "SCR", CurrencySymbol=	"₨"},
                new Currency(){CurrencyName ="Singapore Dollar " , CurrencyCode =  "SGD"	, CurrencySymbol="$"},
                new Currency(){CurrencyName ="Solomon Islands Dollar" , CurrencyCode = "SBD", CurrencySymbol=	"$"},
                new Currency(){CurrencyName ="Somalia Shilling "  , CurrencyCode = "SOS" , CurrencySymbol="S"},
                new Currency(){CurrencyName ="South Korean Won "  , CurrencyCode = "KRW", CurrencySymbol=	"₩"},
                new Currency(){CurrencyName ="South Africa Rand"   , CurrencyCode ="ZAR", CurrencySymbol= "R"},
                new Currency(){CurrencyName ="Sri Lanka Rupee", CurrencyCode = "LKR"	, CurrencySymbol="₨"},
                new Currency(){CurrencyName ="Sweden Krona"  , CurrencyCode =  "SEK" , CurrencySymbol="kr"},
                new Currency(){CurrencyName ="Switzerland Franc"  , CurrencyCode = "CHF" , CurrencySymbol="CHF"},
                new Currency(){CurrencyName ="Suriname Dollar" , CurrencyCode ="SRD", CurrencySymbol=	"$"},
                new Currency(){CurrencyName ="Syria Pound" , CurrencyCode ="SYP"	, CurrencySymbol="£"},
                new Currency(){CurrencyName ="Taiwan New Dollar" , CurrencyCode =  "TWD" , CurrencySymbol="NT$"},
                new Currency(){CurrencyName ="Thailand Baht" , CurrencyCode = "THB", CurrencySymbol=	"฿"},
                new Currency(){CurrencyName ="Trinidad and Tobago Dollar" , CurrencyCode = "TTD", CurrencySymbol= "TT$"},
                new Currency(){CurrencyName ="Turkey Lira", CurrencyCode = "TRY"	, CurrencySymbol="₺"},
                new Currency(){CurrencyName ="Tuvalu Dollar"  , CurrencyCode = "TVD"	, CurrencySymbol="$"},
                new Currency(){CurrencyName ="Ukraine Hryvnia" , CurrencyCode ="UAH"	, CurrencySymbol="₴"},
                new Currency(){CurrencyName ="UAE-Dirham"  , CurrencyCode ="AED" , CurrencySymbol= "د.إ"},
                new Currency(){CurrencyName ="United Kingdom Pound"  , CurrencyCode =  "GBP", CurrencySymbol=	"£"},
                new Currency(){CurrencyName ="United States Dollar "  , CurrencyCode = "USD", CurrencySymbol=	"$"},
                new Currency(){CurrencyName ="Uruguay Peso" , CurrencyCode =   "UYU"	, CurrencySymbol="$U"},
                new Currency(){CurrencyName ="Uzbekistan Som" , CurrencyCode = "UZS" , CurrencySymbol="лв"},
                new Currency(){CurrencyName ="Venezuela Bolívar" , CurrencyCode =  "VEF" , CurrencySymbol="Bs"},
                new Currency(){CurrencyName ="Viet Nam Dong" , CurrencyCode =  "VND", CurrencySymbol=	"₫"},
                new Currency(){CurrencyName ="Yemen Rial" , CurrencyCode = "YER"	, CurrencySymbol="﷼"},
                new Currency(){CurrencyName ="Zimbabwe Dollar", CurrencyCode = "ZWD" , CurrencySymbol="Z$"},
            };
            await OwnersUnitOfWork.Currencies.AddRangeAsync(Currenies);
        }
    }
}
