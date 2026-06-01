using System;
using System.Data;
using MySql.Data.MySqlClient;
using SistemaAcademico.DataAccess;

namespace SistemaAcademico.DAL
{
    /// <summary>
    /// Repositorio de datos para Inscripciones y Módulos.
    /// </summary>
    public static class InscripcionDAL
    {
        public static (int idInscripcion, string resultado, string mensaje) CrearInscripcion(
            int idEstudiante, DateTime fechaInscripcion, string modalidadPago,
            decimal montoTotal, DateTime? fechaVencimiento)
        {
            using (var conn = ConexionDB.ObtenerConexion())
            using (var cmd = new MySqlCommand("sp_CrearInscripcion", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_idEstudiante",     idEstudiante);
                cmd.Parameters.AddWithValue("p_fechaInscripcion", fechaInscripcion.Date);
                cmd.Parameters.AddWithValue("p_modalidadPago",    modalidadPago);
                cmd.Parameters.AddWithValue("p_montoTotal",       montoTotal);
                cmd.Parameters.AddWithValue("p_fechaVencimiento",
                    fechaVencimiento.HasValue ? (object)fechaVencimiento.Value.Date : DBNull.Value);
                var pId  = cmd.Parameters.Add("p_idInscripcion", MySqlDbType.Int32);
                var pRes = cmd.Parameters.Add("p_resultado",     MySqlDbType.VarChar, 10);
                var pMsg = cmd.Parameters.Add("p_mensaje",       MySqlDbType.VarChar, 200);
                pId.Direction = pRes.Direction = pMsg.Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                return (
                    pId.Value  == DBNull.Value ? 0  : Convert.ToInt32(pId.Value),
                    pRes.Value == DBNull.Value ? "" : pRes.Value.ToString(),
                    pMsg.Value == DBNull.Value ? "" : pMsg.Value.ToString()
                );
            }
        }

        public static DataTable ListarInscripciones()
        {
            using (var conn = ConexionDB.ObtenerConexion())
            using (var cmd = new MySqlCommand("sp_ListarInscripciones", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                var da = new MySqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static DataTable ObtenerInscripcionEstudiante(int idEstudiante)
        {
            using (var conn = ConexionDB.ObtenerConexion())
            using (var cmd = new MySqlCommand("sp_ObtenerInscripcionPorEstudiante", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_idEstudiante", idEstudiante);
                var da = new MySqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static DataTable ListarModulos()
        {
            using (var conn = ConexionDB.ObtenerConexion())
            using (var cmd = new MySqlCommand("sp_ListarModulos", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                var da = new MySqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static DataTable ListarTurnos()
        {
            using (var conn = ConexionDB.ObtenerConexion())
            using (var cmd = new MySqlCommand("sp_ListarTurnos", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                var da = new MySqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static DataTable EstadoFinancieroEstudiante(int idEstudiante)
        {
            using (var conn = ConexionDB.ObtenerConexion())
            using (var cmd = new MySqlCommand("sp_EstadoFinancieroEstudiante", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_idEstudiante", idEstudiante);
                var da = new MySqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static DataTable ListarEstudiantesMorosos()
        {
            using (var conn = ConexionDB.ObtenerConexion())
            using (var cmd = new MySqlCommand("sp_ListarEstudiantesMorosos", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                var da = new MySqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}
