namespace BikeRentalWebApp.Database.Repos.Entities
{
    public class RentalModel
    {
        public RentalModel()
        {

        }
        public RentalModel(Guid id, Vechicle vechicle, DateTime dateFrom, DateTime dateTo, RentalPoint rentalPoint)
        {
            Id = id;
            Vechicle = vechicle;
            DateFrom = dateFrom;
            DateTo = dateTo;
            RentalPoint = rentalPoint;
        }

        public Guid Id { get; private set; }


        public virtual Vechicle Vechicle { get; private set; }
        public DateTime DateFrom { get; private set; }
        public DateTime DateTo { get; private set; }

        public virtual RentalPoint RentalPoint { get; private set; }

    }
}
