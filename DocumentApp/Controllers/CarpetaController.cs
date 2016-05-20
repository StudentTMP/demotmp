using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DocumentApp.Models;
using Document.BusinessEntity;
using Document.BusinessLogic;

namespace DocumentApp.Controllers
{
    public class CarpetaController : Controller
    {
        // GET: Carpeta
        public ActionResult Gestionar()
        {
            return View();
        }

        public JsonResult GetTreeviewFiles()
        {
            List<BECarpeta> oListaCarpeta;
            List<BECarpeta> oListaCarpetaMenus = new List<BECarpeta>();
            List<CarpetaViewModel> _ListCarpeta = new List<CarpetaViewModel>();

            //Obtenemos el listado
            oListaCarpeta = new BLCarpeta().Listar_Carpeta();

            if (oListaCarpeta.Count > 0)
            {
                oListaCarpetaMenus = oListaCarpeta.Where(e => e.cod_carpeta_padre < 1).ToList();

                CarpetaViewModel _carpeta;

                foreach (BECarpeta item in oListaCarpetaMenus)
                {
                    _carpeta = new CarpetaViewModel();
                    _carpeta.id = item.cod_carpeta;
                    _carpeta.text = " " + item.gls_ruta_carpeta;
                    _carpeta.nodes = GetAllNodosHijos(oListaCarpeta, item.cod_carpeta);
                    _ListCarpeta.Add(_carpeta);
                }
            }
            
            return Json(_ListCarpeta, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Obtiene todos los nodos referentes al nodo padre solicitado
        /// </summary>
        /// <param name="listado">Lista de nodos existentes</param>
        /// <param name="">id nodo padre para devolver los que le pertenecen</param>
        /// <returns>Lista de nodos hijos</returns>
        private List<CarpetaViewModel> GetAllNodosHijos(List<BECarpeta> listado, int nodoPadre)
        {
            CarpetaViewModel nodoHijo;
            List<CarpetaViewModel> NodosHijos = new List<CarpetaViewModel>();

            foreach (BECarpeta item in listado)
            {
                if (item.cod_carpeta_padre == nodoPadre)
                {
                    nodoHijo = new CarpetaViewModel();
                    nodoHijo.id = item.cod_carpeta;
                    nodoHijo.text = " " + item.gls_ruta_carpeta;
                    List<CarpetaViewModel> nhijos;

                    nhijos = GetAllNodosHijos(listado, item.cod_carpeta);
                    if (nhijos.Count > 0)
                        nodoHijo.nodes = nhijos;
                    else
                        nodoHijo.nodes = null;

                    NodosHijos.Add(nodoHijo);
                }
            }

            return NodosHijos;
        }

        public JsonResult GetAllDocumentosPorCarpeta(string id)
        {
            List<DocumentoViewModel> Documentos = new List<DocumentoViewModel>();
            DocumentoViewModel documento;

            List<BEDocumento> olistaDocumentos;
            BLDocumento oBldocumento = new BLDocumento();

            int nroCarpeta = Convert.ToInt16(id);

            olistaDocumentos = oBldocumento.ListarDocumento_porCarpeta(nroCarpeta);

            int iCorrelativo = 0;

            foreach (BEDocumento item in olistaDocumentos)
            {
                documento = new DocumentoViewModel();
                iCorrelativo += 1;

                documento.nro = iCorrelativo;
                documento.id = item.cod_documento;
                documento.documento = item.gls_nombre_documento;
                documento.tipoDocumento = item.gls_tipo_documento;
                documento.propietario = item.gls_propietario;
                documento.fechaVigencia = item.fec_vigencia.ToString("dd-MM-yyyy");
                Documentos.Add(documento);
            }

            return Json(Documentos, JsonRequestBehavior.AllowGet);
        }

    }
}