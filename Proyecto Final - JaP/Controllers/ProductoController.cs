using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entidades;
using CapaLogica;

namespace Proyecto_Final___JaP.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Prodcuto
        public ActionResult Index()
        {
            if (ValidarRol(Enumerados.Administrador) || ValidarRol(Enumerados.Empleado))
            {
                LogicaProducto logicaProducto = new LogicaProducto();
                List<Producto> producto = logicaProducto.ListarTodos();

                return View(producto);
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
        public ActionResult Create(Producto producto)
        {
            if (ValidarRol(Enumerados.Administrador) || ValidarRol(Enumerados.Empleado))
            {
                LogicaProducto logicaProducto = new LogicaProducto();
                logicaProducto.Agregar(producto);

                return RedirectToAction("Index", "Producto");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public ActionResult Edit(int productoId)
        {
            if (ValidarRol(Enumerados.Administrador) || ValidarRol(Enumerados.Empleado))
            {
                LogicaProducto logicaProducto = new LogicaProducto();
                Producto resultado = logicaProducto.Buscar(productoId);
                return View(resultado);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public ActionResult Edit(Producto producto)
        {
            if (ValidarRol(Enumerados.Administrador) || ValidarRol(Enumerados.Empleado))
            {
                LogicaProducto logicaProducto = new LogicaProducto();
                logicaProducto.Modificar(producto);

                return RedirectToAction("Index", "Producto");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public ActionResult Delete(int productoId)
        {
            if (ValidarRol(Enumerados.Administrador) || ValidarRol(Enumerados.Empleado))
            {
                LogicaProducto logicaProducto = new LogicaProducto();
                Producto resultado = logicaProducto.Buscar(productoId);
                return View(resultado);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int productoId)
        {
            if (ValidarRol(Enumerados.Administrador) || ValidarRol(Enumerados.Empleado))
            {
                LogicaProducto logicaProducto = new LogicaProducto();
                logicaProducto.Eliminar(productoId);

                return RedirectToAction("Index", "Producto");
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