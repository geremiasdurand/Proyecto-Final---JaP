using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entidades;
using CapaLogica;

namespace Proyecto_Final___JaP.Controllers
{
    public class FacturaController : Controller
    {
        // GET: Factura
        public ActionResult Index()
        {
            if (ValidarRol(Enumerados.Administrador) || ValidarRol(Enumerados.Empleado))
            {
                LogicaFactura logicaFactura = new LogicaFactura();
                List<Factura> factura = logicaFactura.ListarTodos();

                return View(factura);
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
                Session["ListaDeTabla"] = new List<LineaFactura>();
                Session["LMontoTotal"] = 0;
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public ActionResult Create(LineaFactura lineaFactura)
        {
            if (ValidarRol(Enumerados.Administrador) || ValidarRol(Enumerados.Empleado))
            {
                LogicaLineaFactura logicaLineaFactura = new LogicaLineaFactura();
                logicaLineaFactura.Agregar(lineaFactura);

                return RedirectToAction("Index", "Factura");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public ActionResult AgregarLineaFactura()
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

        #region Inicializacion de Views
        public ActionResult CreateGet()
        {
            if (ValidarRol(Enumerados.Administrador) || ValidarRol(Enumerados.Empleado))
            {
                return View("CreateFactura");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult FacturarFactura()
        {
            if (ValidarRol(Enumerados.Administrador) || ValidarRol(Enumerados.Empleado))
            {
                return View("FacturarFactura");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        #endregion

        public ActionResult BorrarDelCarritoTodo()
        {
            if (ValidarRol(Enumerados.Administrador) || ValidarRol(Enumerados.Empleado))
            {
                Session["ListaDeTabla"] = new List<LineaFactura>();
                return View("Create");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }            
        }

        [HttpGet]
        public ActionResult BorrarDelCarrito(int productoId)
        {
            if (ValidarRol(Enumerados.Administrador) || ValidarRol(Enumerados.Empleado))
            {
                List<LineaFactura> Lista = (List<LineaFactura>)Session["ListaDeTabla"];
                foreach (var l in Lista)
                {
                    if (productoId == l.Producto.Id)
                    {
                        Lista.Remove(l);
                        Session["LMontoTotal"] = (Int32)Session["LMontoTotal"] - (l.Producto.PrecioPorUnidad * l.Cantidad);
                        break;
                    }
                }
                Session["ListaDeTabla"] = Lista;
                return View("Create");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public ActionResult AgregarAlCarrito(LineaFactura lineaFactura)
        {
            if (ValidarRol(Enumerados.Administrador) || ValidarRol(Enumerados.Empleado))
            {
                List<LineaFactura> Lista = (List<LineaFactura>)Session["ListaDeTabla"];
                lineaFactura.Producto = TraerProducto(lineaFactura.Producto.Id);

                var yaExiste = Lista.FirstOrDefault(m => m.Producto.Id == lineaFactura.Producto.Id);
                if(yaExiste != null)
                {
                    Lista.Remove(yaExiste);
                    yaExiste.Cantidad += lineaFactura.Cantidad;
                    Lista.Add(yaExiste);
                }
                else
                {
                    Lista.Add(lineaFactura);
                }
                Session["ListaDeTabla"] = Lista;
                var sesion = (Int32)Session["LMontoTotal"];
                Session["LMontoTotal"] = sesion + lineaFactura.Producto.PrecioPorUnidad * lineaFactura.Cantidad;

                return View("Create");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public ActionResult CreateFactura()
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
        public ActionResult Facturar(Factura factura)
        {
            try
            {
                if (ValidarRol(Enumerados.Administrador) || ValidarRol(Enumerados.Empleado))
                {
                    List<LineaFactura> Lista = (List<LineaFactura>)Session["ListaDeTabla"];
                    if (Lista.Count > 0)
                    {
                        LogicaCliente logicaCliente = new LogicaCliente();
                        if (logicaCliente.Buscar(factura.IdCliente) != null)
                        {
                            LogicaFactura logicaFactura = new LogicaFactura();
                            Factura nuevaFactura = new Factura()
                            {
                                MontoTotal = (int)Session["LMontoTotal"],
                                IdCliente = factura.IdCliente
                            };

                            int idFactura = logicaFactura.Agregar(nuevaFactura);
                            nuevaFactura.Id = idFactura;

                            LogicaLineaFactura logicaLineaFactura = new LogicaLineaFactura();
                            foreach (var l in Lista)
                            {
                                l.IdFactura = idFactura;
                                logicaLineaFactura.Agregar(l);
                            }

                            Session["ListaDeTabla"] = new List<LineaFactura>();
                            Session["LMontoTotal"] = 0;
                        }
                    }
                    return View("Create");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpGet]
        public ActionResult Edit(int facturaId)
        {
            if (ValidarRol(Enumerados.Administrador) || ValidarRol(Enumerados.Empleado))
            {
                LogicaFactura logicaFactura = new LogicaFactura();
                Factura resultado = logicaFactura.Buscar(facturaId);
                return View(resultado);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public ActionResult Edit(Factura factura)
        {
            if (ValidarRol(Enumerados.Administrador) || ValidarRol(Enumerados.Empleado))
            {
                LogicaFactura logicaFactura = new LogicaFactura();
                logicaFactura.Modificar(factura);

                return RedirectToAction("Index", "Factura");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (ValidarRol(Enumerados.Administrador) || ValidarRol(Enumerados.Empleado))
            {
                LogicaFactura logicaFactura = new LogicaFactura();
                Factura resultado = logicaFactura.Buscar(id);
                
                return View(resultado);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            if (ValidarRol(Enumerados.Administrador) || ValidarRol(Enumerados.Empleado))
            {
                LogicaFactura logicaFactura = new LogicaFactura();
                logicaFactura.Eliminar(id);

                return RedirectToAction("Index", "Factura");
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

        public Producto TraerProducto(int idProducto)
        {
            LogicaProducto logicaProduto = new LogicaProducto();

            return logicaProduto.Buscar(idProducto);
        }

        [HttpGet]
        public ActionResult DetailsFactura (int idFactura)
        {
            if (ValidarRol(Enumerados.Administrador) || ValidarRol(Enumerados.Empleado))
            {
                LogicaFactura logicaFactura = new LogicaFactura();
                Factura resultado = logicaFactura.Buscar(idFactura);

                //Cargamos las lineas de la Factura
                LogicaLineaFactura logicaLineaFactura = new LogicaLineaFactura();
                var retorno = new List<LineaFactura>();
                foreach (var linea in resultado.ListaDeLineasFactura)
                {
                    retorno.Add(logicaLineaFactura.Buscar(linea));
                }

                return View(retorno);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }            
        }
    }
}