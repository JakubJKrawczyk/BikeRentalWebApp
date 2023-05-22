
using BikeRentalWebApp.Areas.Roles.Models;
using BikeRentalWebApp.Areas.Users.Models;
using BikeRentalWebApp.Controllers;
using BikeRentalWebApp.Database;
using BikeRentalWebApp.Database.Repos.Entities;
using BikeRentalWebApp.Services;
using BikeRentalWebApp.tools;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

//Context
builder.Services.AddDbContext<AppDBContext>();
builder.Services.AddTransient<IEmailSender, EmailSender>();
builder.Services.AddDefaultIdentity<User>(//options => options.SignIn.RequireConfirmedAccount = true
                                                  )
                                                  .AddDefaultTokenProviders()
                                                  .AddRoles<Role>()
                                                  .AddEntityFrameworkStores<AppDBContext>();


// Add services to the container.
builder.Services.AddControllersWithViews(
    options =>
    {
        options.EnableEndpointRouting = false;
    }
    );
builder.Services.AddRazorPages();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();



builder.Services.Configure<IdentityOptions>(options =>
{
    // Password settings.
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;

    // Lockout settings.
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;

    // User settings.
    options.User.AllowedUserNameCharacters =
    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    options.User.RequireUniqueEmail = false;
});


builder.Services.ConfigureApplicationCookie(options =>
{
    // Cookie settings

    options.LoginPath = "/Login";
    options.AccessDeniedPath = "/AccessDenied";
});

var app = builder.Build();



using (var Scope = app.Services.CreateScope())
{
    AppDBContext? context = Scope.ServiceProvider.GetService<AppDBContext>();
    List<Vechicle> items = new()
                {
                    new Vechicle("BMX", "V12", VechicleType.Rower, 1990, "Opis Jest nie wa�ny", "https://portal.bikeworld.pl/multimedia/foto/medium/DSC01530_@piotrjurczak_3f4da.eu_3f4da.jpg"),
                     new Vechicle("BMX", "V13", VechicleType.Rower, 2990, "Opis Jest nie wa�ny x2", "https://portal.bikeworld.pl/multimedia/foto/medium/DSC01530_@piotrjurczak_3f4da.eu_3f4da.jpg"),


                };



    context?.Vechicles.AddRange(items);
    context?.SaveChanges();


    //var Items = new List<RentalModel>()
    //                {
    //                    new RentalModel(new Guid(), context.Vechicles.First(),DateTime.Now, DateTime.Now.AddDays(10), context.RentalPoints.First())

    //                };
    //context.RentalModels.AddRange(Items);
    //context.SaveChanges();

}

//Utworzenie użytkowników i ról
using (var serviceScope = app.Services.CreateScope())
{

    UserManager<User>? _um = serviceScope.ServiceProvider.GetService<UserManager<User>>();
    RoleManager<Role>? _rm = serviceScope.ServiceProvider.GetService<RoleManager<Role>>();
    if( _um != null && _rm != null)
    {
        try
        {
            var adminRole = new Role
            {
                Name = "Administrator"
               
            };
            var operRole = new Role
            {
                Name = "Operator"
                
            };
            _rm.CreateAsync(adminRole).Wait();
            _rm.CreateAsync(operRole).Wait();


        }
        catch (Exception ex) { throw new Exception(ex.Message); }
        
        var admin = new User
        {
            UserName = "admin@rentvech.pl",
            Email = "admin@rentvech.pl",
            Id = Guid.NewGuid().ToString(),
            CreatedAt = DateTime.Now,
            SecurityStamp = DateTime.Now.ToString()
        };
        var result = _um.CreateAsync(admin, "admin123");
        Debug.WriteLine(result);
        _um.AddToRoleAsync(admin, "Administrator").Wait();
        var oper = new User
        {
            UserName = "operator@rentvech.pl",
            Email = "operator@rentvech.pl",
            Id = Guid.NewGuid().ToString(),
            CreatedAt = DateTime.Now,
            SecurityStamp = DateTime.Now.ToString()
        };
        _um.CreateAsync(oper, "operator123").Wait();
        _um.AddToRoleAsync(oper, "Operator").Wait();

        var user = new User
        {
            UserName = "user@retvech.pl",
            Email = "user@rentvech.pl",
            Id = Guid.NewGuid().ToString(),
            CreatedAt = DateTime.Now,
            SecurityStamp = DateTime.Now.ToString()
        };
        _um.CreateAsync(user, "user123").Wait();
        var Users = _um.Users.ToList();

        //if (admin == null || oper == null) throw new Exception("Jeden z podanych użytkowników nie istnieje");


    }
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
    name: "MyArea",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");




app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "AccessDenied",
      pattern: "AccessDenied",
      defaults: new { controller = "Account" }

    );
});
app.MapAreaControllerRoute(
                name: "Admin",
                areaName: "Admin",
                pattern: "Admin/{action=Dashboard}/{id?}",
                defaults: new { controller = "Admin" });

app.MapAreaControllerRoute(
                name: "Roles",
                areaName: "Roles",
                pattern: "Roles/{action=List}/{id?}",
                defaults: new { controller = "Role" });

app.MapAreaControllerRoute(
                name: "Users",
                areaName: "Users",
                pattern: "Users/{action=List}/{id?}",
                defaults: new { controller = "User" });

app.MapRazorPages();




app.Run();
