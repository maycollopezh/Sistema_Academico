using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SistemaAcademico.BLL;
using SistemaAcademico.UI.Helpers;

namespace SistemaAcademico.UI.Admin
{
    public partial class FrmGestionPagos : Form
    {
        public FrmGestionPagos()
        {
            InitializeComponent();
            AplicarEstilos();
            CargarEstudiantes();
        }

        private void AplicarEstilos()
        {
            this.Text = "Gestión de Pagos";
            
            var encabezado = EstilosUI.CrearPanelEncabezado("Gestión de Pagos", "Registre pagos de cuotas o contado. El sistema reactiva el acceso automáticamente.");
            this.Controls.Add(encabezado);
            encabezado.BringToFront();

            EstilosUI.EstilizarBotonExito(btnRegistrarPago);
            EstilosUI.EstilizarBotonSecundario(btnRefrescar);
            
            EstilosUI.EstilizarDataGrid(dgvInscripcion);
            EstilosUI.EstilizarDataGrid(dgvPagos);

            cmbEstudiante.SelectedIndexChanged += (s, e) => CargarDatosEstudiante();
            btnRegistrarPago.Click += BtnRegistrarPago_Click;
            btnRefrescar.Click += (s, e) => CargarDatosEstudiante();
        }

        private void CargarEstudiantes()
        {
            cmbEstudiante.DisplayMember = "NombreCompleto";
            cmbEstudiante.ValueMember   = "idEstudiante";
            cmbEstudiante.DataSource    = EstudianteBLL.ListarEstudiantes();
        }

        private void CargarDatosEstudiante()
        {
            if (cmbEstudiante.SelectedValue == null) return;
            int idEst = Convert.ToInt32(cmbEstudiante.SelectedValue);

            var dtInsc = InscripcionBLL.ObtenerInscripcion(idEst);
            dgvInscripcion.DataSource = dtInsc;

            if (dtInsc.Rows.Count > 0)
            {
                int idInsc = Convert.ToInt32(dtInsc.Rows[0]["idInscripcion"]);
                dgvPagos.DataSource = InscripcionBLL.ListarPagos(idInsc);
                var saldo = dtInsc.Rows[0]["Saldo"];
                lblSaldo.Text      = $"Saldo Pendiente: Bs. {saldo:N2}";
                lblSaldo.ForeColor = Convert.ToDecimal(saldo) > 0 ? EstilosUI.ColorPeligro : EstilosUI.ColorExito;
            }
        }

        private void BtnRegistrarPago_Click(object sender, EventArgs e)
        {
            if (cmbEstudiante.SelectedValue == null) { MessageBox.Show("Seleccione un estudiante."); return; }
            int idEst  = Convert.ToInt32(cmbEstudiante.SelectedValue);
            var dtInsc = InscripcionBLL.ObtenerInscripcion(idEst);
            if (dtInsc.Rows.Count == 0) { MessageBox.Show("El estudiante no tiene inscripción activa."); return; }
            int idInsc = Convert.ToInt32(dtInsc.Rows[0]["idInscripcion"]);
            using (var dlg = new FrmRegistrarPago(idInsc))
                if (dlg.ShowDialog() == DialogResult.OK) CargarDatosEstudiante();
        }
    }
}
