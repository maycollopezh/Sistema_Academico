using System;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace SistemaAcademico.DataAccess
{
    /// <summary>
    /// Clase singleton para gestionar la conexión a la base de datos MySQL.
    /// Lee la cadena de conexión desde App.config.
    /// Todas las capas DAL usan este método para obtener conexiones.
    /// </summary>
    public static class ConexionDB
    {
        // Cadena de conexión leída desde App.config
        private static readonly string _connectionString =
            ConfigurationManager.ConnectionStrings["AcademiaDB"].ConnectionString;

        /// <summary>
        /// Crea y abre una nueva conexión MySQL.
        /// Usar siempre dentro de un bloque using() para que se cierre automáticamente.
        /// </summary>
        /// <returns>MySqlConnection ya abierta</returns>
        public static MySqlConnection ObtenerConexion()
        {
            var conn = new MySqlConnection(_connectionString);
            conn.Open();
            return conn;
        }

        /// <summary>
        /// Prueba si la conexión con la base de datos es exitosa.
        /// Útil para diagnóstico al iniciar la aplicación.
        /// </summary>
        /// <returns>true si la conexión es exitosa</returns>
        public static bool PruebaConecion()
        {
            try
            {
                using (var conn = ObtenerConexion())
                    return conn.State == System.Data.ConnectionState.Open;
            }
            catch
            {
                return false;
            }
        }
    }
}
