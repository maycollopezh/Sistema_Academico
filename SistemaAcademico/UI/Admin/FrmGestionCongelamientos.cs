using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SistemaAcademico.BLL;
using SistemaAcademico.UI.Helpers;

namespace SistemaAcademico.UI.Admin
{
    public partial class FrmGestionCongelamientos : Form
    {
        public FrmGestionCongelamientos()
        {
            InitializeComponent();
            AplicarEstilos();
            Cargar();
        }

        private void Cargar() { dgv.DataSource = InscripcionBLL.ListarCongelamientos(); }

        private void AplicarEstilos()
        {
            this.Text = "Congelamientos";
            
            var encabezado = EstilosUI.CrearPanelEncabezado("Gestión de Congelamientos", "Registra congelamientos del curso. Se bloquea el acceso durante el período acordado.");
            this.Controls.Add(encabezado);
            encabezado.BringToFront();

            EstilosUI.EstilizarBotonPrimario(btnNuevo);
            EstilosUI.EstilizarBotonExito(btnLevantar);
            EstilosUI.EstilizarBotonSecundario(btnRefrescar);
            EstilosUI.EstilizarDataGrid(dgv);

            btnNuevo.Click += (s, e) => { using (var d = new FrmCongelamientoNuevo()) { if (d.ShowDialog() == DialogResult.OK) Cargar(); } };
            btnLevantar.Click += BtnLevantar_Click;
            btnRefrescar.Click += (s, e) => Cargar();
        }

        private void BtnLevantar_Click(object sender, EventArgs e)
        {
            if (dgv.CurrentRow == null) { MessageBox.Show("Seleccione un congelamiento."); return; }
            int id = Convert.ToInt32(dgv.CurrentRow.Cells["idCongelamiento"].Value);
            var est= dgv.CurrentRow.Cells["Estado"]?.Value?.ToString();
            if (est == "Finalizado") { MessageBox.Show("Este congelamiento ya fue levantado."); return; }
            if (MessageBox.Show("¿Levantar el congelamiento y reactivar el acceso?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                InscripcionBLL.FinalizarCongelamiento(id);
                MessageBox.Show("✅ Acceso reactivado correctamente.");
                Cargar();
            }
        }
    }
}
