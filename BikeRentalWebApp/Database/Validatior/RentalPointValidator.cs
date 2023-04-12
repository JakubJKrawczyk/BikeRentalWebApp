using BikeRentalWebApp.Database.Repos.Entities;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace BikeRentalWebApp.Database.Validatior
{
    public class RentalPointValidator : AbstractValidator<RentalPoint>
    {

        public RentalPointValidator()
        {
            RuleFor(x => x.Miasto).NotEmpty().Length(1,100).WithMessage("Podaj Miasto");
            RuleFor(x => x.Numer).NotEmpty().GreaterThan(0).WithMessage("Podaj Numer") ;
            RuleFor(x => x.Ulica).NotEmpty().Length(1,100).WithMessage("Podaj Ulicę") ;
        }

    }
}
