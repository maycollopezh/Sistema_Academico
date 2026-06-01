using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SistemaAcademico.BLL;
using SistemaAcademico.UI.Helpers;

namespace SistemaAcademico.UI.Admin
{
    public partial class FrmCertificados : Form
    {
        public FrmCertificados() 
        { 
            InitializeComponent();
            AplicarEstilos();
            CargarEstudiantes(); 
            CargarCertificados(); 
        }

        private void AplicarEstilos()
        {
            this.Text = "Certificados";
            
            var encabezado = EstilosUI.CrearPanelEncabezado("Emisión de Certificados", "Solo estudiantes con proyecto final aprobado pueden recibir certificado (nivel B2).");
            this.Controls.Add(encabezado);
            encabezado.BringToFront();

            EstilosUI.EstilizarBotonAdvertencia(btnEmitir);
            EstilosUI.EstilizarBotonSecundario(btnRefrescar);
            EstilosUI.EstilizarDataGrid(dgv);

            btnEmitir.Click    += BtnEmitir_Click;
            btnRefrescar.Click += (s, e) => CargarCertificados();
        }

        private void CargarEstudiantes() { cmbEstudiante.DisplayMember = "NombreCompleto"; cmbEstudiante.ValueMember = "idEstudiante"; cmbEstudiante.DataSource = EstudianteBLL.ListarEstudiantes(); }
        private void CargarCertificados() { dgv.DataSource = CertificadoBLL.ListarCertificados(); }

        private void BtnEmitir_Click(object sender, EventArgs e)
        {
            if (cmbEstudiante.SelectedValue == null) { MessageBox.Show("Seleccione un estudiante."); return; }
            int idEst = Convert.ToInt32(cmbEstudiante.SelectedValue);
            if (MessageBox.Show("¿Emitir certificado de nivel B2 para este estudiante?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var (id, res, msg) = CertificadoBLL.EmitirCertificado(idEst, SesionActual.IdAdmin);
                MessageBox.Show(res == "OK" ? "✅ " + msg : "⚠ " + msg,
                    "Resultado", MessageBoxButtons.OK,
                    res == "OK" ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
                if (res == "OK") CargarCertificados();
            }
        }
    }
}
