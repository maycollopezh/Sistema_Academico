using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SistemaAcademico.BLL;
using SistemaAcademico.UI.Helpers;

namespace SistemaAcademico.UI.Estudiante
{
    public partial class FrmEstadoFinanciero : Form
    {
        public FrmEstadoFinanciero()
        {
            InitializeComponent();
            AplicarEstilos();
            Cargar();
        }

        private void AplicarEstilos()
        {
            this.Text = "Mi Estado Financiero";
            
            var encabezado = EstilosUI.CrearPanelEncabezado("Mi Estado Financiero", "Consulta el monto de tu inscripción, lo que has pagado y el saldo pendiente.");
            this.Controls.Add(encabezado);
            encabezado.BringToFront();

            lblMonto.ForeColor = EstilosUI.ColorPrimario;
            lblPagado.ForeColor = EstilosUI.ColorExito;
            lblHistorial.ForeColor = EstilosUI.ColorPrimario;

            EstilosUI.EstilizarBotonSecundario(btnRefrescar);
            EstilosUI.EstilizarDataGrid(dgvPagos);

            btnRefrescar.Click += (s, e) => Cargar();
        }

        private void Cargar()
        {
            try
            {
                // Estado general
                var dtFin = InscripcionBLL.EstadoFinanciero(SesionActual.IdEstudiante);
                if (dtFin.Rows.Count > 0)
                {
                    var r     = dtFin.Rows[0];
                    var monto = r.Table.Columns.Contains("MontoTotal") ? r["MontoTotal"] : 0;
                    var pag   = r.Table.Columns.Contains("TotalPagado") ? r["TotalPagado"] : 0;
                    var sal   = r.Table.Columns.Contains("Saldo") ? r["Saldo"] : 0;

                    lblMonto.Text        = $"Monto Total de Inscripción:  Bs. {monto:N2}";
                    lblPagado.Text       = $"Total Pagado:                  Bs. {pag:N2}";
                    lblSaldo.Text        = $"Saldo Pendiente:               Bs. {sal:N2}";
                    lblSaldo.ForeColor   = Convert.ToDecimal(sal) > 0 ? EstilosUI.ColorPeligro : EstilosUI.ColorExito;
                }

                // Historial de pagos
                var dtInsc = InscripcionBLL.ObtenerInscripcion(SesionActual.IdEstudiante);
                if (dtInsc.Rows.Count > 0)
                {
                    int idInsc        = Convert.ToInt32(dtInsc.Rows[0]["idInscripcion"]);
                    dgvPagos.DataSource = InscripcionBLL.ListarPagos(idInsc);
                    var ocultar = new[] { "idPago", "idInscripcion" };
                    foreach (DataGridViewColumn col in dgvPagos.Columns)
                        col.Visible = Array.IndexOf(ocultar, col.Name) < 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar estado financiero:\n" + ex.Message);
            }
        }
    }
}
