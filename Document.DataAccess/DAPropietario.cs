using Document.BusinessEntity;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Document.DataAccess
{
    public class DAPropietario
    {
        public List<BEPropietario> ListarPropietario()
        {
            List<BEPropietario> oListado = new List<BEPropietario>();
            BEPropietario oItem;

            using (NpgsqlConnection ocn = new NpgsqlConnection(Util.getConnection()))
            {
                ocn.Open();
                NpgsqlTransaction tran = ocn.BeginTransaction();
                using (NpgsqlCommand ocmd = new NpgsqlCommand("public.func_listar_doc_propietarios", ocn))
                {
                    ocmd.CommandType = CommandType.StoredProcedure;

                    using (NpgsqlDataReader odr = ocmd.ExecuteReader())
                    {
                        while (odr.Read())
                        {
                            oItem = new BEPropietario();

                            if (!Convert.IsDBNull(odr["cod_propietario"]))
                                oItem.cod_propietario = Convert.ToInt32(odr["cod_propietario"]);

                            if (!Convert.IsDBNull(odr["gls_propietario"]))
                                oItem.gls_propietario = odr["gls_propietario"].ToString();

                            if (!Convert.IsDBNull(odr["cod_estado_registro"]))
                                oItem.cod_estado_registro = Convert.ToInt32(odr["cod_estado_registro"]);

                            oListado.Add(oItem);
                        }
                        odr.Close();
                    }
                }
                tran.Commit();
                ocn.Close();
            }

            return oListado;
        }
    }
}
