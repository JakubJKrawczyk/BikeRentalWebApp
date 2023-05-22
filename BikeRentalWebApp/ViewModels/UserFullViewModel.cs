using BikeRentalWebApp.Areas.Users.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BikeRentalWebApp.ViewModels
{
    [PrimaryKey(nameof(Id))]

    public class UserFullViewModel
    {
        public string Id { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Data Utworzenia")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime CreatedAt { get; set; }

        public List<string> Roles { get; set; }
        public UserFullViewModel()
        {
               
        }
       

        public UserFullViewModel(User user)
        {
            Id = user.Id;
            Email = user.Email;
            CreatedAt = user.CreatedAt;
        }

    }
}
