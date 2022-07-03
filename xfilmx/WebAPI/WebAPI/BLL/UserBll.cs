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

        public bool ChangePassword(int userId, ChangePasswordDto dto)
        {
            User user = this.unitOfWork.UserRepository.Get(userId);
            if (user == null)
                return false;

            if (user.Password != dto.OldPassword)
                return false;

            user.Password = dto.NewPassword;
            this.unitOfWork.Complete();
            return true;
        }

        public bool ChangePicture(int userId, byte[] picture)
        {
            User user = this.unitOfWork.UserRepository.Get(userId);

            if (user == null)
                return false;

            user.Picture = picture;
            this.unitOfWork.Complete();
            return true;
        }

        public bool ChangeType(int userId, UserType userType)
        {
            User user = this.unitOfWork.UserRepository.Get(userId);

            if (user == null)
                return false;

            user.UserType = userType;
            this.unitOfWork.Complete();
            return true;
        }

        public bool Delete(int userId)
        {
            bool deleted = this.unitOfWork.UserRepository.Delete(userId);
            if (deleted) this.unitOfWork.Complete();
            return deleted;
        }

        public bool DeletePicture(int userId)
        {
            User user = this.unitOfWork.UserRepository.Get(userId);

            if (user == null)
                return false;

            user.Picture = File.ReadAllBytes(@"D:\VSProjects\xfilmx\xfilmx\WebAPI\WebAPI\Resources\defaultProfilePicture.png");
            this.unitOfWork.Complete();
            return true;
        }

        public UserDto Get(int userId)
        {
            User user = this.unitOfWork.UserRepository.Get(userId);

            if (user == null)
                return (UserDto)null;

            return new UserDto
            {
                UserId = user.UserId,
                UserType = user.UserType,
                Username = user.Username,
                Picture = user.Picture
            };
        }

        public List<UserDto> Get()
        {
            return this.unitOfWork.UserRepository.Get()
                .Select(u => new UserDto
                {
                    UserId = u.UserId,
                    UserType = u.UserType,
                    Username = u.Username,
                    Picture = u.Picture
                }).ToList();
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
                Password = dto.Password,
                Picture = File.ReadAllBytes(@"D:\VSProjects\xfilmx\xfilmx\WebAPI\WebAPI\Resources\defaultProfilePicture.png")
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
