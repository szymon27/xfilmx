using WebAPI.BLL.Interfaces;
using WebAPI.DAL.Interfaces;
using WebAPI.DTO;
using WebAPI.Models;

namespace WebAPI.BLL
{
    public class AuthorizationBll : IAuthorizationBll
    {
        private readonly IUnitOfWork unitOfWork;

        public AuthorizationBll(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        //(userId, userType)
        public (int, UserType) Login(AuthorizationDto dto)
        {
            User user = this.unitOfWork.UserRepository
                .Get()
                .Where(u => u.Username == dto.Login && u.Password == dto.Password)
                .FirstOrDefault();

            return user == null ? (-1, UserType.Guest) : (user.UserId, user.UserType);
        }
    }
}
