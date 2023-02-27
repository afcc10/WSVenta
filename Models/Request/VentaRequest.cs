using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Request
{
    public class VentaRequest
    {
        public VentaRequest()
        {
            this.conceptos = new List<Concepto>();
        }

        public int IdCliente { get; set; }        
        public List<Concepto> conceptos { get; set; }
    }

    public class Concepto
    {
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Importe { get; set; }
        public int Idproducto { get; set; }
    }
}
