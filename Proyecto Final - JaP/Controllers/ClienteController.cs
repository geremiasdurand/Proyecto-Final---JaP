using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaLogica;
using Entidades;

namespace Proyecto_Final___JaP.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            if (ValidarRol(Enumerados.Administrador) || ValidarRol(Enumerados.Empleado))
            {
                LogicaCliente logicaCliente = new LogicaCliente();
                List<Cliente> cliente = logicaCliente.ListarTodos();

                return View(cliente);
            }

            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            if (ValidarRol(Enumerados.Administrador) || ValidarRol(Enumerados.Empleado))
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public ActionResult Create(Cliente cliente)
        {
            if (ValidarRol(Enumerados.Administrador) || ValidarRol(Enumerados.Empleado))
            {
                LogicaCliente logicaCliente = new LogicaCliente();
                logicaCliente.Agregar(cliente);

                return RedirectToAction("Index", "Cliente");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public ActionResult Edit(int clienteId)
        {
            if (ValidarRol(Enumerados.Administrador) || ValidarRol(Enumerados.Empleado))
            {
                LogicaCliente logicaCliente = new LogicaCliente();
                Cliente resultado = logicaCliente.Buscar(clienteId);
                return View(resultado);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public ActionResult Edit(Cliente cliente)
        {
            if (ValidarRol(Enumerados.Administrador) || ValidarRol(Enumerados.Empleado))
            {
                LogicaCliente logicaCliente = new LogicaCliente();
                logicaCliente.Modificar(cliente);

                return RedirectToAction("Index", "Cliente");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public ActionResult Delete(int clienteId)
        {
            if (ValidarRol(Enumerados.Administrador) || ValidarRol(Enumerados.Empleado))
            {
                LogicaCliente logicaCliente = new LogicaCliente();
                Cliente resultado = logicaCliente.Buscar(clienteId);
                return View(resultado);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int clienteId)
        {
            if (ValidarRol(Enumerados.Administrador) || ValidarRol(Enumerados.Empleado))
            {
                LogicaCliente logicaCliente = new LogicaCliente();
                logicaCliente.Eliminar(clienteId);

                return RedirectToAction("Index", "Cliente");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        private bool ValidarRol(Enumerados Rol)
        {
            bool resultado = false;

            Administradores administrador = (Administradores)Session["Administrador"];

            if (administrador != null)
            {
                resultado = administrador.Rol == Rol;
            }
            return resultado;
        }
    }
}