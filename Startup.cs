using ERP.Areas.Owners.Data;
using ERP.Areas.Owners.Models;
using ERP.Areas.Owners.Models.Identity;
using ERP.Data;
using ERP.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ERP.Data.Identity;
using ERP.Areas.Tenants.Data;
using ERP.Areas.Tenants.Services;
using Microsoft.AspNetCore.Http;
using ERP.Utilities.Services;

namespace ERP
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<TenantProvider>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<ITokenService, TokenService>();
            //services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer());
            services.AddEntityFrameworkSqlServer().AddDbContext<OwnersDbContext>(options =>
                    options.UseSqlServer());
            //Add Owner Identity DbContext
            services.AddDbContext<OwnersDbContext>(options =>
                options.UseSqlServer());
            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddTransient<IRoleStore<OwnerRole>, OwnerRoleStore>();
            services.AddTransient<UserManager<Owner>, OwnerUserManager>();
            services.AddTransient<SignInManager<Owner>, OwnerSignInManager>();
            services.AddTransient<RoleManager<OwnerRole>, OwnerRoleManager>();
            services.AddTransient<IUserStore<Owner>, OwnerUserStore>();
            services.AddIdentityCore<Owner>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<OwnersDbContext>()
                .AddRoles<OwnerRole>().AddRoleManager<OwnerRoleManager>()
                .AddRoleStore<OwnerRoleStore>().AddUserManager<OwnerUserManager>()
                .AddUserStore<OwnerUserStore>()
               .AddDefaultTokenProviders();
            
            services.AddScoped<OwnerRoleStore>();
            services.AddScoped<OwnerUserStore>();

            //Add App DB Context
            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
            //services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer());
            services.AddEntityFrameworkSqlServer().AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer());
            //services.AddScoped<IRoleStore<ApplicationUserRole>, ApplicationUserRoleStore>();
            //services.AddScoped<UserManager<ApplicationUser>, ApplicationUserManager>();
            //services.AddScoped<SignInManager<ApplicationUser>, ApplicationUserSignIngManager>();
            //services.AddScoped<RoleManager<ApplicationUserRole>, ApplicationUserRoleManager>();
            ////services.AddScoped<IUserStore<ApplicationUser>, ApplicationUserStore>();
            //services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddEntityFrameworkStores<ApplicationDbContext>()
            //    .AddRoles<ApplicationUserRole>().AddRoleManager<ApplicationUserRoleManager>()
            //    .AddRoleStore<ApplicationUserRoleStore>().AddUserManager<ApplicationUserManager>()
            //    .AddUserStore<ApplicationUserStore>()
            //   .AddDefaultTokenProviders();

            //services.AddScoped<ApplicationUserRoleStore>();
            //services.AddScoped<ApplicationUserStore>();
            //Add TenantDB
            services.AddDbContext<TenantsDbContext>(options =>
                    options.UseSqlServer()).AddEntityFrameworkSqlServer();

            //Configure JWT Tokens
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["TokenKey"])),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
            services.AddControllersWithViews();
            services.AddRazorPages();
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration => configuration.RootPath = "ClientApp/dist");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
          );
                endpoints.MapRazorPages();
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
