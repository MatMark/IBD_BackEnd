using System;
namespace BackEnd.Models
{
    public partial class Transfer
    {
        public Transfer()
        {
        }
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public float Amount { get; set; }
        public string Destination { get; set; }
        public string Title { get; set; }
        public int? AddressId { get; set; }
        public int AccountId { get; set; }
        public string Currency { get; set; }

        public Address Address { get; set; }
        public Account Account { get; set; }

    }
}
