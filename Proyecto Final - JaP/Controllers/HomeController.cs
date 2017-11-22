using CapaLogica;
using Entidades;
using System.Web.Mvc;

namespace Proyecto_Final___JaP.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
             Administradores administrador = (Administradores)Session["Usuario"];

            if (administrador == null)
            {
                administrador = new Administradores();
                Session["Sesion"] = null;
            }

            return View(administrador);
        }

        [HttpPost]
        public ActionResult LogIn(Administradores administrador)
        {
            LogicaAdministrador logica = new LogicaAdministrador();
            administrador = logica.BuscarPorUserPass(administrador);
            Session["Sesion"] = administrador;
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult LogOut()
        {
            Administradores usuario = new Administradores();
            Session["Sesion"] = usuario;
            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}