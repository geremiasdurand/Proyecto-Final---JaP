using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class LogicaProducto
    {
        CapaDatos.RepositorioProducto repositorio;

        public LogicaProducto()
        {
            repositorio = new CapaDatos.RepositorioProducto();
        }

        public void Agregar(Entidades.Producto entidad)
        {
            repositorio.Agregar(entidad);
        }

        public void Eliminar(int productoId)
        {
            repositorio.Eliminar(productoId);
        }

        public void Modificar(Entidades.Producto entidad)
        {
            repositorio.Modificar(entidad);
        }

        public Entidades.Producto Buscar(int productoId)
        {
            return repositorio.Buscar(productoId);
        }

        public List<Entidades.Producto> ListarTodos()
        {
            return repositorio.ListarTodos();
        }
    }
}
