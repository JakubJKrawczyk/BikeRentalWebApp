using BikeRentalWebApp.Database.Repos.Entities;
using FluentValidation;

namespace BikeRentalWebApp.Database.Validatior
{
    public class RentalPointValidator : AbstractValidator<RentalPoint>
    {

        public RentalPointValidator()
        {
            RuleFor(x => x.Miasto).NotEmpty().Length(1, 100).WithMessage("Podaj Miasto");
            RuleFor(x => x.Numer).NotEmpty().WithMessage("Podaj Numer").GreaterThan(0).WithMessage("Numer nie może być równy lub mniejszy 0");
            RuleFor(x => x.Ulica).NotEmpty().Length(1, 100).WithMessage("Podaj Ulicę");
        }

    }
}
