using WebAPI.DTO;
using WebAPI.Models;

namespace WebAPI.BLL.Interfaces
{
    public interface IUserBll
    {
        public UserDto Get(int userId);
        public List<UserDto> Get();
        public UserDto Post(PostUserDto dto);
        public bool ChangePassword(int userId, ChangePasswordDto dto);
        public bool ChangePicture(int userId, byte[] picture);
        public bool ChangeType(int userId, UserType userType);
        public bool DeletePicture(int userId);
        public bool Delete(int userId);
    }
}
