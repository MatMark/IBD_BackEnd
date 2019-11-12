using System;
namespace BackEnd.Models
{
    public partial class Loans
    {
        public Loans()
        {
        }
        public int ID { get; set; }
        public float Amount { get; set; }
        public float Interest { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime Deadline { get; set; }
        public int AccountId { get; set; }
    }
}
