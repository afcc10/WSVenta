using Common.Utilities.Services;
using DataAccess.Models;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Core.Contract
{
    public interface IClienteRepository
    {
        Task<Response> GetAll();
        Task<Response> AddCliente(ClienteDto clienteDto);
        Task<Response> UpdateCliente(ClienteDto clienteDto);
        Task<Response> DeleteCliente(int idCliente);
    }
}
