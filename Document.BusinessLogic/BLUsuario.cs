using Document.BusinessEntity;
using Document.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Document.BusinessLogic
{
    public class BLUsuario
    {
        /// <summary>
        /// Funcion: ObtenerUsuarioLogin
        /// Obtiene los datos del usuario que se valida.
        /// </summary>
        /// <param name="usuario">Usuario a Validar</param>
        /// <returns>Detalle del Usuario</returns>
        public BEUsuario ObtenerUsuarioLogin(string usuario)
        {
            return new DAUsuario().ObtenerUsuarioLogin(usuario);
        }
    }
}
