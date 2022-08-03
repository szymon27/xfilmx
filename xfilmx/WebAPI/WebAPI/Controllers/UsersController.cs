using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.BLL.Interfaces;
using WebAPI.DTO;
using WebAPI.Models;

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

        [HttpGet("{userId}")]
        public UserDto Get(int userId)
            => this.userBll.Get(userId);

        [HttpGet]
        public List<UserDto> Get()
            => this.userBll.Get();

        [HttpPost]
        public UserDto Post(PostUserDto dto)
            => this.userBll.Post(dto);

        [Authorize]
        [HttpPut("changePassword/{userId}")]
        public bool ChangePassword(int userId, [FromBody] ChangePasswordDto dto)
            => this.userBll.ChangePassword(userId, dto);

        [Authorize(Roles = "Admin")]
        [HttpPut("changeType/{userId}")]
        public bool ChangeType(int userId, [FromBody] UserType userType)
             => this.userBll.ChangeType(userId, userType);

        [Authorize]
        [HttpPut("changePicture/{userId}")]
        public bool ChangePicture(int userId)
        {
            var picture = HttpContext.Request.Form.Files["Picture"];
            if(picture == null)
                return this.userBll.ChangePicture(userId,
                    System.IO.File.ReadAllBytes(Path.Combine(Environment.CurrentDirectory, @"Resources\", "defaultProfilePicture.png")));

            MemoryStream memoryStream = new MemoryStream();
            picture.CopyTo(memoryStream);
            return this.userBll.ChangePicture(userId, memoryStream.ToArray());
        }

        [Authorize]
        [HttpDelete("deletePicture/{userId}")]
        public bool DeletePicture(int userId)
            => this.userBll.DeletePicture(userId);

        [Authorize(Roles = "Admin")]
        [HttpDelete("{userId}")]
        public bool Delete(int userId)
            => this.userBll.Delete(userId);

    }
}

