using Business.Contract;
using Common.Utilities.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models.Request;
using System.Net;
using System;
using System.Threading.Tasks;

namespace WSVenta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class VentaController : ControllerBase
    {
        #region Propierties
        private readonly IVentaServices Service;
        private readonly ILogger<VentaController> _logger;
        #endregion

        #region Constructor
        public VentaController(IVentaServices service, ILogger<VentaController> logger)
        {
            Service = service;
            _logger = logger;
        }
        #endregion

        [HttpPost]
        public async Task<Response> Add(VentaRequest ventaRequest)
        {
            Response response = new();
            try
            {
                response = await Service.add(ventaRequest);
                return response;
            }
            catch (Exception ex)
            {
                return new Response
                {
                    Exito = (int)HttpStatusCode.BadRequest,
                    Mensaje = ex.Message
                };
            }
        }
    }
}
