using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api_proyecto_final.Controllers
{
    using Api_proyecto_final.Models;
    // Controllers/WorkersController.cs
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.Http.Description;

    [RoutePrefix("api/Workers")]
    public class WorkersController : ApiController
    {
        private AppointmentContext db = new AppointmentContext();

        // GET: api/Workers
        public IQueryable<Worker> GetWorkers()
        {
            return db.Workers;
        }

        // GET: api/Workers/5
        [ResponseType(typeof(Worker))]
        public async Task<IHttpActionResult> GetWorker(long id)
        {
            Worker worker = await db.Workers.FindAsync(id);
            if (worker == null)
            {
                return NotFound();
            }

            return Ok(worker);
        }

        // PUT: api/Workers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutWorker(long id, Worker worker)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != worker.Id)
            {
                return BadRequest();
            }

            db.Entry(worker).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Workers
        [ResponseType(typeof(Worker))]
        public async Task<IHttpActionResult> PostWorker(Worker worker)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Workers.Add(worker);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = worker.Id }, worker);
        }

        // DELETE: api/Workers/5
        [ResponseType(typeof(Worker))]
        public async Task<IHttpActionResult> DeleteWorker(long id)
        {
            Worker worker = await db.Workers.FindAsync(id);
            if (worker == null)
            {
                return NotFound();
            }

            db.Workers.Remove(worker);
            await db.SaveChangesAsync();

            return Ok(worker);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WorkerExists(long id)
        {
            return db.Workers.Count(e => e.Id == id) > 0;
        }
    }
}
