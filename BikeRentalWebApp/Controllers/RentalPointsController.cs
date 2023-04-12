using AutoMapper;
using BikeRentalWebApp.Database;
using BikeRentalWebApp.Database.Repos;
using BikeRentalWebApp.Database.Repos.Entities;
using BikeRentalWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BikeRentalWebApp.Controllers
{
    public class RentalPointsController : Controller
    {
        private Mapper mapper;
        public RentalPointsController()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<RentalPoint, RentalPointViewModel>());
            mapper = new Mapper(config);
        }

        RentalPointsRepository repo = new();
        // GET: RentalPointsController
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List()
        {

            List<RentalPointViewModel> list = new();

                foreach (RentalPoint point in repo.GetAll())
                {
                RentalPointViewModel view = new();
                mapper.Map(point, view);
                    list.Add(view);
                }
            return View(list);
        }
        // GET: RentalPointsController/Details/5
        public ActionResult Details(Guid id)
        {
            var details = repo.FindById(id);
            RentalPointViewModel detailsView = new();
            if (details != null) {

                mapper.Map(details, detailsView);
                return View(detailsView);

                }
                else
                {
                    return Redirect(nameof(List));
                }
            
        }
        // GET: RentalPointsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RentalPointsController/Create
        [HttpPost]
        public ActionResult Create(string Miasto, string Ulica, string Numer)
        {
            try
            {
                //TODO: Popraw validacje danych
                int.TryParse(Numer, out var num);

                RentalPoint rental = new(Miasto, Ulica, num);
                if (!ModelState.IsValid)
                {
                    return RedirectToAction(nameof(List));
                }
                repo.Add(rental);
                return RedirectToAction(nameof(List));
            }
            catch
            {
                return Redirect(nameof(List));
            }
        }

        // GET: RentalPointsController/Edit/5
        public ActionResult Edit(Guid id)
        {

            var toEdit = repo.FindById(id);
            RentalPointViewModel view = new();
                if(toEdit is not null)
                {
                mapper.Map(toEdit, view);
                return View(view);

                }
                else
                {
                    return Redirect(nameof(List));
                }
        }

        // POST: RentalPointsController/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, string Miasto, string Ulica, string Numer)
        {
            try
            {
                   

                repo.Edit(id,Miasto,Ulica,Numer);

                return RedirectToAction(nameof(List));
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
                
            }
        }

        // GET: RentalPointsController/Delete/5
        [HttpGet]
        public ActionResult Delete(Guid id)
        {
                var toDelete = repo.FindById(id) ;
                if( toDelete is not null)
                {
                RentalPointViewModel view = new();
                mapper.Map(toDelete, view);
                return View(view);

                }
                else
                {
                    return Redirect(nameof(List));
                }
        }

        // POST: RentalPointsController/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id, RentalPoint rental)
        {
            try
            {
                repo.Delete(repo.FindById(id)) ;
                return RedirectToAction(nameof(List));
            }
            catch
            {
                return View();
            }
        }

       
    }
}
