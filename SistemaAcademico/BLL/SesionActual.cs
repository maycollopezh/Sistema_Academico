namespace SistemaAcademico.BLL
{
    /// <summary>
    /// Clase estática que almacena los datos del usuario autenticado
    /// durante toda la sesión de la aplicación.
    /// Se inicializa en el Login y se limpia al cerrar sesión.
    /// </summary>
    public static class SesionActual
    {
        // Datos del usuario logueado
        public static int    IdUsuario       { get; set; }
        public static string NombreUsuario   { get; set; }
        public static string NombreCompleto  { get; set; }
        public static string EstadoUsuario   { get; set; }

        // Rol del usuario: "Administrador", "Docente" o "Estudiante"
        public static int    IdRol           { get; set; }
        public static string NombreRol       { get; set; }

        // IDs de las entidades según el rol
        public static int    IdEstudiante    { get; set; }  // Solo si es Estudiante
        public static int    IdDocente       { get; set; }  // Solo si es Docente
        public static int    IdAdmin         { get; set; }  // Solo si es Administrador

        /// <summary>
        /// Indica si el usuario tiene un rol específico.
        /// </summary>
        public static bool EsAdministrador => NombreRol == "Administrador";
        public static bool EsDocente       => NombreRol == "Docente";
        public static bool EsEstudiante    => NombreRol == "Estudiante";

        /// <summary>
        /// Limpia todos los datos de sesión al cerrar sesión.
        /// </summary>
        public static void CerrarSesion()
        {
            IdUsuario      = 0;
            NombreUsuario  = null;
            NombreCompleto = null;
            EstadoUsuario  = null;
            IdRol          = 0;
            NombreRol      = null;
            IdEstudiante   = 0;
            IdDocente      = 0;
            IdAdmin        = 0;
        }
    }
}
