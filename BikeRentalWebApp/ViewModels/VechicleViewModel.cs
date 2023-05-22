using BikeRentalWebApp.Database.Repos.Entities;
using System.ComponentModel.DataAnnotations;

namespace BikeRentalWebApp.Models;

public class VechicleViewModel
{
    public VechicleViewModel()
    {

    }
    public VechicleViewModel(Vechicle vechicle)
    {
        Id = vechicle.Id;
        Brand = vechicle.Brand;
        Model = vechicle.Model;
        Type = vechicle.Type;
        Price = vechicle.Price;
        Image = vechicle.Image;
    }

    public Guid? Id { get; set; }

    [Display(Name = "Marka")]
    public string Brand { get; set; }

    [Display(Name = "Model")]
    public string Model { get; set; }

    [Display(Name = "Typ Roweru")]
    public VechicleType Type { get; set; }

    [Display(Name = "Cena")]
    public decimal Price { get; set; }
    [Display(Name = "Zdjêcie")]
    public string Image { get; set; }



}