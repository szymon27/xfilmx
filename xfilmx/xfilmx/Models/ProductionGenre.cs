using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace xfilmx.Models
{
    [Table("ProductionGenres")]
    public class ProductionGenre
    {
        [Key, ForeignKey(nameof(Production)), Column(Order = 0)]
        public int ProductionId { get; set; }

        [Key, ForeignKey(nameof(Genre)), Column(Order = 1)]
        public int GenreId { get; set; }

        public Production Production { get; set; }
        public Genre Genre { get; set; }
    }
}
