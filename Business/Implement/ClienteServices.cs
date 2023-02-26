using AutoMapper;
using Business.Contract;
using Common.Utilities.Services;
using DataAccess.Core.Contract;
using Microsoft.AspNetCore.Mvc;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implement
{
    public class ClienteServices : IClienteServices
    {
        #region Propierties
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public ClienteServices(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }
        #endregion

        public Task<Response> GetAll()
        {
            var result =  _clienteRepository.GetAll();

            return result;
        }

        public Task<Response> AddCliente(ClienteDto clienteDto)
        {
            var result = _clienteRepository.AddCliente(clienteDto);

            return result;
        }

        public Task<Response> UpdateCliente(ClienteDto clienteDto)
        {
            var result = _clienteRepository.UpdateCliente(clienteDto);

            return result;
        }

        public Task<Response> DeleteCliente(int idCliente)
        {
            var result = _clienteRepository.DeleteCliente(idCliente);

            return result;
        }
    }
}
