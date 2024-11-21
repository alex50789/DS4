using ApiCalculadora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiCalculadora.Controllers
{ 

public class OperacionesController : ApiController
{
        private CalculadoraContext context = new CalculadoraContext();

        // GET api/operaciones
        [HttpGet]
        public IHttpActionResult GetOperaciones(string tipo = null)
        {
            List<Operaciones> operaciones;

            if (string.IsNullOrEmpty(tipo))
            {
                operaciones = context.Operaciones.ToList(); // Obtener todas las operaciones
            }
            else
            {
                operaciones = context.Operaciones
                                      .Where(o => o.Tipo == tipo)

                                      .ToList(); // Obtener operaciones por tipo
            }

            return Ok(operaciones); // Retornar la lista de operaciones
        }

        // POST api/operaciones
        [HttpPost]
        public IHttpActionResult PostOperacion([FromBody] Operaciones operacion)
        {
            if (operacion == null)
            {
                return BadRequest("Operación no puede ser nula.");
            }

            context.Operaciones.Add(operacion); // Agregar la nueva operación
            context.SaveChanges(); // Guardar los cambios en la base de datos

            return CreatedAtRoute("DefaultApi", new { id = operacion.Id }, operacion); // Retornar la operación creada
        }
    }
}

