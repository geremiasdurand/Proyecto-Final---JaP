using CapaLogica;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_Final___JaP.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
             Administradores administrador = (Administradores)Session["Administrador"];

            if (administrador == null)
            {
                administrador = new Administradores();
                Session["Administrador"] = null;
            }

            return View(administrador);
        }

        [HttpPost]
        public ActionResult LogIn(Administradores administrador)
        {
            LogicaAdministrador logica = new LogicaAdministrador();
            //administrador = logica.BuscarPorUserPass(administrador);
            administrador = logica.EncontrarAdministrador(administrador.Usuario, administrador.Contraseña);
            Session["Administrador"] = administrador;
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult LogOut()
        {
            Administradores administrador = new Administradores();
            Session["Administrador"] = administrador;
            return RedirectToAction("Index");
        }

        public ActionResult Contact()
        {
            if (ValidarRol(Enumerados.Administrador) || ValidarRol(Enumerados.Empleado))
            {
                ViewBag.Message = "Your application description page.";
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        private bool ValidarRol(Enumerados Rol)
        {
            bool resultado = false;

            Administradores administrador = (Administradores)Session["Administrador"];

            if (administrador == null)
            {
                resultado = administrador.Rol == Rol;
            }
            return resultado;
        }
    }
}