using ERP.Areas.Owners.Models;
using ERP.Areas.Owners.Models.Identity;
using ERP.UnitOfWork;
using ERP.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Areas.Owners.Data.DbInitializer
{
    public class OwnerDbInitializer : IOwnerDbInitializer
    {
        private readonly OwnersDbContext OwnerDbContext;
        private readonly OwnerUserManager UserManager;
        private readonly OwnerRoleManager RoleManager;
        private readonly Constants Constants;


        public OwnerDbInitializer(OwnersDbContext ownerDbContext, Constants constants,
            OwnerUserManager userManager, OwnerRoleManager roleManager,
            IUnitOfWork_Owners ownersUnitOfWork)
        {
            OwnerDbContext = ownerDbContext;
            RoleManager = roleManager;
            OwnersUnitOfWork = ownersUnitOfWork;
            UserManager = userManager;
            Constants = constants;
        }

        public IUnitOfWork_Owners OwnersUnitOfWork { get; }

        public async Task Initialize()
        {
            try
            {
                if (OwnerDbContext.Database.GetPendingMigrations().Any())
                {
                    OwnerDbContext.Database.Migrate();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }

            if (OwnerDbContext.Roles.Any(r => r.Name == Constants.SuperAdmin_Role)) return;

            if (!RoleManager.RoleExistsAsync(Constants.Admin_Role).GetAwaiter().GetResult())
                RoleManager.CreateAsync(new OwnerRole(Constants.Admin_Role)).GetAwaiter().GetResult();
            if (!RoleManager.RoleExistsAsync(Constants.SuperAdmin_Role).GetAwaiter().GetResult())
                RoleManager.CreateAsync(new OwnerRole(Constants.SuperAdmin_Role)).GetAwaiter().GetResult();
            if (!RoleManager.RoleExistsAsync(Constants.Moderator_Role).GetAwaiter().GetResult())
                RoleManager.CreateAsync(new OwnerRole(Constants.Moderator_Role)).GetAwaiter().GetResult();
            if (!RoleManager.RoleExistsAsync(Constants.Employee_Role).GetAwaiter().GetResult())
                RoleManager.CreateAsync(new OwnerRole(Constants.Employee_Role)).GetAwaiter().GetResult();
            if (!RoleManager.RoleExistsAsync(Constants.CustomerService_Role).GetAwaiter().GetResult())
                RoleManager.CreateAsync(new OwnerRole(Constants.CustomerService_Role)).GetAwaiter().GetResult();

            Owner Admin = OwnerDbContext.Users.Where(u => u.Email == "kyroluskamal@gmail.com").FirstOrDefault();
            if (Admin == null)
            {
                UserManager.CreateAsync(new Owner
                {
                    UserName = "KyrolusKamal",
                    Email = "kyroluskamal@gmail.com",
                    EmailConfirmed = true,
                    FirstName = "Kyrolus",
                    LastName = "Faheem"
                }, "Kiko@2009").GetAwaiter().GetResult();

                Owner user = OwnerDbContext.Users.Where(u => u.Email == "kyroluskamal@gmail.com").FirstOrDefault();

                if (!UserManager.IsInRoleAsync(user, Constants.SuperAdmin_Role).GetAwaiter().GetResult())
                    UserManager.AddToRoleAsync(user, Constants.SuperAdmin_Role);
            }
            if (OwnerDbContext.Countries.ToListAsync().GetAwaiter().GetResult().Count == 0)
            {
                Country[] countries = new Country[] {
                   new Country() { CountryName = "Afghanistan", CountryNameCode = "AF", PhoneCode="" },
                   new Country() { CountryName = "Åland Islands", CountryNameCode = "AX", PhoneCode = "" },
                   new Country() { CountryName = "Albania", CountryNameCode = "AL", PhoneCode = "" },
                   new Country() { CountryName = "Algeria", CountryNameCode = "DZ", PhoneCode = "" },
                   new Country() { CountryName = "American Samoa", CountryNameCode = "AS", PhoneCode = "" },
                   new Country() { CountryName = "Andorra", CountryNameCode = "AD", PhoneCode = "" },
                   new Country() { CountryName = "Angola", CountryNameCode = "AO", PhoneCode = "" },
                   new Country() { CountryName =   "Anguilla", CountryNameCode = "AI", PhoneCode = "" },
                   new Country() { CountryName =   "Antarctica", CountryNameCode = "AQ",  PhoneCode = "" },
                   new Country() { CountryName =   "Antigua and Barbuda", CountryNameCode = "AG",  PhoneCode = "" },
                   new Country() { CountryName =   "Argentina", CountryNameCode = "AR",  PhoneCode = "" },
                   new Country() { CountryName =   "Armenia", CountryNameCode = "AM",  PhoneCode = "" },
                   new Country() { CountryName =   "Aruba", CountryNameCode = "AW",  PhoneCode = "" },
                   new Country() { CountryName =   "Australia", CountryNameCode = "AU", PhoneCode = "" },
                   new Country() { CountryName =  "Austria", CountryNameCode = "AT",  PhoneCode = "" },
                   new Country() { CountryName =   "Azerbaijan", CountryNameCode = "AZ", PhoneCode = "" },
                   new Country() { CountryName =   "Bahamas", CountryNameCode = "BS",  PhoneCode = "" },
                   new Country() { CountryName =   "Bahrain", CountryNameCode = "BH", PhoneCode = "" },
                   new Country() { CountryName =   "Bangladesh", CountryNameCode = "BD", PhoneCode = "" },
                   new Country() { CountryName =   "Barbados", CountryNameCode = "BB",  PhoneCode = "" },
                   new Country() { CountryName =   "Belarus", CountryNameCode = "BY", PhoneCode = "" },
                   new Country() { CountryName =   "Belgium", CountryNameCode = "BE",  PhoneCode = "" },
                    new Country() { CountryName =  "Belize", CountryNameCode = "BZ", PhoneCode = "" },
                    new Country() { CountryName =  "Benin", CountryNameCode = "BJ", PhoneCode = "" },
                    new Country() { CountryName =  "Bermuda", CountryNameCode = "BM", PhoneCode = "" },
                    new Country() { CountryName =  "Bhutan", CountryNameCode = "BT",  PhoneCode = "" },
                    new Country() { CountryName =  "Bolivia", CountryNameCode = "BO",  PhoneCode = "" },
                      new Country() { CountryName ="Bosnia and Herzegovina", CountryNameCode = "BA", PhoneCode = "" },
                      new Country() { CountryName ="Botswana", CountryNameCode = "BW", PhoneCode = "" },
                      new Country() { CountryName ="Bouvet Island", CountryNameCode = "BV",  PhoneCode = "" },
                      new Country() { CountryName ="Brazil", CountryNameCode = "BR", PhoneCode = "" },
                      new Country() { CountryName ="British Indian Ocean Territory", CountryNameCode = "IO", PhoneCode = "" },
                      new Country() { CountryName ="Brunei Darussalam", CountryNameCode = "BN",  PhoneCode = "" },
                      new Country() { CountryName ="Bulgaria", CountryNameCode = "BG", PhoneCode = "" },
                      new Country() { CountryName ="Burkina Faso", CountryNameCode = "BF",   PhoneCode = "" },
                      new Country() { CountryName ="Burundi", CountryNameCode = "BI",   PhoneCode = "" },
                      new Country() { CountryName ="Cambodia", CountryNameCode = "KH",   PhoneCode = "" },
                      new Country() { CountryName ="Cameroon", CountryNameCode = "CM",   PhoneCode = "" },
                      new Country() { CountryName ="Canada", CountryNameCode = "CA",   PhoneCode = "" },
                      new Country() { CountryName ="Cape Verde", CountryNameCode = "CV",   PhoneCode = "" },
                      new Country() { CountryName ="Cayman Islands", CountryNameCode = "KY",   PhoneCode = "" },
                      new Country() { CountryName ="Central African Republic", CountryNameCode = "CF",   PhoneCode = "" },
                      new Country() { CountryName ="Chad", CountryNameCode = "TD",   PhoneCode = "" },
                      new Country() { CountryName ="Chile", CountryNameCode = "CL",   PhoneCode = "" },
                      new Country() { CountryName ="China", CountryNameCode = "CN",   PhoneCode = "" },
                      new Country() { CountryName ="Christmas Island", CountryNameCode = "CX",   PhoneCode = "" },
                      new Country() { CountryName ="Cocos (Keeling) Islands", CountryNameCode = "CC",   PhoneCode = "" },
                      new Country() { CountryName ="Colombia", CountryNameCode = "CO",   PhoneCode = "" },
                      new Country() { CountryName ="Comoros", CountryNameCode = "KM",   PhoneCode = "" },
                      new Country() { CountryName ="Congo", CountryNameCode = "CG",   PhoneCode = "" },
                      new Country() { CountryName ="Congo, The Democratic Republic of the", CountryNameCode = "CD",   PhoneCode = "" },
                      new Country() { CountryName ="Cook Islands", CountryNameCode = "CK",   PhoneCode = "" },
                      new Country() { CountryName ="Costa Rica", CountryNameCode = "CR",   PhoneCode = "" },
                      new Country() { CountryName ="Côte d'Ivoire", CountryNameCode = "CI",   PhoneCode = "" },
                      new Country() { CountryName ="Croatia", CountryNameCode = "HR",   PhoneCode = "" },
                      new Country() { CountryName ="Cuba", CountryNameCode = "CU",   PhoneCode = "" },
                      new Country() { CountryName ="Cyprus", CountryNameCode = "CY",   PhoneCode = "" },
                      new Country() { CountryName ="Czech Republic", CountryNameCode = "CZ",   PhoneCode = "" },
                      new Country() { CountryName ="Denmark", CountryNameCode = "DK",   PhoneCode = "" },
                      new Country() { CountryName ="Djibouti", CountryNameCode = "DJ",   PhoneCode = "" },
                      new Country() { CountryName ="Dominica", CountryNameCode = "DM",   PhoneCode = "" },
                      new Country() { CountryName ="Dominican Republic", CountryNameCode = "DO",   PhoneCode = "" },
                      new Country() { CountryName ="Ecuador", CountryNameCode = "EC",   PhoneCode = "" },
                      new Country() { CountryName ="Egypt", CountryNameCode = "EG",   PhoneCode = "" },
                      new Country() { CountryName ="El Salvador", CountryNameCode = "SV",   PhoneCode = "" },
                      new Country() { CountryName ="Equatorial Guinea", CountryNameCode = "GQ",   PhoneCode = "" },
                      new Country() { CountryName ="Eritrea", CountryNameCode = "ER",   PhoneCode = "" },
                      new Country() { CountryName ="Estonia", CountryNameCode = "EE",   PhoneCode = "" },
                      new Country() { CountryName ="Ethiopia", CountryNameCode = "ET",   PhoneCode = "" },
                      new Country() { CountryName ="Falkland Islands (Malvinas)", CountryNameCode = "FK",   PhoneCode = "" },
                      new Country() { CountryName ="Faroe Islands", CountryNameCode = "FO",   PhoneCode = "" },
                      new Country() { CountryName ="Fiji", CountryNameCode = "FJ",   PhoneCode = "" },
                      new Country() { CountryName ="Finland", CountryNameCode = "FI",   PhoneCode = "" },
                      new Country() { CountryName ="France", CountryNameCode = "FR",   PhoneCode = "" },
                      new Country() { CountryName ="French Guiana", CountryNameCode = "GF",   PhoneCode = "" },
                      new Country() { CountryName ="French Polynesia", CountryNameCode = "PF",   PhoneCode = "" },
                      new Country() { CountryName ="French Southern Territories", CountryNameCode = "TF",   PhoneCode = "" },
                      new Country() { CountryName ="Gabon", CountryNameCode = "GA",   PhoneCode = "" },
                      new Country() { CountryName ="Gambia", CountryNameCode = "GM",   PhoneCode = "" },
                      new Country() { CountryName ="Georgia", CountryNameCode = "GE",   PhoneCode = "" },
                      new Country() { CountryName ="Germany", CountryNameCode = "DE",   PhoneCode = "" },
                      new Country() { CountryName ="Ghana", CountryNameCode = "GH",   PhoneCode = "" },
                      new Country() { CountryName ="Gibraltar", CountryNameCode = "GI",   PhoneCode = "" },
                      new Country() { CountryName ="Greece", CountryNameCode = "GR",   PhoneCode = "" },
                      new Country() { CountryName ="Greenland", CountryNameCode = "GL",   PhoneCode = "" },
                      new Country() { CountryName ="Grenada", CountryNameCode = "GD",   PhoneCode = "" },
                      new Country() { CountryName ="Guadeloupe", CountryNameCode = "GP",   PhoneCode = "" },
                      new Country() { CountryName ="Guam", CountryNameCode = "GU",   PhoneCode = "" },
                      new Country() { CountryName ="Guatemala", CountryNameCode = "GT",   PhoneCode = "" },
                      new Country() { CountryName ="Guernsey", CountryNameCode = "GG",   PhoneCode = "" },
                      new Country() { CountryName ="Guinea", CountryNameCode = "GN",   PhoneCode = "" },
                      new Country() { CountryName ="Guinea-Bissau", CountryNameCode = "GW",   PhoneCode = "" },
                      new Country() { CountryName ="Guyana", CountryNameCode = "GY",   PhoneCode = "" },
                      new Country() { CountryName ="Haiti", CountryNameCode = "HT",   PhoneCode = "" },
                      new Country() { CountryName ="Heard Island and Mcdonald Islands", CountryNameCode = "HM",   PhoneCode = "" },
                      new Country() { CountryName ="Holy See (Vatican City State)", CountryNameCode = "VA",   PhoneCode = "" },
                      new Country() { CountryName ="Honduras", CountryNameCode = "HN",   PhoneCode = "" },
                      new Country() { CountryName ="Hong Kong", CountryNameCode = "HK",   PhoneCode = "" },
                      new Country() { CountryName ="Hungary", CountryNameCode = "HU",   PhoneCode = "" },
                      new Country() { CountryName ="Iceland", CountryNameCode = "IS",   PhoneCode = "" },
                      new Country() { CountryName ="India", CountryNameCode = "IN",   PhoneCode = "" },
                      new Country() { CountryName ="Indonesia", CountryNameCode = "ID",   PhoneCode = "" },
                      new Country() { CountryName ="Iran, Islamic Republic Of", CountryNameCode = "IR",   PhoneCode = "" },
                      new Country() { CountryName ="Iraq", CountryNameCode = "IQ",   PhoneCode = "" },
                      new Country() { CountryName ="Ireland", CountryNameCode = "IE",   PhoneCode = "" },
                      new Country() { CountryName ="Isle of Man", CountryNameCode = "IM",   PhoneCode = "" },
                      new Country() { CountryName ="Israel", CountryNameCode = "IL",   PhoneCode = "" },
                      new Country() { CountryName ="Italy", CountryNameCode = "IT",   PhoneCode = "" },
                      new Country() { CountryName ="Jamaica", CountryNameCode = "JM",   PhoneCode = "" },
                      new Country() { CountryName ="Japan", CountryNameCode = "JP",   PhoneCode = "" },
                      new Country() { CountryName ="Jersey", CountryNameCode = "JE",   PhoneCode = "" },
                      new Country() { CountryName ="Jordan", CountryNameCode = "JO",   PhoneCode = "" },
                      new Country() { CountryName ="Kazakhstan", CountryNameCode = "KZ",   PhoneCode = "" },
                      new Country() { CountryName ="Kenya", CountryNameCode = "KE",   PhoneCode = "" },
                      new Country() { CountryName ="Kiribati", CountryNameCode = "KI",   PhoneCode = "" },
                      new Country() { CountryName ="Kuwait", CountryNameCode = "KW",   PhoneCode = "" },
                      new Country() { CountryName ="Kyrgyzstan", CountryNameCode = "KG",   PhoneCode = "" },
                      new Country() { CountryName ="Lao People'S Democratic Republic", CountryNameCode = "LA",   PhoneCode = "" },
                      new Country() { CountryName ="Latvia", CountryNameCode = "LV",   PhoneCode = "" },
                      new Country() { CountryName ="Lebanon", CountryNameCode = "LB",   PhoneCode = "" },
                      new Country() { CountryName ="Lesotho", CountryNameCode = "LS",   PhoneCode = "" },
                      new Country() { CountryName ="Liberia", CountryNameCode = "LR",   PhoneCode = "" },
                      new Country() { CountryName ="Libyan Arab Jamahiriya", CountryNameCode = "LY",   PhoneCode = "" },
                      new Country() { CountryName ="Liechtenstein", CountryNameCode = "LI",   PhoneCode = "" },
                      new Country() { CountryName ="Lithuania", CountryNameCode = "LT",   PhoneCode = "" },
                      new Country() { CountryName ="Luxembourg", CountryNameCode ="LU",   PhoneCode = "" },
                      new Country() { CountryName ="Macao", CountryNameCode = "MO",   PhoneCode = "" },
                      new Country() { CountryName ="Macedonia, The Former Yugoslav Republic of", CountryNameCode = "MK",   PhoneCode = "" },
                      new Country() { CountryName ="Madagascar", CountryNameCode = "MG",   PhoneCode = "" },
                      new Country() { CountryName ="Malawi", CountryNameCode = "MW",   PhoneCode = "" },
                      new Country() { CountryName ="Malaysia", CountryNameCode = "MY",   PhoneCode = "" },
                      new Country() { CountryName ="Maldives", CountryNameCode = "MV",   PhoneCode = "" },
                      new Country() { CountryName ="Mali", CountryNameCode = "ML",   PhoneCode = "" },
                      new Country() { CountryName ="Malta", CountryNameCode = "MT",   PhoneCode = "" },
                      new Country() { CountryName ="Marshall Islands", CountryNameCode = "MH",   PhoneCode = "" },
                      new Country() { CountryName ="Martinique", CountryNameCode = "MQ",   PhoneCode = "" },
                      new Country() { CountryName ="Mauritania", CountryNameCode = "MR",   PhoneCode = "" },
                      new Country() { CountryName ="Mauritius", CountryNameCode = "MU",   PhoneCode = "" },
                      new Country() { CountryName ="Mayotte", CountryNameCode = "YT",   PhoneCode = "" },
                      new Country() { CountryName ="Mexico", CountryNameCode = "MX",   PhoneCode = "" },
                      new Country() { CountryName ="Micronesia", CountryNameCode = "FM",   PhoneCode = "" },
                      new Country() { CountryName ="Moldova", CountryNameCode = "MD",   PhoneCode = "" },
                      new Country() { CountryName ="Monaco", CountryNameCode = "MC",   PhoneCode = "" },
                      new Country() { CountryName ="Mongolia", CountryNameCode = "MN",   PhoneCode = "" },
                      new Country() { CountryName ="Montserrat", CountryNameCode = "MS",   PhoneCode = "" },
                      new Country() { CountryName ="Morocco", CountryNameCode = "MA",   PhoneCode = "" },
                      new Country() { CountryName ="Mozambique", CountryNameCode = "MZ",   PhoneCode = "" },
                      new Country() { CountryName ="Myanmar", CountryNameCode = "MM",   PhoneCode = "" },
                      new Country() { CountryName ="Namibia", CountryNameCode = "NA",   PhoneCode = "" },
                      new Country() { CountryName ="Nauru", CountryNameCode = "NR",   PhoneCode = "" },
                      new Country() { CountryName ="Nepal", CountryNameCode = "NP",   PhoneCode = "" },
                      new Country() { CountryName ="Netherlands", CountryNameCode = "NL",   PhoneCode = "" },
                      new Country() { CountryName ="Netherlands Antilles", CountryNameCode = "AN",   PhoneCode = "" },
                      new Country() { CountryName ="New Caledonia", CountryNameCode = "NC",   PhoneCode = "" },
                      new Country() { CountryName ="New Zealand", CountryNameCode = "NZ",   PhoneCode = "" },
                      new Country() { CountryName ="Nicaragua", CountryNameCode = "NI",   PhoneCode = "" },
                      new Country() { CountryName ="Niger", CountryNameCode = "NE",   PhoneCode = "" },
                      new Country() { CountryName ="Nigeria", CountryNameCode = "NG",   PhoneCode = "" },
                      new Country() { CountryName ="Niue", CountryNameCode = "NU",   PhoneCode = "" },
                      new Country() { CountryName ="Norfolk Island", CountryNameCode = "NF",   PhoneCode = "" },
                      new Country() { CountryName ="North Korea", CountryNameCode = "KP",   PhoneCode = "" },
                      new Country() { CountryName ="Northern Mariana Islands", CountryNameCode = "MP",   PhoneCode = "" },
                      new Country() { CountryName ="Norway", CountryNameCode = "NO",   PhoneCode = "" },
                      new Country() { CountryName ="Oman", CountryNameCode = "OM",   PhoneCode = "" },
                      new Country() { CountryName ="Pakistan", CountryNameCode = "PK",   PhoneCode = "" },
                      new Country() { CountryName ="Palau", CountryNameCode = "PW",   PhoneCode = "" },
                      new Country() { CountryName ="Palestinian Territory, Occupied", CountryNameCode = "PS",   PhoneCode = "" },
                      new Country() { CountryName ="Panama", CountryNameCode = "PA",   PhoneCode = "" },
                      new Country() { CountryName ="Papua New Guinea", CountryNameCode = "PG",   PhoneCode = "" },
                      new Country() { CountryName ="Paraguay", CountryNameCode = "PY",   PhoneCode = "" },
                      new Country() { CountryName ="Peru", CountryNameCode = "PE",   PhoneCode = "" },
                      new Country() { CountryName ="Philippines", CountryNameCode = "PH",   PhoneCode = "" },
                      new Country() { CountryName ="Pitcairn", CountryNameCode = "PN",   PhoneCode = "" },
                      new Country() { CountryName ="Poland", CountryNameCode = "PL",   PhoneCode = "" },
                      new Country() { CountryName ="Portugal", CountryNameCode = "PT",   PhoneCode = "" },
                      new Country() { CountryName ="Puerto Rico", CountryNameCode = "PR",   PhoneCode = "" },
                      new Country() { CountryName ="Qatar", CountryNameCode = "QA",   PhoneCode = "" },
                      new Country() { CountryName ="Reunion", CountryNameCode = "RE",   PhoneCode = "" },
                      new Country() { CountryName ="Romania", CountryNameCode = "RO",   PhoneCode = "" },
                      new Country() { CountryName ="Russian Federation", CountryNameCode = "RU",   PhoneCode = "" },
                      new Country() { CountryName ="RWANDA", CountryNameCode = "RW",   PhoneCode = "" },
                      new Country() { CountryName ="Saint Helena", CountryNameCode = "SH",   PhoneCode = "" },
                      new Country() { CountryName ="Saint Kitts and Nevis", CountryNameCode = "KN",   PhoneCode = "" },
                      new Country() { CountryName ="Saint Lucia", CountryNameCode = "LC",   PhoneCode = "" },
                      new Country() { CountryName ="Saint Pierre and Miquelon", CountryNameCode = "PM",   PhoneCode = "" },
                      new Country() { CountryName ="Saint Vincent and the Grenadines", CountryNameCode = "VC",   PhoneCode = "" },
                      new Country() { CountryName ="Samoa", CountryNameCode = "WS",   PhoneCode = "" },
                      new Country() { CountryName ="San Marino", CountryNameCode = "SM",   PhoneCode = "" },
                      new Country() { CountryName ="Sao Tome and Principe", CountryNameCode = "ST",   PhoneCode = "" },
                      new Country() { CountryName ="Saudi Arabia", CountryNameCode = "SA",   PhoneCode = "" },
                      new Country() { CountryName ="Senegal", CountryNameCode = "SN",   PhoneCode = "" },
                      new Country() { CountryName ="Serbia and Montenegro", CountryNameCode = "CS",   PhoneCode = "" },
                      new Country() { CountryName ="Seychelles", CountryNameCode = "SC",   PhoneCode = "" },
                      new Country() { CountryName ="Sierra Leone", CountryNameCode = "SL",   PhoneCode = "" },
                      new Country() { CountryName ="Singapore", CountryNameCode = "SG",   PhoneCode = "" },
                      new Country() { CountryName ="Slovakia", CountryNameCode = "SK",   PhoneCode = "" },
                      new Country() { CountryName ="Slovenia", CountryNameCode = "SI",   PhoneCode = "" },
                      new Country() { CountryName ="Solomon Islands", CountryNameCode = "SB",   PhoneCode = "" },
                      new Country() { CountryName ="Somalia", CountryNameCode = "SO",   PhoneCode = "" },
                      new Country() { CountryName ="South Africa", CountryNameCode = "ZA",   PhoneCode = "" },
                      new Country() { CountryName ="South Georgia and the South Sandwich Islands", CountryNameCode = "GS",   PhoneCode = "" },
                      new Country() { CountryName ="South Korea ", CountryNameCode = "KR",   PhoneCode = "" },
                      new Country() { CountryName ="Spain", CountryNameCode = "ES",   PhoneCode = "" },
                      new Country() { CountryName ="Sri Lanka", CountryNameCode = "LK",   PhoneCode = "" },
                      new Country() { CountryName ="Sudan", CountryNameCode = "SD",   PhoneCode = "" },
                      new Country() { CountryName ="Suriname", CountryNameCode = "SR",   PhoneCode = "" },
                      new Country() { CountryName ="Svalbard and Jan Mayen", CountryNameCode = "SJ",   PhoneCode = "" },
                      new Country() { CountryName ="Swaziland", CountryNameCode = "SZ",   PhoneCode = "" },
                      new Country() { CountryName ="Sweden", CountryNameCode = "SE",   PhoneCode = "" },
                      new Country() { CountryName ="Switzerland", CountryNameCode = "CH",   PhoneCode = "" },
                      new Country() { CountryName ="Syrian Arab Republic", CountryNameCode = "SY",   PhoneCode = "" },
                      new Country() { CountryName ="Taiwan, Province of China", CountryNameCode = "TW",   PhoneCode = "" },
                      new Country() { CountryName ="Tajikistan", CountryNameCode = "TJ",   PhoneCode = "" },
                      new Country() { CountryName ="Tanzania, United Republic of", CountryNameCode = "TZ",   PhoneCode = "" },
                      new Country() { CountryName ="Thailand", CountryNameCode = "TH",   PhoneCode = "" },
                      new Country() { CountryName ="Timor-Leste", CountryNameCode = "TL",   PhoneCode = "" },
                      new Country() { CountryName ="Togo", CountryNameCode = "TG",   PhoneCode = "" },
                      new Country() { CountryName ="Tokelau", CountryNameCode = "TK",   PhoneCode = "" },
                      new Country() { CountryName ="Tonga", CountryNameCode = "TO",   PhoneCode = "" },
                      new Country() { CountryName ="Trinidad and Tobago", CountryNameCode = "TT",   PhoneCode = "" },
                      new Country() { CountryName ="Tunisia", CountryNameCode = "TN",   PhoneCode = "" },
                      new Country() { CountryName ="Turkey", CountryNameCode = "TR",   PhoneCode = "" },
                      new Country() { CountryName ="Turkmenistan", CountryNameCode = "TM",   PhoneCode = "" },
                      new Country() { CountryName ="Turks and Caicos Islands", CountryNameCode = "TC",   PhoneCode = "" },
                      new Country() { CountryName ="Tuvalu", CountryNameCode = "TV",   PhoneCode = "" },
                      new Country() { CountryName ="Uganda", CountryNameCode = "UG",   PhoneCode = "" },
                      new Country() { CountryName ="Ukraine", CountryNameCode = "UA",   PhoneCode = "" },
                      new Country() { CountryName ="United Arab Emirates", CountryNameCode = "AE",   PhoneCode = "" },
                      new Country() { CountryName ="United Kingdom", CountryNameCode = "GB",   PhoneCode = "" },
                      new Country() { CountryName ="United States", CountryNameCode = "US",   PhoneCode = "" },
                      new Country() { CountryName ="United States Minor Outlying Islands", CountryNameCode = "UM",   PhoneCode = "" },
                      new Country() { CountryName ="Uruguay", CountryNameCode = "UY",   PhoneCode = "" },
                      new Country() { CountryName ="Uzbekistan", CountryNameCode = "UZ",   PhoneCode = "" },
                      new Country() { CountryName ="Vanuatu", CountryNameCode = "VU",   PhoneCode = "" },
                      new Country() { CountryName ="Venezuela", CountryNameCode = "VE",   PhoneCode = "" },
                      new Country() { CountryName ="Viet Nam", CountryNameCode = "VN",   PhoneCode = "" },
                      new Country() { CountryName ="Virgin Islands, British", CountryNameCode = "VG",   PhoneCode = "" },
                      new Country() { CountryName ="Virgin Islands, U.S.", CountryNameCode = "VI",   PhoneCode = "" },
                      new Country() { CountryName ="Wallis and Futuna", CountryNameCode = "WF",   PhoneCode = "" },
                      new Country() { CountryName ="Western Sahara", CountryNameCode = "EH",   PhoneCode = "" },
                      new Country() { CountryName ="Yemen", CountryNameCode = "YE",   PhoneCode = "" },
                      new Country() { CountryName ="Zambia", CountryNameCode = "ZM",   PhoneCode = "" },
                      new Country() { CountryName ="Zimbabwe", CountryNameCode = "ZW",   PhoneCode = "" }
                };
                await OwnersUnitOfWork.Countries.AddRangeAsync(countries);
            }
        }
    }
}
