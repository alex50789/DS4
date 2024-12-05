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
    [RoutePrefix("api/workers")]
    public class WorkersController : ApiController
    {
        private readonly AppointmentContext _db;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public WorkersController()
        {
            _db = new AppointmentContext();
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAllWorkers()
        {
            try
            {
                log.Info("GetAllWorkers method called");
                var workers = _db.Workers.ToList();
                log.Info($"Retrieved {workers.Count} workers");
                return Ok(workers);
            }
            catch (Exception ex)
            {
                log.Error("Error in GetAllWorkers", ex);
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("{id:long}", Name = "GetWorker")]
        public async Task<IHttpActionResult> GetWorker(long id)
        {
            try
            {
                log.Info($"GetWorker method called with id: {id}");
                Worker worker = await _db.Workers.FindAsync(id);
                if (worker == null)
                {
                    log.Warn($"Worker with id {id} not found");
                    return NotFound();
                }
                return Ok(worker);
            }
            catch (Exception ex)
            {
                log.Error($"Error in GetWorker for id: {id}", ex);
                return InternalServerError(ex);
            }
        }

        [HttpPut]
        [Route("{id:long}")]
        public async Task<IHttpActionResult> UpdateWorker(long id, [FromBody] Worker worker)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != worker.Id)
            {
                return BadRequest("El ID en la URL no coincide con el ID en el cuerpo de la solicitud.");
            }

            try
            {
                log.Info($"Método UpdateWorker llamado para el id: {id}");

                // Obtener el trabajador existente de la base de datos
                var existingWorker = await _db.Workers.FindAsync(id);
                if (existingWorker == null)
                {
                    log.Warn($"No se encontró el trabajador con id {id} para actualizar");
                    return NotFound();
                }

                // Actualizar las propiedades del trabajador existente
                existingWorker.Name = worker.Name;
                existingWorker.Email = worker.Email;
                existingWorker.Password = worker.Password;

                // Marcar la entidad como modificada
                _db.Entry(existingWorker).State = EntityState.Modified;

                // Intentar guardar los cambios
                await _db.SaveChangesAsync();

                log.Info($"Trabajador con id {id} actualizado exitosamente");
                return StatusCode(HttpStatusCode.NoContent);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                log.Error($"Error de concurrencia al actualizar el trabajador {id}", ex);
                if (!WorkerExists(id))
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
                log.Error($"Error en UpdateWorker para el id: {id}", ex);
                return InternalServerError(ex);
            }
        }

        private bool WorkerExists(long id)
        {
            return _db.Workers.Count(e => e.Id == id) > 0;
        }


        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> CreateWorker([FromBody] Worker worker)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                log.Info("CreateWorker method called");
                _db.Workers.Add(worker);
                await _db.SaveChangesAsync();
                log.Info($"Worker created with id: {worker.Id}");
                return CreatedAtRoute("GetWorker", new { id = worker.Id }, worker);
            }
            catch (Exception ex)
            {
                log.Error("Error in CreateWorker", ex);
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        [Route("{id:long}")]
        public async Task<IHttpActionResult> DeleteWorker(long id)
        {
            try
            {
                log.Info($"DeleteWorker method called for id: {id}");
                Worker worker = await _db.Workers.FindAsync(id);
                if (worker == null)
                {
                    log.Warn($"Worker with id {id} not found for deletion");
                    return NotFound();
                }

                _db.Workers.Remove(worker);
                await _db.SaveChangesAsync();
                log.Info($"Worker with id {id} deleted successfully");
                return StatusCode(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                log.Error($"Error in DeleteWorker for id: {id}", ex);
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
