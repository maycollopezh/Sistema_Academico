using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SistemaAcademico.BLL;
using SistemaAcademico.UI.Helpers;

namespace SistemaAcademico.UI.Admin
{

    public partial class FrmReservasPorClase : Form
    {
        public FrmReservasPorClase(int idClase) { _idClase = idClase; InitializeComponent();
            ConfigurarInterfaz(); Cargar(); }
        private void Cargar() { dgv.DataSource = ReservaBLL.ListarReservasClase(_idClase); }
    
        private void ConfigurarInterfaz()
        {
            this.Text = "Reservas de la Clase"; this.Size = new Size(700, 450);
            this.StartPosition = FormStartPosition.CenterParent; this.BackColor = EstilosUI.ColorFondo;
            this.Controls.Add(EstilosUI.CrearPanelEncabezado("Estudiantes Reservados en esta Clase"));
            dgv = new DataGridView { Dock = DockStyle.Fill };
            EstilosUI.EstilizarDataGrid(dgv);
            var pnlG = new Panel { Dock = DockStyle.Fill, Padding = new Padding(10) };
            pnlG.Controls.Add(dgv); this.Controls.Add(pnlG);
        }
}

}
