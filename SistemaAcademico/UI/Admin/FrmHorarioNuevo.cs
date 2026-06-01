using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SistemaAcademico.BLL;
using SistemaAcademico.UI.Helpers;

namespace SistemaAcademico.UI.Admin
{
    public partial class FrmHorarioNuevo : Form
    {
        public FrmHorarioNuevo()
        {
            InitializeComponent();
            AplicarEstilos();
            CargarModulos();
        }

        private void AplicarEstilos()
        {
            this.Text = "Nuevo Horario";
            
            var encabezado = EstilosUI.CrearPanelEncabezado("Crear Nuevo Horario");
            this.Controls.Add(encabezado);
            encabezado.BringToFront();

            EstilosUI.EstilizarBotonExito(btnGuardar);
            EstilosUI.EstilizarBotonSecundario(btnCancelar);

            btnGuardar.Click += (s, e) => {
                if (string.IsNullOrWhiteSpace(txtNombre.Text)) { MessageBox.Show("Ingrese el nombre."); return; }
                if (cmbModulo.SelectedValue == null) { MessageBox.Show("Seleccione el módulo."); return; }
                HorarioBLL.CrearHorario(txtNombre.Text.Trim(), Convert.ToInt32(cmbModulo.SelectedValue));
                MessageBox.Show("✅ Horario creado correctamente.");
                this.DialogResult = DialogResult.OK; this.Close();
            };
            btnCancelar.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };
        }

        private void CargarModulos()
        {
            cmbModulo.DisplayMember = "NombreModulo";
            cmbModulo.ValueMember   = "idModulo";
            cmbModulo.DataSource    = InscripcionBLL.ListarModulos();
        }
    }
}
