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
    public class VentaServices : IVentaServices
    {
        #region Propierties
        private readonly IVentaRepository _ventaRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public VentaServices(IVentaRepository ventaRepository, IMapper mapper)
        {
            _ventaRepository = ventaRepository;
            _mapper = mapper;
        }
        #endregion

        public Task<Response> add(VentaRequest ventaRequest)
        {
            var result = _ventaRepository.add(ventaRequest);

            return result;
        }
    }
}
