using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    [Table("Countries")]
    public class Country
    {
        [Key, Column(Order = 0)]
        public int CountryId { get; set; }

        [Required, MaxLength(100), Column(Order = 1)]
        public string Name { get; set; }

        public ICollection<ProductionCountry> ProductionCountries { get; set; }
    }
}
