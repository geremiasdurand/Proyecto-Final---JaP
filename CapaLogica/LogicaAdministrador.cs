using System.Collections.Generic;

namespace CapaLogica
{
    public class LogicaAdministrador
    {
        CapaDatos.RepositorioAdministradores repositorio;

        public LogicaAdministrador() {
            repositorio = new CapaDatos.RepositorioAdministradores();
        }

        public void Agregar(Entidades.Administradores entidad) {
            repositorio.Agregar(entidad);
        }

        public void Eliminar(Entidades.Administradores entidad)
        {
            repositorio.Eliminar(entidad);
        }

        public void Modificar(Entidades.Administradores entidad)
        {
            repositorio.Modificar(entidad);
        }

        public Entidades.Administradores Buscar(Entidades.Administradores entidad)
        {
            return repositorio.Buscar(entidad);
        }

        public Entidades.Administradores BuscarPorUserPass(Entidades.Administradores entidad)
        {
            return repositorio.BuscarPorUserPass(entidad);
        }

        public List<Entidades.Administradores> ListarTodos()
        {
            return repositorio.ListarTodos();
        }
    }
}
