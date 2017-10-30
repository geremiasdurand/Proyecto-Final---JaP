namespace CapaDatos.ModeloBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LineaFactura")]
    public partial class LineaFactura
    {
        [Key]
        public int IdLineaFactura { get; set; }

        public int IdProducto { get; set; }

        public int Cantidad { get; set; }

        public int IdFactura { get; set; }

        public virtual Factura Factura { get; set; }

        public virtual Producto Producto { get; set; }
    }
}
