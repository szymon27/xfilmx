using System.ComponentModel.DataAnnotations;

namespace xfilmx.ViewModels
{
    public class CreateGenreVM
    {
        [Required(ErrorMessage = "genre name is required")]
        [RegularExpression(@"^[A-Za-z -]{3,50}$", ErrorMessage = "enter a valid genre name")]
        public string Name { get; set; }
    }
}
