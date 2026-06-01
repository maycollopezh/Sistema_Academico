using System;
using System.Data;
using MySql.Data.MySqlClient;
using SistemaAcademico.DataAccess;

namespace SistemaAcademico.DAL
{
    public static class PagoDAL
    {
        public static (int idPago, string resultado, string mensaje) RegistrarPago(
            int idInscripcion, decimal monto, string tipoPago,
            int numeroCuota, DateTime fechaPago, DateTime? nuevaFechaVencimiento)
        {
            using (var conn = ConexionDB.ObtenerConexion())
            using (var cmd = new MySqlCommand("sp_RegistrarPago", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_idInscripcion",       idInscripcion);
                cmd.Parameters.AddWithValue("p_monto",               monto);
                cmd.Parameters.AddWithValue("p_tipoPago",            tipoPago);
                cmd.Parameters.AddWithValue("p_numeroCuota",         numeroCuota > 0 ? (object)numeroCuota : DBNull.Value);
                cmd.Parameters.AddWithValue("p_fechaPago",           fechaPago.Date);
                cmd.Parameters.AddWithValue("p_nuevaFechaVencimiento",
                    nuevaFechaVencimiento.HasValue ? (object)nuevaFechaVencimiento.Value.Date : DBNull.Value);
                var pId  = cmd.Parameters.Add("p_idPago",    MySqlDbType.Int32);
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

        public static DataTable ListarPagosPorInscripcion(int idInscripcion)
        {
            using (var conn = ConexionDB.ObtenerConexion())
            using (var cmd = new MySqlCommand("sp_ListarPagosPorInscripcion", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_idInscripcion", idInscripcion);
                var da = new MySqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }

    public static class CongelamientoDAL
    {
        public static int CrearCongelamiento(int idInscripcion, DateTime fechaInicio,
            DateTime fechaFin, string motivo)
        {
            using (var conn = ConexionDB.ObtenerConexion())
            using (var cmd = new MySqlCommand("sp_CrearCongelamiento", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_idInscripcion", idInscripcion);
                cmd.Parameters.AddWithValue("p_fechaInicio",   fechaInicio.Date);
                cmd.Parameters.AddWithValue("p_fechaFin",      fechaFin.Date);
                cmd.Parameters.AddWithValue("p_motivo",        motivo ?? (object)DBNull.Value);
                var da = new MySqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt.Rows.Count > 0 ? Convert.ToInt32(dt.Rows[0]["idCongelamiento"]) : 0;
            }
        }

        public static void FinalizarCongelamiento(int idCongelamiento)
        {
            using (var conn = ConexionDB.ObtenerConexion())
            using (var cmd = new MySqlCommand("sp_FinalizarCongelamiento", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_idCongelamiento", idCongelamiento);
                cmd.ExecuteNonQuery();
            }
        }

        public static DataTable ListarCongelamientos()
        {
            using (var conn = ConexionDB.ObtenerConexion())
            using (var cmd = new MySqlCommand("sp_ListarCongelamientos", conn))
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
