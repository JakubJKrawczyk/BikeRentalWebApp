using BikeRentalWebApp.Database.Repos.Entities;
using Microsoft.EntityFrameworkCore;

namespace BikeRentalWebApp.Database.Repos
{
    public class RentalModelsRepository
    {

        public RentalModelsRepository()
        {

        }

        public List<RentalModel> GetAll()
        {
            using (AppDBContext context = new(new DbContextOptions<AppDBContext>()))
            {
                var list = context.RentalModels.ToList();
                return list;
            }
        }
        public void Add(Guid gui, Vechicle vechicle, DateTime to, RentalPoint point)
        {
            using (var context = new AppDBContext(new DbContextOptions<AppDBContext>()))
            {
                var newRentalModel = new RentalModel(gui, vechicle, DateTime.Now, to, point);
                context.RentalModels.Add(newRentalModel);
                context.SaveChanges();
            }

        }

        public void Delete(RentalModel rentalModel)
        {
            using (var context = new AppDBContext(new DbContextOptions<AppDBContext>()))
            {
                context.RentalModels.Remove(rentalModel);
                context.SaveChanges();
            }

        }

        public void Edit(RentalModel rentalnew)
        {
            using (var context = new AppDBContext(new DbContextOptions<AppDBContext>()))
            {
                var RentalToEdit = context.RentalModels.FirstOrDefault(x => x.Id == rentalnew.Id);
                if (RentalToEdit != null)
                {

                    RentalModel RentalModel = new(RentalToEdit.Id, rentalnew.Vechicle, rentalnew.DateFrom, rentalnew.DateTo, rentalnew.RentalPoint);
                    context.RentalModels.Remove(RentalToEdit);
                    context.RentalModels.Add(RentalModel);
                }


                context.SaveChanges();
            }

        }

        public RentalModel FindById(Guid id)
        {
            using (var context = new AppDBContext(new DbContextOptions<AppDBContext>()))
            {

                var rental = context.RentalModels.FirstOrDefault(x => x.Id == id);
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
