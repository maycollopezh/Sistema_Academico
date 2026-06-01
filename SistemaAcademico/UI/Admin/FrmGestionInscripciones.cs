using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SistemaAcademico.BLL;
using SistemaAcademico.UI.Helpers;

namespace SistemaAcademico.UI.Admin
{
    public partial class FrmGestionInscripciones : Form
    {
        public FrmGestionInscripciones()
        {
            InitializeComponent();
            AplicarEstilos();
            Cargar();
        }

        private void Cargar() { dgv.DataSource = InscripcionBLL.ListarInscripciones(); }

        private void AplicarEstilos()
        {
            this.Text = "Inscripciones";
            
            var encabezado = EstilosUI.CrearPanelEncabezado("Gestión de Inscripciones", "Registra inscripciones al curso. La inscripción cubre los 10 meses completos.");
            this.Controls.Add(encabezado);
            encabezado.BringToFront();

            EstilosUI.EstilizarBotonExito(btnNueva);
            EstilosUI.EstilizarBotonSecundario(btnRefrescar);
            EstilosUI.EstilizarDataGrid(dgv);

            btnNueva.Text = "➕ Nueva Inscripción";
            btnRefrescar.Text = "🔄 Refrescar";

            btnNueva.Click += (s, e) => { using (var d = new FrmInscripcionNueva()) { if (d.ShowDialog() == DialogResult.OK) Cargar(); } };
            btnRefrescar.Click += (s, e) => Cargar();
        }
    }
}
