using AutoMapper;
using BikeRentalWebApp;
using BikeRentalWebApp.Database;
using BikeRentalWebApp.Database.Repos.Entities;

var builder = WebApplication.CreateBuilder(args);


//Context
builder.Services.AddDbContext<AppDBContext>();
// Add services to the container.
builder.Services.AddControllersWithViews();
var app = builder.Build();



using (AppDBContext context = new())
{
    
        List<Vechicle> items = new()
                {
                    new Vechicle("BMX", "V12", VechicleType.Rower, 1990, "Opis Jest nie wa¿ny", "https://portal.bikeworld.pl/multimedia/foto/medium/DSC01530_@piotrjurczak_3f4da.eu_3f4da.jpg"),
                     new Vechicle("BMX", "V13", VechicleType.Rower, 2990, "Opis Jest nie wa¿ny x2", "https://portal.bikeworld.pl/multimedia/foto/medium/DSC01530_@piotrjurczak_3f4da.eu_3f4da.jpg"),


                };



        context.Vechicles.AddRange(items);
        context.SaveChanges();


    //var Items = new List<RentalModel>()
    //                {
    //                    new RentalModel(new Guid(), context.Vechicles.First(),DateTime.Now, DateTime.Now.AddDays(10), context.RentalPoints.First())

    //                };
    //context.RentalModels.AddRange(Items);
    //context.SaveChanges();

}




// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");






app.Run();