using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuyerAPI.Models
{
    public class Response
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public dynamic Data { get; set; }
        public ProblemDetails problemDetails { get; set; }
    }
}
