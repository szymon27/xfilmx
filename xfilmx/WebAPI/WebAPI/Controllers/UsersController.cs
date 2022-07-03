using Microsoft.AspNetCore.Mvc;
using WebAPI.BLL.Interfaces;
using WebAPI.DTO;

namespace WebAPI.Controllers
{  
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserBll userBll;

        public UsersController(IUserBll userBll)
        {
            this.userBll = userBll;
        }

        [HttpPost]
        public UserDto Post(PostUserDto dto)
            => this.userBll.Post(dto);

        [HttpDelete("{userId}")]
        public bool Delete(int userId)
            => this.userBll.Delete(userId);
    }
}
