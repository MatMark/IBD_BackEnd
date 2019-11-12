using System;
using System.Collections.Generic;
using BackEnd.Models;
using BackEnd.Models.Managers;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    public class AccountsController : Controller
    {
        private W4rtaDBContext context;
        private AccountsManager accountsManager;
        public AccountsController(W4rtaDBContext context)
        {
            this.context = context;
            accountsManager = new AccountsManager(this.context);
    }
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Accounts> accounts = accountsManager.GetAll();
            return Ok(accounts);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Accounts accounts = accountsManager.Get(id);
            if (accounts == null)
                return NotFound("Account couldn't be found");
            return Ok(accounts);
        }
        [HttpPost]
        public IActionResult Post([FromBody] Accounts accounts)
        {
            if (accounts == null)
            {
                return BadRequest("Account is null");
            }
            accountsManager.Add(accounts);
            return Ok(accounts.ID);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Accounts accounts = accountsManager.Get(id);
            if (accounts == null)
                return NotFound("Account couldn't be found");
            accountsManager.Delete(accounts);
            accounts = accountsManager.Get(id);
            if (accounts == null)
                return Ok(true);
            return BadRequest(false);
        }
    }
}
