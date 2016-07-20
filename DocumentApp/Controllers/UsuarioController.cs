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
        [HttpGet]
        public ActionResult ConsultaUsuario(int? page)
        {

            UsuarioViewModel usuarios = new UsuarioViewModel();
            var listaUsuarios = new List<Usuario>();
            Usuario usuario;

            List<BEUsuario> olistaUsuarios;
            BLUsuario oBlusuario = new BLUsuario();

            olistaUsuarios = oBlusuario.ListarUsuarios();
            int iCorrelativo = 0;
            var pager = new Pager(olistaUsuarios.Count(), page);

            foreach (BEUsuario item in olistaUsuarios)
            {
                usuario = new Usuario();
                iCorrelativo += 1;
                usuario.Nro = iCorrelativo;
                usuario.CodigoUsuario = item.cod_usuario;
                usuario.ApellidoMaterno = item.ape_materno;
                usuario.ApellidoPaterno = item.ape_paterno;
                usuario.Nombres = item.nombres;
                usuario.CodigoArea = item.cod_area;
                usuario.CodigoRol = item.cod_rol;
                usuario.Area = item.gls_area;
                usuario.Rol = item.gls_rol;
                usuario.Estado = item.cod_estado_registro;
                usuario.UsuarioIngreso = item.aud_usr_ingreso;
                usuario.FechaIngreso = item.aud_fec_ingreso.ToString("dd-MM-yyyy");
                listaUsuarios.Add(usuario);
            }

            usuarios.Items = listaUsuarios.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize);
            usuarios.Pager = pager;

            return View(usuarios);
        }

        public JsonResult GetAllUsuarios()
        {
            List<UsuarioViewModel> Usuarios = new List<UsuarioViewModel>();
            UsuarioViewModel usuario;

            List<BEUsuario> olistaUsuarios;
            BLUsuario oBlusuario = new BLUsuario();

            olistaUsuarios = oBlusuario.ListarUsuarios();
            int iCorrelativo = 0;

            //foreach (BEUsuario item in olistaUsuarios)
            //{
            //    usuario = new UsuarioViewModel();
            //    iCorrelativo += 1;
            //    usuario.Nro = iCorrelativo;
            //    usuario.CodigoUsuario = item.cod_usuario;
            //    usuario.Area = item.gls_area;
            //    usuario.Rol = item.gls_rol;
            //    usuario.Estado = item.cod_estado_registro;
            //    usuario.UsuarioIngreso = item.aud_usr_ingreso;
            //    usuario.FechaIngreso = item.aud_fec_ingreso.ToString("dd-MM-yyyy");
            //    Usuarios.Add(usuario);
            //}

            return Json(Usuarios, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Actualizar(string code, string descripcion)
        {
            UsuarioLoginViewModel UsuarioActual;
            UsuarioActual = (UsuarioLoginViewModel)Session["objUsuario"];

            //BEUsuario usuario = new BEUsuario();
            //propietario.cod_propietario = Convert.ToInt16(code);
            //propietario.gls_propietario = descripcion;
            //propietario.aud_usr_modificacion = UsuarioActual.Codigo;

            //BLPropietario oBLPropietario = new BLPropietario();
            //int iResultado = oBLPropietario.Actualizar(propietario);

            return RedirectToAction("ConsultaUsuario", "Usuario");
        }

        public JsonResult Eliminar(string code)
        {
            //UsuarioLoginViewModel UsuarioActual;
            //UsuarioActual = (UsuarioLoginViewModel)Session["objUsuario"];

            //BEPropietario propietario = new BEPropietario();
            //propietario.cod_propietario = Convert.ToInt16(code);
            //propietario.aud_usr_modificacion = UsuarioActual.Codigo;

            //BLPropietario oBLPropietario = new BLPropietario();
            //int iResultado = oBLPropietario.Eliminar(propietario);

            return Json(1, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPerfilesAsignadosUsuarios(string id)
        {
            List<PerfilViewModel> Lista = new List<PerfilViewModel>();
            PerfilViewModel perfil;

            List<BEPerfil> oListaPerfil;
            BLTipoDocumento oBLTipoDocumento = new BLTipoDocumento();
            //oListaTipoDocumento = oBLTipoDocumento.ListarTipoDocumento();

            //foreach (BETipoDocumento item in oListaTipoDocumento)
            //{
            //    tipoDocumento = new TipoDocumentoViewModel();
            //    tipoDocumento.codigo = item.cod_tipo_documento;
            //    tipoDocumento.descripcion = item.gls_tipo_documento;
            //    tipoDocumento.estado = item.cod_estado_registro;
            //    Lista.Add(tipoDocumento);
            //}

            return Json(Lista, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllAreas()
        {
            List<AreaViewModel> Lista = new List<AreaViewModel>();
            AreaViewModel area;

            List<BEArea> oListaArea;
            BLArea oBLArea = new BLArea();
            oListaArea = oBLArea.ListarArea();

            foreach (BEArea item in oListaArea)
            {
                area = new AreaViewModel();
                area.codigo = item.cod_area;
                area.descripcion = item.gls_area;
                area.estado = item.cod_estado_registro;
                Lista.Add(area);
            }

            return Json(Lista, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllRoles()
        {
            List<RolViewModel> Lista = new List<RolViewModel>();
            RolViewModel rol;

            List<BERol> oListaRol;
            BLRol oBlRol = new BLRol();
            oListaRol = oBlRol.ListarRol();

            foreach (BERol item in oListaRol)
            {
                rol = new RolViewModel();
                rol.codigo = item.cod_rol;
                rol.descripcion = item.gls_rol;
                rol.estado = item.cod_estado_registro;
                Lista.Add(rol);
            }

            return Json(Lista, JsonRequestBehavior.AllowGet);
        }
    }
}