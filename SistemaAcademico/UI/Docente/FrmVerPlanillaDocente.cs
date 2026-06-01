using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SistemaAcademico.BLL;
using SistemaAcademico.UI.Helpers;

namespace SistemaAcademico.UI.Docente
{
    public partial class FrmVerPlanillaDocente : Form
    {
        public FrmVerPlanillaDocente() 
        { 
            InitializeComponent();
            AplicarEstilos();
            CargarEstudiantes(); 
        }

        private void AplicarEstilos()
        {
            this.Text = "Ver Planilla de Evaluación";
            
            var encabezado = EstilosUI.CrearPanelEncabezado("Planilla de Evaluación del Estudiante", "Visualiza las notas de temas y exámenes del módulo actual.");
            this.Controls.Add(encabezado);
            encabezado.BringToFront();

            EstilosUI.EstilizarBotonPrimario(btnCargar);
            EstilosUI.EstilizarDataGrid(dgvTemas);
            EstilosUI.EstilizarDataGrid(dgvExamenes);

            lblTemas.ForeColor = EstilosUI.ColorPrimario;
            lblExamenes.ForeColor = EstilosUI.ColorPrimario;

            btnCargar.Click += (s, e) => CargarPlanilla();
        }

        private void CargarEstudiantes()
        {
            cmbEstudiante.DisplayMember = "NombreCompleto"; cmbEstudiante.ValueMember = "idEstudiante";
            cmbEstudiante.DataSource = EstudianteBLL.ListarEstudiantes();
        }

        private void CargarPlanilla()
        {
            if (cmbEstudiante.SelectedValue == null) return;
            int idEst = Convert.ToInt32(cmbEstudiante.SelectedValue);
            var dtMod = EstudianteBLL.ObtenerModuloActual(idEst);
            if (dtMod.Rows.Count == 0) { MessageBox.Show("El estudiante no tiene módulo activo."); return; }
            int idMod = Convert.ToInt32(dtMod.Rows[0]["idModulo"]);
            lblResumen.Text = $"Módulo: {dtMod.Rows[0]["NombreModulo"]}";

            var ds = EvaluacionBLL.ObtenerPlanillaCompleta(idEst, idMod);
            if (ds.Tables.Count > 1) dgvTemas.DataSource    = ds.Tables[1];
            if (ds.Tables.Count > 2) dgvExamenes.DataSource = ds.Tables[2];
        }

        private void lblTemas_Click(object sender, EventArgs e)
        {

        }
    }
}
