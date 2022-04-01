using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

namespace StudentsBaseAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BaseController : ControllerBase
    {
        #region Private fields

        private readonly ILogger<BaseController> _logger;

        #endregion

        #region Public constructor

        public BaseController(ILogger<BaseController> logger)
        {
            _logger = logger;
        }

        #endregion

        #region Public methods

        protected async Task<ActionResult> TryReturnOk<TReturn>(Func<Task<TReturn>> function)
        {
            try
            {
                return Ok(await function());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                _logger.LogError(ex.StackTrace);
                if (ex.InnerException != null)
                {
                    _logger.LogError(ex.InnerException.Message);
                    _logger.LogError(ex.InnerException.StackTrace);
                }
                return InternalServerError(ex);
            }
        }

        protected ObjectResult InternalServerError(Exception ex)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
        }

        #endregion
    }
}
