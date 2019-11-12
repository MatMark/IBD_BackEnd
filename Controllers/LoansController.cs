using System;
using System.Collections.Generic;
using BackEnd.Models;
using BackEnd.Models.Managers;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    public class LoansController : Controller
    {
        private W4rtaDBContext context;
        private LoansManager loansManager;
        public LoansController(W4rtaDBContext context)
        {
            this.context = context;
            loansManager = new LoansManager(this.context);
        }
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Loans> loans = loansManager.GetAll();
            return Ok(loans);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Loans loans = loansManager.Get(id);
            if (loans == null)
                return NotFound("Loan couldn't be found");
            return Ok(loans);
        }
        [HttpPost]
        public IActionResult Post([FromBody] Loans loans)
        {
            if (loans == null)
            {
                return BadRequest("Loan is null");
            }
            loansManager.Add(loans);
            return Ok(loans.ID);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Loans loans = loansManager.Get(id);
            if (loans == null)
                return NotFound("Loan couldn't be found");
            loansManager.Delete(loans);
            return NoContent();
        }
    }
}
