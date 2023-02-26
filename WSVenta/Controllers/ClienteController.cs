using Business.Contract;
using Common.Utilities.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace WSVenta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        #region Propierties
        private readonly IClienteServices Service;
        private readonly ILogger<ClienteController> _logger;
        #endregion

        #region Constructor
        public ClienteController(IClienteServices service, ILogger<ClienteController> logger)
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
                response = await Service.GetAll();
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

        [HttpPost]
        public async Task<Response> AddCliente(ClienteDto cliente)
        {
            Response response = new();
            try
            {
                response = await Service.AddCliente(cliente);
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

        [HttpPut]
        public async Task<Response> UpdateCliente(ClienteDto cliente)
        {
            Response response = new();
            try
            {
                response = await Service.UpdateCliente(cliente);
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

        [HttpDelete]
        public async Task<Response> DeleteCliente(int idCliente)
        {
            Response response = new();
            try
            {
                response = await Service.DeleteCliente(idCliente);
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
