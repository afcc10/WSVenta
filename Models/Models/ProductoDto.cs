using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class ProductoDto
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Costo { get; set; }
        public int CantidadInventario { get; set; }

        public virtual ICollection<ConceptoDto> Conceptos { get; set; }
    }
}
