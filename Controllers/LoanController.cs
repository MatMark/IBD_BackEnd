using System;
using System.Collections.Generic;
using BackEnd.Models;
using BackEnd.Models.Managers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    public class LoanController : Controller
    {
        private W4rtaDBContext context;
        private LoanManager loanManager;
        public LoanController(W4rtaDBContext context)
        {
            this.context = context;
            loanManager = new LoanManager(this.context);
        }
        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            IEnumerable<Loan> loan = loanManager.GetAll();
            return Ok(loan);
        }
        [HttpGet("{id}")]
        [Authorize]
        public IActionResult Get(int id)
        {
            Loan loan = loanManager.Get(id);
            if (loan == null)
                return NotFound("Loan couldn't be found");
            return Ok(loan);
        }
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] Loan loan)
        {
            if (loan == null)
            {
                return BadRequest("Loan is null");
            }
            if (loanManager.Add(loan) == 1)
            {
                return Ok(true);
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
            Loan loan = loanManager.Get(id);
            if (loan == null)
                return NotFound("Loan couldn't be found");
            if (loanManager.Delete(loan) == 1)
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
        public IActionResult Put([FromBody] Loan loan)
        {
            if (loanManager.Update(loan) == 1)
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
