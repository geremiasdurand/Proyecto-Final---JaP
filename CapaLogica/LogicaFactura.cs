using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class LogicaFactura
    {
        CapaDatos.RepositorioFactura repositorio;

        public LogicaFactura()
        {
            repositorio = new CapaDatos.RepositorioFactura();
        }

        public void Agregar(Entidades.Factura entidad)
        {
            repositorio.Agregar(entidad);
        }

        public void Eliminar(Entidades.Factura entidad)
        {
            repositorio.Eliminar(entidad);
        }

        public void Modificar(Entidades.Factura entidad)
        {
            repositorio.Modificar(entidad);
        }

        public Entidades.Factura Buscar(Entidades.Factura entidad)
        {
            return repositorio.Buscar(entidad);
        }

        public List<Entidades.Factura> ListarTodos()
        {
            return repositorio.ListarTodos();
        }
    }
}
