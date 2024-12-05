using System;
using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using Api_proyecto_final.Models;

namespace Api_proyecto_final.Controllers
{
    [RoutePrefix("api/notices")]
    public class NoticesController : ApiController
    {
        private readonly AppointmentContext _db;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public NoticesController()
        {
            _db = new AppointmentContext();
        }

        // GET: api/notices
        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> GetAllNotices()
        {
            try
            {
                log.Info("Método GetAllNotices llamado");
                var notices = await _db.Notices.ToListAsync();
                log.Info($"Recuperados {notices.Count} avisos");
                return Ok(notices);
            }
            catch (Exception ex)
            {
                log.Error("Error en GetAllNotices", ex);
                return InternalServerError(ex);
            }
        }

        // GET: api/notices/5
        [HttpGet]
        [Route("{id:long}", Name = "GetNotice")]
        public async Task<IHttpActionResult> GetNotice(long id)
        {
            try
            {
                log.Info($"Método GetNotice llamado para el id: {id}");
                var notice = await _db.Notices.FindAsync(id);
                if (notice == null)
                {
                    log.Warn($"No se encontró el aviso con id {id}");
                    return NotFound();
                }
                return Ok(notice);
            }
            catch (Exception ex)
            {
                log.Error($"Error en GetNotice para el id: {id}", ex);
                return InternalServerError(ex);
            }
        }

        // POST: api/notices
        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> CreateNotice([FromBody] Notice notice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                log.Info("Método CreateNotice llamado");
                notice.PublishedDate = DateTime.Now;
                notice.IsActive = true;
                _db.Notices.Add(notice);
                await _db.SaveChangesAsync();
                log.Info($"Aviso creado con id: {notice.Id}");
                return CreatedAtRoute("GetNotice", new { id = notice.Id }, notice);
            }
            catch (Exception ex)
            {
                log.Error("Error en CreateNotice", ex);
                return InternalServerError(ex);
            }
        }

        // PUT: api/notices/5
        [HttpPut]
        [Route("{id:long}")]
        public async Task<IHttpActionResult> UpdateNotice(long id, [FromBody] Notice notice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != notice.Id)
            {
                return BadRequest("El ID en la URL no coincide con el ID en el cuerpo de la solicitud.");
            }

            try
            {
                log.Info($"Método UpdateNotice llamado para el id: {id}");

                var existingNotice = await _db.Notices.FindAsync(id);
                if (existingNotice == null)
                {
                    log.Warn($"No se encontró el aviso con id {id} para actualizar");
                    return NotFound();
                }

                existingNotice.Title = notice.Title;
                existingNotice.Content = notice.Content;
                existingNotice.IsActive = notice.IsActive;
                // No actualizamos PublishedDate para mantener la fecha original de publicación

                _db.Entry(existingNotice).State = EntityState.Modified;
                await _db.SaveChangesAsync();

                log.Info($"Aviso con id {id} actualizado exitosamente");
                return StatusCode(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                log.Error($"Error en UpdateNotice para el id: {id}", ex);
                return InternalServerError(ex);
            }
        }

        // DELETE: api/notices/5
        [HttpDelete]
        [Route("{id:long}")]
        public async Task<IHttpActionResult> DeleteNotice(long id)
        {
            try
            {
                log.Info($"Método DeleteNotice llamado para el id: {id}");
                var notice = await _db.Notices.FindAsync(id);
                if (notice == null)
                {
                    log.Warn($"No se encontró el aviso con id {id} para eliminar");
                    return NotFound();
                }

                _db.Notices.Remove(notice);
                await _db.SaveChangesAsync();
                log.Info($"Aviso con id {id} eliminado exitosamente");
                return StatusCode(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                log.Error($"Error en DeleteNotice para el id: {id}", ex);
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





