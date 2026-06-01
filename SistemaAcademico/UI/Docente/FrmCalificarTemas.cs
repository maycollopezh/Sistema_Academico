using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SistemaAcademico.BLL;
using SistemaAcademico.UI.Helpers;

namespace SistemaAcademico.UI.Docente
{
    public partial class FrmCalificarTemas : Form
    {
        public FrmCalificarTemas()
        {
            InitializeComponent();
            AplicarEstilos();
            CargarEstudiantes();
        }

        private void AplicarEstilos()
        {
            this.Text = "Calificar Temas";
            
            var encabezado = EstilosUI.CrearPanelEncabezado("Calificar Temas del Módulo", "Ingrese las notas por habilidad para cada tema (Speaking, Writing, Listening, Reading). Mínimo aprobatorio: 51.");
            this.Controls.Add(encabezado);
            encabezado.BringToFront();

            EstilosUI.EstilizarBotonSecundario(btnRefrescar);
            EstilosUI.EstilizarBotonExito(btnRegistrar);
            EstilosUI.EstilizarDataGrid(dgvNotas);

            cmbEstudiante.SelectedIndexChanged += (s, e) => CargarPlanilla();
            btnRefrescar.Click += (s, e) => CargarPlanilla();
            btnRegistrar.Click += BtnRegistrar_Click;
        }

        private void CargarEstudiantes()
        {
            cmbEstudiante.DisplayMember = "NombreCompleto"; 
            cmbEstudiante.ValueMember = "idEstudiante";
            cmbEstudiante.DataSource = EstudianteBLL.ListarEstudiantes();
        }

        private void CargarPlanilla()
        {
            if (cmbEstudiante.SelectedValue == null) return;
            int idEst = Convert.ToInt32(cmbEstudiante.SelectedValue);
            try
            {
                // Obtener módulo actual
                var dtMod = EstudianteBLL.ObtenerModuloActual(idEst);
                if (dtMod.Rows.Count == 0) { lblInfoModulo.Text = "Sin módulo activo"; return; }
                int idMod = Convert.ToInt32(dtMod.Rows[0]["idModulo"]);
                lblInfoModulo.Text = $"📚 Módulo actual: {dtMod.Rows[0]["NombreModulo"]}";

                // Obtener planilla
                var ds = EvaluacionBLL.ObtenerPlanillaCompleta(idEst, idMod);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    _idPlanilla = Convert.ToInt32(ds.Tables[0].Rows[0]["idPlanilla"]);
                    if (ds.Tables.Count > 1) dgvNotas.DataSource = ds.Tables[1]; // Notas de tema
                }
                else
                {
                    // Crear planilla si no existe
                    _idPlanilla = EvaluacionBLL.CrearPlanilla(idEst, idMod);
                    lblInfoModulo.Text += " (Planilla creada)";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            if (_idPlanilla == 0) { MessageBox.Show("Seleccione un estudiante con módulo activo."); return; }
            var (res, msg) = EvaluacionBLL.RegistrarNotaTema(
                _idPlanilla, (int)nudTema.Value,
                nudSpeaking.Value, nudWriting.Value,
                nudListening.Value, nudReading.Value,
                SesionActual.IdDocente);
            MessageBox.Show(res == "OK" ? "✅ " + msg : "⚠ " + msg,
                "Resultado", MessageBoxButtons.OK,
                res == "OK" ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
            if (res == "OK") CargarPlanilla();
        }
    }
}
