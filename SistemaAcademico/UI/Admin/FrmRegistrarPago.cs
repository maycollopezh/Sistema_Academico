using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SistemaAcademico.BLL;
using SistemaAcademico.UI.Helpers;

namespace SistemaAcademico.UI.Admin
{
    public partial class FrmRegistrarPago : Form
    {
        public FrmRegistrarPago(int idInscripcion)
        {
            _idInscripcion = idInscripcion;
            InitializeComponent();
            AplicarEstilos();
        }

        private void AplicarEstilos()
        {
            this.Text = "Registrar Pago";
            
            var encabezado = EstilosUI.CrearPanelEncabezado("Registrar Nuevo Pago");
            this.Controls.Add(encabezado);
            encabezado.BringToFront();

            EstilosUI.EstilizarBotonExito(btnGuardar); 
            EstilosUI.EstilizarBotonSecundario(btnCancelar);
            
            btnGuardar.Click += (s, e) => {
                var (id, res, msg) = InscripcionBLL.RegistrarPago(_idInscripcion, nudMonto.Value,
                    cmbTipo.Text, (int)nudNumeroCuota.Value, dtpFecha.Value, dtpVencimiento.Value);
                if (res == "OK") { MessageBox.Show("✅ Pago registrado."); this.DialogResult = DialogResult.OK; this.Close(); }
                else MessageBox.Show("⚠ " + msg);
            };
            btnCancelar.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };
        }
    }
}
