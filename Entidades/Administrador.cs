using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Validadores;
using System.ComponentModel.DataAnnotations;

namespace Entidades
{
    public class Administrador : ValidationAttribute
    {
        public int IdAdministrador { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string Apellido { get; set; }

        public int CI { get; set; }

        [Required]
        [StringLength(50)]
        public string Domicilio { get; set; }

        [ValidadorEdad(18)]
        public DateTime FechaDeNacimiento { get; set; }

        [Required]
        [StringLength(50)]
        public string Usuario { get; set; }

        [Required]
        [StringLength(50)]
        public string Contraseña { get; set; }

        public int Rol { get; set; }
    }
}
