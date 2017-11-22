using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatos.ModeloBase;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class RepositorioCliente
    {
        public List<Entidades.Cliente> ListarTodos()
        {
            using (ConexionDB bd = new ConexionDB())
            {
                var lista = from tabla in bd.Clientes
                            select new Entidades.Cliente()
                            {
                                idCliente = tabla.idCliente,
                                Nombre = tabla.Nombre,
                                Apellido = tabla.Apellido,
                                CIoRut = tabla.CIoRut,
                                Domicilio = tabla.Domicilio,
                                FechaDeNacimiento = tabla.FechaDeNacimiento,
                            };

                return lista.ToList();
            }
        }

        public void Agregar(Entidades.Cliente cliente)
        {
            using (ConexionDB bd = new ConexionDB())
            {
                var nuevaEntidad = new Cliente
                {
                    Nombre = cliente.Nombre,
                    Apellido = cliente.Apellido,
                    idCliente = cliente.idCliente,
                    Domicilio = cliente.Domicilio,
                    FechaDeNacimiento = cliente.FechaDeNacimiento,
                    CIoRut = cliente.CIoRut,
                };
                bd.Clientes.Add(nuevaEntidad);
                bd.SaveChanges();
            }
        }

        public Entidades.Cliente Buscar(int idCliente)
        {
            Entidades.Cliente resultado = null;

            using (ConexionDB bd = new ConexionDB())
            {
                var entidadABuscar = bd.Clientes.Find(idCliente);

                if (entidadABuscar != null)
                {
                    resultado = new Entidades.Cliente();
                    resultado.Nombre = entidadABuscar.Nombre;
                    resultado.Apellido = entidadABuscar.Apellido;
                    resultado.idCliente = entidadABuscar.idCliente;
                    resultado.CIoRut = entidadABuscar.CIoRut;
                    resultado.Domicilio = entidadABuscar.Domicilio;
                    resultado.FechaDeNacimiento = entidadABuscar.FechaDeNacimiento;

                    //DESABILITADO BY GERE
                    {
                        //Nombre = cliente.Nombre,
                        //Apellido = cliente.Apellido,
                        //idCliente = cliente.idCliente,
                        //CIoRut = cliente.CIoRut,
                        //Domicilio = cliente.Domicilio,
                        //FechaDeNacimiento = cliente.FechaDeNacimiento,
                    };
                    //DESABILITADO BY GERE END
                }
            }

            return resultado;
        }

        public void Modificar(Entidades.Cliente cliente)
        {
            using (ConexionDB bd = new ConexionDB())
            {
                var buscarEntidad = bd.Clientes.Find(cliente.idCliente);

                if (buscarEntidad != null)
                {
                    buscarEntidad.Apellido = cliente.Apellido;
                    buscarEntidad.Nombre = cliente.Nombre;
                    buscarEntidad.CIoRut = cliente.CIoRut;
                    buscarEntidad.FechaDeNacimiento = cliente.FechaDeNacimiento;
                    buscarEntidad.Domicilio = cliente.Domicilio;
                    bd.SaveChanges();
                }
            }
        }

        public void Eliminar(Entidades.Cliente cliente)
        {
            using (ConexionDB bd = new ConexionDB())
            {
                var buscarEntidad = bd.Clientes.Find(cliente.idCliente);

                if (buscarEntidad != null)
                {
                    bd.Clientes.Remove(buscarEntidad);
                    bd.SaveChanges();
                }
            }
        }
    }
}
