using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace xfilmx.Models
{
    [Table("News")]
    public class News
    {
        [Key, Column(Order = 0)]
        public int NewsId { get; set; }

        [ForeignKey(nameof(User)), Column(Order = 1)]
        public int UserId { get; set; }

        [Required, MaxLength(100), Column(Order = 2)]
        public string Title { get; set; }

        [Required, MaxLength(1000), Column(Order = 3)]
        public string Description { get; set; }

        [Column(TypeName = "date", Order = 4)]
        public DateTime Date { get; set; }

        [Column(Order = 5)]
        public byte[] Picture { get; set; }

        public User User { get; set; }
    }
}
