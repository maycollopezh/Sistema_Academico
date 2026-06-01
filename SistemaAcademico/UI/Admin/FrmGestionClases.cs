using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SistemaAcademico.BLL;
using SistemaAcademico.UI.Helpers;

namespace SistemaAcademico.UI.Admin
{
    /// <summary>Gestión de Clases dentro de un Horario seleccionado.</summary>
    public partial class FrmGestionClases : Form
    {
        public FrmGestionClases(int idHorario, string nombreHorario)
        {
            _idHorario     = idHorario;
            _nombreHorario = nombreHorario;
            InitializeComponent();
            AplicarEstilos();
            CargarClases();
        }

        private void AplicarEstilos()
        {
            this.Text      = $"Clases – {_nombreHorario}";
            this.BackColor = EstilosUI.ColorFondo;

            btnNueva.Text       = "➕ Nueva Clase";
            btnEliminar.Text    = "🗑️ Eliminar";
            btnVerReservas.Text = "👥 Ver Reservas";
            btnRefrescar.Text   = "🔄 Refrescar";

            EstilosUI.EstilizarBotonExito(btnNueva);
            EstilosUI.EstilizarBotonPeligro(btnEliminar);
            EstilosUI.EstilizarBotonPrimario(btnVerReservas);
            EstilosUI.EstilizarBotonSecundario(btnRefrescar);
            EstilosUI.EstilizarDataGrid(dgvClases);

            btnNueva.Click       += BtnNueva_Click;
            btnEliminar.Click    += BtnEliminar_Click;
            btnVerReservas.Click += BtnVerReservas_Click;
            btnRefrescar.Click   += (s, e) => CargarClases();
            dgvClases.CellFormatting += (s, e) => {
                if (e.ColumnIndex < 0 || e.RowIndex < 0) return;
                var col = dgvClases.Columns[e.ColumnIndex];
                if (col.Name == "CupoActual")
                {
                    int cupo   = int.TryParse(dgvClases.Rows[e.RowIndex].Cells["CupoActual"]?.Value?.ToString(), out int ca) ? ca : 0;
                    int maximo = int.TryParse(dgvClases.Rows[e.RowIndex].Cells["CupoMaximo"]?.Value?.ToString(), out int cm) ? cm : 8;
                    e.CellStyle.ForeColor = cupo >= maximo ? Color.Red : EstilosUI.ColorTexto;
                    e.CellStyle.Font      = cupo >= maximo ? new Font("Segoe UI", 9f, FontStyle.Bold) : new Font("Segoe UI", 9f);
                }
            };
        }

        private void CargarClases()
        {
            var dt = HorarioBLL.ListarClases(_idHorario);
            dgvClases.DataSource = dt;
            var ocultar = new[] { "idClase", "idDocente", "idHorario", "NombreHorario", "LinkZoom", "Aula" };
            foreach (DataGridViewColumn col in dgvClases.Columns)
                col.Visible = Array.IndexOf(ocultar, col.Name) < 0;
        }

        private void BtnNueva_Click(object sender, EventArgs e)
        {
            using (var dlg = new FrmClaseNueva(_idHorario))
                if (dlg.ShowDialog() == DialogResult.OK) CargarClases();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvClases.CurrentRow == null) { MessageBox.Show("Seleccione una clase."); return; }
            int id = Convert.ToInt32(dgvClases.CurrentRow.Cells["idClase"].Value);
            if (MessageBox.Show("¿Eliminar esta clase?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                var (res, msg) = HorarioBLL.EliminarClase(id);
                MessageBox.Show(res == "OK" ? "✅ " + msg : "⚠ " + msg,
                    "Resultado", MessageBoxButtons.OK,
                    res == "OK" ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
                if (res == "OK") CargarClases();
            }
        }

        private void BtnVerReservas_Click(object sender, EventArgs e)
        {
            if (dgvClases.CurrentRow == null) { MessageBox.Show("Seleccione una clase."); return; }
            int idClase = Convert.ToInt32(dgvClases.CurrentRow.Cells["idClase"].Value);
            using (var dlg = new FrmReservasPorClase(idClase))
                dlg.ShowDialog();
        }
    }
}
