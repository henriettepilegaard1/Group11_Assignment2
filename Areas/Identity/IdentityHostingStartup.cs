using System;
using Assignment2.Data;
using Assignment2.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Assignment2.Areas.Identity.IdentityHostingStartup))]
namespace Assignment2.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<Assignment2Context>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("Assignment2ContextConnection")));

                services.AddDefaultIdentity<Staff>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<Assignment2Context>();
            });
        }
    }
}