using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace xfilmx.Models
{
    [Table("ProductionRates")]
    public class ProductionRate
    {
        [Key, ForeignKey(nameof(Production)), Column(Order = 0)]
        public int ProductionId { get; set; }

        [Key, ForeignKey(nameof(User)), Column(Order = 1)]
        public int UserId { get; set; }

        [Column(Order = 2)]
        public Stars Stars { get; set; }

        public Production Production { get; set; }
        public User User { get; set; }
    }

    public enum Stars
    {
        One = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10
    }
}
