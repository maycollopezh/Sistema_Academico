using System;
using System.Data;
using MySql.Data.MySqlClient;
using SistemaAcademico.DataAccess;

namespace SistemaAcademico.DAL
{
    /// <summary>Repositorio de datos para Planillas, Notas de Tema y Exámenes de Módulo.</summary>
    public static class PlanillaDAL
    {
        public static int CrearPlanilla(int idEstudiante, int idModulo)
        {
            using (var conn = ConexionDB.ObtenerConexion())
            using (var cmd = new MySqlCommand("sp_CrearPlanilla", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_idEstudiante", idEstudiante);
                cmd.Parameters.AddWithValue("p_idModulo",     idModulo);
                var pId = cmd.Parameters.Add("p_idPlanilla", MySqlDbType.Int32);
                pId.Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                return pId.Value == DBNull.Value ? 0 : Convert.ToInt32(pId.Value);
            }
        }

        public static DataTable ObtenerPlanillaEstudianteModulo(int idEstudiante, int idModulo)
        {
            using (var conn = ConexionDB.ObtenerConexion())
            using (var cmd = new MySqlCommand("sp_ObtenerPlanillaEstudianteModulo", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_idEstudiante", idEstudiante);
                cmd.Parameters.AddWithValue("p_idModulo",     idModulo);
                // SP retorna 3 result sets: planilla info, notas de tema, exámenes
                var ds = new DataSet();
                var da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                return ds.Tables.Count > 0 ? ds.Tables[0] : new DataTable();
            }
        }

        /// <summary>Retorna todas las planillas (notas de tema) en un DataSet con tablas separadas.</summary>
        public static DataSet ObtenerPlanillaCompleta(int idEstudiante, int idModulo)
        {
            using (var conn = ConexionDB.ObtenerConexion())
            using (var cmd = new MySqlCommand("sp_ObtenerPlanillaEstudianteModulo", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_idEstudiante", idEstudiante);
                cmd.Parameters.AddWithValue("p_idModulo",     idModulo);
                var ds = new DataSet();
                var da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
        }

        public static DataTable ListarPlanillasPorEstudiante(int idEstudiante)
        {
            using (var conn = ConexionDB.ObtenerConexion())
            using (var cmd = new MySqlCommand("sp_ListarPlanillasPorEstudiante", conn))
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

    /// <summary>Repositorio de datos para Notas por Tema (1-16).</summary>
    public static class NotaTemaDAL
    {
        public static (string resultado, string mensaje) RegistrarNotaTema(
            int idPlanilla, int nroTema, decimal? speaking, decimal? writing,
            decimal? listening, decimal? reading, int idDocente)
        {
            using (var conn = ConexionDB.ObtenerConexion())
            using (var cmd = new MySqlCommand("sp_RegistrarNotaTema", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_idPlanilla", idPlanilla);
                cmd.Parameters.AddWithValue("p_nroTema",    nroTema);
                cmd.Parameters.AddWithValue("p_speaking",   speaking.HasValue  ? (object)speaking.Value  : DBNull.Value);
                cmd.Parameters.AddWithValue("p_writing",    writing.HasValue   ? (object)writing.Value   : DBNull.Value);
                cmd.Parameters.AddWithValue("p_listening",  listening.HasValue ? (object)listening.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("p_reading",    reading.HasValue   ? (object)reading.Value   : DBNull.Value);
                cmd.Parameters.AddWithValue("p_idDocente",  idDocente);
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

        public static void ActualizarNotaTema(int idNotaTema, decimal? speaking,
            decimal? writing, decimal? listening, decimal? reading, int idDocente)
        {
            using (var conn = ConexionDB.ObtenerConexion())
            using (var cmd = new MySqlCommand("sp_ActualizarNotaTema", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_idNotaTema", idNotaTema);
                cmd.Parameters.AddWithValue("p_speaking",   speaking.HasValue  ? (object)speaking.Value  : DBNull.Value);
                cmd.Parameters.AddWithValue("p_writing",    writing.HasValue   ? (object)writing.Value   : DBNull.Value);
                cmd.Parameters.AddWithValue("p_listening",  listening.HasValue ? (object)listening.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("p_reading",    reading.HasValue   ? (object)reading.Value   : DBNull.Value);
                cmd.Parameters.AddWithValue("p_idDocente",  idDocente);
                cmd.ExecuteNonQuery();
            }
        }
    }

    /// <summary>Repositorio de datos para Exámenes de Módulo (Teórico y Oral).</summary>
    public static class ExamenModuloDAL
    {
        public static (string resultado, string mensaje) RegistrarExamen(
            int idPlanilla, string tipoExamen, decimal nota, int idDocente)
        {
            using (var conn = ConexionDB.ObtenerConexion())
            using (var cmd = new MySqlCommand("sp_RegistrarExamenModulo", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_idPlanilla",  idPlanilla);
                cmd.Parameters.AddWithValue("p_tipoExamen",  tipoExamen); // 'Teorico' o 'Oral'
                cmd.Parameters.AddWithValue("p_nota",        nota);
                cmd.Parameters.AddWithValue("p_idDocente",   idDocente);
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

        public static DataTable VerificarAprobacion(int idEstudiante, int idModulo)
        {
            using (var conn = ConexionDB.ObtenerConexion())
            using (var cmd = new MySqlCommand("sp_VerificarAprobacionModulo", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_idEstudiante", idEstudiante);
                cmd.Parameters.AddWithValue("p_idModulo",     idModulo);
                var da = new MySqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }

    /// <summary>Repositorio de datos para Diagnóstico, Proyecto Final y Certificado.</summary>
    public static class DiagnosticoDAL
    {
        public static (string resultado, string mensaje) RegistrarDiagnostico(
            int idEstudiante, DateTime fecha, int puntaje, string nivel,
            string observaciones, int idModuloAsignado)
        {
            using (var conn = ConexionDB.ObtenerConexion())
            using (var cmd = new MySqlCommand("sp_RegistrarDiagnostico", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_idEstudiante",    idEstudiante);
                cmd.Parameters.AddWithValue("p_fecha",           fecha.Date);
                cmd.Parameters.AddWithValue("p_puntaje",         puntaje);
                cmd.Parameters.AddWithValue("p_nivel",           nivel);
                cmd.Parameters.AddWithValue("p_observaciones",   observaciones ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("p_idModuloAsignado",idModuloAsignado);
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

        public static DataTable ObtenerDiagnostico(int idEstudiante)
        {
            using (var conn = ConexionDB.ObtenerConexion())
            using (var cmd = new MySqlCommand("sp_ObtenerDiagnostico", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_idEstudiante", idEstudiante);
                var da = new MySqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static DataTable ListarDiagnosticos()
        {
            using (var conn = ConexionDB.ObtenerConexion())
            using (var cmd = new MySqlCommand("sp_ListarDiagnosticos", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                var da = new MySqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }

    public static class ProyectoFinalDAL
    {
        public static (int idProyecto, string resultado, string mensaje) CrearProyectoFinal(
            int idEstudiante, string tema, string linkEnsayo, string linkVideo)
        {
            using (var conn = ConexionDB.ObtenerConexion())
            using (var cmd = new MySqlCommand("sp_CrearProyectoFinal", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_idEstudiante", idEstudiante);
                cmd.Parameters.AddWithValue("p_tema",         tema);
                cmd.Parameters.AddWithValue("p_linkEnsayo",   linkEnsayo ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("p_linkVideo",    linkVideo  ?? (object)DBNull.Value);
                var pId  = cmd.Parameters.Add("p_idProyecto", MySqlDbType.Int32);
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

        public static DataTable CalificarProyecto(int idProyecto, decimal notaEnsayo,
            decimal notaVideo, decimal notaDefensa, int idDocente)
        {
            using (var conn = ConexionDB.ObtenerConexion())
            using (var cmd = new MySqlCommand("sp_CalificarProyectoFinal", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_idProyecto",  idProyecto);
                cmd.Parameters.AddWithValue("p_notaEnsayo",  notaEnsayo);
                cmd.Parameters.AddWithValue("p_notaVideo",   notaVideo);
                cmd.Parameters.AddWithValue("p_notaDefensa", notaDefensa);
                cmd.Parameters.AddWithValue("p_idDocente",   idDocente);
                var da = new MySqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static DataTable ObtenerProyecto(int idEstudiante)
        {
            using (var conn = ConexionDB.ObtenerConexion())
            using (var cmd = new MySqlCommand("sp_ObtenerProyectoFinal", conn))
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

    public static class CertificadoDAL
    {
        public static (int idCertificado, string resultado, string mensaje) EmitirCertificado(
            int idEstudiante, int idAdmin)
        {
            using (var conn = ConexionDB.ObtenerConexion())
            using (var cmd = new MySqlCommand("sp_EmitirCertificado", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_idEstudiante", idEstudiante);
                cmd.Parameters.AddWithValue("p_idAdmin",      idAdmin);
                var pId  = cmd.Parameters.Add("p_idCertificado", MySqlDbType.Int32);
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

        public static DataTable ListarCertificados()
        {
            using (var conn = ConexionDB.ObtenerConexion())
            using (var cmd = new MySqlCommand("sp_ListarCertificados", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                var da = new MySqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }

    public static class ProgresoDAL
    {
        public static (string resultado, string mensaje) AvanzarModulo(int idEstudiante)
        {
            using (var conn = ConexionDB.ObtenerConexion())
            using (var cmd = new MySqlCommand("sp_AvanzarModulo", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_idEstudiante", idEstudiante);
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
    }
}
