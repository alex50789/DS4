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
    [RoutePrefix("api/services")]
    public class ServicesController : ApiController
    {
        private readonly AppointmentContext _db;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ServicesController()
        {
            _db = new AppointmentContext();
        }

        // GET: api/services
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAllServices()
        {
            try
            {
                log.Info("GetAllServices method called");
                var services = _db.Services.ToList();
                log.Info($"Retrieved {services.Count} services");
                return Ok(services);
            }
            catch (Exception ex)
            {
                log.Error("Error in GetAllServices", ex);
                return InternalServerError(ex);
            }
        }

        // GET: api/services/5
        [HttpGet]
        [Route("{id:long}", Name = "GetService")]
        public async Task<IHttpActionResult> GetService(long id)
        {
            try
            {
                log.Info($"GetService method called with id: {id}");
                Service service = await _db.Services.FindAsync(id);
                if (service == null)
                {
                    log.Warn($"Service with id {id} not found");
                    return NotFound();
                }
                return Ok(service);
            }
            catch (Exception ex)
            {
                log.Error($"Error in GetService for id: {id}", ex);
                return InternalServerError(ex);
            }
        }

        // POST: api/services
        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> CreateService([FromBody] Service service)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                log.Info("CreateService method called");
                _db.Services.Add(service);
                await _db.SaveChangesAsync();
                log.Info($"Service created with id: {service.Id}");
                return CreatedAtRoute("GetService", new { id = service.Id }, service);
            }
            catch (Exception ex)
            {
                log.Error("Error in CreateService", ex);
                return InternalServerError(ex);
            }
        }

        // PUT: api/services/5
        [HttpPut]
        [Route("{id:long}")]
        public async Task<IHttpActionResult> UpdateService(long id, [FromBody] Service service)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != service.Id)
            {
                return BadRequest("El ID en la URL no coincide con el ID en el cuerpo de la solicitud.");
            }

            try
            {
                log.Info($"Método UpdateService llamado para el id: {id}");

                // Obtener el servicio existente de la base de datos
                var existingService = await _db.Services.FindAsync(id);
                if (existingService == null)
                {
                    log.Warn($"No se encontró el servicio con id {id} para actualizar");
                    return NotFound();
                }

                // Actualizar las propiedades del servicio existente
                existingService.Name = service.Name;

                // Marcar la entidad como modificada
                _db.Entry(existingService).State = EntityState.Modified;

                // Intentar guardar los cambios
                await _db.SaveChangesAsync();

                log.Info($"Servicio con id {id} actualizado exitosamente");
                return StatusCode(HttpStatusCode.NoContent);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                log.Error($"Error de concurrencia al actualizar el servicio {id}", ex);
                if (!ServiceExists(id))
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
                log.Error($"Error en UpdateService para el id: {id}", ex);
                return InternalServerError(ex);
            }
        }

        private bool ServiceExists(long id)
        {
            return _db.Services.Count(e => e.Id == id) > 0;
        }



        // DELETE: api/services/5
        [HttpDelete]
        [Route("{id:long}")]
        public async Task<IHttpActionResult> DeleteService(long id)
        {
            try
            {
                log.Info($"DeleteService method called for id: {id}");
                Service service = await _db.Services.FindAsync(id);
                if (service == null)
                {
                    log.Warn($"Service with id {id} not found for deletion");
                    return NotFound();
                }

                _db.Services.Remove(service);
                await _db.SaveChangesAsync();
                log.Info($"Service with id {id} deleted successfully");
                return StatusCode(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                log.Error($"Error in DeleteService for id: {id}", ex);
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
