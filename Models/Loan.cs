using System;
namespace BackEnd.Models
{
    public partial class Loan
    {
        public Loan()
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
