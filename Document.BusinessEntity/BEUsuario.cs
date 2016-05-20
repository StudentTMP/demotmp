using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Document.BusinessEntity
{
    /// <summary>
    /// Propiedades de Usuarios generados.
    /// </summary>
    public class BEUsuario : Auditoria
    {
        public int cod_usuario { get; set; }
        public int cod_area { get; set; }
        public int cod_rol { get; set; }
    }
}
