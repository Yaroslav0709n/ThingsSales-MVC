using System.ComponentModel.DataAnnotations;

namespace ThingsSales.Model.Auth
{
    public class Register
    {
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        public string? PhoneNumber { get; set; }

        public string? City { get; set; }
    }
}
