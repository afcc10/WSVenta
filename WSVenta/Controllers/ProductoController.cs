using Business.Contract;
using Common.Utilities.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Threading.Tasks;
using System;

namespace WSVenta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        #region Propierties
        private readonly IProductoServices Service;
        private readonly ILogger<ProductoController> _logger;
        #endregion

        #region Constructor
        public ProductoController(IProductoServices service, ILogger<ProductoController> logger)
        {
            Service = service;
            _logger = logger;
        }
        #endregion

        [HttpGet]
        public async Task<Response> Get()
        {
            Response response = new();
            try
            {
                response = await Service.get();
                response.Exito = 200;
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
