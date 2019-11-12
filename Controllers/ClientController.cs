using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.Models;
using BackEnd.Models.Managers;
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
        public IActionResult Get()
        {
            IEnumerable<Client> client = clientManager.GetAll();
            return Ok(client);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Client client = clientManager.Get(id);
            if (client == null)
                return NotFound("Client couldn't be found");
            return Ok(client);
        }
        [HttpPost]
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
        [HttpPut("{id}")]
        public IActionResult Put(int id, Client client)
        {
            if (id != client.Id)
            {
                return BadRequest();
            }
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