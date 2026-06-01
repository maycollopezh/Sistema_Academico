using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SistemaAcademico.BLL;
using SistemaAcademico.UI.Helpers;

namespace SistemaAcademico.UI.Estudiante
{
    public partial class FrmReservarClase : Form
    {
        public FrmReservarClase()
        {
            InitializeComponent();
            AplicarEstilos();
            CargarDatos();
        }

        private void AplicarEstilos()
        {
            this.Text = "Reservar una Clase";
            
            var encabezado = EstilosUI.CrearPanelEncabezado("Reservar Clase", "Selecciona una clase y presiona 'Reservar'. Máximo 8 alumnos por clase. Mínimo 5 h/semana.");
            this.Controls.Add(encabezado);
            encabezado.BringToFront();

            EstilosUI.EstilizarBotonExito(btnReservar);
            EstilosUI.EstilizarBotonSecundario(btnRefrescar);
            EstilosUI.EstilizarDataGrid(dgvClases);
            lblHorasSemana.ForeColor = EstilosUI.ColorPrimario;

            btnReservar.Click += BtnReservar_Click;
            btnRefrescar.Click += (s, e) => CargarDatos();
        }

        private void CargarDatos()
        {
            try
            {
                // Horas reservadas esta semana
                var dtH = ReservaBLL.ContarHorasSemana(SesionActual.IdEstudiante);
                int horas = dtH.Rows.Count > 0 ? Convert.ToInt32(dtH.Rows[0]["HorasSemana"]) : 0;
                lblHorasSemana.Text      = $"Horas reservadas esta semana: {horas}/5 mínimo";
                lblHorasSemana.ForeColor = horas >= 5 ? EstilosUI.ColorExito : EstilosUI.ColorAdvertencia;

                // Clases disponibles
                dgvClases.DataSource = HorarioBLL.ObtenerHorarioEstudiante(SesionActual.IdEstudiante);
                var ocultar = new[] { "idHorario", "idDocente", "LinkZoom" };
                foreach (DataGridViewColumn col in dgvClases.Columns)
                    col.Visible = Array.IndexOf(ocultar, col.Name) < 0;

                // Resaltar cupo lleno en rojo
                dgvClases.CellFormatting += (s, e) =>
                {
                    if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
                    if (dgvClases.Columns[e.ColumnIndex].Name == "CupoActual")
                    {
                        var actual = dgvClases.Rows[e.RowIndex].Cells["CupoActual"]?.Value?.ToString();
                        var max    = dgvClases.Rows[e.RowIndex].Cells["CupoMaximo"]?.Value?.ToString();
                        if (actual == max)
                        {
                            e.CellStyle.ForeColor  = Color.Red;
                            e.CellStyle.Font       = new Font("Segoe UI", 9f, FontStyle.Bold);
                            e.Value                = actual + " (LLENO)";
                            e.FormattingApplied    = true;
                        }
                    }
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clases:\n" + ex.Message);
            }
        }

        private void BtnReservar_Click(object sender, EventArgs e)
        {
            if (dgvClases.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una clase de la lista.", "Selección requerida",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idClase = Convert.ToInt32(dgvClases.CurrentRow.Cells["idClase"].Value);
            var fecha   = dgvClases.CurrentRow.Cells["Fecha"]?.Value?.ToString();
            var hora    = dgvClases.CurrentRow.Cells["HoraInicio"]?.Value?.ToString();

            if (MessageBox.Show(
                $"¿Confirmas la reserva para la clase del {fecha} a las {hora}?",
                "Confirmar Reserva",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var (id, res, msg) = ReservaBLL.CrearReserva(SesionActual.IdEstudiante, idClase);
                MessageBox.Show(res == "OK" ? $"✅ {msg}" : $"⚠ {msg}",
                    "Resultado", MessageBoxButtons.OK,
                    res == "OK" ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
                CargarDatos();
            }
        }
    }
}
