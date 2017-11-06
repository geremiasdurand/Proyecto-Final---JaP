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

        public int IdProducto { get; set; }

        public int Cantidad { get; set; }

        public int IdFactura { get; set; }
    }
}
