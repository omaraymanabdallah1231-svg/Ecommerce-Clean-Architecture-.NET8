using Microsoft.EntityFrameworkCore;
using ecomerce.domain.entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ecomerce.domain.entity.identity;
using Microsoft.AspNetCore.Identity;
using ecomerce.domain.entity.cart;
using ecomerce.infrsutractor.repostry.cart;

namespace ecomerce.infrsutractor.Data
{
 public  class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Proudct> proudcts { get; set; }
        public DbSet<Catogry> catogries { get; set; }
        public DbSet<RefreshToken> refreshTokens { get; set; }
        public DbSet<payment> payment { get; set; }
        public DbSet<Achive> checkoutachives { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<payment>().HasData(new payment { 
          Id  = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                
                Name="credit cread"

            });
            

            builder.Entity<IdentityRole>()
    .HasData(
    new IdentityRole
    {
        Id = "1", // ✅ ثابت
        Name = "Admin",
        NormalizedName = "ADMIN"
    },
    new IdentityRole
    {
        Id = "2", // ✅ ثابت
        Name = "User",
        NormalizedName = "USER"
    });
        }

    }
}
 