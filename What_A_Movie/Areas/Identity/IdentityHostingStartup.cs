using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using What_A_Movie.Models;

[assembly: HostingStartup(typeof(What_A_Movie.Areas.Identity.IdentityHostingStartup))]
namespace What_A_Movie.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            
            builder.ConfigureServices((context, services) => {
                
                services.AddDefaultIdentity<ApplicationUser>()
                .AddRoles<IdentityRole>()  
                .AddEntityFrameworkStores<AppDbContext>();
                
               
            });
        }
    }
}