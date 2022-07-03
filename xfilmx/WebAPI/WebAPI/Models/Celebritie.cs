using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    [Table("Celebrities")]
    public class Celebritie
    {
        [Key, Column(Order = 0)]
        public int CelebritieId { get; set; }

        [Required, MaxLength(60), Column(Order = 1)]
        public string Name { get; set; }

        [Required, MaxLength(100), Column(Order = 2)]
        public string Surname { get; set; }

        [Column(TypeName = "date", Order = 3)]
        public DateTime? DateOfBirth { get; set; }

        [MaxLength(60), Column(Order = 4)]
        public string PlaceOfBirth { get; set; }

        [Column(Order = 5)]
        public byte[] Picture { get; set; }

        public ICollection<ProductionDirector> ProductionDirectors { get; set; }
        public ICollection<ProductionScreenwriter> ProductionScreenwriters { get; set; }
        public ICollection<ProductionActor> ProductionActors { get; set; }
    }
}
