using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SistemaAcademico.BLL;
using SistemaAcademico.UI.Helpers;

namespace SistemaAcademico.UI.Docente
{
    public partial class FrmRegistrarExamen : Form
    {
        public FrmRegistrarExamen()
        {
            InitializeComponent();
            AplicarEstilos();
            CargarEstudiantes();
        }

        private void AplicarEstilos()
        {
            this.Text = "Registrar Examen de Módulo";
            
            var encabezado = EstilosUI.CrearPanelEncabezado("Registrar Examen de Módulo", "Examen Teórico y Oral. Mínimo 51 para aprobar. Peso: 20% c/u.");
            this.Controls.Add(encabezado);
            encabezado.BringToFront();

            EstilosUI.EstilizarBotonExito(btnRegistrar);
            EstilosUI.EstilizarBotonPrimario(btnVerificarAprobacion);
            lblResultado.ForeColor = EstilosUI.ColorSecundario;

            btnRegistrar.Click += BtnRegistrar_Click;
            btnVerificarAprobacion.Click += BtnVerificar_Click;
        }

        private void CargarEstudiantes()
        {
            cmbEstudiante.DisplayMember = "NombreCompleto"; 
            cmbEstudiante.ValueMember = "idEstudiante";
            cmbEstudiante.DataSource = EstudianteBLL.ListarEstudiantes();
        }

        private int ObtenerPlanilla()
        {
            int idEst = Convert.ToInt32(cmbEstudiante.SelectedValue);
            var dtMod = EstudianteBLL.ObtenerModuloActual(idEst);
            if (dtMod.Rows.Count == 0) return 0;
            int idMod = Convert.ToInt32(dtMod.Rows[0]["idModulo"]);
            var ds = EvaluacionBLL.ObtenerPlanillaCompleta(idEst, idMod);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return Convert.ToInt32(ds.Tables[0].Rows[0]["idPlanilla"]);
            return EvaluacionBLL.CrearPlanilla(idEst, idMod);
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            if (cmbEstudiante.SelectedValue == null) { MessageBox.Show("Seleccione un estudiante."); return; }
            int idPlanilla = ObtenerPlanilla();
            if (idPlanilla == 0) { MessageBox.Show("El estudiante no tiene módulo activo."); return; }
            var (res, msg) = EvaluacionBLL.RegistrarExamen(idPlanilla, cmbTipo.Text, nudNota.Value, SesionActual.IdDocente);
            lblResultado.Text      = res == "OK" ? "✅ " + msg : "⚠ " + msg;
            lblResultado.ForeColor = res == "OK" ? EstilosUI.ColorExito : EstilosUI.ColorPeligro;
        }

        private void BtnVerificar_Click(object sender, EventArgs e)
        {
            if (cmbEstudiante.SelectedValue == null) { MessageBox.Show("Seleccione un estudiante."); return; }
            int idEst = Convert.ToInt32(cmbEstudiante.SelectedValue);
            var dtMod = EstudianteBLL.ObtenerModuloActual(idEst);
            if (dtMod.Rows.Count == 0) { MessageBox.Show("Sin módulo activo."); return; }
            int idMod = Convert.ToInt32(dtMod.Rows[0]["idModulo"]);
            var dt = EvaluacionBLL.VerificarAprobacion(idEst, idMod);
            if (dt.Rows.Count > 0)
            {
                var r = dt.Rows[0];
                bool aprobado = Convert.ToBoolean(r["Aprobado"]);
                string info = $"Promedio Temas: {r["PromedioTemas"]}\nExamen Teórico: {r["ExamenTeorico"]}\nExamen Oral: {r["ExamenOral"]}\nCalificación Final: {r["NotaFinal"]}";
                if (aprobado) {
                    if (MessageBox.Show($"✅ APROBADO\n\n{info}\n\n¿Avanzar al siguiente módulo?",
                        "Resultado", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        var (res2, msg2) = EvaluacionBLL.AvanzarModulo(idEst);
                        MessageBox.Show(res2 == "OK" ? "✅ " + msg2 : "⚠ " + msg2);
                    }
                } else {
                    MessageBox.Show($"❌ NO APROBADO\n\n{info}", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
