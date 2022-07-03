using WebAPI.BLL.Interfaces;
using WebAPI.DAL.Interfaces;
using WebAPI.DTO;
using WebAPI.Models;

namespace WebAPI.BLL
{
    public class UserBll : IUserBll
    {
        private readonly IUnitOfWork unitOfWork;

        public UserBll(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public bool Delete(int userId)
        {
            bool deleted = this.unitOfWork.UserRepository.Delete(userId);
            if (deleted) this.unitOfWork.Complete();
            return deleted;
        }

        public UserDto Post(PostUserDto dto)
        {
            User user = this.unitOfWork.UserRepository.Get()
                .Where(u => u.Username.ToLower() == dto.Username.ToLower())
                .FirstOrDefault();

            if (user != null)
                return (UserDto)null;

            user = new User
            {
                UserType = UserType.Normal,
                Username = dto.Username,
                Password = dto.Password
            };

            this.unitOfWork.UserRepository.Add(user);
            this.unitOfWork.Complete();

            return new UserDto
            {
                UserId = user.UserId,
                UserType = user.UserType,
                Username = user.Username,
                Picture = user.Picture
            };
        }
    }
}
