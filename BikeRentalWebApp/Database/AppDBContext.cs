
using BikeRentalWebApp.Areas.Users.Models;
using BikeRentalWebApp.Database.Repos.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BikeRentalWebApp.Areas.Roles.Models;

namespace BikeRentalWebApp.Database
{
    public class AppDBContext : IdentityDbContext<User, IdentityRole, string>
    {

        public DbSet<RentalModel> RentalModels { get; set; }
        public DbSet<RentalPoint> RentalPoints { get; set; }
        public DbSet<Vechicle> Vechicles { get; set; }

        public DbSet<IdentityRole> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {


        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("VechicleRental");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Ignore<IdentityUser<string>>();

        }
        public DbSet<BikeRentalWebApp.Areas.Roles.Models.Role> Role { get; set; } = default!;
    }
}
