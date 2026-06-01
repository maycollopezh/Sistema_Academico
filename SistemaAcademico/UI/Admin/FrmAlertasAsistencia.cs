using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SistemaAcademico.BLL;
using SistemaAcademico.UI.Helpers;

namespace SistemaAcademico.UI.Admin
{
    public partial class FrmAlertasAsistencia : Form
    {
        public FrmAlertasAsistencia() 
        { 
            InitializeComponent();
            AplicarEstilos();
            Cargar(); 
        }

        private void AplicarEstilos()
        {
            this.Text = "Alertas de Asistencia";
            
            var encabezado = EstilosUI.CrearPanelEncabezado("⚠ Alertas de Asistencia", "Estudiantes con menos de 5 horas de clase en la semana. Comuníquese con ellos.");
            this.Controls.Add(encabezado);
            encabezado.BringToFront();

            EstilosUI.EstilizarBotonExito(btnMarcarRevisado);
            EstilosUI.EstilizarBotonSecundario(btnRefrescar);
            EstilosUI.EstilizarDataGrid(dgv);

            btnMarcarRevisado.Click += BtnMarcar_Click;
            btnRefrescar.Click      += (s, e) => Cargar();
        }

        private void Cargar() { dgv.DataSource = ReservaBLL.ListarAlertasActivas(); }

        private void BtnMarcar_Click(object sender, EventArgs e)
        {
            if (dgv.CurrentRow == null) { MessageBox.Show("Seleccione una alerta."); return; }
            int id = Convert.ToInt32(dgv.CurrentRow.Cells["idAlerta"].Value);
            ReservaBLL.MarcarAlertaRevisada(id);
            MessageBox.Show("✅ Alerta marcada como revisada.");
            Cargar();
        }
    }
}
