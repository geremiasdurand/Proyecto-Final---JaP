using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos.ModeloBase;

namespace CapaDatos
{
    public class RepositorioLineaFactura
    {
        public List<Entidades.LineaFactura> ListarTodos()
        {
            using (ConexionDB bd = new ConexionDB())
            {
                var lista = from tabla in bd.LineaFacturas
                            select new Entidades.LineaFactura()
                            {
                                IdLineaFactura = tabla.IdLineaFactura,
                                IdFactura = tabla.IdFactura,
                                Cantidad = tabla.Cantidad,
                            };

                foreach (var l in lista)
                {
                    var producto = bd.Productoes.Find(l.Producto.Id);

                    l.Producto = new Entidades.Producto()
                    {
                        Id = producto.Id,
                        Nombre = producto.Nombre,
                        Marca = producto.Marca,
                        PrecioPorUnidad = producto.PrecioPorUnidad,
                    }; 
                }

                return lista.ToList();
            }
        }

        public void Agregar(Entidades.LineaFactura lineafactura)
        {
            using (ConexionDB bd = new ConexionDB())
            {
                var nuevaEntidad = new LineaFactura
                {
                    IdFactura = lineafactura.IdFactura,
                    IdProducto = lineafactura.Producto.Id,
                    Cantidad = lineafactura.Cantidad,

                };
                bd.LineaFacturas.Add(nuevaEntidad);
                bd.SaveChanges();
            }
        }

        public Entidades.LineaFactura Buscar(Entidades.LineaFactura lineafactura)
        {
            Entidades.LineaFactura resultado = null;

            using (ConexionDB bd = new ConexionDB())
            {
                var entidadABuscar = bd.Facturas.Find(lineafactura.IdLineaFactura);

                if (entidadABuscar != null)
                {
                    resultado = new Entidades.LineaFactura
                    {
                        IdLineaFactura = lineafactura.IdLineaFactura,
                        IdFactura = lineafactura.IdFactura,
                        Cantidad = lineafactura.Cantidad,
                    };

                    var producto = bd.Productoes.Find(lineafactura.Producto.Id);

                    resultado.Producto = new Entidades.Producto
                    {
                        Id = producto.Id,
                        Nombre = producto.Nombre,
                        Marca = producto.Marca,
                        PrecioPorUnidad = producto.PrecioPorUnidad,
                    };

                }
            }

            return resultado;
        }

        public void Eliminar(Entidades.LineaFactura lineafactura)
        {
            using (ConexionDB bd = new ConexionDB())
            {
                var buscarEntidad = bd.Facturas.Find(lineafactura.IdLineaFactura);

                if (buscarEntidad != null)
                {
                    bd.Facturas.Remove(buscarEntidad);
                    bd.SaveChanges();
                }
            }
        }

        public void Modificar(Entidades.LineaFactura lineafactura)
        {
            using (ConexionDB bd = new ConexionDB())
            {
                var buscarEntidad = bd.LineaFacturas.Find(lineafactura.IdLineaFactura);

                if (buscarEntidad != null)
                {
                    buscarEntidad.IdProducto = lineafactura.Producto.Id;
                    buscarEntidad.IdFactura = lineafactura.IdFactura;
                    buscarEntidad.Cantidad = lineafactura.Cantidad;
                    bd.SaveChanges();
                }
            }
        }
    }
}
