using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Validadores;
using System.ComponentModel.DataAnnotations;

namespace Entidades
{
    public class Cliente : ValidationAttribute
    {
        public int idCliente { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string Apellido { get; set; }

        [Required]
        [Range(10000000, 999999999999)]
        public int CIoRut { get; set; }

        [Required]
        [StringLength(50)]
        public string Domicilio { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaDeNacimiento { get; set; }
    }
}
