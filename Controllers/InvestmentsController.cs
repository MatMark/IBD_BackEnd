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
        //TODO InvestmentsManager

        public AddressesController(W4rtaDBContext context)
        {
            this.context = context;
            //TODO InvestmentsManager
        }
    }
}
