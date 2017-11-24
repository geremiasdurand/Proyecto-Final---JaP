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

        public Entidades.Factura Buscar(int facturaId)
        {
            Entidades.Factura resultado = null;

            using (ConexionDB bd = new ConexionDB())
            {
                var entidadABuscar = bd.Facturas.Find(facturaId);

                if (entidadABuscar != null)
                {
                    resultado = new Entidades.Factura
                    {
                        Id = entidadABuscar.Id,
                        IdCliente = entidadABuscar.IdCliente,
                        MontoTotal = entidadABuscar.MontoTotal,
                    };
                }
            }

            return resultado;
        }

        public void Modificar(int facturaId)
        {
            using (ConexionDB bd = new ConexionDB())
            {
                var buscarEntidad = bd.Facturas.Find(facturaId);

                if (buscarEntidad != null)
                {
                    buscarEntidad.IdCliente = buscarEntidad.IdCliente;
                    buscarEntidad.MontoTotal = buscarEntidad.MontoTotal;
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
