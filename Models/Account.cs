using System;
using System.Collections.Generic;

namespace BackEnd.Models
{
    public partial class Account
    {
        public Account()
        {
        }
        public int Id { get; set; }
        public string Number { get; set; }
        public float Balance { get; set; }
        public int ClientId { get; set; }

        public Client Client { get; set; }
        public ICollection<Transfer> Transfers { get; set; }
        public ICollection<Investment> Investments { get; set; }
        public ICollection<Loan> Loans { get; set; }

    }
}
