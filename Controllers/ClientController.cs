using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.Models;
using BackEnd.Models.Managers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    public class ClientController : Controller
    {
        private W4rtaDBContext context;
        private ClientManager clientManager;
        public ClientController(W4rtaDBContext context)
        {
            this.context = context;
            clientManager = new ClientManager(this.context);
        }
        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            IEnumerable<Client> client = clientManager.GetAll();
            return Ok(client);
        }
        [HttpGet("{id}")]
        [Authorize]
        public IActionResult Get(int id)
        {
            Client client = clientManager.Get(id);
            if (client == null)
                return NotFound("Client couldn't be found");
            return Ok(client);
        }
        [HttpGet("{email}")]
        [Authorize]
        public IActionResult Get(string email)
        {
            Client client = clientManager.Get(email);
            if (client == null)
                return NotFound("Client couldn't be found");
            return Ok(client);
        }
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] Client client)
        {
            if (client == null)
            {
                return BadRequest("Client is null");
            }
            if (clientManager.Add(client) == 1)
            {
                return Ok(true);
            }
            else
            {
                return BadRequest(false);
            }
        }
        [HttpDelete]
        [Authorize]
        public IActionResult Delete(int id)
        {
            Client client = clientManager.Get(id);
            if (client == null)
                return NotFound("Client couldn't be found");
            if (clientManager.Delete(client) == 1)
            {
                return Ok(true);
            }
            else
            {
                return BadRequest(false);
            }
        }
        [HttpPut]
        [Authorize]
        public IActionResult Put([FromBody] Client client)
        {
            if (clientManager.Update(client) == 1)
            {
                return Ok(true);
            }
            else
            {
                return BadRequest(false);
            }
        }
    }
}