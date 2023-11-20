using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Ws_precotex.Context;
using Ws_precotex.Models;

namespace Ws_precotex.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JWTTokenController : ControllerBase
    {
        public IConfiguration _configuration;
        public readonly ApplicationDBContext _context;
        public JWTTokenController(IConfiguration configuration, ApplicationDBContext context)
        {
            _context = context;
            _configuration = configuration;

        }
        [HttpPost]
        public async Task<IActionResult> GenerateToken(User user)
        {

            if (user != null && user.UserName != null && user.Password != null && user.Role >= 0)
            {
                var userData = await GetUserInfo(user.UserName, user.Password);
                var jwt = _configuration.GetSection("Jwt").Get<Jwt>();

                var regla = "user";
                if (userData.UserName != null) {
               
                    if (userData.Role == Role.Admin)
                    {
                        regla = "admin";
                    }
                    else if (userData.Role == Role.User)
                    {
                        regla = "user";
                    }
                }


                if (user != null)
                {
                    var claims = new[] {
                     new Claim(JwtRegisteredClaimNames.Sub, jwt.Subject),
                     new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                     new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                     new Claim("Id", user.UserId.ToString()),
                     new Claim("UserName", user.UserName),
                     new Claim("Password", user.Password),
                     new Claim(ClaimTypes.Role, regla),
                };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        jwt.Issuer,
                        jwt.Audience,
                        claims,
                        expires: DateTime.Now.AddMinutes(10),
                        signingCredentials: signIn
                        );
                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Credenciales Incorrectos");
                }
            }
            else
            {
                return BadRequest("Credenciales Incorrectos");
            }

        }

        [HttpGet]
        public async Task<User> GetUserInfo(string username, string password)
        {
            return await _context.userInfo.FirstOrDefaultAsync(x => x.UserName == username && x.Password == password);
        }
    }
}
