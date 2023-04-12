using BikeRentalWebApp.Database.Repos.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using BikeRentalWebApp.Models;

namespace BikeRentalWebApp.Database
{
    public class AppDBContext: DbContext
    {

        public DbSet<RentalModel> RentalModels { get; set; }
        public DbSet<RentalPoint> RentalPoints { get; set; }
        public DbSet<Vechicle> Vechicles { get; set; }


        public AppDBContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("VechicleRental");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
        public DbSet<BikeRentalWebApp.Models.RentalPointViewModel>? RentalPointViewModel { get; set; }
        public DbSet<BikeRentalWebApp.Models.VechicleViewModel>? VechicleViewModel { get; set; }
        public DbSet<BikeRentalWebApp.Models.VechicleDetailViewModel>? VechicleDetailViewModel { get; set; }
    }
}
