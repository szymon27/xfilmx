using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    [Table("ProductionCountries")]
    public class ProductionCountry
    {
        [Key, ForeignKey(nameof(Production)), Column(Order = 0)]
        public int ProductionId { get; set; }

        [Key, ForeignKey(nameof(Country)), Column(Order = 1)]
        public int CountryId { get; set; }

        public Production Production { get; set; }
        public Country Country { get; set; }
    }
}
