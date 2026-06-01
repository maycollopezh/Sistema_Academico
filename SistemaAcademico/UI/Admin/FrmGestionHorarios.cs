using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SistemaAcademico.BLL;
using SistemaAcademico.UI.Helpers;

namespace SistemaAcademico.UI.Admin
{
    /// <summary>
    /// Gestión de Horarios: crear horarios por módulo, publicarlos y añadir clases.
    /// </summary>
    public partial class FrmGestionHorarios : Form
    {
        public FrmGestionHorarios()
        {
            InitializeComponent();
            AplicarEstilos();
            CargarHorarios();
        }

        private void AplicarEstilos()
        {
            this.BackColor = EstilosUI.ColorFondo;
            btnNuevo.Text     = "➕ Nuevo Horario";
            btnPublicar.Text  = "📢 Publicar/Ocultar";
            btnVerClases.Text = "📋 Ver Clases";
            btnRefrescar.Text = "🔄 Refrescar";

            EstilosUI.EstilizarBotonExito(btnNuevo);
            EstilosUI.EstilizarBotonAdvertencia(btnPublicar);
            EstilosUI.EstilizarBotonPrimario(btnVerClases);
            EstilosUI.EstilizarBotonSecundario(btnRefrescar);
            EstilosUI.EstilizarDataGrid(dgvHorarios);

            btnNuevo.Click     += BtnNuevo_Click;
            btnPublicar.Click  += BtnPublicar_Click;
            btnVerClases.Click += BtnVerClases_Click;
            btnRefrescar.Click += (s, e) => CargarHorarios();
            dgvHorarios.SelectionChanged += (s, e) =>
            {
                if (dgvHorarios.CurrentRow == null) return;
                var pub = dgvHorarios.CurrentRow.Cells["Publicado"]?.Value?.ToString();
                lblEstado.Text = pub == "1" ? "✅ Publicado" : "📝 Borrador";
                lblEstado.ForeColor = pub == "1" ? EstilosUI.ColorExito : System.Drawing.Color.FromArgb(100, 110, 120);
            };
        }

        private void CargarHorarios()
        {
            var dt = HorarioBLL.ListarHorarios();
            dgvHorarios.DataSource = dt;
            if (dgvHorarios.Columns["idHorario"] != null) dgvHorarios.Columns["idHorario"].Visible = false;
            if (dgvHorarios.Columns["idModulo"]  != null) dgvHorarios.Columns["idModulo"].Visible  = false;
            if (dgvHorarios.Columns["Publicado"] != null)
            {
                dgvHorarios.Columns["Publicado"].HeaderText = "Estado";
                dgvHorarios.Columns["Publicado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            using (var dlg = new FrmHorarioNuevo())
            {
                if (dlg.ShowDialog() == DialogResult.OK) CargarHorarios();
            }
        }

        private void BtnPublicar_Click(object sender, EventArgs e)
        {
            if (dgvHorarios.CurrentRow == null) { MessageBox.Show("Seleccione un horario."); return; }
            int id  = Convert.ToInt32(dgvHorarios.CurrentRow.Cells["idHorario"].Value);
            var pub = dgvHorarios.CurrentRow.Cells["Publicado"]?.Value?.ToString() == "1";
            HorarioBLL.PublicarHorario(id, !pub);
            CargarHorarios();
            MessageBox.Show(!pub ? "✅ Horario publicado. Los estudiantes ya pueden verlo."
                                 : "📝 Horario ocultado.", "Estado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnVerClases_Click(object sender, EventArgs e)
        {
            if (dgvHorarios.CurrentRow == null) { MessageBox.Show("Seleccione un horario."); return; }
            int idHorario = Convert.ToInt32(dgvHorarios.CurrentRow.Cells["idHorario"].Value);
            string nombre = dgvHorarios.CurrentRow.Cells["Nombre"]?.Value?.ToString();
            using (var dlg = new FrmGestionClases(idHorario, nombre))
                dlg.ShowDialog();
        }
    }
}
