using Common.Utilities.Services;
using Microsoft.AspNetCore.Mvc;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contract
{
    public interface IClienteServices
    {
        Task<Response> GetAll();
        Task<Response> AddCliente(ClienteDto clienteDto);
        Task<Response> UpdateCliente(ClienteDto clienteDto);
        Task<Response> DeleteCliente(int idCliente);
    }
}
