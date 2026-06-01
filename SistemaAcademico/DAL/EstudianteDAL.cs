using System;
using System.Data;
using MySql.Data.MySqlClient;
using SistemaAcademico.DataAccess;

namespace SistemaAcademico.DAL
{
    /// <summary>
    /// Repositorio de datos para Estudiantes.
    /// Invoca los procedimientos almacenados del grupo de Estudiantes.
    /// </summary>
    public static class EstudianteDAL
    {
        /// <summary>
        /// Crea un estudiante completo (persona + estudiante + usuario + rol).
        /// Llama al SP sp_CrearEstudiante que ejecuta todo en una transacción.
        /// </summary>
        public static (int idEstudiante, string resultado, string mensaje) CrearEstudiante(
            string nombre, string apellidoPaterno, string apellidoMaterno,
            string ci, string correo, string telefono,
            string ciudad, string departamento, string sexo,
            DateTime? fechaNacimiento, string nombreUsuario, string clave)
        {
            using (var conn = ConexionDB.ObtenerConexion())
            using (var cmd = new MySqlCommand("sp_CrearEstudiante", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_nombre",          nombre);
                cmd.Parameters.AddWithValue("p_apellidoPaterno", apellidoPaterno);
                cmd.Parameters.AddWithValue("p_apellidoMaterno", apellidoMaterno ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("p_ci",              ci);
                cmd.Parameters.AddWithValue("p_correo",          correo ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("p_telefono",        telefono ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("p_ciudad",          ciudad ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("p_departamento",    departamento ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("p_sexo",            sexo ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("p_fechaNacimiento", fechaNacimiento.HasValue ? (object)fechaNacimiento.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("p_nombreUsuario",   nombreUsuario);
                // Hashear contraseña antes de enviar
                cmd.Parameters.AddWithValue("p_clave", UsuarioDAL.HashearClave(clave));

                // Parámetros de salida
                var pId  = cmd.Parameters.Add("p_idEstudiante", MySqlDbType.Int32);
                var pRes = cmd.Parameters.Add("p_resultado",    MySqlDbType.VarChar, 10);
                var pMsg = cmd.Parameters.Add("p_mensaje",      MySqlDbType.VarChar, 200);
                pId.Direction = pRes.Direction = pMsg.Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                return (
                    pId.Value  == DBNull.Value ? 0  : Convert.ToInt32(pId.Value),
                    pRes.Value == DBNull.Value ? "" : pRes.Value.ToString(),
                    pMsg.Value == DBNull.Value ? "" : pMsg.Value.ToString()
                );
            }
        }

        /// <summary>Obtiene todos los datos de un estudiante por su ID.</summary>
        public static DataTable ObtenerEstudiante(int idEstudiante)
        {
            using (var conn = ConexionDB.ObtenerConexion())
            using (var cmd = new MySqlCommand("sp_ObtenerEstudiante", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_idEstudiante", idEstudiante);
                var da = new MySqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        /// <summary>Lista todos los estudiantes del sistema.</summary>
        public static DataTable ListarEstudiantes()
        {
            using (var conn = ConexionDB.ObtenerConexion())
            using (var cmd = new MySqlCommand("sp_ListarEstudiantes", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                var da = new MySqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        /// <summary>Actualiza los datos personales de un estudiante.</summary>
        public static void ActualizarEstudiante(int idEstudiante, string nombre,
            string apellidoPaterno, string apellidoMaterno, string ci,
            string correo, string telefono, string ciudad, string departamento,
            string sexo, DateTime? fechaNacimiento)
        {
            using (var conn = ConexionDB.ObtenerConexion())
            using (var cmd = new MySqlCommand("sp_ActualizarEstudiante", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_idEstudiante",    idEstudiante);
                cmd.Parameters.AddWithValue("p_nombre",          nombre);
                cmd.Parameters.AddWithValue("p_apellidoPaterno", apellidoPaterno);
                cmd.Parameters.AddWithValue("p_apellidoMaterno", apellidoMaterno ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("p_ci",              ci);
                cmd.Parameters.AddWithValue("p_correo",          correo ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("p_telefono",        telefono ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("p_ciudad",          ciudad ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("p_departamento",    departamento ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("p_sexo",            sexo ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("p_fechaNacimiento", fechaNacimiento.HasValue ? (object)fechaNacimiento.Value : DBNull.Value);
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>Baja lógica del estudiante (no elimina físicamente).</summary>
        public static void EliminarEstudiante(int idEstudiante)
        {
            using (var conn = ConexionDB.ObtenerConexion())
            using (var cmd = new MySqlCommand("sp_EliminarEstudiante", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_idEstudiante", idEstudiante);
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>Verifica si el estudiante puede acceder según su estado de pago.</summary>
        public static DataTable VerificarAccesoPago(int idEstudiante)
        {
            using (var conn = ConexionDB.ObtenerConexion())
            using (var cmd = new MySqlCommand("sp_VerificarAccesoPago", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_idEstudiante", idEstudiante);
                var da = new MySqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        /// <summary>Obtiene el módulo actual en progreso del estudiante.</summary>
        public static DataTable ObtenerModuloActual(int idEstudiante)
        {
            using (var conn = ConexionDB.ObtenerConexion())
            using (var cmd = new MySqlCommand("sp_ObtenerModuloActual", conn))
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
