using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Required]
        [Range(1, Double.MaxValue,ErrorMessage ="El id debe ser mayor a cero")]        
        public int IdCliente { get; set; }
        [Required]
        [MinLength(1,ErrorMessage ="Debe existir al menos un concepto")]
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
