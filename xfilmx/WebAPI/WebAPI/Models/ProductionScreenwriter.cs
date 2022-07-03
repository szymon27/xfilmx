using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    [Table("ProductionScreenwriters")]
    public class ProductionScreenwriter
    {
        [Key, ForeignKey(nameof(Production)), Column(Order = 0)]
        public int ProductionId { get; set; }

        [Key, ForeignKey(nameof(Celebritie)), Column(Order = 1)]
        public int CelebritieId { get; set; }

        public Production Production { get; set; }
        public Celebritie Celebritie { get; set; }
    }
}
