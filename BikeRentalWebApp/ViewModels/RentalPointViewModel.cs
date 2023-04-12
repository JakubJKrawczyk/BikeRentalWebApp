using System.ComponentModel.DataAnnotations;

namespace BikeRentalWebApp.Models
{
    public class RentalPointViewModel
    {

        public RentalPointViewModel()
        {
                
        }

        public RentalPointViewModel(Guid id, string miasto, string ulica, string numer)
        {
            Id = id;
            Miasto = miasto;
            Ulica = ulica;
            Numer = numer;
        }

        public Guid Id { get; private set; }
        public string Miasto { get; private set; }
        public string Ulica { get; private set; }
        public string Numer { get; private set; }

    }
}
