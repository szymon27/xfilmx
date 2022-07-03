using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    [Table("ProductionTrailers")]
    public class ProductionTrailer
    {
        [Key, Column(Order = 0)]
        public int ProductionTrailerId { get; set; }

        [ForeignKey(nameof(Production)), Column(Order = 1)]
        public int ProductionId { get; set; }

        [Required, MaxLength(255), Column(Order = 2)]
        public string Link { get; set; }

        public Production Production { get; set; }
    }
}
