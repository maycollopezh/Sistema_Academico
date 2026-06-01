using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SistemaAcademico.BLL;
using SistemaAcademico.UI.Helpers;

namespace SistemaAcademico.UI.Estudiante
{
    public partial class FrmMisPlanillas : Form
    {
        public FrmMisPlanillas()
        {
            InitializeComponent();
            AplicarEstilos();
            CargarModulos();
        }

        private void AplicarEstilos()
        {
            this.Text = "Mis Planillas de Evaluación";
            
            var encabezado = EstilosUI.CrearPanelEncabezado("Mis Planillas de Evaluación", "Consulta tus notas por tema y resultados de exámenes. Mínimo aprobatorio: 51.");
            this.Controls.Add(encabezado);
            encabezado.BringToFront();

            EstilosUI.EstilizarBotonPrimario(btnCargar);
            lblTemas.ForeColor = EstilosUI.ColorPrimario;
            lblExamenes.ForeColor = EstilosUI.ColorPrimario;
            
            EstilosUI.EstilizarDataGrid(dgvTemas);
            EstilosUI.EstilizarDataGrid(dgvExamenes);

            btnCargar.Click += (s, e) => CargarPlanilla();
        }

        private void CargarModulos()
        {
            cmbModulo.DisplayMember = "NombreModulo";
            cmbModulo.ValueMember   = "idModulo";
            cmbModulo.DataSource    = InscripcionBLL.ListarModulos();
        }

        private void CargarPlanilla()
        {
            if (cmbModulo.SelectedValue == null) return;
            int idMod = Convert.ToInt32(cmbModulo.SelectedValue);
            try
            {
                var ds = EvaluacionBLL.ObtenerPlanillaCompleta(SesionActual.IdEstudiante, idMod);
                if (ds.Tables.Count == 0) { MessageBox.Show("No existe planilla para este módulo."); return; }

                if (ds.Tables.Count > 1) dgvTemas.DataSource    = ds.Tables[1];
                if (ds.Tables.Count > 2) dgvExamenes.DataSource = ds.Tables[2];

                // Resumen en encabezado
                if (ds.Tables[0].Rows.Count > 0)
                {
                    var r   = ds.Tables[0].Rows[0];
                    string nota = r.Table.Columns.Contains("NotaFinal") ? r["NotaFinal"]?.ToString() : "--";
                    lblResumen.Text      = $"Nota Final: {nota}  |  Estado: {(r.Table.Columns.Contains("EstadoPlanilla") ? r["EstadoPlanilla"] : "--")}";
                    lblResumen.ForeColor = EstilosUI.ColorSecundario;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar planilla:\n" + ex.Message);
            }
        }
    }
}
