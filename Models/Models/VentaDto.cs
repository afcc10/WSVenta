using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class VentaDto
    {
        public long Id { get; set; }
        public DateTime Fecha { get; set; }
        public long IdCliente { get; set; }
        public decimal? Total { get; set; }

        public virtual ClienteDto IdClienteNavigation { get; set; }
        public virtual ICollection<ConceptoDto> Conceptos { get; set; }
    }
}
