using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiCalculadora.Models
{
    public class Operaciones
    {
        public int Id { get; set; }
        public string Operacion { get; set; }
        public string Resultado { get; set; }
        public DateTime fecha_operacion { get; set; }
        public string Tipo { get; set; }
    }
}