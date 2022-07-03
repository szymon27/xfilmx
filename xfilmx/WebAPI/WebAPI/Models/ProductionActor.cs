using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    [Table("ProductionActors")]
    public class ProductionActor
    {
        [Key, ForeignKey(nameof(Production)), Column(Order = 0)]
        public int ProductionId { get; set; }

        [Key, ForeignKey(nameof(Celebritie)), Column(Order = 1)]
        public int CelebritieId { get; set; }

        [Required, MaxLength(200), Column(Order = 2)]
        public string Character { get; set; }


        public Production Production { get; set; }
        public Celebritie Celebritie { get; set; }
    }
}
