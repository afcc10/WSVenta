using AutoMapper;
using Business.Contract;
using Common.Utilities.Services;
using DataAccess.Core.Contract;
using DataAccess.Core.Implements;
using Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implement
{
    public class ProductoServices : IProductoServices
    {
        #region Propierties
        private readonly IProductoRepository _productoRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public ProductoServices(IProductoRepository productoRepository, IMapper mapper)
        {
            _productoRepository = productoRepository;
            _mapper = mapper;
        }
        #endregion

        public Task<Response> get()
        {
            var result = _productoRepository.get();

            return result;
        }
    }
}
