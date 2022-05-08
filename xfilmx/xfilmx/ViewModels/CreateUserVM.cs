using System.ComponentModel.DataAnnotations;
using xfilmx.Extensions;

namespace xfilmx.ViewModels
{
    public class CreateUserVM
    {
        [Required(ErrorMessage = "username is required")]
        [RegularExpression(@"^[A-Za-z]{8,50}$", ErrorMessage ="Username must contain at least 8 letters")]
        public string Username { get; set; }

        [Required(ErrorMessage = "password is required")]
        [MinLength(8, ErrorMessage = "password must contain at least 8 characters")]
        public string Password { get; set; }

        [Required(ErrorMessage = "confirm password is required")]
        public string ConfirmPassword { get; set; }

    }
}
