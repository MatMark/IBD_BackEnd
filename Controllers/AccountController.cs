﻿using System;
using System.Collections.Generic;
using System.Linq;
using BackEnd.Models;
using BackEnd.Models.Managers;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        public IActionResult Get()
        {
            IEnumerable<Account> account = accountManager.GetAll();
            return Ok(account);
        }
        [HttpGet("{id}")]
        [Authorize]
        public IActionResult Get(int id)
        {
            Account account = accountManager.Get(id);
            if (account == null)
                return NotFound("Account couldn't be found");
            return Ok(account);
        }

        [HttpGet("by_number/{number}")]
        [Authorize]
        public IActionResult GetByNumber(string number)
        {
            Account account = accountManager.Get(number);
            if (account == null)
                return NotFound("Account couldn't be found");
            return Ok(account);
        }

        [HttpPost("client_accounts")]
        [Authorize]
        public IActionResult GetClientAccounts([FromBody] int clientId)
        {
            IEnumerable<Account> accounts = accountManager.GetAll().Where(e => e.ClientId == clientId);
            return Ok(accounts);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] int clientId)
        {
            Account account = new Account();
            account.ClientId = clientId;
            account.Balance = 0;
            String startWith = "PL";
            Random generator = new Random();
            String one = generator.Next(100000000, 999999999).ToString("D6");
            String two = generator.Next(100000000, 999999999).ToString("D6");
            String three = generator.Next(10000000, 99999999).ToString("D6");
            String accountNumber = startWith + one + two + three;
            account.Number = accountNumber;

            if (accountManager.Add(account) == 1)
            {
                return Ok(account);
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
        [HttpPut]
        [Authorize]
        public IActionResult Put([FromBody] Account account)
        {
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
