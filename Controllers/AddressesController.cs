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
    public class AddressesController : Controller
    {
        private W4rtaDBContext context;
        private AddressesManager addressManager;
        public AddressesController(W4rtaDBContext context)
        {
            this.context = context;
            addressManager = new AddressesManager(this.context);
        }
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Addresses> addresses = addressManager.GetAll();
            return Ok(addresses);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Addresses addresses = addressManager.Get(id);
            if (addresses == null)
                return NotFound("Address couldn't be found");
            return Ok(addresses);
        }
        [HttpPost]
        public IActionResult Post([FromBody] Addresses addresses)
        {
            if (addresses == null)
            {
                return BadRequest("Address is null");
            }
            addressManager.Add(addresses);
            return Ok(addresses.Id);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Addresses address = addressManager.Get(id);
            if (address == null)
                return NotFound("Address couldn't be found");
            addressManager.Delete(address);
            return NoContent();
        }
    }
}
