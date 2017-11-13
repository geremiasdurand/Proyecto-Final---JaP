using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class LogicaLineaFactura
    {
        CapaDatos.RepositorioLineaFactura repositorio;

        public LogicaLineaFactura()
        {
            repositorio = new CapaDatos.RepositorioLineaFactura();
        }

        public void Agregar(Entidades.LineaFactura entidad)
        {
            repositorio.Agregar(entidad);
        }

        public void Eliminar(Entidades.LineaFactura entidad)
        {
            repositorio.Eliminar(entidad);
        }

        public void Modificar(Entidades.LineaFactura entidad)
        {
            repositorio.Modificar(entidad);
        }

        public Entidades.LineaFactura Buscar(Entidades.LineaFactura entidad)
        {
            return repositorio.Buscar(entidad);
        }

        public List<Entidades.LineaFactura> ListarTodos()
        {
            return repositorio.ListarTodos();
        }
    }
}
