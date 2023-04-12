using BikeRentalWebApp.Database.Repos.Entities;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using System.Drawing;

namespace BikeRentalWebApp.Database.Repos
{
    public class VechiclesRepository
    {

        public VechiclesRepository()
        {
           


        }

        public List<Vechicle> GetAll()
        {
            using (AppDBContext context = new())
            {
                var list = context.Vechicles.ToList();
                return list;
            }
        }

        public void Add(Vechicle vechicle)
        {
            using(var context = new AppDBContext())
            {
                context.Vechicles.Add(vechicle);
                context.SaveChanges();
            }
            
        }

        public void Delete(Vechicle vechicle)
        {
            using (var context = new AppDBContext())
            {
                try
                {
                    context.Vechicles.Remove(vechicle);
                    context.SaveChanges();

                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }

        }

        public void Edit(Vechicle vechicleNew)
        {
            using (var context = new AppDBContext())
            {
               
                    Vechicle vech = FindById(vechicleNew.Id);

                    context.Vechicles.Remove(vech);
                    Vechicle newVech = new(vech.Id, vechicleNew.Brand, vechicleNew.Model, vechicleNew.Type, vechicleNew.Price,vechicleNew.Description, vechicleNew.Image);
                    context.SaveChanges();
                    context.Vechicles.Add(newVech);
                    context.SaveChanges();
            }

        }

        public Vechicle FindById(Guid id)
        {
            using(var context = new AppDBContext())
            {
                if (id == Guid.Empty) return new();
                var vechicle = context.Vechicles.FirstOrDefault(x => x.Id == id);
                if(vechicle is not null)
                {
                    return vechicle;
                }
                else
                {
                    throw new Exception("Obiekt nie istnieje w bazie danych");
                }
                
            }
        }
    }
}
