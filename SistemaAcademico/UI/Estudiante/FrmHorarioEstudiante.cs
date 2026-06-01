using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SistemaAcademico.BLL;
using SistemaAcademico.UI.Helpers;

namespace SistemaAcademico.UI.Estudiante
{
    public partial class FrmHorarioEstudiante : Form
    {
        public FrmHorarioEstudiante()
        {
            InitializeComponent();
            AplicarEstilos();
            Cargar();
        }

        private void AplicarEstilos()
        {
            this.Text = "Mi Horario de Clases";
            
            var encabezado = EstilosUI.CrearPanelEncabezado("Mi Horario de Clases", "Clases disponibles para tu módulo actual. Usa 'Reservar Clase' para inscribirte en una.");
            this.Controls.Add(encabezado);
            encabezado.BringToFront();

            EstilosUI.EstilizarBotonSecundario(btnRefrescar);
            EstilosUI.EstilizarDataGrid(dgv);

            btnRefrescar.Click += (s, e) => Cargar();
        }

        private void Cargar()
        {
            try
            {
                dgv.DataSource = HorarioBLL.ObtenerHorarioEstudiante(SesionActual.IdEstudiante);
                // Ocultar columnas técnicas
                var ocultar = new[] { "idClase", "idHorario", "idDocente", "LinkZoom" };
                foreach (DataGridViewColumn col in dgv.Columns)
                    col.Visible = Array.IndexOf(ocultar, col.Name) < 0;

                // Colorear filas de cupo lleno
                dgv.CellFormatting += (s, e) =>
                {
                    if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
                    if (dgv.Columns[e.ColumnIndex].Name == "CupoActual")
                    {
                        bool lleno = dgv.Rows[e.RowIndex].Cells["CupoActual"]?.Value?.ToString() ==
                                     dgv.Rows[e.RowIndex].Cells["CupoMaximo"]?.Value?.ToString();
                        e.CellStyle.ForeColor = lleno ? Color.Red : EstilosUI.ColorTexto;
                        e.CellStyle.Font      = lleno ? new Font("Segoe UI", 9f, FontStyle.Bold) : new Font("Segoe UI", 9f, FontStyle.Regular);
                    }
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar horario:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
