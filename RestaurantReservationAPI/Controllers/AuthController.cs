using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RestaurantReservationAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ITokenService _jwtTokenGenerator;
        public AuthController(ITokenService jwtTokenGenerator)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("Login")]
        public IActionResult Authenticate(string userName)
        {
            var token = _jwtTokenGenerator.GenerateJwtToken(userName);

            if (token is null)
            {
                return Ok(new { Message = "Unauthorized" });
            }
            return Ok(token);
        }
    }
}