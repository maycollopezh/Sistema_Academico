using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SistemaAcademico.BLL;
using SistemaAcademico.UI.Helpers;

namespace SistemaAcademico.UI.Admin
{
    public partial class FrmCongelamientoNuevo : Form
    {
        public FrmCongelamientoNuevo() 
        { 
            InitializeComponent();
            AplicarEstilos();
            CargarEstudiantes(); 
        }

        private void AplicarEstilos()
        {
            this.Text = "Nuevo Congelamiento";
            
            var encabezado = EstilosUI.CrearPanelEncabezado("Registrar Congelamiento del Curso");
            this.Controls.Add(encabezado);
            encabezado.BringToFront();

            EstilosUI.EstilizarBotonPrimario(btnGuardar);
            EstilosUI.EstilizarBotonSecundario(btnCancelar);

            btnGuardar.Click += BtnGuardar_Click;
            btnCancelar.Click+= (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };
            
            dtpFin.Value = DateTime.Today.AddMonths(1);
        }

        private void CargarEstudiantes()
        {
            cmbEstudiante.DisplayMember = "NombreCompleto"; cmbEstudiante.ValueMember = "idEstudiante";
            cmbEstudiante.DataSource = EstudianteBLL.ListarEstudiantes();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (cmbEstudiante.SelectedValue == null) { MessageBox.Show("Seleccione un estudiante."); return; }
            if (string.IsNullOrWhiteSpace(txtMotivo.Text)) { MessageBox.Show("Ingrese el motivo."); return; }
            int idEst  = Convert.ToInt32(cmbEstudiante.SelectedValue);
            var dtInsc = InscripcionBLL.ObtenerInscripcion(idEst);
            if (dtInsc.Rows.Count == 0) { MessageBox.Show("El estudiante no tiene inscripción activa."); return; }
            int idInsc = Convert.ToInt32(dtInsc.Rows[0]["idInscripcion"]);
            InscripcionBLL.CrearCongelamiento(idInsc, dtpInicio.Value, dtpFin.Value, txtMotivo.Text.Trim());
            MessageBox.Show("✅ Congelamiento registrado. El acceso del estudiante ha sido bloqueado.");
            this.DialogResult = DialogResult.OK; this.Close();
        }
    }
}
