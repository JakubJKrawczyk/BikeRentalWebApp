using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = Microsoft.Build.Framework.RequiredAttribute;

namespace BikeRentalWebApp.Database.Repos.Entities
{
    [PrimaryKey(nameof(Id))]

    public class RentalPoint
    {
        public RentalPoint()
        {

        }
        public RentalPoint(Guid id, string miasto, string ulica, int numer)
        {
            Id = id;
            Miasto = miasto;
            Ulica = ulica;
            Numer = numer;
        }
        public RentalPoint(string miasto, string ulica, int numer)
        {
            Miasto = miasto;
            Ulica = ulica;
            Numer = numer;
        }

        public Guid Id { get; private set; }
        [Required]
        [StringLength(100)]
        public string Miasto { get; private set; }
        [Required]
        [StringLength(100)]
        public string Ulica { get; private set; }
        [Required]
        [Range(1, 1000)]
        public int Numer { get; private set; }

    }
}
