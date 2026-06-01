using System;
using System.Drawing;
using System.Windows.Forms;
using SistemaAcademico.BLL;
using SistemaAcademico.UI.Admin;
using SistemaAcademico.UI.Docente;
using SistemaAcademico.UI.Estudiante;

namespace SistemaAcademico.UI.Login
{
    /// <summary>
    /// Formulario de inicio de sesión del sistema.
    /// Redirige al panel correspondiente según el rol del usuario autenticado.
    /// </summary>
    public partial class FrmLogin : Form
    {

        public FrmLogin()
        {
            InitializeComponent();
        }

        // ── Evento Login ─────────────────────────────────────────────────────
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            OcultarError();

            var usuario = txtUsuario.Text.Trim();
            var clave   = txtClave.Text;

            if (string.IsNullOrEmpty(usuario))
            { MostrarError("Ingrese su nombre de usuario."); return; }
            if (string.IsNullOrEmpty(clave))
            { MostrarError("Ingrese su contraseña."); return; }

            btnLogin.Enabled = false;
            btnLogin.Text    = "  Verificando...";

            var resultado = AuthBLL.IniciarSesion(usuario, clave);
            btnLogin.Enabled = true;
            btnLogin.Text    = "  INICIAR SESIÓN";

            switch (resultado)
            {
                case AuthBLL.ResultadoLogin.Exitoso:
                    AbrirPanelSegunRol();
                    break;
                case AuthBLL.ResultadoLogin.CredencialesInvalidas:
                    MostrarError("Usuario o contraseña incorrectos.");
                    txtClave.Clear();
                    break;
                case AuthBLL.ResultadoLogin.UsuarioBloqueado:
                    MostrarError("Cuenta bloqueada por falta de pago. Contacte al administrador.");
                    break;
                case AuthBLL.ResultadoLogin.UsuarioInactivo:
                    MostrarError("Esta cuenta está inactiva. Contacte al administrador.");
                    break;
            }
        }

        private void AbrirPanelSegunRol()
        {
            this.Hide();
            Form panelPrincipal;

            switch (SesionActual.NombreRol)
            {
                case "Administrador":
                    panelPrincipal = new FrmPrincipalAdmin();
                    break;
                case "Docente":
                    panelPrincipal = new FrmPrincipalDocente();
                    break;
                case "Estudiante":
                    // Verificar acceso por pago antes de abrir
                    var acceso = AuthBLL.VerificarAccesoEstudiante(SesionActual.IdEstudiante);
                    if (acceso == "BLOQUEADO")
                    {
                        this.Show();
                        MostrarError("Acceso bloqueado por pago vencido. Contacte al administrador.");
                        return;
                    }
                    panelPrincipal = new FrmPrincipalEstudiante();
                    break;
                default:
                    this.Show();
                    MostrarError("Rol no reconocido. Contacte al administrador.");
                    return;
            }

            panelPrincipal.FormClosed += (s, e) =>
            {
                AuthBLL.CerrarSesion();
                txtUsuario.Clear();
                txtClave.Clear();
                this.Show();
            };
            panelPrincipal.Show();
        }

        private void MostrarError(string mensaje)
        {
            lblError.Text    = "⚠ " + mensaje;
            lblError.Visible = true;
        }

        private void OcultarError()
        {
            lblError.Visible = false;
        }

        // ── Eventos de UI ────────────────────────────────────────────────────
        private void pnlCard_Paint(object sender, PaintEventArgs e)
        {
            // Sombra usando borde pintado
            e.Graphics.DrawRectangle(new Pen(Color.FromArgb(30, 0, 0, 0), 2),
                1, 1, pnlCard.Width - 2, pnlCard.Height - 2);
        }

        private void txtClave_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) BtnLogin_Click(sender, e);
        }

        private void chkMostrarClave_CheckedChanged(object sender, EventArgs e)
        {
            txtClave.PasswordChar = chkMostrarClave.Checked ? '\0' : '●';
        }

        private void btnLogin_MouseEnter(object sender, EventArgs e)
        {
            btnLogin.BackColor = Color.FromArgb(27, 82, 140);
        }

        private void btnLogin_MouseLeave(object sender, EventArgs e)
        {
            btnLogin.BackColor = Color.FromArgb(46, 109, 164);
        }
    }

}
