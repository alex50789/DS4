using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaginaWeb.Models
{
    public class Appointment
    {
        public long Id { get; set; }
        public long ClientId { get; set; }
        public long WorkerId { get; set; }
        public long ServiceId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; }

        // Navegación
        public virtual Client Client { get; set; }
        public virtual Worker Worker { get; set; }
        public virtual Service Service { get; set; }
    }


}