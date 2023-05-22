using BikeRentalWebApp.Database.Repos.Entities;
using System.ComponentModel.DataAnnotations;

namespace BikeRentalWebApp.Models;

public class VechicleDetailViewModel
{

    public VechicleDetailViewModel()
    {

    }
    public VechicleDetailViewModel(Guid id, string brand, string model, VechicleType type, decimal price, string image, string description)
    {
        Id = id;
        Brand = brand;
        Model = model;
        Type = type;
        Price = price;
        Image = image;
        Description = description;
    }

    public Guid Id { get; private set; }

    [Display(Name = "Marka")]
    public string Brand { get; private set; }

    [Display(Name = "Model")]
    public string Model { get; private set; }

    [Display(Name = "Typ Roweru")]
    public VechicleType Type { get; private set; }

    [Display(Name = "Cena")]
    public decimal Price { get; private set; }

    [Display(Name = "Opis")]
    public string Description { get; private set; }

    [Display(Name = "Zdjêcie")]
    public string Image { get; private set; }
}