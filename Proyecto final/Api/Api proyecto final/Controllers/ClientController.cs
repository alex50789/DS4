using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using Api_proyecto_final.Models;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Http.Description;
using global::Api_proyecto_final.Models;
using System.Data.Entity.Infrastructure;

namespace Api_proyecto_final.Controllers
{
    namespace Api_proyecto_final.Controllers
    {
        [RoutePrefix("api/clients")]
        public class ClientsController : ApiController
        {
            private readonly AppointmentContext _db;
            private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            public ClientsController()
            {
                _db = new AppointmentContext();
            }

            // GET: api/clients
            [HttpGet]
            [Route("")]
            public IHttpActionResult GetAllClients()
            {
                try
                {
                    log.Info("GetAllClients method called");
                    var clients = _db.Clients.ToList();
                    log.Info($"Retrieved {clients.Count} clients");
                    return Ok(clients);
                }
                catch (Exception ex)
                {
                    log.Error("Error in GetAllClients", ex);
                    return InternalServerError(ex);
                }
            }

            // GET: api/clients/5
            [HttpGet]
            [Route("{id:long}", Name = "GetClient")]
            public async Task<IHttpActionResult> GetClient(long id)
            {
                try
                {
                    log.Info($"GetClient method called with id: {id}");
                    Client client = await _db.Clients.FindAsync(id);
                    if (client == null)
                    {
                        log.Warn($"Client with id {id} not found");
                        return NotFound();
                    }
                    return Ok(client);
                }
                catch (Exception ex)
                {
                    log.Error($"Error in GetClient for id: {id}", ex);
                    return InternalServerError(ex);
                }
            }

            // POST: api/clients
            [HttpPost]
            [Route("")]
            public async Task<IHttpActionResult> CreateClient([FromBody] Client client)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                try
                {
                    log.Info("CreateClient method called");
                    _db.Clients.Add(client);
                    await _db.SaveChangesAsync();
                    log.Info($"Client created with id: {client.Id}");
                    return CreatedAtRoute("GetClient", new { id = client.Id }, client);
                }
                catch (Exception ex)
                {
                    log.Error("Error in CreateClient", ex);
                    return InternalServerError(ex);
                }
            }

            [HttpPost]
            [Route("login")]
            public async Task<IHttpActionResult> Login([FromBody] LoginModel model)
            {
                try
                {
                    log.Info($"Login attempt for email: {model.Email}");
                    var client = await _db.Clients.FirstOrDefaultAsync(c => c.Email == model.Email && c.Password == model.Password);
                    if (client == null)
                    {
                        log.Warn($"Login failed for email: {model.Email}");
                        return NotFound();
                    }
                    log.Info($"Login successful for client id: {client.Id}");
                    return Ok(client);
                }
                catch (Exception ex)
                {
                    log.Error($"Error in Client Login for email: {model.Email}", ex);
                    return InternalServerError(ex);
                }
            }



            // PUT: api/clients/5
            [HttpPut]
            [Route("{id:long}")]
            public async Task<IHttpActionResult> UpdateClient(long id, [FromBody] Client client)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (id != client.Id)
                {
                    return BadRequest("El ID en la URL no coincide con el ID en el cuerpo de la solicitud.");
                }

                try
                {
                    log.Info($"Método UpdateClient llamado para el id: {id}");

                    // Obtener el cliente existente de la base de datos
                    var existingClient = await _db.Clients.FindAsync(id);
                    if (existingClient == null)
                    {
                        log.Warn($"No se encontró el cliente con id {id} para actualizar");
                        return NotFound();
                    }

                    // Actualizar las propiedades del cliente existente
                    existingClient.Name = client.Name;
                    existingClient.Email = client.Email;
                    existingClient.Password = client.Password;

                    // Marcar la entidad como modificada
                    _db.Entry(existingClient).State = EntityState.Modified;

                    // Intentar guardar los cambios
                    await _db.SaveChangesAsync();

                    log.Info($"Cliente con id {id} actualizado exitosamente");
                    return StatusCode(HttpStatusCode.NoContent);
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    log.Error($"Error de concurrencia al actualizar el cliente {id}", ex);
                    if (!ClientExists(id))
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
                    log.Error($"Error en UpdateClient para el id: {id}", ex);
                    return InternalServerError(ex);
                }
            }

            private bool ClientExists(long id)
            {
                return _db.Clients.Count(e => e.Id == id) > 0;
            }


            // DELETE: api/clients/5
            [HttpDelete]
            [Route("{id:long}")]
            public async Task<IHttpActionResult> DeleteClient(long id)
            {
                try
                {
                    log.Info($"DeleteClient method called for id: {id}");
                    Client client = await _db.Clients.FindAsync(id);
                    if (client == null)
                    {
                        log.Warn($"Client with id {id} not found for deletion");
                        return NotFound();
                    }

                    _db.Clients.Remove(client);
                    await _db.SaveChangesAsync();
                    log.Info($"Client with id {id} deleted successfully");
                    return StatusCode(HttpStatusCode.NoContent);
                }
                catch (Exception ex)
                {
                    log.Error($"Error in DeleteClient for id: {id}", ex);
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


}
