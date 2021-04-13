using System;
using ASpecialDay.Areas.Identity.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(ASpecialDay.Areas.Identity.IdentityHostingStartup))]
namespace ASpecialDay.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            //builder.ConfigureServices((context, services) => {
            //    services.AddDbContext<ASpecialDayContext>(options =>
            //        options.UseSqlServer(
            //            context.Configuration.GetConnectionString("ASpecialDayContextConnection")));

            //    services.AddDefaultIdentity<Bride>(options => options.SignIn.RequireConfirmedAccount = true)
            //        .AddEntityFrameworkStores<ASpecialDayContext>();
            //});
        }
    }
}