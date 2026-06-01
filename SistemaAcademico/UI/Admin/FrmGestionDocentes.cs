using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SistemaAcademico.BLL;
using SistemaAcademico.UI.Helpers;

namespace SistemaAcademico.UI.Admin
{
    /// <summary>CRUD completo de Docentes para el Administrador.</summary>
    public partial class FrmGestionDocentes : Form
    {
        public FrmGestionDocentes()
        {
            InitializeComponent();
            AplicarEstilos();
            CargarDocentes();
        }

        private void AplicarEstilos()
        {
            this.BackColor    = EstilosUI.ColorFondo;
            this.Font         = new Font("Segoe UI", 9.5f);

            btnNuevo.Text    = "➕ Nuevo";
            btnEditar.Text   = "✏️ Editar";
            btnEliminar.Text = "🗑️ Dar de baja";
            btnRefrescar.Text= "🔄 Refrescar";
            lblBuscar.Text   = "🔍 Buscar:";

            EstilosUI.EstilizarBotonExito(btnNuevo);
            EstilosUI.EstilizarBotonPrimario(btnEditar);
            EstilosUI.EstilizarBotonPeligro(btnEliminar);
            EstilosUI.EstilizarBotonSecundario(btnRefrescar);
            EstilosUI.EstilizarDataGrid(dgvDocentes);

            btnNuevo.Click     += (s, e) => { using (var d = new FrmDocenteDetalle())    { if (d.ShowDialog() == DialogResult.OK) CargarDocentes(); } };
            btnEditar.Click    += (s, e) => { if (FilaSel()) { using (var d = new FrmDocenteDetalle(IdSelec())) { if (d.ShowDialog() == DialogResult.OK) CargarDocentes(); } } };
            btnEliminar.Click  += BtnEliminar_Click;
            btnRefrescar.Click += (s, e) => CargarDocentes();
            txtBuscar.TextChanged += (s, e) =>
            {
                if (_dtDocentes == null) return;
                var f = txtBuscar.Text.Trim().Replace("'", "''");
                _dtDocentes.DefaultView.RowFilter = $"NombreCompleto LIKE '%{f}%' OR CI LIKE '%{f}%'";
            };
        }

        private void CargarDocentes()
        {
            _dtDocentes = DocenteBLL.ListarDocentes();
            dgvDocentes.DataSource = _dtDocentes;
            foreach (DataGridViewColumn col in dgvDocentes.Columns)
                col.Visible = new[] { "idDocente", "idPersona" }.Length > 0 &&
                              Array.IndexOf(new[] { "idDocente", "idPersona" }, col.Name) < 0;
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (!FilaSel()) return;
            int id = IdSelec();
            var nombre = dgvDocentes.CurrentRow?.Cells["NombreCompleto"]?.Value?.ToString();
            if (MessageBox.Show($"¿Dar de baja al docente: \"{nombre}\"?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                DocenteBLL.EliminarDocente(id);
                CargarDocentes();
            }
        }

        private bool FilaSel() { if (dgvDocentes.CurrentRow == null) { MessageBox.Show("Seleccione un docente."); return false; } return true; }
        private int  IdSelec() => Convert.ToInt32(dgvDocentes.CurrentRow?.Cells["idDocente"]?.Value);
    }
}
