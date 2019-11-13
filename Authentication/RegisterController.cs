using BackEnd.Models;
using BackEnd.Models.Managers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Authentication
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : Controller
    {
        private W4rtaDBContext context;
        private ClientManager clientManager;
        public RegisterController(W4rtaDBContext context)
        {
            this.context = context;
            clientManager = new ClientManager(this.context);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Register([FromBody]Client registerRequest)
        {
            if (registerRequest == null) return BadRequest("Client is null");

            byte[] salt = Encoding.UTF8.GetBytes(registerRequest.Email);
            string hashedPassword = PasswordHasher.Hash(salt, registerRequest.Password);
            registerRequest.Password = hashedPassword;

            if (clientManager.Add(registerRequest) == 1) return Ok(true);
            else return BadRequest(false);
        }
    }
}
