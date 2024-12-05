using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_proyecto_final.Models
{
    public class Client
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}