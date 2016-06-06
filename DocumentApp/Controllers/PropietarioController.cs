using Document.BusinessEntity;
using Document.BusinessLogic;
using DocumentApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DocumentApp.Controllers
{
    public class PropietarioController : Controller
    {
        // GET: Propietario
        public ActionResult Buscar()
        {
            List<PropietarioViewModel> ResultadoBusqueda;
            ResultadoBusqueda = Util.ListaPropietario();

            return View(ResultadoBusqueda);
        }

        public ActionResult Nuevo()
        {
            return View();
        }

        public ActionResult Registrar(string propietario)
        {
            UsuarioLoginViewModel UsuarioActual;
            UsuarioActual = (UsuarioLoginViewModel)Session["objUsuario"];

            BEPropietario nuevo = new BEPropietario();
            nuevo.gls_propietario = propietario;
            nuevo.aud_usr_ingreso = UsuarioActual.Codigo;

            BLPropietario oBLPropietario = new BLPropietario();
            int iResultado = oBLPropietario.Registrar(nuevo);

            return RedirectToAction("Buscar","Propietario");
            //return Json(iResultado, JsonRequestBehavior.AllowGet);
        }
    }
}