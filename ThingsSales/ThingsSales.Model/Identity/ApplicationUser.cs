using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ThingsSales.Model.Identity
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string? City { get; set; }
    }
}
