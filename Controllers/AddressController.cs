﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.Models;
using BackEnd.Models.Managers;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    public class AddressController : Controller
    {
        private W4rtaDBContext context;
        private AddressManager addressManager;
        public AddressController(W4rtaDBContext context)
        {
            this.context = context;
            addressManager = new AddressManager(this.context);
        }
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Address> address = addressManager.GetAll();
            return Ok(address);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Address address = addressManager.Get(id);
            if (address == null)
                return NotFound("Address couldn't be found");
            return Ok(address);
        }
        [HttpPost]
        public IActionResult Post([FromBody] Address address)
        {
            if (address == null)
            {
                return BadRequest("Address is null");
            }
            addressManager.Add(address);
            return Ok(address.Id);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Address address = addressManager.Get(id);
            if (address == null)
                return NotFound("Address couldn't be found");
            addressManager.Delete(address);
            return NoContent();
        }
    }
}