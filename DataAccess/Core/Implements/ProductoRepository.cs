using AutoMapper;
using Common.Utilities.Resource;
using Common.Utilities.Services;
using DataAccess.Core.Contract;
using DataAccess.Models;
using Microsoft.Extensions.Logging;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Core.Implements
{
    public class ProductoRepository : IProductoRepository
    {
        #region Propierties
        private readonly VentaRealContext context;
        private readonly ILogger<ProductoRepository> _logger;
        private readonly IMapper _mapper;
        #endregion

        #region Contructor
        public ProductoRepository(VentaRealContext context, ILogger<ProductoRepository> logger, IMapper mapper)
        {
            this.context = context;
            this._logger = logger;
            _mapper = mapper;
        }

        #endregion

        public async Task<Response> get()
        {
            Response response = new();
            try
            {
                List<ProductoDto> list = new List<ProductoDto>();

                var listProducto = context.Productos.OrderByDescending(d => d.Id).ToList();

                list = listProducto.ConvertAll(x => new ProductoDto()
                {
                    Id = x.Id,
                    Nombre = x.Nombre,
                    PrecioUnitario= x.PrecioUnitario,
                    Costo = x.Costo
                });

                response = new()
                {
                    Exito = (int)HttpStatusCode.OK,
                    Data = list,
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
    }
}
