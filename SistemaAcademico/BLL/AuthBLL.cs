using System;
using System.Data;
using SistemaAcademico.DAL;

namespace SistemaAcademico.BLL
{
    /// <summary>
    /// Lógica de negocio para Autenticación.
    /// Valida credenciales, llena SesionActual y verifica acceso.
    /// </summary>
    public static class AuthBLL
    {
        public enum ResultadoLogin { Exitoso, CredencialesInvalidas, UsuarioBloqueado, UsuarioInactivo }

        /// <summary>
        /// Intenta autenticar al usuario.
        /// Retorna el resultado y rellena SesionActual si es exitoso.
        /// </summary>
        public static ResultadoLogin IniciarSesion(string nombreUsuario, string clave)
        {
            var dt = UsuarioDAL.Login(nombreUsuario, clave);

            if (dt == null || dt.Rows.Count == 0)
                return ResultadoLogin.CredencialesInvalidas;

            var fila = dt.Rows[0];
            var estado = fila["Estado"]?.ToString() ?? "Activo";

            if (estado == "Inactivo")
                return ResultadoLogin.UsuarioInactivo;

            if (estado == "Bloqueado")
                return ResultadoLogin.UsuarioBloqueado;

            // Rellenar sesión
            SesionActual.IdUsuario      = Convert.ToInt32(fila["idUsuario"]);
            SesionActual.NombreUsuario  = fila["NombreUsuario"]?.ToString();
            SesionActual.NombreCompleto = fila["NombreCompleto"]?.ToString();
            SesionActual.EstadoUsuario  = estado;
            SesionActual.IdRol          = Convert.ToInt32(fila["idRol"]);
            SesionActual.NombreRol      = fila["NombreRol"]?.ToString();
            SesionActual.IdEstudiante   = fila["idEstudiante"] == DBNull.Value ? 0 : Convert.ToInt32(fila["idEstudiante"]);
            SesionActual.IdDocente      = fila["idDocente"]    == DBNull.Value ? 0 : Convert.ToInt32(fila["idDocente"]);
            SesionActual.IdAdmin        = fila["idAdmin"]      == DBNull.Value ? 0 : Convert.ToInt32(fila["idAdmin"]);

            return ResultadoLogin.Exitoso;
        }

        // Estructura de Datos: Tablas Hash (Diccionarios)
        // Uso: Cache temporal de validación de estado de pagos para evitar múltiples consultas a la BD.
        private static readonly System.Collections.Generic.Dictionary<int, string> CacheAccesoEstudiantes = new System.Collections.Generic.Dictionary<int, string>();

        /// <summary>Verifica si un estudiante puede acceder según su estado de pago.</summary>
        public static string VerificarAccesoEstudiante(int idEstudiante)
        {
            if (CacheAccesoEstudiantes.ContainsKey(idEstudiante))
                return CacheAccesoEstudiantes[idEstudiante];

            var dt = EstudianteDAL.VerificarAccesoPago(idEstudiante);
            string acceso = dt.Rows.Count == 0 ? "PERMITIDO" : (dt.Rows[0]["Acceso"]?.ToString() ?? "PERMITIDO");
            
            CacheAccesoEstudiantes[idEstudiante] = acceso;
            return acceso;
        }

        public static void LimpiarCacheAcceso() => CacheAccesoEstudiantes.Clear();

        public static void CerrarSesion() 
        {
            LimpiarCacheAcceso();
            SesionActual.CerrarSesion();
        }
    }
}
