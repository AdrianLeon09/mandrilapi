using MandrilAPI.Infrastructure.Authentication.AuthModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace MandrilAPI.Infrastructure.Authentication.AuthDatabaseContext
{
    public class AuthDbContext(DbContextOptions<AuthDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole {Id = "1", Name = "Admin", NormalizedName = "Admin"},
                new IdentityRole{Id = "2", Name = "User", NormalizedName = "User",}
                );

        }
    }
}
