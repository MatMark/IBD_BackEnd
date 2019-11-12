using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models
{
    public class Investment
    {
        public Investment()
        {

        }

        public int Id { get; set; }
        public float Amount { get; set; }
        public float Interest { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime Deadline { get; set; }
        public int AccountId { get; set; }
    }
}
