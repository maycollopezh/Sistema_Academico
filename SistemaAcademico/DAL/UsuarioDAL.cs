using System;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using MySql.Data.MySqlClient;
using SistemaAcademico.DataAccess;

namespace SistemaAcademico.DAL
{
    /// <summary>
    /// Repositorio de acceso a datos para Usuarios.
    /// Llama a los procedimientos almacenados del módulo de autenticación.
    /// </summary>
    public static class UsuarioDAL
    {
        /// <summary>
        /// Genera un hash SHA-256 de la contraseña en texto plano.
        /// El mismo hash que usa MySQL con SHA2(clave, 256).
        /// </summary>
        public static string HashearClave(string claveTextoPlano)
        {
            using (var sha = SHA256.Create())
            {
                var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(claveTextoPlano));
                var sb = new StringBuilder();
                foreach (var b in bytes) sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }

        /// <summary>
        /// Autentica al usuario. Retorna DataTable con los datos si es correcto,
        /// o DataTable vacío si las credenciales son incorrectas.
        /// </summary>
        public static DataTable Login(string nombreUsuario, string clave)
        {
            using (var conn = ConexionDB.ObtenerConexion())
            using (var cmd = new MySqlCommand("sp_Login", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_nombreUsuario", nombreUsuario);
                cmd.Parameters.AddWithValue("p_clave", HashearClave(clave));
                var da = new MySqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        /// <summary>
        /// Cambia la contraseña del usuario (valida la contraseña anterior).
        /// </summary>
        public static DataTable CambiarContrasena(int idUsuario, string claveVieja, string claveNueva)
        {
            using (var conn = ConexionDB.ObtenerConexion())
            using (var cmd = new MySqlCommand("sp_CambiarContrasena", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_idUsuario", idUsuario);
                cmd.Parameters.AddWithValue("p_claveVieja", HashearClave(claveVieja));
                cmd.Parameters.AddWithValue("p_claveNueva", HashearClave(claveNueva));
                var da = new MySqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        /// <summary>
        /// Cambia el estado de un usuario: 'Activo', 'Inactivo' o 'Bloqueado'.
        /// </summary>
        public static void CambiarEstadoUsuario(int idUsuario, string estado)
        {
            using (var conn = ConexionDB.ObtenerConexion())
            using (var cmd = new MySqlCommand("sp_CambiarEstadoUsuario", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_idUsuario", idUsuario);
                cmd.Parameters.AddWithValue("p_estado", estado);
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Lista todos los usuarios del sistema con su rol.
        /// </summary>
        public static DataTable ListarUsuarios()
        {
            using (var conn = ConexionDB.ObtenerConexion())
            using (var cmd = new MySqlCommand("sp_ListarUsuarios", conn))
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
