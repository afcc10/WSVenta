using Business.Contract;
using Common.Utilities.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models.Request;
using System.Net;

namespace WSVenta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        #region Propierties
        private readonly IUserServices Service;
        private readonly ILogger<UserController> _logger;
        #endregion

        #region Constructor
        public UserController(IUserServices service, ILogger<UserController> logger)
        {
            Service = service;
            _logger = logger;
        }
        #endregion

        [HttpPost("login")]
        public IActionResult Autentificar([FromBody] AuthRequest model)
        {
            Response response = new Response();
            var userResponse = Service.Auth(model);
            if (userResponse == null)
            {
                response.Exito = (int)HttpStatusCode.BadRequest;
                response.Mensaje= "Usuario o contrasena incorrecto";
                return BadRequest(response);
            }

            response.Exito= (int)HttpStatusCode.OK;
            response.Data= userResponse;
                
            return Ok(response);
        }
    }
}
