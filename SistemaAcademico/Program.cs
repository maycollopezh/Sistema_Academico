using System;
using System.Windows.Forms;
using SistemaAcademico.UI.Login;

namespace SistemaAcademico
{
    /// <summary>
    /// Punto de entrada de la aplicación.
    /// Inicia con el formulario de Login, que redirige
    /// al panel correspondiente según el rol del usuario.
    /// </summary>
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Iniciar siempre en el formulario de Login
            Application.Run(new FrmLogin());
        }
    }
}
