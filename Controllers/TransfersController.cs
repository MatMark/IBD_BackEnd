using System;
using System.Collections.Generic;
using BackEnd.Models;
using BackEnd.Models.Managers;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    public class TransfersController : Controller
    {
        private W4rtaDBContext context;
        private TransfersManager transfersManager;
        public TransfersController(W4rtaDBContext context)
        {
            this.context = context;
            transfersManager = new TransfersManager(this.context);
        }
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Transfers> transfers = transfersManager.GetAll();
            return Ok(transfers);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Transfers transfers = transfersManager.Get(id);
            if (transfers == null)
                return NotFound("Transfer couldn't be found");
            return Ok(transfers);
        }
        [HttpPost]
        public IActionResult Post([FromBody] Transfers transfers)
        {
            if (transfers == null)
            {
                return BadRequest("Transfer is null");
            }
            transfersManager.Add(transfers);
            return Ok(transfers.ID);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Transfers transfers = transfersManager.Get(id);
            if (transfers == null)
                return NotFound("Transfer couldn't be found");
            transfersManager.Delete(transfers);
            transfers = transfersManager.Get(id);
            if (transfers == null)
                return Ok(true);
            return BadRequest(false);
        }
    }
}
