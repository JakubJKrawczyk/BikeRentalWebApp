using AutoMapper;
using BikeRentalWebApp.Database.Repos;
using BikeRentalWebApp.Database.Repos.Entities;
using BikeRentalWebApp.Database.Validatior;
using BikeRentalWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BikeRentalWebApp.Controllers;

public class VechiclesController : Controller
{

    VechiclesRepository repo = new VechiclesRepository();

    private Mapper mapper;
    private Mapper mapperDetails;
    private VechicleValidator validator;
    public VechiclesController()
    {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<Vechicle, VechicleViewModel>());
        var configDetails = new MapperConfiguration(cfg => cfg.CreateMap<Vechicle, VechicleDetailViewModel>());

        mapper = new Mapper(config);
        mapperDetails = new Mapper(configDetails);
        validator = new();
    }
    // GET
    public IActionResult List()
    {
        List<VechicleViewModel> list = new List<VechicleViewModel>();

        foreach (var vechicle in repo.GetAll())
        {
            VechicleViewModel view = new();
            mapper.Map(vechicle, view);
            list.Add(view);
        }
        Warning.warningMessage = "";
        return View(list);


    }

    public IActionResult Edit(Guid id)
    {
        var bike = repo.FindById(id);


        if (bike == null) return RedirectToAction("List");
        VechicleDetailViewModel view = new();
        mapperDetails.Map(bike, view);

        return View(view);
    }



    public IActionResult Details(Guid id)
    {
        var bike = repo.FindById(id);

        if (bike is null) return RedirectToAction("List");
        VechicleDetailViewModel view = new();

        mapperDetails.Map(bike, view);


        return View(view);
    }
    public IActionResult Delete(Guid id)
    {
        var bike = repo.FindById(id);

        if (bike is null) return RedirectToAction("List");
        else
        {

            VechicleViewModel view = new();
            mapper.Map(bike, view);
            return View(view);

        }
    }
    [HttpGet]
    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Edit(Guid id, string brand, string model, VechicleType type, decimal price, string image, string description)
    {
        var bikeToEdit = new Vechicle(id, brand, model, type, price, description, image);
        if (bikeToEdit == null) return RedirectToAction("List");
        var result = validator.Validate(bikeToEdit);
        if (result.IsValid)
        {
            try
            {

                repo.Edit(bikeToEdit);
                Warning.warningMessage = "";






                return RedirectToAction("List");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
        else
        {
            Warning.warningMessage = result.Errors.FirstOrDefault().ErrorMessage;
            return RedirectToAction("Edit");
        }


    }

    [HttpPost]
    public ActionResult Delete(Guid id, Vechicle vech)
    {
        try
        {

            repo.Delete(repo.FindById(id));

            return RedirectToAction(nameof(List));
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }

    }


    [HttpPost]
    public ActionResult Create(string Brand, string Model, VechicleType Type, decimal Price, string Description, string Image)
    {
        Vechicle vech = new(Brand, Model, Type, Price, Description, Image);
        var result = validator.Validate(vech);
        if (result.IsValid)
        {
            try
            {
                repo.Add(vech);
                Warning.warningMessage = "";

                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }
        }
        else
        {
            Warning.warningMessage = result.Errors.FirstOrDefault().ErrorMessage;
            return Redirect(nameof(Create));
        }

    }
}