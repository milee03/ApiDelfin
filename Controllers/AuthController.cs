using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ApiDelfin.Models;
using ApiDelfin.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ApiDelfin.Models;
using ApiDelfin.Services;
using ApiDelfin.DTOs.Auth;
namespace ApiDelfin.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;

        public AuthController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterRequestDTO model)
        {
            var result = _userService.Register(model.Name, model.Dni, model.Password, model.IsAdmin);
            if (!result) return BadRequest("Usuario ya existe.");
            return Ok("Usuario registrado.");
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequestDTO model)
        {
            var user = _userService.ValidateUser(model.Dni, model.Password);
            if (user == null) return Unauthorized("Credenciales inválidas.");

            var token = GenerateJwtToken(user);
            return Ok(new { token });
        }

        private string GenerateJwtToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.NameIdentifier, user.Dni),
                new Claim(ClaimTypes.Role, user.IsAdmin ? "Admin" : "User")
            };

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

