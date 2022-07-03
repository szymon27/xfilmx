using WebAPI.Models;

namespace WebAPI.DTO
{
    public class UserDto
    {
        public int UserId { get; set; }
        public UserType UserType { get; set; }
        public string Username { get; set; }
        public byte[] Picture { get; set; }
    }
}
