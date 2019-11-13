using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.Models;
using BackEnd.Models.Managers;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        public IActionResult Get()
        {
            IEnumerable<Investment> investment = investmentManager.GetAll();
            return Ok(investment);
        }

        [HttpGet("{id}")]
        [Authorize]
        public IActionResult Get(int id)
        {
            Investment investment = investmentManager.Get(id);
            if (investment == null)
                return NotFound("Investment could not be found");
            return Ok(investment);
        }

        [HttpPost]
        [Authorize]
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
        [Authorize]
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
        [Authorize]
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
