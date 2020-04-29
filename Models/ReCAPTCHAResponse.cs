using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace reCAPTCHAv3.Models
{
    public class ReCAPTCHAResponse
    {
        public bool Success { get; set; }
        public double Score { get; set; }
        public string Action { get; set; }
        public DateTime Challenge_Ts { get; set; }
        public string Hostname { get; set; }
    }
}
