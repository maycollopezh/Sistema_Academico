using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SistemaAcademico.BLL;
using SistemaAcademico.UI.Helpers;

namespace SistemaAcademico.UI.Estudiante
{
    public partial class FrmMiAsistencia : Form
    {
        public FrmMiAsistencia()
        {
            InitializeComponent();
            AplicarEstilos();
            Cargar();
        }

        private void AplicarEstilos()
        {
            this.Text = "Mi Asistencia";
            
            var encabezado = EstilosUI.CrearPanelEncabezado("Mi Historial de Asistencia", "Registro de clases reservadas y asistidas. Exporta tu planilla semanal a Excel.");
            this.Controls.Add(encabezado);
            encabezado.BringToFront();

            EstilosUI.EstilizarBotonExito(btnExportar);
            EstilosUI.EstilizarBotonSecundario(btnRefrescar);
            lblResumen.ForeColor = EstilosUI.ColorPrimario;
            
            lblDetalle.ForeColor = EstilosUI.ColorPrimario;
            lblSemanal.ForeColor = EstilosUI.ColorPrimario;

            EstilosUI.EstilizarDataGrid(dgvAsistencia);
            EstilosUI.EstilizarDataGrid(dgvResumenSemanal);

            btnExportar.Click += BtnExportar_Click;
            btnRefrescar.Click += (s, e) => Cargar();
        }

        private void Cargar()
        {
            try
            {
                // Horas esta semana
                var dtH = ReservaBLL.ContarHorasSemana(SesionActual.IdEstudiante);
                int h   = dtH.Rows.Count > 0 ? Convert.ToInt32(dtH.Rows[0]["HorasSemana"]) : 0;
                lblResumen.Text      = $"Horas reservadas esta semana: {h} h";
                lblResumen.ForeColor = h >= 5 ? EstilosUI.ColorExito : EstilosUI.ColorAdvertencia;

                // Detalle asistencia
                _dtAsistencia             = ReservaBLL.ListarAsistencia(SesionActual.IdEstudiante);
                dgvAsistencia.DataSource  = _dtAsistencia;
                var ocultar = new[] { "idReserva", "idClase", "idEstudiante", "LinkZoom" };
                foreach (DataGridViewColumn col in dgvAsistencia.Columns)
                    col.Visible = Array.IndexOf(ocultar, col.Name) < 0;

                // Resumen semanal
                dgvResumenSemanal.DataSource = ReservaBLL.ResumenSemanal(SesionActual.IdEstudiante);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar asistencia:\n" + ex.Message);
            }
        }

        private void BtnExportar_Click(object sender, EventArgs e)
        {
            if (_dtAsistencia == null || _dtAsistencia.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos de asistencia para exportar.", "Sin datos",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nombreArchivo = $"Asistencia_{SesionActual.NombreCompleto.Replace(" ", "_")}_{DateTime.Now:yyyy-MM-dd}";
            ExcelHelper.ExportarDataTable(_dtAsistencia, nombreArchivo, "Mi Asistencia");
        }
    }
}
