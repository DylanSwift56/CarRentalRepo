using System.ComponentModel.DataAnnotations;

namespace CarRental_BlazorApp.Models
{
    public class DisplayLoginModel
    {
        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
    }
}
