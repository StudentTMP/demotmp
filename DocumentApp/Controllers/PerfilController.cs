using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DocumentApp.Controllers
{
    public class PerfilController : Controller
    {
        // GET: Perfil
        [HttpGet]
        public ActionResult MantenimientoPerfil(int? page)
        {
            /*
            PerfilViewModel perfiles = new PerfilViewModel();
            var listaPerfiles = new List<Perfil>();
            Perfil perfil;

            List<BEPerfil> olistaPerfiles;
            BLPerfil oBlperfil = new BLPerfil();

            olistaPerfiles = oBlperfil.ListarPerfiles();
            int iCorrelativo = 0;
            var pager = new Pager(olistaPerfiles.Count(), page);

            foreach (BEPerfiles item in olistaPerfiles)
            {
                perfil = new Perfil();
                iCorrelativo += 1;
                perfil.Nro = iCorrelativo;
                perfil.Id = item.cod_perfil;
                perfil.Descripcion = item.gls_descripcion;
                perfil.Estado = item.cod_estado_registro;
                listaPerfiles.Add(perfil);
            }

            perfiles.Items = listaPerfiles.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize);
            perfiles.Pager = pager;
             * */
            return View();
        }
    }
}