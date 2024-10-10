using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Server.Data.DTO;

namespace Server.WS.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        readonly IConfiguration config;

        public AuthController(IConfiguration config)
        {
            this.config = config;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginUserModel loginModel)
        {
            // Validate the user credentials (this is just a demo, so we'll accept any user)
            if (CheckLogin(loginModel))
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var keyConfigValue = config["AppSettings:JWTSecret"];
                var key = Encoding.ASCII.GetBytes(keyConfigValue!);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, loginModel.Username)
                    }),
                    Expires = DateTime.UtcNow.AddHours(12),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);

                return Ok(new { Token = tokenString });
            }

            return Unauthorized();
        }

        private bool CheckLogin(LoginUserModel loginModel)
        {
            // Just for the demo, I will accept any user & password
            return true;
        }
    }
}
