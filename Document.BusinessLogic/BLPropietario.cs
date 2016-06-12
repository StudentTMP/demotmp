using Document.BusinessEntity;
using Document.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Document.BusinessLogic
{
    public class BLPropietario
    {
        public List<BEPropietario> ListarPropietario()
        {
            return new DAPropietario().ListarPropietario();
        }

        public int Registrar(BEPropietario propietario)
        {
            return new DAPropietario().Registrar(propietario);
        }

        public int Actualizar(BEPropietario propietario)
        {
            return new DAPropietario().Actualizar(propietario);
        }

        public int Eliminar(BEPropietario propietario)
        {
            return new DAPropietario().Eliminar(propietario);
        }

    }
}
