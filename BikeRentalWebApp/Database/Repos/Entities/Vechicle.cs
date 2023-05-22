using Microsoft.EntityFrameworkCore;

namespace BikeRentalWebApp.Database.Repos.Entities
{
    [PrimaryKey(nameof(Id))]

    public class Vechicle
    {

        public Vechicle()
        {

        }

        public Vechicle(Guid id, string brand, string model, VechicleType type, decimal price, string description, string image)
        {
            Id = id;
            Brand = brand;
            Model = model;
            Type = type;
            Price = price;
            Description = description;
            Image = image;
        }

        public Vechicle(string brand, string model, VechicleType type, decimal price, string description, string image)
        {
            Brand = brand;
            Model = model;
            Type = type;
            Price = price;
            Description = description;
            Image = image;
        }

        public Guid Id { get; private set; }

        public string Brand { get; private set; }

        public string Model { get; private set; }

        public VechicleType Type { get; private set; }

        public decimal Price { get; private set; }

        public string Description { get; private set; }

        public string Image { get; private set; }


    }
}
