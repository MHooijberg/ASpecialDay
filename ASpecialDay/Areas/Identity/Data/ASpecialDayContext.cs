using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASpecialDay.Areas.Identity.Data;
using ASpecialDay.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ASpecialDay.Areas.Identity.Data
{
    public class ASpecialDayContext : IdentityDbContext<Bride>
    {
        public DbSet<Bride> Brides { get; set; }
        public DbSet<GiftList> GiftLists { get; set; }
        public DbSet<Gift> Gifts { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Wedding> Weddings { get; set; }
        public DbSet<BoughtBy> Boughts { get; set; }
        public ASpecialDayContext(DbContextOptions<ASpecialDayContext> options)
                : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<Gift>()
                .HasKey(g => new { g.InviteCode, g.Position });
        }
    }
}
