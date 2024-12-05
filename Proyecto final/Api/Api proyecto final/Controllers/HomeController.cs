using System;
using System.Web.Http;

namespace Api_proyecto_final.Controllers
{
    public class HomeController : ApiController
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [HttpGet]
        [Route("")]
        public IHttpActionResult Index()
        {
            try
            {
                log.Info("Home Index method called");
                return Ok(new { message = "API is running" });
            }
            catch (Exception ex)
            {
                log.Error("Error in Home Index", ex);
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("status")]
        public IHttpActionResult Status()
        {
            try
            {
                log.Info("Home Status method called");
                return Ok(new { status = "healthy", timestamp = DateTime.UtcNow });
            }
            catch (Exception ex)
            {
                log.Error("Error in Home Status", ex);
                return InternalServerError(ex);
            }
        }
    }
}