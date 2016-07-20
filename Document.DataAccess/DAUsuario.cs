﻿using Document.BusinessEntity;
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

        /// <summary>
        /// Listado de usuarios
        /// </summary>
        /// <returns>Lista de usuarios</returns>
        public List<BEUsuario> ListarUsuarios()
        {
            List<BEUsuario> oListado = new List<BEUsuario>();
            BEUsuario oItem;

            using (NpgsqlConnection cnx = new NpgsqlConnection(Util.getConnection()))
            {
                cnx.Open();
                NpgsqlTransaction tran = cnx.BeginTransaction();
                using (NpgsqlCommand cmd = new NpgsqlCommand("public.func_listar_doc_usuarios", cnx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (NpgsqlDataReader odr = cmd.ExecuteReader())
                    {
                        while (odr.Read())
                        {
                            oItem = new BEUsuario();

                            if (!Convert.IsDBNull(odr["cod_usuario"]))
                                oItem.cod_usuario = Convert.ToString(odr["cod_usuario"]);

                            if (!Convert.IsDBNull(odr["ape_paterno"]))
                                oItem.ape_paterno = Convert.ToString(odr["ape_paterno"]);

                            if (!Convert.IsDBNull(odr["ape_materno"]))
                                oItem.ape_materno = Convert.ToString(odr["ape_materno"]);

                            if (!Convert.IsDBNull(odr["nombres"]))
                                oItem.nombres = Convert.ToString(odr["nombres"]);

                            if (!Convert.IsDBNull(odr["correo"]))
                                oItem.correo = Convert.ToString(odr["correo"]);

                            if (!Convert.IsDBNull(odr["cod_area"]))
                                oItem.cod_area = Convert.ToInt32(odr["cod_area"]);

                            if (!Convert.IsDBNull(odr["gls_area"]))
                                oItem.gls_area = Convert.ToString(odr["gls_area"]);

                            if (!Convert.IsDBNull(odr["cod_rol"]))
                                oItem.cod_rol = Convert.ToInt32(odr["cod_rol"]);

                            if (!Convert.IsDBNull(odr["gls_rol"]))
                                oItem.gls_rol = Convert.ToString(odr["gls_rol"]);

                            if (!Convert.IsDBNull(odr["cod_estado_registro"]))
                                oItem.cod_estado_registro = Convert.ToInt32(odr["cod_estado_registro"]);

                            if (!Convert.IsDBNull(odr["aud_usr_ingreso"]))
                                oItem.aud_usr_ingreso = odr["aud_usr_ingreso"].ToString();

                            if (!Convert.IsDBNull(odr["aud_fec_ingreso"]))
                                oItem.aud_fec_ingreso = Convert.ToDateTime(odr["aud_fec_ingreso"]);



                            oListado.Add(oItem);
                        }
                        odr.Close();
                    }
                }
                tran.Commit();
                cnx.Close();


                return oListado;
            }
        }





    }
}
