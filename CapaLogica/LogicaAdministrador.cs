using System;
using CapaDatos;
using Entidades;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        //AGREGADO POR GERE

        public Administradores EncontrarAdministrador(string Usuario, string Contraseña)
        {
            return repositorio.EncontrarAdministrador(Usuario, Contraseña);
        }

        //AGREGADO POR GERE FIN-
    }
}
