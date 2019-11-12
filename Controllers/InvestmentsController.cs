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
    public class InvestmentsController : Controller
    {
        private W4rtaDBContext context;
        InvestmentsManager investmentsManager;

        public InvestmentsController(W4rtaDBContext context)
        {
            this.context = context;
            investmentsManager = new InvestmentsManager(this.context);
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Investments> investments = investmentsManager.GetAll();
            return Ok(investments);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Investments investments = investmentsManager.Get(id);
            if (investments == null)
                return NotFound("Investment could not be found");
            return Ok(investments);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Investments investments)
        {
            if (investments == null)
            {
                return BadRequest("Address is null");
            }
            investmentsManager.Add(investments);
            return Ok(investments.Id);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Investments investments = investmentsManager.Get(id);
            if (investments == null)
                return NotFound("Address couldn't be found");
            investmentsManager.Delete(investments);
            return NoContent();
        }

    }
}
