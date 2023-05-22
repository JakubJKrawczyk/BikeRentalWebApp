using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BikeRentalWebApp.Areas.Users.Models
{
    [PrimaryKey(nameof(Id))]
    public class User : IdentityUser<string>
    {
        public User(): base()
        {
            
        }

        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime CreatedAt { get; set; }
    }
}
