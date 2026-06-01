using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SistemaAcademico.BLL;
using SistemaAcademico.UI.Helpers;

namespace SistemaAcademico.UI.Admin
{
    public partial class FrmClaseNueva : Form
    {
        private int _idHorario;
        
        public FrmClaseNueva(int idHorario)
        {
            _idHorario = idHorario;
            InitializeComponent();
            AplicarEstilos();
            CargarDocentes();
        }

        private void AplicarEstilos()
        {
            this.Text = "Nueva Clase";
            
            var encabezado = EstilosUI.CrearPanelEncabezado("Agregar Nueva Clase", "Las clases duran 1 hora. El docente no puede tener conflicto de horario.");
            this.Controls.Add(encabezado);
            encabezado.BringToFront();

            EstilosUI.EstilizarBotonExito(btnGuardar);
            EstilosUI.EstilizarBotonSecundario(btnCancelar);

            for (int h = 7; h <= 21; h++) cmbHora.Items.Add($"{h:D2}:00");
            cmbHora.SelectedIndex = 0;

            cmbModalidad.SelectedIndex = 0;
            cmbModalidad.SelectedIndexChanged += (s, e) => {
                txtLinkZoom.Enabled = cmbModalidad.Text == "Virtual";
                txtAula.Enabled     = cmbModalidad.Text == "Presencial";
            };

            btnGuardar.Click += BtnGuardar_Click;
            btnCancelar.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };
        }

        private void CargarDocentes()
        {
            cmbDocente.DisplayMember = "NombreCompleto";
            cmbDocente.ValueMember   = "idDocente";
            cmbDocente.DataSource    = DocenteBLL.ListarDocentes();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (cmbDocente.SelectedValue == null) { MessageBox.Show("Seleccione un docente."); return; }
            var hora = TimeSpan.Parse(cmbHora.Text + ":00");
            var (id, res, msg) = HorarioBLL.CrearClase(dtpFecha.Value.Date, hora,
                cmbModalidad.Text, Convert.ToInt32(cmbDocente.SelectedValue),
                _idHorario, txtLinkZoom.Text.Trim(), txtAula.Text.Trim());

            if (res == "OK") {
                MessageBox.Show("✅ Clase creada correctamente.");
                this.DialogResult = DialogResult.OK; this.Close();
            } else {
                MessageBox.Show("⚠ " + msg, "Conflicto de Horario",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
