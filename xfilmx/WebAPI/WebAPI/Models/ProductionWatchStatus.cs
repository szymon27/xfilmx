using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    [Table("ProductionWatchStatuses")]
    public class ProductionWatchStatus
    {
        [Key, ForeignKey(nameof(Production)), Column(Order = 0)]
        public int ProductionId { get; set; }

        [Key, ForeignKey(nameof(User)), Column(Order = 1)]
        public int UserId { get; set; }

        [Column(Order = 2)]
        public WatchStatus WatchStatus { get; set; }

        public Production Production { get; set; }
        public User User { get; set; }
    }

    public enum WatchStatus
    {
        None = 0,
        Watched = 1,
        ToWatch = 2
    }
}
