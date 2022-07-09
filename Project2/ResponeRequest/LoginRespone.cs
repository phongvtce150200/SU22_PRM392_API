using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.ResponeRequest
{
    public class LoginRespone
    {
        public bool Succesful { get; set; }
        public string Error { get; set; }
        public string Token { get; set; }
    }
}
