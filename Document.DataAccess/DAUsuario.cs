using Document.BusinessEntity;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Document.DataAccess
{
    public class DAUsuario
    {
        /// <summary>
        /// Funcion: ObtenerUsuarioLogin
        /// Obtiene los datos del usuario que se valida.
        /// </summary>
        /// <param name="usuario">Usuario a Validar</param>
        /// <returns>Detalle del Usuario</returns>
        public BEUsuario ObtenerUsuarioLogin(string usuario)
        {
            BEUsuario oUsuario = new BEUsuario();

            using (NpgsqlConnection ocn = new NpgsqlConnection(Util.getConnection()))
            {
                ocn.Open();
                NpgsqlTransaction tran = ocn.BeginTransaction();
                using (NpgsqlCommand ocmd = new NpgsqlCommand("public.func_obtener_doc_usuario_Login", ocn))
                {
                    ocmd.CommandType = CommandType.StoredProcedure;
                    ocmd.Parameters.Add("@p_cod_usuario", NpgsqlDbType.Varchar).Value = usuario;

                    using (NpgsqlDataReader odr = ocmd.ExecuteReader())
                    {
                        while (odr.Read())
                        {

                            if (!Convert.IsDBNull(odr["cod_usuario"]))
                                oUsuario.cod_usuario = odr["cod_usuario"].ToString();

                            if (!Convert.IsDBNull(odr["ape_paterno"]))
                                oUsuario.ape_paterno = odr["ape_paterno"].ToString();

                            if (!Convert.IsDBNull(odr["ape_materno"]))
                                oUsuario.ape_materno = odr["ape_materno"].ToString();

                            if (!Convert.IsDBNull(odr["nombres"]))
                                oUsuario.nombres = odr["nombres"].ToString();

                            if (!Convert.IsDBNull(odr["cod_area"]))
                                oUsuario.cod_area = Convert.ToInt32(odr["cod_area"]);

                            if (!Convert.IsDBNull(odr["gls_area"]))
                                oUsuario.gls_area = odr["gls_area"].ToString();

                            if (!Convert.IsDBNull(odr["cod_rol"]))
                                oUsuario.cod_rol = Convert.ToInt32(odr["cod_rol"]);

                            if (!Convert.IsDBNull(odr["gls_rol"]))
                                oUsuario.gls_rol = odr["gls_rol"].ToString();

                            if (!Convert.IsDBNull(odr["correo"]))
                                oUsuario.correo = odr["correo"].ToString();

                        }
                        odr.Close();
                    }
                }
                tran.Commit();
                ocn.Close();
            }

            return oUsuario;
        }
    }
}
