using System;
namespace BackEnd.Models
{
    public partial class Accounts
    {
        public Accounts()
        {
        }
        public int ID { get; set; }
        public string Number { get; set; }
        public float Balance { get; set; }
        public int ClientId { get; set; }
    }
}
