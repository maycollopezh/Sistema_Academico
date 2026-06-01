using System;
using System.Data;
using MySql.Data.MySqlClient;
using SistemaAcademico.DataAccess;

namespace SistemaAcademico.DAL
{
    /// <summary>Repositorio de datos para Reservas y Asistencias.</summary>
    public static class ReservaDAL
    {
        public static (int idReserva, string resultado, string mensaje) CrearReserva(
            int idEstudiante, int idClase)
        {
            using (var conn = ConexionDB.ObtenerConexion())
            using (var cmd = new MySqlCommand("sp_CrearReserva", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_idEstudiante", idEstudiante);
                cmd.Parameters.AddWithValue("p_idClase",      idClase);
                var pId  = cmd.Parameters.Add("p_idReserva",  MySqlDbType.Int32);
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

        public static (string resultado, string mensaje) CancelarReserva(int idReserva)
        {
            using (var conn = ConexionDB.ObtenerConexion())
            using (var cmd = new MySqlCommand("sp_CancelarReserva", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_idReserva", idReserva);
                var pRes = cmd.Parameters.Add("p_resultado", MySqlDbType.VarChar, 10);
                var pMsg = cmd.Parameters.Add("p_mensaje",   MySqlDbType.VarChar, 200);
                pRes.Direction = pMsg.Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                return (
                    pRes.Value == DBNull.Value ? "" : pRes.Value.ToString(),
                    pMsg.Value == DBNull.Value ? "" : pMsg.Value.ToString()
                );
            }
        }

        public static DataTable ListarReservasPorEstudiante(int idEstudiante)
        {
            using (var conn = ConexionDB.ObtenerConexion())
            using (var cmd = new MySqlCommand("sp_ListarReservasPorEstudiante", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_idEstudiante", idEstudiante);
                var da = new MySqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static DataTable ListarReservasPorClase(int idClase)
        {
            using (var conn = ConexionDB.ObtenerConexion())
            using (var cmd = new MySqlCommand("sp_ListarReservasPorClase", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_idClase", idClase);
                var da = new MySqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static DataTable ContarHorasSemana(int idEstudiante)
        {
            using (var conn = ConexionDB.ObtenerConexion())
            using (var cmd = new MySqlCommand("sp_ContarHorasSemana", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_idEstudiante", idEstudiante);
                var da = new MySqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static DataTable ListarAsistenciaEstudiante(int idEstudiante)
        {
            using (var conn = ConexionDB.ObtenerConexion())
            using (var cmd = new MySqlCommand("sp_ListarAsistenciaEstudiante", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_idEstudiante", idEstudiante);
                var da = new MySqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static DataTable ResumenAsistenciaSemanal(int idEstudiante)
        {
            using (var conn = ConexionDB.ObtenerConexion())
            using (var cmd = new MySqlCommand("sp_ResumenAsistenciaSemanal", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_idEstudiante", idEstudiante);
                var da = new MySqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static DataTable VerificarYGenerarAlerta(int idEstudiante)
        {
            using (var conn = ConexionDB.ObtenerConexion())
            using (var cmd = new MySqlCommand("sp_VerificarYGenerarAlerta", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_idEstudiante", idEstudiante);
                var da = new MySqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }

    /// <summary>Repositorio de datos para Alertas de Asistencia.</summary>
    public static class AlertaDAL
    {
        public static DataTable ListarAlertasActivas()
        {
            using (var conn = ConexionDB.ObtenerConexion())
            using (var cmd = new MySqlCommand("sp_ListarAlertasActivas", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                var da = new MySqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static void MarcarAlertaRevisada(int idAlerta)
        {
            using (var conn = ConexionDB.ObtenerConexion())
            using (var cmd = new MySqlCommand("sp_MarcarAlertaRevisada", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_idAlerta", idAlerta);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
