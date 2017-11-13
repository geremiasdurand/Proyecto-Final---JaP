using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class LogicaCliente
    {
        CapaDatos.RepositorioCliente repositorio;

        public LogicaCliente()
        {
            repositorio = new CapaDatos.RepositorioCliente();
        }

        public void Agregar(Entidades.Cliente entidad)
        {
            repositorio.Agregar(entidad);
        }

        public void Eliminar(Entidades.Cliente entidad)
        {
            repositorio.Eliminar(entidad);
        }

        public void Modificar(Entidades.Cliente entidad)
        {
            repositorio.Modificar(entidad);
        }

        public Entidades.Cliente Buscar(Entidades.Cliente entidad)
        {
            return repositorio.Buscar(entidad);
        }

        public List<Entidades.Cliente> ListarTodos()
        {
            return repositorio.ListarTodos();
        }
    }
}
