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

        public void Eliminar(int facturaId)
        {
            repositorio.Eliminar(facturaId);
        }

        public void Modificar(Entidades.Factura entidad)
        {
            repositorio.Modificar(entidad);
        }

        public Entidades.Factura Buscar(int facturaId)
        {
            return repositorio.Buscar(facturaId);
        }

        public List<Entidades.Factura> ListarTodos()
        {
            return repositorio.ListarTodos();
        }
    }
}
