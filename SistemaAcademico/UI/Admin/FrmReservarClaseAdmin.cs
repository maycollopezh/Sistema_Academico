using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SistemaAcademico.BLL;
using SistemaAcademico.UI.Helpers;

namespace SistemaAcademico.UI.Admin
{
    public partial class FrmReservarClaseAdmin : Form
    {
        private int _idEstudiante;

        public FrmReservarClaseAdmin(int idEstudiante) 
        { 
            _idEstudiante = idEstudiante; 
            InitializeComponent();
            AplicarEstilos();
            Cargar(); 
        }

        private void AplicarEstilos()
        {
            this.Text = "Seleccionar Clase";
            
            var encabezado = EstilosUI.CrearPanelEncabezado("Seleccionar Clase para Reservar", "Se muestran las clases del módulo actual del estudiante.");
            this.Controls.Add(encabezado);
            encabezado.BringToFront();

            EstilosUI.EstilizarBotonExito(btnReservar);
            EstilosUI.EstilizarBotonSecundario(btnCancelar);
            EstilosUI.EstilizarDataGrid(dgvClases);

            btnReservar.Click += BtnReservar_Click;
            btnCancelar.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };
        }

        private void Cargar()
        {
            dgvClases.DataSource = HorarioBLL.ObtenerHorarioEstudiante(_idEstudiante);
            if (dgvClases.Columns["idClase"] != null) dgvClases.Columns["idClase"].Visible = false;
        }

        private void BtnReservar_Click(object sender, EventArgs e)
        {
            if (dgvClases.CurrentRow == null) { MessageBox.Show("Seleccione una clase."); return; }
            int idClase = Convert.ToInt32(dgvClases.CurrentRow.Cells["idClase"].Value);
            var (id, res, msg) = ReservaBLL.CrearReserva(_idEstudiante, idClase);
            MessageBox.Show(res == "OK" ? "✅ " + msg : "⚠ " + msg,
                "Resultado", MessageBoxButtons.OK,
                res == "OK" ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
            if (res == "OK") { this.DialogResult = DialogResult.OK; this.Close(); }
        }
    }
}
