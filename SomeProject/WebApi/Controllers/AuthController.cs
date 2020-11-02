using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthController(IConfiguration configuration,
                SignInManager<ApplicationUser> signInManager,
                UserManager<ApplicationUser> userManager)
        {
            _configuration = configuration;
            _signInManager = signInManager;
            _userManager = userManager;
        }
        
        [HttpPost("/authorize")]
        public async Task<IActionResult> Authorize([FromBody]LoginViewModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user != null)
            {
                var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
            
                if (result.Succeeded)
                {
                    var secretKey = _configuration.GetValue<string>("JWTSecretKey");
                    var key = Encoding.ASCII.GetBytes(secretKey);

                    var claims = new[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Email, user.Email)
                    };

                    var expires = DateTime.UtcNow.AddHours(1);

                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(claims),
                        Expires = expires,
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };
            
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var createdToken = tokenHandler.CreateToken(tokenDescriptor);

                    var response = new AuthorizationResponse
                    {
                        Token = tokenHandler.WriteToken(createdToken),
                        Expires = expires
                    };

                    return Ok(response);
                }
            }

            return Unauthorized("Unauthorized access.");
        }
    }
}