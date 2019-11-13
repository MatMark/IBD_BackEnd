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
    public class InvestmentController : Controller
    {
        private W4rtaDBContext context;
        InvestmentManager investmentManager;

        public InvestmentController(W4rtaDBContext context)
        {
            this.context = context;
            investmentManager = new InvestmentManager(this.context);
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Investment> investment = investmentManager.GetAll();
            return Ok(investment);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Investment investment = investmentManager.Get(id);
            if (investment == null)
                return NotFound("Investment could not be found");
            return Ok(investment);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Investment investment)
        {
            if (investment == null)
            {
                return BadRequest("Investment is null");
            }
            if (investmentManager.Add(investment) == 1)
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
            Investment investment = investmentManager.Get(id);
            if (investment == null)
                return NotFound("Investment couldn't be found");
            if (investmentManager.Delete(investment) == 1)
            {
                return Ok(true);
            }
            else
            {
                return BadRequest(false);
            }
        }
        [HttpPut]
        public IActionResult Put([FromBody] Investment investment)
        {
            if (investmentManager.Update(investment) == 1)
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
