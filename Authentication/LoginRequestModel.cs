using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Authentication
{
    public partial class LoginRequestModel
    {
        public LoginRequestModel()
        {
        }

        public string Email { get; set; }
        public string Password { get; set; }
    }
}
