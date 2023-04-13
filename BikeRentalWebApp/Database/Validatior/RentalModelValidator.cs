using BikeRentalWebApp.Database.Repos.Entities;
using FluentValidation;

namespace BikeRentalWebApp.Database.Validatior
{
    public class RentalModelValidator : AbstractValidator<RentalModel>
    {

        RentalModel rent = new();
        public RentalModelValidator()
        {
            //TODO: Dodać walidację danych i daty
            RuleFor(x => x.RentalPoint).NotEmpty().WithMessage("Punkt, z którego wypożyczasz pojazd nie może być pusty");
            RuleFor(x => x.Vechicle).NotEmpty().WithMessage("Pojazd, który wypożyczasz nie może być pusty.");

            RuleFor(x => x.DateFrom).NotEmpty().WithMessage("Data rezerwacji nie może byc pusta").Must((rentalModel, DateFrom) => 
            DateFrom < rentalModel.DateTo).WithMessage("Data rozpoczęcia rezerwacji nie może być później niż data zakończenia rezerwacji");
                
            

        }
    }
}
