using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Validadores;

namespace Entidades
{
    public class Administradores : ValidationAttribute
    {
        public int IdAdministrador { get; set; }

        public Administradores() {
            Rol = Enumerados.Indefinido;
        }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string Apellido { get; set; }

        [Required]
        [Range(10000000, 99999999)]
        public int CI { get; set; }

        [Required]
        [StringLength(50)]
        public string Domicilio { get; set; }

        public DateTime FechaDeNacimiento { get; set; }

        [Required]
        [StringLength(50)]
        public string Usuario { get; set; }

        [Required]
        [StringLength(50)]
        [DataType(DataType.Password)]
        public string Contraseña { get; set; }

        public Enumerados Rol { get; set; }
    }
}
