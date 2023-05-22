using BikeRentalWebApp.Database.Repos.Entities;
using Microsoft.EntityFrameworkCore;

namespace BikeRentalWebApp.Database.Repos
{
    public class RentalPointsRepository
    {

        public RentalPointsRepository()
        {

        }

        public List<RentalPoint> GetAll()
        {
            using (AppDBContext context = new(new DbContextOptions<AppDBContext>()))
            {
                var list = context.RentalPoints.ToList();
                return list;
            }
        }
        public void Add(RentalPoint rentalPoint)
        {
            using (var context = new AppDBContext(new DbContextOptions<AppDBContext>()))
            {
                context.RentalPoints.Add(rentalPoint);
                context.SaveChanges();
            }

        }

        public void Delete(RentalPoint rentalPoint)
        {
            using (var context = new AppDBContext(new DbContextOptions<AppDBContext>()))
            {
                try
                {
                    context.RentalPoints.Remove(rentalPoint);
                    context.SaveChanges();

                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }

        }

        public void Edit(Guid id, string Miasto, string Ulica, string Numer)
        {
            using (var context = new AppDBContext(new DbContextOptions<AppDBContext>()))
            {
                RentalPoint point = FindById(id);

                if (!int.TryParse(Numer, out var num)) throw new Exception("Zły format danych");
                context.RentalPoints.Remove(point);
                RentalPoint rental = new(id, Miasto, Ulica, num);
                context.SaveChanges();
                context.RentalPoints.Add(rental);
                context.SaveChanges();
            }

        }

        public RentalPoint FindById(Guid id)
        {
            using (var context = new AppDBContext(new DbContextOptions<AppDBContext>()))
            {

                var rental = context.RentalPoints.FirstOrDefault(x => x.Id == id);
                if (rental is not null)
                {
                    return rental;
                }
                else
                {
                    throw new Exception("Obiekt nie istnieje w bazie danych");
                }

            }
        }


    }
}
