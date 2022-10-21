using System;
using System.Collections.Generic;
using System.Text;

namespace JwtAuthenticationManager.Models
{
    public class AuthenticatonRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
