using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CVApp.Server.Data;
using CVApp.Server.Model;
using CVApp.Server.Dtos.Responses;
using CVApp.Server.Dtos;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Security.Cryptography;
using CVApp.Server.Dtos.Requests;

namespace CVApp.Server.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly CVAppDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthController(CVAppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        private string HashPassword(string password)
        {

            // Choose the hash algorithm (SHA-256 or SHA-512)
            using (var sha256 = SHA256.Create())
            {
                // Convert the combined password string to a byte array
                byte[] bytes = Encoding.UTF8.GetBytes(password);

                // Compute the hash value of the byte array
                byte[] hash = sha256.ComputeHash(bytes);

                // Convert the byte array to a hexadecimal string
                StringBuilder result = new StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    result.Append(hash[i].ToString("x2"));
                }

                return result.ToString();
            }
        }

        private List<Claim> GetAllValidClaims(User user)
        {
            var claims = new List<Claim>()
            {
                new Claim("Id", user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName)
            };

            return claims;
        }

        private AuthResult GenerateJwtTokens(User user)
        {
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                                                {
                                                    new Claim("Id", user.Id.ToString()),
                                                    new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                                                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                                                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                                                 }),
                Expires = DateTime.UtcNow.AddMonths(5),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = tokenHandler.WriteToken(token);
            return new AuthResult()
            {
                Success = true,
                Token = jwtToken
            };
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> Register([FromBody] RegisterRequest request)
        {
            var exsitUser = _context.User.Where(u => u.Email == request.Email);
            if (exsitUser.Any())
            {
                var response = new RegisterResponse();
                response.Success = false;
                response.Errors.Add("Email exists already.");
                return BadRequest(response);
            }
            request.Password = HashPassword(request.Password);
            User user = new User()
            {
                Email = request.Email,
                UserName = request.UserName,
                Password = request.Password,
                CreatedAt = DateTime.UtcNow
            };

            _context.User.Add(user);
            await _context.SaveChangesAsync();

            var result = GenerateJwtTokens(user);
            return Ok(result);
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> Login([FromBody] LoginRequest request)
        {
            var isValidUser = _context.User.Where(u => u.Email == request.Email);
            if (!isValidUser.Any())
            {
                var response = new RegisterResponse();
                response.Success = false;
                response.Errors.Add("The email does not exist.");
                return BadRequest(response);
            }
            var user = await isValidUser.SingleAsync();
            request.Password = HashPassword(request.Password);
            if (user.Password != request.Password)
            {
                var response = new RegisterResponse();
                response.Success = false;
                response.Errors.Add("The password is wrong.");
                return BadRequest(response);
            }

            var result = GenerateJwtTokens(user);
            return Ok(result);
        }
    }
}
