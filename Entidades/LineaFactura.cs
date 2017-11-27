using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Validadores;
using System.ComponentModel.DataAnnotations;

namespace Entidades
{
    public class LineaFactura : ValidationAttribute
    {
        public int IdLineaFactura { get; set; }

        public Producto Producto{ get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Debe ser un numero mayor a 0")]
        public int Cantidad { get; set; }

        public int IdFactura { get; set; }
    }
}
