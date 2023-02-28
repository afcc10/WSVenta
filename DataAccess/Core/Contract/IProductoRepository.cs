using Common.Utilities.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Core.Contract
{
    public interface IProductoRepository
    {
        Task<Response> get();
    }
}
