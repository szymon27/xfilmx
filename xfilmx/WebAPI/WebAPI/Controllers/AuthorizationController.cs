using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebAPI.BLL.Interfaces;
using WebAPI.DTO;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]  
    public class AuthorizationController : ControllerBase
    {
        private readonly IAuthorizationBll authorizationBll;
        public AuthorizationController(IAuthorizationBll authorizationBll)
        {
            this.authorizationBll = authorizationBll;
        }

        [HttpPost]
        public IActionResult Login([FromBody] AuthorizationDto dto)
        {
            var userIdType = this.authorizationBll.Login(dto);
            if (userIdType.Item1 == -1)
                return Unauthorized();

            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, dto.Login));
            claims.Add(new Claim("userId", userIdType.Item1.ToString()));
            claims.Add(new Claim(ClaimTypes.Role, userIdType.Item2.ToString()));
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("secretKey@$%2123"));
            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokenOptions = new JwtSecurityToken(
                issuer: "http://localhost:1234",
                audience: "http://localhost:1234",
                claims: claims,
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: signingCredentials
            );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return Ok(new { Token = tokenString });
        }
    }
}
