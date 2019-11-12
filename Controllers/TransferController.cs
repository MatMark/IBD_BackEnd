using System;
using System.Collections.Generic;
using BackEnd.Models;
using BackEnd.Models.Managers;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    public class TransferController : Controller
    {
        private W4rtaDBContext context;
        private TransferManager transferManager;
        public TransferController(W4rtaDBContext context)
        {
            this.context = context;
            transferManager = new TransferManager(this.context);
        }
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Transfer> transfer = transferManager.GetAll();
            return Ok(transfer);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Transfer transfer = transferManager.Get(id);
            if (transfer == null)
                return NotFound("Transfer couldn't be found");
            return Ok(transfer);
        }
        [HttpPost]
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
        [HttpDelete]
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
        [HttpPut("{id}")]
        public IActionResult Put(int id, Transfer transfer)
        {
            if (id != transfer.Id)
            {
                return BadRequest();
            }
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
