using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    [Table("ProductionComments")]
    public class ProductionComment
    {
        [Key, Column(Order = 0)]
        public int ProductionCommentId { get; set; }

        [ForeignKey(nameof(Production)), Column(Order = 1)]
        public int ProductionId { get; set; }

        [ForeignKey(nameof(User)), Column(Order = 2)]
        public int UserId { get; set; }

        [Required, MaxLength(300), Column(Order = 3)]
        public string Comment { get; set; }

        [Column(TypeName = "date", Order = 4)]
        public DateTime Date { get; set; }

        public Production Production { get; set; }
        public User User { get; set; }
    }
}
