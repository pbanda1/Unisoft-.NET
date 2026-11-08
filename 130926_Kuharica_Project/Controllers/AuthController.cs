using _130926_Kuharica_Project.Auth;
using BusinessLayerLogic.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _130926_Kuharica_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthController : ControllerBase
    {
        private readonly ITokenService _tokenService;

        public AuthController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Login(LoginDto dto) {
            string role;

            if (dto.Username == "admin" && dto.Password == "admin123")
            {
                role = "Admin";
            }
            else if (dto.Username == "korisnik" && dto.Password == "korisnik123")
            {
                role = "Korisnik";
            }
            else
            {
                return Unauthorized("Pogrešno korisničko ime ili lozinka.");
            }
            var token = _tokenService.CreateToken(dto.Username, role);
            return Ok(new { token }); // ovako user dobije objekt a ne goli string 
        }
    }
}
