using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BackEnd.Models;
using BackEnd.Models.Managers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BackEnd.Authentication
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private IConfiguration _config;
        private W4rtaDBContext context;
        private ClientManager clientManager;

        public LoginController(W4rtaDBContext context, IConfiguration config)
        {
            _config = config;
            this.context = context;
            clientManager = new ClientManager(this.context);
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody]LoginRequestModel loginRequest)
        {
            IActionResult response = Unauthorized();
            var user = AuthenticateUser(loginRequest);

            if (user != null)
            {
                var tokenString = GenerateJSONWebToken(user);
                response = Ok(new { token = tokenString });
            }
            else response = BadRequest(new { error = "Bad login or password" });

            return response;
        }

        private string GenerateJSONWebToken(Client userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            
            var claims = new[] {
            new Claim(JwtRegisteredClaimNames.NameId, userInfo.Id.ToString()),
            //new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private Client AuthenticateUser(LoginRequestModel loginRequest)
        {
            Client client = clientManager.Get(loginRequest.Email);
            if (client == null) return null;
            byte[] salt = Encoding.UTF8.GetBytes(loginRequest.Email);
            string hashedPassword = PasswordHasher.Hash(salt, loginRequest.Password);
            if (client.Password == hashedPassword) return client;
            else return null;
        }
    }
}