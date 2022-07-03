using System.ComponentModel.DataAnnotations;

namespace xfilmx.ViewModels
{
    public class CreateCelebritieVM
    {
        [Required(ErrorMessage = "name is required")]
        [RegularExpression(@"^[A-Za-z]{2,60}$", ErrorMessage = "enter a valid name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "surname is required")]
        [RegularExpression(@"^[A-Za-z]{2,100}$", ErrorMessage = "enter a valid surname")]
        public string Surname { get; set; }


        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        [RegularExpression(@"^[A-Za-z ]{0,60}$", ErrorMessage = "enter a valid surname")]
        public string PlaceOfBirth { get; set; }

        public byte[] Picture { get; set; }
    }
}
