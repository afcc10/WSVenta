using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class ConceptoDto
    {
        public long Id { get; set; }
        public long IdVenta { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Total { get; set; }
        public long IdProducto { get; set; }

        public virtual ProductoDto IdProductoNavigation { get; set; }
        public virtual VentaDto IdVentaNavigation { get; set; }
    }
}
