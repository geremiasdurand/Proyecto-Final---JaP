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
            LogicaCliente logicaCliente = new LogicaCliente();
            List<Cliente> cliente = logicaCliente.ListarTodos();

            return View(cliente);
        }
    }
}