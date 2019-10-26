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
        public int HomeNumber { get; set; }
        public int? ApartmentNumber { get; set; }
        public string PostCode { get; set; }
    }
}
