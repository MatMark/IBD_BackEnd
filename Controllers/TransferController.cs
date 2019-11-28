using System;
using System.Collections.Generic;
using System.Linq;
using BackEnd.Models;
using BackEnd.Models.Managers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    public class TransferController : Controller
    {
        private W4rtaDBContext context;
        private TransferManager transferManager;
        private AccountManager accountManager;

        public TransferController(W4rtaDBContext context)
        {
            this.context = context;
            transferManager = new TransferManager(this.context);
            accountManager = new AccountManager(this.context);
        }
        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            IEnumerable<Transfer> transfer = transferManager.GetAll();
            return Ok(transfer);
        }
        [HttpGet("{id}")]
        [Authorize]
        public IActionResult Get(int id)
        {
            Transfer transfer = transferManager.Get(id);
            if (transfer == null)
                return NotFound("Transfer couldn't be found");
            return Ok(transfer);
        }
        [HttpGet("by_account_id/{accountId}")]
        [Authorize]
        public IActionResult GetByAccountId(int accountId)
        {
            IEnumerable<Transfer> transfers = transferManager.GetAll().Where(e => e.AccountId == accountId);
            return Ok(transfers);
        }
        [HttpGet("by_destination/{destination}")]
        [Authorize]
        public IActionResult GetByAccountId(string destination)
        {
            IEnumerable<Transfer> transfers = transferManager.GetAll().Where(e => e.Destination == destination);
            return Ok(transfers);
        }
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] Transfer transfer)
        {
            if (transfer == null)
            {
                return BadRequest("Transfer is null");
            }
            if (transferManager.Add(transfer) == 1)
            {
                return Ok(true);
            }
            else
            {
                return BadRequest(false);
            }
        }
        [HttpPost("make_transfer")]
        [Authorize]
        public IActionResult MakeTransfer([FromBody] Transfer transfer)
        {
            if (transfer == null) return BadRequest("Transfer is null");

            Account srcAccount = accountManager.Get(transfer.AccountId);

            if (srcAccount == null) return BadRequest("Bad source account");

            Account dstAccount = accountManager.Get(transfer.Destination);

            if (srcAccount.Balance < transfer.Amount) return BadRequest("Not enought money");

            if (transferManager.Add(transfer) == 1)
            {
                srcAccount.Balance -= transfer.Amount;
                accountManager.Update(srcAccount);
                if (dstAccount != null)
                {
                    dstAccount.Balance += transfer.Amount;
                    accountManager.Update(dstAccount);
                }
                return Ok(true);
            }
            else
            {
                return BadRequest("Unknown error");
            }
        }
        [HttpDelete]
        [Authorize]
        public IActionResult Delete(int id)
        {
            Transfer transfer = transferManager.Get(id);
            if (transfer == null)
                return NotFound("Transfer couldn't be found");
            if (transferManager.Delete(transfer) == 1)
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
        public IActionResult Put([FromBody] Transfer transfer)
        {
            if (transferManager.Update(transfer) == 1)
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
