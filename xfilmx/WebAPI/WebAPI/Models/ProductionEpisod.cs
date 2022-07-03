using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    [Table("ProductionEpisods")]
    public class ProductionEpisod
    {
        [Key, ForeignKey(nameof(Production)), Column(Order = 0)]
        public int ProductionId { get; set; }

        [Key, Column(Order = 1)]
        public int Season { get; set; }

        [Key, Column(Order = 2)]
        public int Episod { get; set; }

        [MaxLength(100), Column(Order = 3)]
        public string Title { get; set; }

        public Production Production { get; set; }
    }
}
