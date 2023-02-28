using AutoMapper;
using Common.Utilities.Resource;
using Common.Utilities.Services;
using DataAccess.Core.Contract;
using DataAccess.Models;
using Microsoft.Extensions.Logging;
using Models.Models;
using Models.Request;
using System.Net;
using System;
using System.Threading.Tasks;
using WSVenta.Models;
using System.Linq;

namespace DataAccess.Core.Implements
{
    public class VentaRepository : IVentaRepository
    {
        #region Propierties
        private readonly VentaRealContext context;
        private readonly ILogger<VentaRepository> _logger;
        private readonly IMapper _mapper;
        #endregion

        #region Contructor
        public VentaRepository(VentaRealContext context, ILogger<VentaRepository> logger, IMapper mapper)
        {
            this.context = context;
            this._logger = logger;
            _mapper = mapper;
        }

        #endregion

        public async Task<Response> add(VentaRequest ventaRequest)
        {
            Response response = new();
            try
            {
                using (var transaction = context.Database.BeginTransaction()) 
                {
                    try
                    {
                        Venta venta = new()
                        {
                            IdCliente = ventaRequest.IdCliente,
                            Total = ventaRequest.conceptos.Sum(x => x.Cantidad * x.PrecioUnitario),
                            Fecha = DateTime.UtcNow,
                        };

                        context.Add(venta);
                        context.SaveChanges();

                        foreach (var item in ventaRequest.conceptos)
                        {
                            WSVenta.Models.Concepto concepto1 = new()
                            {
                                Cantidad = item.Cantidad,
                                IdProducto = item.Idproducto,
                                PrecioUnitario = item.PrecioUnitario,
                                IdVenta = venta.Id
                            };
                            context.Add(concepto1);
                            await context.SaveChangesAsync();
                        }

                        transaction.Commit();

                        response = new()
                        {
                            Exito = (int)HttpStatusCode.OK,
                            Data = null,
                            Mensaje = Message_es.CreateSucces
                        };
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                    }
                    
                }

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
    }
}
