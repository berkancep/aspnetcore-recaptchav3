using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace reCAPTCHAv3.Models
{
    public class LoginModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public bool RememberMe { get; set; }
    }
}
