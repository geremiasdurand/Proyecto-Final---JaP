using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entidades.Validadores;
using Entidades;
using CapaLogica;

namespace Proyecto_Final___JaP.Controllers
{
    public class AdministradorController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            if (ValidarRol(Enumerados.Administrador) || ValidarRol(Enumerados.Empleado))
            {
                LogicaAdministrador logicaAdministrador = new LogicaAdministrador();
                List<Administradores> administrador = logicaAdministrador.ListarTodos();

                return View(administrador);
            }

            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            if (ValidarRol(Enumerados.Administrador))
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public ActionResult Create(Administradores administrador)
        {
            if (ValidarRol(Enumerados.Administrador))
            {
                LogicaAdministrador logicaAdministrador = new LogicaAdministrador();
                logicaAdministrador.Agregar(administrador);

                return RedirectToAction("Index", "Administrador");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public ActionResult Edit(int adminId)
        {
            if (ValidarRol(Enumerados.Administrador))
            {
                LogicaAdministrador logicaAdministrador = new LogicaAdministrador();
                Administradores resultado = logicaAdministrador.Buscar(adminId);
                return View(resultado);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public ActionResult Edit(Administradores administrador)
        {
            if (ValidarRol(Enumerados.Administrador))
            {
                LogicaAdministrador logicaAdministrador = new LogicaAdministrador();
                logicaAdministrador.Modificar(administrador);

                return RedirectToAction("Index", "Administrador");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public ActionResult Delete(int adminId)
        {
            if (ValidarRol(Enumerados.Administrador))
            {
                LogicaAdministrador logicaAdministrador = new LogicaAdministrador();
                Administradores resultado = logicaAdministrador.Buscar(adminId);
                return View(resultado);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int adminId)
        {
            if (ValidarRol(Enumerados.Administrador) )
            {
                LogicaAdministrador logicaAdministrador = new LogicaAdministrador();
                logicaAdministrador.Eliminar(adminId);

                return RedirectToAction("Index", "Administrador");
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