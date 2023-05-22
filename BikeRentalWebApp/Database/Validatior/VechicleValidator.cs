using BikeRentalWebApp.Database.Repos.Entities;
using FluentValidation;

namespace BikeRentalWebApp.Database.Validatior
{
    public class VechicleValidator : AbstractValidator<Vechicle>
    {
        public VechicleValidator()
        {

            RuleFor(x => x.Model).NotEmpty().Length(1, 100).WithMessage("Model musi mieć do 1 do 100 znaków");
            RuleFor(x => x.Brand).NotEmpty().Length(1, 100).WithMessage("Marka musi mieć do 1 do 100 znaków");
            RuleFor(x => x.Price).NotEmpty().GreaterThan(0).WithMessage("Cena nie może być mniejsza niż 1");
            RuleFor(x => x.Description).NotEmpty().Length(0, 500).WithMessage("Opis może mieć maksymalnie 500 znaków");
            RuleFor(x => x.Image).NotEmpty().Length(0, 100).WithMessage("Opis może mieć maksymalnie 500 znaków");


        }
    }
}
