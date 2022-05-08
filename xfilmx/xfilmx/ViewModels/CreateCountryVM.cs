using System.ComponentModel.DataAnnotations;

namespace xfilmx.ViewModels
{
    public class CreateCountryVM
    {
        [Required(ErrorMessage = "country name is required")]
        [RegularExpression(@"^[A-Za-z ]{3,100}$", ErrorMessage = "enter a valid country name")]
        public string Name { get; set; }
    }
}
