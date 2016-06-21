using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Document.BusinessEntity;
using Document.BusinessLogic;
using DocumentApp.Models;

namespace DocumentApp.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult ConsultaUsuario(int? page)
        {

            List<UsuarioViewModel> Usuarios = new List<UsuarioViewModel>();
            UsuarioViewModel usuario;

            List<BEUsuario> olistaUsuarios;
            BLUsuario oBlusuario = new BLUsuario();

            olistaUsuarios = oBlusuario.ListarUsuarios();
            int iCorrelativo = 0;
            var pager = new Pager(olistaUsuarios.Count(), page);
            var Items = Enumerable.Range(1, olistaUsuarios.Count());

            foreach (BEUsuario item in olistaUsuarios)
            {
                usuario = new UsuarioViewModel();
                iCorrelativo += 1;
                usuario.Nro = iCorrelativo;
                usuario.CodigoUsuario = item.cod_usuario;
                usuario.Area = item.gls_area;
                usuario.Rol = item.gls_rol;
                usuario.Estado = item.cod_estado_registro;
                usuario.UsuarioIngreso = item.aud_usr_ingreso;
                usuario.FechaIngreso = item.aud_fec_ingreso.ToString("dd-MM-yyyy");
                usuario.Items = Items.Skip((pager.CurrentPage - 1)*pager.PageSize).Take(pager.PageSize);
                usuario.Pager = pager;
                Usuarios.Add(usuario);
            }


            return View(Usuarios);
        }

        public JsonResult GetAllUsuarios()
        {
            List<UsuarioViewModel> Usuarios = new List<UsuarioViewModel>();
            UsuarioViewModel usuario;

            List<BEUsuario> olistaUsuarios;
            BLUsuario oBlusuario = new BLUsuario();

            olistaUsuarios = oBlusuario.ListarUsuarios();
            int iCorrelativo = 0;

            foreach (BEUsuario item in olistaUsuarios)
            {
                usuario = new UsuarioViewModel();
                iCorrelativo += 1;
                usuario.Nro = iCorrelativo;
                usuario.CodigoUsuario = item.cod_usuario;
                usuario.Area = item.gls_area;
                usuario.Rol = item.gls_rol;
                usuario.Estado = item.cod_estado_registro;
                usuario.UsuarioIngreso = item.aud_usr_ingreso;
                usuario.FechaIngreso = item.aud_fec_ingreso.ToString("dd-MM-yyyy");
                Usuarios.Add(usuario);
            }

            return Json(Usuarios, JsonRequestBehavior.AllowGet);
        }



    }
}