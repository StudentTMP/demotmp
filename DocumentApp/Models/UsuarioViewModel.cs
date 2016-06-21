using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocumentApp.Models
{
    public class UsuarioViewModel
    {
        public int Nro { get; set; }
        public string CodigoUsuario { get; set; }
        public int CodigoArea { get; set; }
        public int CodigoRol { get; set; }
        public string Area { get; set; }
        public string Rol { get; set; }
        public int Estado { get; set; }
        public string UsuarioIngreso { get; set; }
        public string FechaIngreso { get; set; }
        public IEnumerable<int> Items { get; set; }
        public Pager Pager { get; set; }


    }


} 