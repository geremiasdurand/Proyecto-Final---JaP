using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos.ModeloBase;

namespace CapaDatos
{
    public class RepositorioFactura
    {
        public List<Entidades.Factura> ListarTodos()
        {
            using (ConexionDB bd = new ConexionDB())
            {
                var lista = from tabla in bd.Facturas
                            select new Entidades.Factura()
                            {
                                Id = tabla.Id,
                                IdCliente = tabla.IdCliente,
                                MontoTotal = tabla.MontoTotal,
                            };

                return lista.ToList();
            }
        }

        public void Agregar(Entidades.Factura factura)
        {
            using (ConexionDB bd = new ConexionDB())
            {
                var nuevaEntidad = new Factura
                {
                    IdCliente = factura.IdCliente,
                    MontoTotal = factura.MontoTotal,
                };
                bd.Facturas.Add(nuevaEntidad);
                bd.SaveChanges();
            }
        }

        public Entidades.Factura Buscar(Entidades.Factura factura)
        {
            Entidades.Factura resultado = null;

            using (ConexionDB bd = new ConexionDB())
            {
                var entidadABuscar = bd.Facturas.Find(factura.Id);

                if (entidadABuscar != null)
                {
                    resultado = new Entidades.Factura
                    {
                        Id = factura.Id,
                        IdCliente = factura.IdCliente,
                        MontoTotal = factura.MontoTotal,
                    };
                }
            }

            return resultado;
        }

        public void Modificar(Entidades.Factura factura)
        {
            using (ConexionDB bd = new ConexionDB())
            {
                var buscarEntidad = bd.Facturas.Find(factura.Id);

                if (buscarEntidad != null)
                {
                    buscarEntidad.IdCliente = factura.IdCliente;
                    buscarEntidad.MontoTotal = factura.MontoTotal;
                    bd.SaveChanges();
                }
            }
        }

        public void Eliminar(Entidades.Factura factura)
        {
            using (ConexionDB bd = new ConexionDB())
            {
                var buscarEntidad = bd.Facturas.Find(factura.Id);

                if (buscarEntidad != null)
                {
                    bd.Facturas.Remove(buscarEntidad);
                    bd.SaveChanges();
                }
            }
        }
    }
}
