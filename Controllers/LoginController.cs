using System.Linq;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using MyStore.Data;
using MyStore.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Security.Claims;
using System;
using System.IdentityModel.Tokens;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Collections.Generic;

namespace MyStore.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly MyStoreContext _context;
        private readonly string _secretString;

        public LoginController(MyStoreContext context)
        {
            this._context = context;
            this._secretString = "MySecretsmlkmfwlemfmeewjhevryqbouhtipuhaoifbreuafbuafieunquuenfu";
        }


        [HttpPost]
        public ActionResult Login([FromBody] User user
            )
        {

            var employees = _context.Employees.ToArray();

            var g = _context.Employees.SingleOrDefault(x => x.Name == user.Name);

            

            if (g != null)
            {
                if (g.Password == user.Password)
                {
                    SymmetricSecurityKey secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretString));

                    var hand = new JwtSecurityTokenHandler();

                    var claimsIdentity = new ClaimsIdentity(new[]
                        {
                                new Claim(ClaimTypes.Name, g.Id.ToString()),
                                new Claim("authorize", "true")
                            });

                    var securityTokenDescriptor = new SecurityTokenDescriptor()
                    {
                        Issuer = "http://localhost:5000",
                        Audience = "http://localhost:5000",
                        Subject = claimsIdentity,
                        Expires = DateTime.UtcNow.AddMonths(12),
                        SigningCredentials = new SigningCredentials(secret, SecurityAlgorithms.HmacSha256Signature, SecurityAlgorithms.Sha512Digest)
                    };

                    var plainToken = hand.CreateToken(securityTokenDescriptor);
                    var token = hand.WriteToken(plainToken);

                    var newUser = new User(token);

                    return Ok(new { token = newUser.Token});

                }
                else
                {
                    return Unauthorized(new { error = "Wrong password" });
                }
            }
            else
            {
                return NotFound(new { error = "No employee found." });
            }

        }

    }
}