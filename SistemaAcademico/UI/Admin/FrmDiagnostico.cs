using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SistemaAcademico.BLL;
using SistemaAcademico.UI.Helpers;

namespace SistemaAcademico.UI.Admin
{
    public partial class FrmDiagnostico : Form
    {
        public FrmDiagnostico() 
        { 
            InitializeComponent();
            AplicarEstilos();
            CargarEstudiantes(); 
            CargarModulos(); 
            CargarDiagnosticos();
        }

        private void AplicarEstilos()
        {
            this.Text = "Examen Diagnóstico";
            
            var encabezado = EstilosUI.CrearPanelEncabezado("Examen Diagnóstico", "Evalúa el nivel inicial y asigna el módulo de inicio (normalmente Módulo 1, excepcionalmente Módulo 2).");
            this.Controls.Add(encabezado);
            encabezado.BringToFront();

            EstilosUI.EstilizarBotonExito(btnRegistrar);
            EstilosUI.EstilizarDataGrid(dgvDiagnosticos);
            lblRegistrados.ForeColor = EstilosUI.ColorPrimario;

            btnRegistrar.Click += BtnRegistrar_Click;
        }

        private void CargarEstudiantes()
        {
            cmbEstudiante.DisplayMember = "NombreCompleto"; cmbEstudiante.ValueMember = "idEstudiante";
            cmbEstudiante.DataSource = EstudianteBLL.ListarEstudiantes();
        }

        private void CargarModulos() 
        { 
            cmbModulo.DisplayMember = "NombreModulo"; cmbModulo.ValueMember = "idModulo"; 
            cmbModulo.DataSource = InscripcionBLL.ListarModulos(); 
        }

        private void CargarDiagnosticos()
        {
            try
            {
                var dt = EvaluacionBLL.ListarDiagnosticos();
                dgvDiagnosticos.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar diagnósticos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            if (cmbEstudiante.SelectedValue == null || cmbModulo.SelectedValue == null) { MessageBox.Show("Complete todos los campos."); return; }
            var (res, msg) = EvaluacionBLL.RegistrarDiagnostico(
                Convert.ToInt32(cmbEstudiante.SelectedValue), dtpFecha.Value,
                (int)nudPuntaje.Value, txtNivel.Text.Trim(), txtObservaciones.Text.Trim(),
                Convert.ToInt32(cmbModulo.SelectedValue));
            MessageBox.Show(res == "OK" ? "✅ " + msg : "⚠ " + msg,
                "Resultado", MessageBoxButtons.OK,
                res == "OK" ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
            
            if (res == "OK") CargarDiagnosticos();
        }
    }
}
