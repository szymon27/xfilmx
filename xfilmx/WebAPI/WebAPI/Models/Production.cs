using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    [Table("Productions")]
    public class Production
    {
        [Key, Column(Order = 0)]
        public int ProductionId { get; set; }

        [Column(Order = 1)]
        public bool IsSerie { get; set; }

        [Required, MaxLength(100), Column(Order = 2)]
        public string Title { get; set; }

        [Column(TypeName = "date", Order = 3)]
        public DateTime BeginDate { get; set; }

        [Column(TypeName = "date", Order = 4)]
        public DateTime? EndDate { get; set; }

        [Column(Order = 5)]
        public int Duration { get; set; }

        [Required, MaxLength(1000), Column(Order = 6)]
        public string Description { get; set; }

        [Column(Order = 7)]
        public byte[] Picture { get; set; }

        public ICollection<ProductionPicture> ProductionPictures { get; set; }
        public ICollection<ProductionTrailer> ProductionTrailers { get; set; }
        public ICollection<ProductionEpisod> ProductionEpisods { get; set; }
        public ICollection<ProductionDirector> ProductionDirectors { get; set; }
        public ICollection<ProductionScreenwriter> ProductionScreenwriters { get; set; }
        public ICollection<ProductionActor> ProductionActors { get; set; }
        public ICollection<ProductionCountry> ProductionCountries { get; set; }
        public ICollection<ProductionGenre> ProductionGenres { get; set; }
        public ICollection<ProductionComment> ProductionComments { get; set; }
        public ICollection<ProductionRate> ProductionRates { get; set; }
        public ICollection<ProductionWatchStatus> ProductionWatchStatuses { get; set; }
    }
}
