namespace CapaDatos.ModeloBase
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ConexionDB : DbContext
    {
        public ConexionDB()
            : base("name=ConexionDB")
        {
        }

        public virtual DbSet<Administradore> Administradores { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Factura> Facturas { get; set; }
        public virtual DbSet<LineaFactura> LineaFacturas { get; set; }
        public virtual DbSet<Producto> Productoes { get; set; }
        public virtual DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administradore>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Administradore>()
                .Property(e => e.Apellido)
                .IsUnicode(false);

            modelBuilder.Entity<Administradore>()
                .Property(e => e.Domicilio)
                .IsUnicode(false);

            modelBuilder.Entity<Administradore>()
                .Property(e => e.Usuario)
                .IsUnicode(false);

            modelBuilder.Entity<Administradore>()
                .Property(e => e.Contraseña)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.Apellido)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.Domicilio)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .HasMany(e => e.Facturas)
                .WithRequired(e => e.Cliente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Factura>()
                .HasMany(e => e.LineaFacturas)
                .WithRequired(e => e.Factura)
                .HasForeignKey(e => e.IdFactura)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Producto>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Producto>()
                .Property(e => e.Marca)
                .IsUnicode(false);

            modelBuilder.Entity<Producto>()
                .HasMany(e => e.LineaFacturas)
                .WithRequired(e => e.Producto)
                .HasForeignKey(e => e.IdProducto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Role>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.Administradores)
                .WithRequired(e => e.Role)
                .WillCascadeOnDelete(false);
        }
    }
}
