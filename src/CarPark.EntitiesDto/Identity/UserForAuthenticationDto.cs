using System.ComponentModel.DataAnnotations;

namespace CarPark.EntitiesDto.Identity
{
    public class UserForAuthenticationDto
    {
        [Required(ErrorMessage = "Email name is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password name is required")]
        public string Password { get; set; }
    }
}
