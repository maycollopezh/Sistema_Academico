using System;
using System.Data;
using MySql.Data.MySqlClient;
using SistemaAcademico.DataAccess;

namespace SistemaAcademico.DAL
{
    /// <summary>Repositorio de datos para Horarios y Clases.</summary>
    public static class HorarioDAL
    {
        public static int CrearHorario(string nombre, int idModulo)
        {
            using (var conn = ConexionDB.ObtenerConexion())
            using (var cmd = new MySqlCommand("sp_CrearHorario", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_nombre",    nombre);
                cmd.Parameters.AddWithValue("p_idModulo",  idModulo);
                var pId = cmd.Parameters.Add("p_idHorario", MySqlDbType.Int32);
                pId.Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                return pId.Value == DBNull.Value ? 0 : Convert.ToInt32(pId.Value);
            }
        }

        public static void PublicarHorario(int idHorario, bool publicado)
        {
            using (var conn = ConexionDB.ObtenerConexion())
            using (var cmd = new MySqlCommand("sp_PublicarHorario", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_idHorario", idHorario);
                cmd.Parameters.AddWithValue("p_publicado", publicado ? 1 : 0);
                cmd.ExecuteNonQuery();
            }
        }

        public static DataTable ListarHorarios()
        {
            using (var conn = ConexionDB.ObtenerConexion())
            using (var cmd = new MySqlCommand("sp_ListarHorarios", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                var da = new MySqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }

    /// <summary>Repositorio de datos para Clases individuales.</summary>
    public static class ClaseDAL
    {
        public static (int idClase, string resultado, string mensaje) CrearClase(
            DateTime fecha, TimeSpan horaInicio, string modalidad,
            int idDocente, int idHorario, string linkZoom, string aula)
        {
            using (var conn = ConexionDB.ObtenerConexion())
            using (var cmd = new MySqlCommand("sp_CrearClase", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_fecha",      fecha.Date);
                cmd.Parameters.AddWithValue("p_horaInicio", horaInicio.ToString(@"hh\:mm\:ss"));
                cmd.Parameters.AddWithValue("p_modalidad",  modalidad);
                cmd.Parameters.AddWithValue("p_idDocente",  idDocente);
                cmd.Parameters.AddWithValue("p_idHorario",  idHorario);
                cmd.Parameters.AddWithValue("p_linkZoom",   linkZoom  ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("p_aula",       aula      ?? (object)DBNull.Value);
                var pId  = cmd.Parameters.Add("p_idClase",   MySqlDbType.Int32);
                var pRes = cmd.Parameters.Add("p_resultado", MySqlDbType.VarChar, 10);
                var pMsg = cmd.Parameters.Add("p_mensaje",   MySqlDbType.VarChar, 200);
                pId.Direction = pRes.Direction = pMsg.Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                return (
                    pId.Value  == DBNull.Value ? 0  : Convert.ToInt32(pId.Value),
                    pRes.Value == DBNull.Value ? "" : pRes.Value.ToString(),
                    pMsg.Value == DBNull.Value ? "" : pMsg.Value.ToString()
                );
            }
        }

        public static (string resultado, string mensaje) EliminarClase(int idClase)
        {
            using (var conn = ConexionDB.ObtenerConexion())
            using (var cmd = new MySqlCommand("sp_EliminarClase", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_idClase", idClase);
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

        public static DataTable ListarClasesPorHorario(int idHorario)
        {
            using (var conn = ConexionDB.ObtenerConexion())
            using (var cmd = new MySqlCommand("sp_ListarClasesPorHorario", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_idHorario", idHorario);
                var da = new MySqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static DataTable ObtenerHorarioEstudiante(int idEstudiante)
        {
            using (var conn = ConexionDB.ObtenerConexion())
            using (var cmd = new MySqlCommand("sp_ObtenerHorarioEstudiante", conn))
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
}
