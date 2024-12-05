using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using Api_proyecto_final.Models;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Http.Description;
using System.Data.Entity.Infrastructure;

namespace Api_proyecto_final.Controllers
{
    [RoutePrefix("api/appointments")]
    public class AppointmentsController : ApiController
    {
        private readonly AppointmentContext _db;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public AppointmentsController()
        {
            _db = new AppointmentContext();
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAllAppointments()
        {
            try
            {
                log.Info("GetAllAppointments method called");
                var appointments = _db.Appointments
                    .Include(a => a.Client)
                    .Include(a => a.Worker)
                    .Include(a => a.Service)
                    .ToList();
                log.Info($"Retrieved {appointments.Count} appointments");
                return Ok(appointments);
            }
            catch (Exception ex)
            {
                log.Error("Error in GetAllAppointments", ex);
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("{id:long}", Name = "GetAppointment")]
        public async Task<IHttpActionResult> GetAppointment(long id)
        {
            try
            {
                log.Info($"GetAppointment method called with id: {id}");
                Appointment appointment = await _db.Appointments
                    .Include(a => a.Client)
                    .Include(a => a.Worker)
                    .Include(a => a.Service)
                    .FirstOrDefaultAsync(a => a.Id == id);

                if (appointment == null)
                {
                    log.Warn($"Appointment with id {id} not found");
                    return NotFound();
                }
                return Ok(appointment);
            }
            catch (Exception ex)
            {
                log.Error($"Error in GetAppointment for id: {id}", ex);
                return InternalServerError(ex);
            }
        }

        [HttpPut]
        [Route("{id:long}")]
        public async Task<IHttpActionResult> UpdateAppointment(long id, [FromBody] Appointment appointment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != appointment.Id)
            {
                return BadRequest("El ID en la URL no coincide con el ID en el cuerpo de la solicitud.");
            }

            try
            {
                log.Info($"Método UpdateAppointment llamado para el id: {id}");

                // Obtener la cita existente de la base de datos
                var existingAppointment = await _db.Appointments.FindAsync(id);
                if (existingAppointment == null)
                {
                    log.Warn($"No se encontró la cita con id {id} para actualizar");
                    return NotFound();
                }

                // Actualizar las propiedades de la cita existente
                existingAppointment.ClientId = appointment.ClientId;
                existingAppointment.WorkerId = appointment.WorkerId;
                existingAppointment.ServiceId = appointment.ServiceId;
                existingAppointment.AppointmentDate = appointment.AppointmentDate;
                existingAppointment.Status = appointment.Status;

                // Marcar la entidad como modificada
                _db.Entry(existingAppointment).State = EntityState.Modified;

                // Intentar guardar los cambios
                await _db.SaveChangesAsync();

                log.Info($"Cita con id {id} actualizada exitosamente");
                return StatusCode(HttpStatusCode.NoContent);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                log.Error($"Error de concurrencia al actualizar la cita {id}", ex);
                if (!AppointmentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    return Conflict();
                }
            }
            catch (Exception ex)
            {
                log.Error($"Error en UpdateAppointment para el id: {id}", ex);
                return InternalServerError(ex);
            }
        }

        private bool AppointmentExists(long id)
        {
            return _db.Appointments.Count(e => e.Id == id) > 0;
        }



        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> CreateAppointment([FromBody] Appointment appointment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                log.Info("CreateAppointment method called");
                _db.Appointments.Add(appointment);
                await _db.SaveChangesAsync();
                log.Info($"Appointment created with id: {appointment.Id}");
                return CreatedAtRoute("GetAppointment", new { id = appointment.Id }, appointment);
            }
            catch (Exception ex)
            {
                log.Error("Error in CreateAppointment", ex);
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        [Route("{id:long}")]
        public async Task<IHttpActionResult> DeleteAppointment(long id)
        {
            try
            {
                log.Info($"DeleteAppointment method called for id: {id}");
                Appointment appointment = await _db.Appointments.FindAsync(id);
                if (appointment == null)
                {
                    log.Warn($"Appointment with id {id} not found for deletion");
                    return NotFound();
                }

                _db.Appointments.Remove(appointment);
                await _db.SaveChangesAsync();
                log.Info($"Appointment with id {id} deleted successfully");
                return StatusCode(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                log.Error($"Error in DeleteAppointment for id: {id}", ex);
                return InternalServerError(ex);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
