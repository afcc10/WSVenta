using Common.Utilities.Services;
using Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contract
{
    public interface IVentaServices
    {
        Task<Response> add(VentaRequest ventaRequest);
    }
}
