using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment2.Data;
using Assignment2.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Assignment2
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


            //? Taget fra eksemplet : https://docs.microsoft.com/en-us/aspnet/core/security/authentication/scaffold-identity?view=aspnetcore-3.1&tabs=visual-studio
            // Prøv at udfør eksemplet fuldt ud ...

            //! Fejler ved at den muligvis ikke kender noget, der har typen IdentityUser / Role
            //services.AddDefaultIdentity<Staff>()
            //services.AddIdentity<IdentityUser, IdentityRole>()
            //    .AddEntityFrameworkStores<ApplicationDbContext>()
            //    .AddDefaultTokenProviders();

            //            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
            //                .AddRazorPagesOptions(options =>
            //                {
            //                    options.AllowAreas = true;
            //                    options.Conventions.AuthorizeAreaFolder("Identity", "/Account/Manage");
            //                    options.Conventions.AuthorizeAreaPage("Identity", "/Account/Logout");
            //                });

            //services.ConfigureApplicationCookie(options =>
            //{
            //    options.LoginPath = $"/Identity/Account/Login";
            //    options.LogoutPath = $"/Identity/Account/Logout";
            //    options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
            //});

            // using Microsoft.AspNetCore.Identity.UI.Services;
            // services.AddSingleton<IEmailSender, EmailSender>();



            services.AddAuthorization(options =>
            {
                //TODO ændre roller til receptionist, etc...
                options.AddPolicy(
                    "IsAdmin",
                    policyBuilder => policyBuilder
                        .RequireRole(StaffRoles.Reception));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
