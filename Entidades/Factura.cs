using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Validadores;
using System.ComponentModel.DataAnnotations;

namespace Entidades
{
    public class Factura : ValidationAttribute
    {
        public int Id { get; set; }

        public int IdCliente { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public int MontoTotal { get; set; }

        public List<LineaFactura> ListaDeLineasFactura { get; set; }

        public Factura()
        {
            ListaDeLineasFactura = new List<LineaFactura>();
        }
    }
}
