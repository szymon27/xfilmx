using System.ComponentModel.DataAnnotations;

namespace xfilmx.ViewModels
{
    public class EditGenreVM
    {
        public int GenreId { get; set; }

        [Required(ErrorMessage = "genre name is required")]
        [RegularExpression(@"^[A-Za-z -]{3,50}$", ErrorMessage = "enter a valid genre name")]
        public string Name { get; set; }
    }
}
