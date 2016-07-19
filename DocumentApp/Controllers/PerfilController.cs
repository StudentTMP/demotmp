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

            foreach (BEPerfiles item in olistaUsuarios)
            {
                usuario = new Usuario();
                iCorrelativo += 1;
                usuario.Nro = iCorrelativo;
                usuario.CodigoUsuario = item.cod_usuario;
                usuario.Area = item.gls_area;
                usuario.Rol = item.gls_rol;
                usuario.Estado = item.cod_estado_registro;
                usuario.UsuarioIngreso = item.aud_usr_ingreso;
                usuario.FechaIngreso = item.aud_fec_ingreso.ToString("dd-MM-yyyy");
                listaUsuarios.Add(usuario);
            }

            usuarios.Items = listaUsuarios.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize);
            usuarios.Pager = pager;
             * */
            return View();
        }
    }
}