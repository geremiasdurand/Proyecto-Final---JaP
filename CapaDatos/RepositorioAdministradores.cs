using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos.ModeloBase;

namespace CapaDatos
{
    public class RepositorioAdministradores
    {
        //INICIO DE LA PRUEBA BY GERE

            public Entidades.Administradores EncontrarAdministrador(string Usuario, string Contraseña)
        {
            Entidades.Administradores resultado = null;

            using (ConexionDB bd = new ConexionDB())
            {
                var registros = from admin in bd.Administradores
                                where admin.Usuario == Usuario && admin.Contraseña == Contraseña
                                select admin;

                var registro = registros.FirstOrDefault();

                if (registro != null)
                {
                    resultado = new Entidades.Administradores()
                    {
                        IdAdministrador = registro.IdAdministrador,
                        Nombre = registro.Nombre,
                        Apellido = registro.Apellido,
                        Contraseña = registro.Contraseña,
                        Usuario = registro.Usuario,
                        CI = registro.CI,
                        Domicilio = registro.Domicilio,
                        FechaDeNacimiento = registro.FechaDeNacimiento,
                        Rol = (Entidades.Enumerados)registro.Rol
                    };
                }
            }

            return resultado;
        }
        //FIN DE LA PRUEBA BY GERE
        public List<Entidades.Administradores> ListarTodos()
        {
            using (ConexionDB bd = new ConexionDB())
            {
                var lista = from tabla in bd.Administradores
                            select new Entidades.Administradores()
                            {
                                IdAdministrador = tabla.IdAdministrador,
                                Nombre = tabla.Nombre,
                                Apellido = tabla.Apellido,
                                Contraseña = tabla.Contraseña,
                                Usuario = tabla.Usuario,
                                CI = tabla.CI,
                                Domicilio = tabla.Domicilio,
                                FechaDeNacimiento = tabla.FechaDeNacimiento,
                                Rol = (Entidades.Enumerados)tabla.Rol
                            };

                return lista.ToList();
            }
        }

        public void Agregar(Entidades.Administradores administrador)
        {
            using (ConexionDB bd = new ConexionDB())
            {
                var nuevaEntidad = new Administradore{
                    Nombre = administrador.Nombre,
                    Apellido = administrador.Apellido,
                    IdAdministrador = administrador.IdAdministrador,
                    Domicilio = administrador.Domicilio,
                    FechaDeNacimiento = administrador.FechaDeNacimiento,
                    Rol = (int)administrador.Rol,
                    Contraseña = administrador.Contraseña,
                    Usuario = administrador.Usuario,
                    CI = administrador.CI
                };
                bd.Administradores.Add(nuevaEntidad);
                bd.SaveChanges();
            }
        }

        public Entidades.Administradores Buscar(Entidades.Administradores administrador)
        {
            Entidades.Administradores resultado = null;

            using (ConexionDB bd = new ConexionDB())
            {
                var entidadABuscar = bd.Administradores.Find(administrador.IdAdministrador);

                if (entidadABuscar != null)
                {
                    resultado = new Entidades.Administradores{
                        Nombre = administrador.Nombre,
                        Apellido = administrador.Apellido,
                        IdAdministrador = administrador.IdAdministrador,
                        Domicilio = administrador.Domicilio,
                        FechaDeNacimiento = administrador.FechaDeNacimiento,
                        Rol = administrador.Rol,
                        Contraseña = administrador.Contraseña,
                        Usuario = administrador.Usuario,
                        CI = administrador.CI
                    };
                }
            }

            return resultado;
        }

        public Entidades.Administradores BuscarPorUserPass(Entidades.Administradores administrador)
        {
            Entidades.Administradores resultado = null;

            using (ConexionDB bd = new ConexionDB())
            {
                var lista = from Administradore in bd.Administradores
                                where Administradore.Usuario == administrador.Usuario && Administradore.Contraseña == administrador.Contraseña
                                select Administradore;

                var entidad = lista.FirstOrDefault();

                if (entidad != null)
                {
                    resultado = new Entidades.Administradores()
                    {
                        IdAdministrador = entidad.IdAdministrador,
                        Usuario = entidad.Nombre,
                        Rol = (Entidades.Enumerados)entidad.Rol
                    };
                }
            }

            return resultado;
        }

        public void Modificar(Entidades.Administradores administrador)
        {
            using (ConexionDB bd = new ConexionDB())
            {
                var buscarEntidad = bd.Administradores.Find(administrador.IdAdministrador);

                if (buscarEntidad != null)
                {
                    buscarEntidad.Apellido = administrador.Apellido;
                    buscarEntidad.Nombre = administrador.Nombre;
                    buscarEntidad.Rol = (int)administrador.Rol;
                    buscarEntidad.FechaDeNacimiento = administrador.FechaDeNacimiento;
                    buscarEntidad.Contraseña = administrador.Contraseña;
                    buscarEntidad.Domicilio = administrador.Domicilio;
                    bd.SaveChanges();
                }
            }
        }

        public void Eliminar(Entidades.Administradores administrador)
        {
            using (ConexionDB bd = new ConexionDB())
            {
                var buscarEntidad = bd.Administradores.Find(administrador.IdAdministrador);

                if (buscarEntidad != null)
                {
                    bd.Administradores.Remove(buscarEntidad);
                    bd.SaveChanges();
                }
            }
        }
    }
}
