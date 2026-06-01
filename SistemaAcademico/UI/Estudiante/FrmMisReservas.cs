using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SistemaAcademico.BLL;
using SistemaAcademico.UI.Helpers;

namespace SistemaAcademico.UI.Estudiante
{
    public partial class FrmMisReservas : Form
    {
        public FrmMisReservas()
        {
            InitializeComponent();
            AplicarEstilos();
            Cargar();
        }

        private void AplicarEstilos()
        {
            this.Text = "Mis Reservas";
            
            var encabezado = EstilosUI.CrearPanelEncabezado("Mis Reservas de Clases", "Aquí puedes ver y cancelar tus clases reservadas. No puedes cancelar después de que inicie.");
            this.Controls.Add(encabezado);
            encabezado.BringToFront();

            EstilosUI.EstilizarBotonPeligro(btnCancelar);
            EstilosUI.EstilizarBotonSecundario(btnRefrescar);
            EstilosUI.EstilizarDataGrid(dgv);
            
            lblHorasSemana.ForeColor = EstilosUI.ColorPrimario;

            btnCancelar.Click += BtnCancelar_Click;
            btnRefrescar.Click += (s, e) => Cargar();
        }

        private void Cargar()
        {
            try
            {
                // Actualizar conteo de horas
                var dtH = ReservaBLL.ContarHorasSemana(SesionActual.IdEstudiante);
                int h   = dtH.Rows.Count > 0 ? Convert.ToInt32(dtH.Rows[0]["HorasSemana"]) : 0;
                lblHorasSemana.Text      = $"Horas esta semana: {h} h  (mínimo 5 h)";
                lblHorasSemana.ForeColor = h >= 5 ? EstilosUI.ColorExito : EstilosUI.ColorAdvertencia;

                dgv.DataSource = ReservaBLL.ListarReservasEstudiante(SesionActual.IdEstudiante);
                var ocultar = new[] { "idReserva", "idClase", "idEstudiante", "LinkZoom" };
                foreach (DataGridViewColumn col in dgv.Columns)
                    col.Visible = Array.IndexOf(ocultar, col.Name) < 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            if (dgv.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una reserva.", "Selección requerida",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int    id    = Convert.ToInt32(dgv.CurrentRow.Cells["idReserva"].Value);
            string fecha = dgv.CurrentRow.Cells["Fecha"]?.Value?.ToString();

            if (MessageBox.Show($"¿Cancelar la reserva del {fecha}?", "Confirmar cancelación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                var (res, msg) = ReservaBLL.CancelarReserva(id);
                MessageBox.Show(res == "OK" ? $"✅ {msg}" : $"⚠ {msg}",
                    "Resultado", MessageBoxButtons.OK,
                    res == "OK" ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
                Cargar();
            }
        }
    }
}
