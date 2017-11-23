using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos.ModeloBase;

namespace CapaDatos
{
    public class RepositorioProducto
    {
        public List<Entidades.Producto> ListarTodos()
        {
            using (ConexionDB bd = new ConexionDB())
            {
                var lista = from tabla in bd.Productoes
                            select new Entidades.Producto()
                            {
                                Id = tabla.Id,
                                Nombre = tabla.Nombre,
                                Marca = tabla.Marca,
                                PrecioPorUnidad = tabla.PrecioPorUnidad,
                            };

                return lista.ToList();
            }
        }

        public void Agregar(Entidades.Producto Producto)
        {
            using (ConexionDB bd = new ConexionDB())
            {
                var nuevaEntidad = new Producto
                {
                    Nombre = Producto.Nombre,
                    Marca = Producto.Marca,
                    PrecioPorUnidad = Producto.PrecioPorUnidad,
                };
                bd.Productoes.Add(nuevaEntidad);
                bd.SaveChanges();
            }
        }

        public Entidades.Producto Buscar(int productoId)
        {
            Entidades.Producto resultado = null;

            using (ConexionDB bd = new ConexionDB())
            {
                var entidadABuscar = bd.Productoes.Find(productoId);

                if (entidadABuscar != null)
                {
                    resultado = new Entidades.Producto
                    {
                        Id = entidadABuscar.Id,
                        Nombre = entidadABuscar.Nombre,
                        Marca = entidadABuscar.Marca,
                        PrecioPorUnidad = entidadABuscar.PrecioPorUnidad,
                    };
                }
            }

            return resultado;
        }

        public void Modificar(Entidades.Producto Producto)
        {
            using (ConexionDB bd = new ConexionDB())
            {
                var buscarEntidad = bd.Productoes.Find(Producto.Id);

                if (buscarEntidad != null)
                {
                    buscarEntidad.Nombre = Producto.Nombre;
                    buscarEntidad.Marca = Producto.Marca;
                    buscarEntidad.PrecioPorUnidad = Producto.PrecioPorUnidad;
                    bd.SaveChanges();
                }
            }
        }

        public void Eliminar(int productoId)
        {
            using (ConexionDB bd = new ConexionDB())
            {
                var buscarEntidad = bd.Productoes.Find(productoId);

                if (buscarEntidad != null)
                {
                    bd.Productoes.Remove(buscarEntidad);
                    bd.SaveChanges();
                }
            }
        }
    }
}
