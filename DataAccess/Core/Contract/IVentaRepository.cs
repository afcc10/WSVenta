using Common.Utilities.Services;
using Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Core.Contract
{
    public interface IVentaRepository
    {
        Task<Response> add(VentaRequest ventaRequest);
    }
}
