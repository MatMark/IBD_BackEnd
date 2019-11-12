using System;
using System.Collections.Generic;
using BackEnd.Models;
using BackEnd.Models.Managers;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private W4rtaDBContext context;
        private AccountManager accountManager;
        public AccountController(W4rtaDBContext context)
        {
            this.context = context;
            accountManager = new AccountManager(this.context);
    }
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Account> account = accountManager.GetAll();
            return Ok(account);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Account account = accountManager.Get(id);
            if (account == null)
                return NotFound("Account couldn't be found");
            return Ok(account);
        }
        [HttpPost]
        public IActionResult Post([FromBody] Account account)
        {
            if (account == null)
            {
                return BadRequest("Account is null");
            }
            if (accountManager.Add(account) == 1)
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
            Account account = accountManager.Get(id);
            if (account == null)
                return NotFound("Account couldn't be found");
            if (accountManager.Delete(account) == 1)
            {
                return Ok(true);
            }
            else
            {
                return BadRequest(false);
            }
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, Account account)
        {
            if (id != account.Id)
            {
                return BadRequest();
            }
            if (accountManager.Update(account) == 1)
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
