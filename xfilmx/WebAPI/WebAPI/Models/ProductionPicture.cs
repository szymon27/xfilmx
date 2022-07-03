using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    [Table("ProductionPictures")]
    public class ProductionPicture
    {
        [Key, Column(Order = 0)]
        public int ProductionPictureId { get; set; }

        [ForeignKey(nameof(Production)), Column(Order = 1)]
        public int ProductionId { get; set; }

        [Column(Order = 2)]
        public byte[] Picture { get; set; }

        public Production Production { get; set; }
    }
}
