using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Videoteka.Data;

[assembly: HostingStartup(typeof(Videoteka.Areas.Identity.IdentityHostingStartup))]
namespace Videoteka.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<VideotekaContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("VideotekaContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<VideotekaContext>();
            });
        }
    }
}