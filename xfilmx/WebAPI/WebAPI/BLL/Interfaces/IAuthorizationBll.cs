using WebAPI.DTO;
using WebAPI.Models;

namespace WebAPI.BLL.Interfaces
{
    public interface IAuthorizationBll
    {
        public (int, UserType) Login(AuthorizationDto dto);
    }
}
