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
    public class ClientsController : Controller
    {
        private W4rtaDBContext context;
        private ClientsManager clientsManager;
        public ClientsController(W4rtaDBContext context)
        {
            this.context = context;
            clientsManager = new ClientsManager(this.context);
        }
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Clients> clients = clientsManager.GetAll();
            return Ok(clients);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Clients clients = clientsManager.Get(id);
            if (clients == null)
                return NotFound("Client couldn't be found");
            return Ok(clients);
        }
        [HttpPost]
        public IActionResult Post([FromBody] Clients clients)
        {
            if (clients == null)
            {
                return BadRequest("Client is null");
            }
            clientsManager.Add(clients);
            return Ok(clients.Id);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Clients clients = clientsManager.Get(id);
            if (clients == null)
                return NotFound("Client couldn't be found");
            clientsManager.Delete(clients);
            return NoContent();
        }
    }
}