using System;
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
    }
}
