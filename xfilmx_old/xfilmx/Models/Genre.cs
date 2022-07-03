using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace xfilmx.Models
{
    [Table("Genres")]
    public class Genre
    {
        [Key, Column(Order = 0)]
        public int GenreId { get; set; }

        [Required, MaxLength(50), Column(Order = 1)]
        public string Name { get; set; }

        public ICollection<ProductionGenre> ProductionGenres { get; set; }
    }
}
