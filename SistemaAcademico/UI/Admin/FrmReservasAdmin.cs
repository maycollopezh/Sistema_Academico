using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SistemaAcademico.BLL;
using SistemaAcademico.UI.Helpers;

namespace SistemaAcademico.UI.Admin
{
    public partial class FrmReservasAdmin : Form
    {
        public FrmReservasAdmin() 
        { 
            InitializeComponent();
            AplicarEstilos();
            CargarEstudiantes(); 
        }

        private void AplicarEstilos()
        {
            this.Text = "Gestión de Reservas";
            
            var encabezado = EstilosUI.CrearPanelEncabezado("Reservas de Clases", "El admin puede reservar clases para estudiantes o cancelar reservas existentes.");
            this.Controls.Add(encabezado);
            encabezado.BringToFront();

            EstilosUI.EstilizarBotonPrimario(btnBuscar);
            EstilosUI.EstilizarBotonExito(btnNuevaReserva);
            EstilosUI.EstilizarBotonPeligro(btnCancelarReserva);
            EstilosUI.EstilizarDataGrid(dgv);

            btnBuscar.Click         += (s, e) => Cargar();
            btnNuevaReserva.Click   += BtnNuevaReserva_Click;
            btnCancelarReserva.Click += BtnCancelar_Click;
        }

        private void CargarEstudiantes()
        {
            cmbEstudiante.DisplayMember = "NombreCompleto"; cmbEstudiante.ValueMember = "idEstudiante";
            cmbEstudiante.DataSource = EstudianteBLL.ListarEstudiantes();
        }

        private void Cargar()
        {
            if (cmbEstudiante.SelectedValue == null) return;
            dgv.DataSource = ReservaBLL.ListarReservasEstudiante(Convert.ToInt32(cmbEstudiante.SelectedValue));
        }

        private void BtnNuevaReserva_Click(object sender, EventArgs e)
        {
            if (cmbEstudiante.SelectedValue == null) { MessageBox.Show("Seleccione un estudiante."); return; }
            int idEst = Convert.ToInt32(cmbEstudiante.SelectedValue);
            using (var dlg = new FrmReservarClaseAdmin(idEst))
                if (dlg.ShowDialog() == DialogResult.OK) Cargar();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            if (dgv.CurrentRow == null) { MessageBox.Show("Seleccione una reserva."); return; }
            int id = Convert.ToInt32(dgv.CurrentRow.Cells["idReserva"].Value);
            if (MessageBox.Show("¿Cancelar esta reserva?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                var (res, msg) = ReservaBLL.CancelarReserva(id);
                MessageBox.Show(res == "OK" ? "✅ " + msg : "⚠ " + msg);
                Cargar();
            }
        }
    }
}
