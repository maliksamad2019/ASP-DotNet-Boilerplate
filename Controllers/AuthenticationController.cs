using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASP_Net_Boilerplate.Controllers
{
    [Route("api/[controller]")] 
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly Dictionary<string, string> users = new Dictionary<string, string>() { { "user1", "password1" }, { "user2", "password2" } };

        private const string SecretKey = "this is my custom Secret key for authentication";
        private const string allowedRolle = "Customer";
        [HttpGet] 
        [Authorize(Roles = allowedRolle+", Admin, Dev")]
        public IActionResult Get()
        {
            return Ok("this is secure API");
        }

        [HttpGet("GetToken")]
        public IActionResult GetToken([FromBody] UserCred userCred)
        {
            string token = generateToken(userCred);
            if(string.IsNullOrEmpty(token))
                return Forbid();

            return Ok(token);
        }
        

        private string generateToken(UserCred userCred)
        {
            if (!users.Any(item => item.Key == userCred.Username && item.Value == userCred.Password))
                return string.Empty;


            // Package: System.IdentityModel.Tokens.Jwt
            JwtSecurityToken token = new JwtSecurityToken(
                issuer: "malik",
                audience: "malik-audience",
                claims: new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, userCred.Username),
                    new Claim("another-key", "another-value"),
                    new Claim("boilerplate-roles", allowedRolle),
                    new Claim("boilerplate-roles", "Admin"),
                    new Claim("boilerplate-roles", "Dev"),
                },
                expires: DateTime.UtcNow.AddMinutes(5),
                signingCredentials: new SigningCredentials(
                    key: new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey)),
                    algorithm: SecurityAlgorithms.HmacSha256
                )
             );

            return (new JwtSecurityTokenHandler()).WriteToken(token);

        }

    }
}
