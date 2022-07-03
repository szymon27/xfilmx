using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    [Table("Users")]
    public class User
    {
        [Key, Column(Order = 0)]
        public int UserId { get; set; }

        [Column(Order = 1)]
        public UserType UserType { get; set; }

        [Required, Column(Order = 2), MinLength(8), MaxLength(50)]
        public string Username { get; set; }

        [Required, Column(Order = 3), MinLength(8)]
        public string Password { get; set; }

        [Column(Order = 4)]
        public byte[] Picture { get; set; }

        public ICollection<News> News { get; set; }
        public ICollection<ProductionComment> ProductionComments { get; set; }
        public ICollection<ProductionRate> ProductionRates { get; set; }
        public ICollection<ProductionWatchStatus> ProductionWatchStatuses { get; set; }
    }

    public enum UserType
    {
        Guest = 0,
        Normal = 1,
        Employee = 2,
        Admin = 3
    };
}
