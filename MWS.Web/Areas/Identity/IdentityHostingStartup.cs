using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MWS.Web.Areas.Identity.Data;
using MWS.Web.Data;

[assembly: HostingStartup(typeof(MWS.Web.Areas.Identity.IdentityHostingStartup))]
namespace MWS.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<MWSWebContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("MWSWebContextConnection")));

                services.AddDefaultIdentity<ApplicationUser>(options => 
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequiredLength = 5;
                    options.Password.RequireDigit = false;
                })
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<MWSWebContext>();
            });
        }
    }
}