using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Server.WS.ApiControllers
{
    [Route("api")]
    [Authorize]
    public class ApiController : ControllerBase
    {
        [HttpGet("UserInfo")]
        public IActionResult Index()
        {
            var token = HttpContext.Request.Headers.Authorization.ToString().Replace("Bearer ", "");

            // Optionally, decode the token to get user information
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);

            var username = jwtToken.Claims.FirstOrDefault(c => c.Type == "unique_name")?.Value;

            return new JsonResult(new { Name = "username" });
        }
    }
}
