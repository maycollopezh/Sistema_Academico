using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SistemaAcademico.BLL;
using SistemaAcademico.UI.Helpers;

namespace SistemaAcademico.UI.Admin
{
    public partial class FrmInscripcionNueva : Form
    {
        public FrmInscripcionNueva()
        {
            InitializeComponent();
            AplicarEstilos();
            CargarEstudiantes();
        }

        private void AplicarEstilos()
        {
            this.Text = "Nueva Inscripción";
            
            var encabezado = EstilosUI.CrearPanelEncabezado("Registrar Nueva Inscripción");
            this.Controls.Add(encabezado);
            encabezado.BringToFront();

            EstilosUI.EstilizarBotonExito(btnGuardar); 
            EstilosUI.EstilizarBotonSecundario(btnCancelar);
            
            btnGuardar.Click += BtnGuardar_Click;
            btnCancelar.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };
        }

        private void CargarEstudiantes()
        {
            cmbEstudiante.DisplayMember = "NombreCompleto";
            cmbEstudiante.ValueMember   = "idEstudiante";
            cmbEstudiante.DataSource    = EstudianteBLL.ListarEstudiantes();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (cmbEstudiante.SelectedValue == null) { MessageBox.Show("Seleccione un estudiante."); return; }
            var (id, res, msg) = InscripcionBLL.CrearInscripcion(
                Convert.ToInt32(cmbEstudiante.SelectedValue), dtpFecha.Value,
                cmbModalidad.Text, nudMonto.Value, dtpVencimiento.Value);
            if (res == "OK") {
                MessageBox.Show($"✅ {msg}\n\nNo olvide registrar el Examen Diagnóstico.");
                this.DialogResult = DialogResult.OK; this.Close();
            } else MessageBox.Show("⚠ " + msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
