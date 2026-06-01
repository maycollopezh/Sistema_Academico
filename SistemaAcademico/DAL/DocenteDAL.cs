using System;
using System.Data;
using MySql.Data.MySqlClient;
using SistemaAcademico.DataAccess;

namespace SistemaAcademico.DAL
{
    /// <summary>
    /// Repositorio de datos para Docentes.
    /// </summary>
    public static class DocenteDAL
    {
        public static (int idDocente, string resultado, string mensaje) CrearDocente(
            string nombre, string apellidoPaterno, string apellidoMaterno,
            string ci, string correo, string telefono, string ciudad,
            string sexo, string nombreUsuario, string clave, int idTurno)
        {
            using (var conn = ConexionDB.ObtenerConexion())
            using (var cmd = new MySqlCommand("sp_CrearDocente", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_nombre",          nombre);
                cmd.Parameters.AddWithValue("p_apellidoPaterno", apellidoPaterno);
                cmd.Parameters.AddWithValue("p_apellidoMaterno", apellidoMaterno ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("p_ci",              ci);
                cmd.Parameters.AddWithValue("p_correo",          correo ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("p_telefono",        telefono ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("p_ciudad",          ciudad ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("p_sexo",            sexo ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("p_nombreUsuario",   nombreUsuario);
                cmd.Parameters.AddWithValue("p_clave",           UsuarioDAL.HashearClave(clave));
                cmd.Parameters.AddWithValue("p_idTurno",         idTurno > 0 ? (object)idTurno : DBNull.Value);
                var pId  = cmd.Parameters.Add("p_idDocente",  MySqlDbType.Int32);
                var pRes = cmd.Parameters.Add("p_resultado",  MySqlDbType.VarChar, 10);
                var pMsg = cmd.Parameters.Add("p_mensaje",    MySqlDbType.VarChar, 200);
                pId.Direction = pRes.Direction = pMsg.Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                return (
                    pId.Value  == DBNull.Value ? 0  : Convert.ToInt32(pId.Value),
                    pRes.Value == DBNull.Value ? "" : pRes.Value.ToString(),
                    pMsg.Value == DBNull.Value ? "" : pMsg.Value.ToString()
                );
            }
        }

        public static DataTable ListarDocentes()
        {
            using (var conn = ConexionDB.ObtenerConexion())
            using (var cmd = new MySqlCommand("sp_ListarDocentes", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                var da = new MySqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static DataTable ObtenerDocente(int idDocente)
        {
            using (var conn = ConexionDB.ObtenerConexion())
            using (var cmd = new MySqlCommand("sp_ObtenerDocente", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_idDocente", idDocente);
                var da = new MySqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static void ActualizarDocente(int idDocente, string nombre,
            string apellidoPaterno, string apellidoMaterno, string ci,
            string correo, string telefono, string ciudad, int idTurno)
        {
            using (var conn = ConexionDB.ObtenerConexion())
            using (var cmd = new MySqlCommand("sp_ActualizarDocente", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_idDocente",       idDocente);
                cmd.Parameters.AddWithValue("p_nombre",          nombre);
                cmd.Parameters.AddWithValue("p_apellidoPaterno", apellidoPaterno);
                cmd.Parameters.AddWithValue("p_apellidoMaterno", apellidoMaterno ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("p_ci",              ci);
                cmd.Parameters.AddWithValue("p_correo",          correo ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("p_telefono",        telefono ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("p_ciudad",          ciudad ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("p_idTurno",         idTurno > 0 ? (object)idTurno : DBNull.Value);
                cmd.ExecuteNonQuery();
            }
        }

        public static void EliminarDocente(int idDocente)
        {
            using (var conn = ConexionDB.ObtenerConexion())
            using (var cmd = new MySqlCommand("sp_EliminarDocente", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_idDocente", idDocente);
                cmd.ExecuteNonQuery();
            }
        }

        public static DataTable ListarClasesDocente(int idDocente)
        {
            using (var conn = ConexionDB.ObtenerConexion())
            using (var cmd = new MySqlCommand("sp_ListarClasesDocente", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_idDocente", idDocente);
                var da = new MySqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}
