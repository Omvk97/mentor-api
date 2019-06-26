using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using mentor_api.Data;
using mentor_api.DTOs;
using mentor_api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace mentor_api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        private readonly IConfiguration _config;
        public AuthController(IAuthRepository repo, IConfiguration config)
        {
            _config = config;
            _repo = repo;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDTO userForRegisterDTO)
        {
            userForRegisterDTO.Username = userForRegisterDTO.Username.ToLower();
            if (await _repo.UserExists(userForRegisterDTO.Username))
            {
                return BadRequest("Username already exits");
            }

            var userToCreate = new User
            {
                Username = userForRegisterDTO.Username
            };

            var createdUSer = await _repo.Register(userToCreate, userForRegisterDTO.Password);

            return StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDTO userForLoginDTO)
        {
            // User exists in the database check
            var userFromRepo = await _repo.Login(userForLoginDTO.Username.ToLower(), userForLoginDTO.Password);

            if (userFromRepo == null)
                return Unauthorized();

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
                new Claim(ClaimTypes.Name, userFromRepo.Username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new {
                token = tokenHandler.WriteToken(token)
            });

        }
    }
}