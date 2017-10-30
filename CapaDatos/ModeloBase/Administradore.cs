namespace CapaDatos.ModeloBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Administradore
    {
        [Key]
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

        [Column(TypeName = "date")]
        public DateTime FechaDeNacimiento { get; set; }

        [Required]
        [StringLength(50)]
        public string Usuario { get; set; }

        [Required]
        [StringLength(50)]
        public string Contraseña { get; set; }

        public int Rol { get; set; }

        public virtual Role Role { get; set; }
    }
}
