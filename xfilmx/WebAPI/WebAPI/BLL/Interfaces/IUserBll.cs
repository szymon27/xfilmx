using WebAPI.DTO;

namespace WebAPI.BLL.Interfaces
{
    public interface IUserBll
    {
        public UserDto Post(PostUserDto dto);
        public bool Delete(int userId);
    }
}
