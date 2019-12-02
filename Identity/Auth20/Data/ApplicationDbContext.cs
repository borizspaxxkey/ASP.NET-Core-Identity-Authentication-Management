using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Auth20.Models;
using Microsoft.AspNetCore.Identity;

namespace Auth20.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityUser>(n =>
            {
                //primary key
                n.HasKey(p => p.Id);

                //column configuration
                n.Property(p => p.UserName).HasMaxLength(256);

                //each user can have many userclaims
                n.HasMany<IdentityUserClaim<string>>().WithOne().HasForeignKey(fk => fk.UserId).IsRequired();
            });

            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
