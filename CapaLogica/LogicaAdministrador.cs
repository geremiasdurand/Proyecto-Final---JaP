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

        public void Eliminar(int adminId)
        {
            repositorio.Eliminar(adminId);
        }

        public void Modificar(Entidades.Administradores entidad)
        {
            repositorio.Modificar(entidad);
        }

        public Entidades.Administradores Buscar(int adminId)
        {
            return repositorio.Buscar(adminId);
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
