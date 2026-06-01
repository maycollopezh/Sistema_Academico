using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SistemaAcademico.BLL;
using SistemaAcademico.UI.Helpers;

namespace SistemaAcademico.UI.Admin
{
    /// <summary>
    /// Formulario modal para crear o editar un estudiante.
    /// </summary>
    public partial class FrmEstudianteDetalle : Form
    {
        public FrmEstudianteDetalle(int idEstudiante = 0)
        {
            _idEstudiante = idEstudiante;
            _esNuevo      = idEstudiante == 0;
            InitializeComponent();
            AplicarEstilos();
            
            if (!_esNuevo) 
            {
                OcultarCamposCredenciales();
                CargarDatosEstudiante();
            }
        }

        private void AplicarEstilos()
        {
            this.Text = _esNuevo ? "Nuevo Estudiante" : "Editar Estudiante";
            
            // Estilos generales
            var encabezado = EstilosUI.CrearPanelEncabezado(_esNuevo ? "Registrar Nuevo Estudiante" : "Editar Datos del Estudiante");
            this.Controls.Add(encabezado);
            encabezado.BringToFront(); // Para que quede arriba
            
            EstilosUI.EstilizarBotonExito(btnGuardar);
            EstilosUI.EstilizarBotonSecundario(btnCancelar);
            
            btnGuardar.Click += BtnGuardar_Click;
            btnCancelar.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };
            
            chkMostrarClave.CheckedChanged += (s, e) => txtClave.PasswordChar = chkMostrarClave.Checked ? '\0' : '●';
        }

        private void OcultarCamposCredenciales()
        {
            lblUsuario.Visible = false;
            txtUsuario.Visible = false;
            lblClave.Visible = false;
            txtClave.Visible = false;
            chkMostrarClave.Visible = false;
        }

        private void CargarDatosEstudiante()
        {
            try
            {
                var dt = EstudianteBLL.ObtenerEstudiante(_idEstudiante);
                if (dt.Rows.Count == 0) return;
                var r = dt.Rows[0];
                txtNombre.Text    = r["Nombre"]?.ToString();
                txtApellidoP.Text = r["ApellidoPaterno"]?.ToString();
                txtApellidoM.Text = r["ApellidoMaterno"]?.ToString();
                txtCI.Text        = r["CI"]?.ToString();
                txtCorreo.Text    = r["Correo"]?.ToString();
                txtTelefono.Text  = r["Telefono"]?.ToString();
                txtCiudad.Text    = r["Ciudad"]?.ToString();
                txtDept.Text      = r["Departamento"]?.ToString();
                if (r["Sexo"]?.ToString() == "M") cmbSexo.SelectedIndex = 0;
                else if (r["Sexo"]?.ToString() == "F") cmbSexo.SelectedIndex = 1;
                if (DateTime.TryParse(r["FechaNacimiento"]?.ToString(), out var fn))
                    dtpFechaNac.Value = fn;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message);
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (_esNuevo)
            {
                var (id, res, msg) = EstudianteBLL.CrearEstudiante(
                    txtNombre.Text.Trim(), txtApellidoP.Text.Trim(), txtApellidoM.Text.Trim(),
                    txtCI.Text.Trim(), txtCorreo.Text.Trim(), txtTelefono.Text.Trim(),
                    txtCiudad.Text.Trim(), txtDept.Text.Trim(),
                    cmbSexo.SelectedItem?.ToString(), dtpFechaNac.Value,
                    txtUsuario?.Text.Trim(), txtClave?.Text);

                if (res == "OK")
                {
                    MessageBox.Show($"✅ {msg}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show($"⚠ {msg}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                try
                {
                    EstudianteBLL.ActualizarEstudiante(_idEstudiante,
                        txtNombre.Text.Trim(), txtApellidoP.Text.Trim(), txtApellidoM.Text.Trim(),
                        txtCI.Text.Trim(), txtCorreo.Text.Trim(), txtTelefono.Text.Trim(),
                        txtCiudad.Text.Trim(), txtDept.Text.Trim(),
                        cmbSexo.SelectedItem?.ToString(), dtpFechaNac.Value);

                    MessageBox.Show("✅ Estudiante actualizado correctamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
