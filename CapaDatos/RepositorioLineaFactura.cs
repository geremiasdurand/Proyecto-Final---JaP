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
                                IdProducto = tabla.IdProducto,
                                IdFactura = tabla.IdFactura,
                                Cantidad = tabla.Cantidad,
                            };

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
                    IdProducto = lineafactura.IdProducto,
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
                        IdProducto = lineafactura.IdProducto,
                        Cantidad = lineafactura.Cantidad,
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
                    buscarEntidad.IdProducto = lineafactura.IdProducto;
                    buscarEntidad.IdFactura = lineafactura.IdFactura;
                    buscarEntidad.Cantidad = lineafactura.Cantidad;
                    bd.SaveChanges();
                }
            }
        }
    }
}
