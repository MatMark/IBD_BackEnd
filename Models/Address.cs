using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models
{
    public partial class Address
    {
        public Address()
        {
        }

        public int Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public short HomeNumber { get; set; }
        public short? ApartmentNumber { get; set; }
        public string PostCode { get; set; }

        //public Clients Clients { get; set; }
        //public Transfers IdTransfersNavigation { get; set; }
    }
}
