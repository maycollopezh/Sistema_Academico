using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SistemaAcademico.BLL;
using SistemaAcademico.UI.Helpers;

namespace SistemaAcademico.UI.Admin
{
    public partial class FrmDocenteDetalle : Form
    {
        public FrmDocenteDetalle(int id = 0)
        {
            _idDocente = id; 
            _esNuevo = id == 0;
            InitializeComponent();
            AplicarEstilos();
            CargarTurnos();
            if (!_esNuevo) 
            {
                OcultarCamposCredenciales();
                CargarDatos();
            }
        }

        private void AplicarEstilos()
        {
            this.Text = _esNuevo ? "Nuevo Docente" : "Editar Docente";
            
            var encabezado = EstilosUI.CrearPanelEncabezado(_esNuevo ? "Registrar Docente" : "Editar Docente");
            this.Controls.Add(encabezado);
            encabezado.BringToFront();

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

        private void CargarTurnos()
        {
            var dt = InscripcionBLL.ListarTurnos();
            cmbTurno.DisplayMember = "NombreTurno";
            cmbTurno.ValueMember   = "idTurno";
            cmbTurno.DataSource    = dt;
        }

        private void CargarDatos()
        {
            var dt = DocenteBLL.ObtenerDocente(_idDocente);
            if (dt.Rows.Count == 0) return;
            var r = dt.Rows[0];
            txtNombre.Text = r["Nombre"]?.ToString(); 
            txtApellidoP.Text = r["ApellidoPaterno"]?.ToString();
            txtApellidoM.Text = r["ApellidoMaterno"]?.ToString(); 
            txtCI.Text = r["CI"]?.ToString();
            txtCorreo.Text = r["Correo"]?.ToString(); 
            txtTelefono.Text = r["Telefono"]?.ToString();
            txtCiudad.Text = r["Ciudad"]?.ToString();
            if (r["Sexo"]?.ToString() == "M") cmbSexo.SelectedIndex = 0; else cmbSexo.SelectedIndex = 1;
            if (r["idTurno"] != DBNull.Value) cmbTurno.SelectedValue = r["idTurno"];
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            int idTurno = cmbTurno.SelectedValue != null ? Convert.ToInt32(cmbTurno.SelectedValue) : 0;
            if (_esNuevo) {
                var (id, res, msg) = DocenteBLL.CrearDocente(txtNombre.Text.Trim(), txtApellidoP.Text.Trim(),
                    txtApellidoM.Text.Trim(), txtCI.Text.Trim(), txtCorreo.Text.Trim(), txtTelefono.Text.Trim(),
                    txtCiudad.Text.Trim(), cmbSexo.SelectedItem?.ToString(), txtUsuario?.Text.Trim(),
                    txtClave?.Text, idTurno);
                if (res == "OK") { MessageBox.Show("✅ " + msg); this.DialogResult = DialogResult.OK; this.Close(); }
                else MessageBox.Show("⚠ " + msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } else {
                DocenteBLL.ActualizarDocente(_idDocente, txtNombre.Text.Trim(), txtApellidoP.Text.Trim(),
                    txtApellidoM.Text.Trim(), txtCI.Text.Trim(), txtCorreo.Text.Trim(), txtTelefono.Text.Trim(),
                    txtCiudad.Text.Trim(), idTurno);
                MessageBox.Show("✅ Docente actualizado."); this.DialogResult = DialogResult.OK; this.Close();
            }
        }
    }
}
