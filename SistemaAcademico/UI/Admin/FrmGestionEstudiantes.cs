using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SistemaAcademico.BLL;
using SistemaAcademico.UI.Helpers;

namespace SistemaAcademico.UI.Admin
{
    /// <summary>
    /// CRUD completo de Estudiantes para el Administrador.
    /// Permite crear, ver, editar y dar de baja estudiantes.
    /// </summary>
    public partial class FrmGestionEstudiantes : Form
    {
        public FrmGestionEstudiantes()
        {
            InitializeComponent();
            AplicarEstilos();
            CargarEstudiantes();
        }

        private void AplicarEstilos()
        {
            this.Text          = "Gestión de Estudiantes";
            this.BackColor     = EstilosUI.ColorFondo;
            this.Font          = new Font("Segoe UI", 9.5f);

            btnNuevo.Text    = "➕ Nuevo";
            btnEditar.Text   = "✏️ Editar";
            btnEliminar.Text = "🗑️ Eliminar";
            btnRefrescar.Text= "🔄 Refrescar";
            lblBuscar.Text   = "🔍 Buscar:";

            EstilosUI.EstilizarBotonExito(btnNuevo);
            EstilosUI.EstilizarBotonPrimario(btnEditar);
            EstilosUI.EstilizarBotonPeligro(btnEliminar);
            EstilosUI.EstilizarBotonSecundario(btnRefrescar);
            EstilosUI.EstilizarDataGrid(dgvEstudiantes);

            btnNuevo.Click     += BtnNuevo_Click;
            btnEditar.Click    += BtnEditar_Click;
            btnEliminar.Click  += BtnEliminar_Click;
            btnRefrescar.Click += (s, e) => CargarEstudiantes();
            txtBuscar.TextChanged += TxtBuscar_TextChanged;
        }

        private void CargarEstudiantes()
        {
            try
            {
                _dtEstudiantes = EstudianteBLL.ListarEstudiantes();
                dgvEstudiantes.DataSource = _dtEstudiantes;
                ConfigurarColumnas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar estudiantes:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarColumnas()
        {
            // Ocultar columnas técnicas
            var ocultar = new[] { "idEstudiante", "idPersona", "EstadoPersona" };
            foreach (DataGridViewColumn col in dgvEstudiantes.Columns)
                col.Visible = Array.IndexOf(ocultar, col.Name) < 0;

            // Renombrar columnas visibles
            if (dgvEstudiantes.Columns["NombreCompleto"] != null)
                dgvEstudiantes.Columns["NombreCompleto"].HeaderText = "Nombre Completo";
            if (dgvEstudiantes.Columns["EstadoUsuario"] != null)
                dgvEstudiantes.Columns["EstadoUsuario"].HeaderText = "Estado";
            if (dgvEstudiantes.Columns["ModuloActual"] != null)
                dgvEstudiantes.Columns["ModuloActual"].HeaderText = "Módulo Actual";
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (_dtEstudiantes == null) return;
            var filtro = txtBuscar.Text.Trim().Replace("'", "''");
            _dtEstudiantes.DefaultView.RowFilter =
                $"NombreCompleto LIKE '%{filtro}%' OR CI LIKE '%{filtro}%'";
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            using (var dlg = new FrmEstudianteDetalle())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                    CargarEstudiantes();
            }
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (!FilaSeleccionada()) return;
            var fila = dgvEstudiantes.CurrentRow;
            int id = Convert.ToInt32(fila.Cells["idEstudiante"].Value);
            using (var dlg = new FrmEstudianteDetalle(id))
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                    CargarEstudiantes();
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (!FilaSeleccionada()) return;
            var fila   = dgvEstudiantes.CurrentRow;
            var nombre = fila.Cells["NombreCompleto"]?.Value?.ToString() ?? "?";
            int id     = Convert.ToInt32(fila.Cells["idEstudiante"].Value);

            if (MessageBox.Show($"¿Desea dar de baja al estudiante:\n\"{nombre}\"?\n\n" +
                "El registro no se elimina físicamente.", "Confirmar baja",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    EstudianteBLL.EliminarEstudiante(id);
                    MessageBox.Show("Estudiante dado de baja correctamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarEstudiantes();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool FilaSeleccionada()
        {
            if (dgvEstudiantes.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un estudiante de la lista.", "Selección requerida",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
    }
}
