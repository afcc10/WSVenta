using AutoMapper;
using Common.Utilities.Resource;
using Common.Utilities.Services;
using DataAccess.Core.Contract;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WSVenta.Models;

namespace DataAccess.Core.Implements
{
    public class ClienteRepository : IClienteRepository
    {
        #region Propierties
        private readonly VentaRealContext context;
        private readonly ILogger<ClienteRepository> _logger;
        private readonly IMapper _mapper;
        #endregion

        #region Contructor
        public ClienteRepository(VentaRealContext context,ILogger<ClienteRepository> logger, IMapper mapper)
        {
            this.context = context;
            this._logger = logger;
            _mapper = mapper;
        }

        #endregion

        #region Method

        public async Task<Response> GetAll()
        {
            Response response = new();
            try
            {
                List<ClienteDto> list = new List<ClienteDto>();

                var listCliente = context.Clientes.OrderByDescending(d=> d.Id).ToList();

                list = listCliente.ConvertAll(x => new ClienteDto()
                {
                    Id = x.Id,
                    Nombre = x.Nombre,
                });

                response = new()
                {
                    Exito = (int)HttpStatusCode.OK,
                    Data= list,
                    Mensaje = Message_es.ConsultaExitosa
                };

                return await Task.FromResult(response);
            }
            catch (Exception ex)
            {
                return new Response
                {
                    Exito = (int)HttpStatusCode.NotFound,
                    Data = null,
                    Mensaje = ex.Message
                };
            }
        }

        public async Task<Response> AddCliente(ClienteDto clienteDto)
        {
            Response response = new();
            try
            {
                Cliente cliente = new();

                cliente = _mapper.Map<Cliente>(clienteDto);

                context.Add(cliente);
                await context.SaveChangesAsync();

                response = new()
                {
                    Exito = (int)HttpStatusCode.OK,
                    Data = cliente,
                    Mensaje = Message_es.CreateSucces
                };

                return await Task.FromResult(response);
            }
            catch (Exception ex)
            {
                return new Response
                {
                    Exito = (int)HttpStatusCode.NotFound,
                    Data = null,
                    Mensaje = ex.Message
                };
            }
        }

        public async Task<Response> UpdateCliente(ClienteDto clienteDto)
        {
            Response response = new();
            try
            {
                var cliente = context.Clientes.Where(x => x.Id == clienteDto.Id).AsNoTracking().FirstOrDefault();

                cliente = _mapper.Map<Cliente>(clienteDto);

                context.Update(cliente);
                await context.SaveChangesAsync();

                response = new()
                {
                    Exito = (int)HttpStatusCode.OK,
                    Data = cliente,
                    Mensaje = Message_es.UpdateSucces
                };

                return await Task.FromResult(response);
            }
            catch (Exception)
            {
                return new Response
                {
                    Exito = (int)HttpStatusCode.BadRequest,
                    Data = null,
                    Mensaje = Message_es.UpdateError
                };
            }
        }

        public async Task<Response> DeleteCliente(int idCliente)
        {
            Response response = new();
            try
            {
                var cliente = context.Clientes.Where(x => x.Id == idCliente).AsNoTracking().FirstOrDefault();

                context.Remove(cliente);
                await context.SaveChangesAsync();

                response = new()
                {
                    Exito = (int)HttpStatusCode.OK,
                    Data = cliente,
                    Mensaje = Message_es.DeleteSucces
                };

                return await Task.FromResult(response);
            }
            catch (Exception)
            {
                return new Response
                {
                    Exito = (int)HttpStatusCode.BadRequest,
                    Data = null,
                    Mensaje = Message_es.DeleteError
                };
            }
        }

        #endregion
    }
}
