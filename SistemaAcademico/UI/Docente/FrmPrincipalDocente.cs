using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SistemaAcademico.BLL;
using SistemaAcademico.UI.Helpers;

namespace SistemaAcademico.UI.Docente
{
    /// <summary>Panel principal del Docente con resumen de clases del día.</summary>
    public partial class FrmPrincipalDocente : Form
    {

        public FrmPrincipalDocente()
        {
            InitializeComponent();
            ConfigurarInterfaz();
            CargarDashboard();
        }

        private void ConfigurarInterfaz()
        {
            // Barra superior
            pnlTop = new Panel { Name = "pnlTop",  Dock = DockStyle.Top, Height = 56, BackColor = EstilosUI.ColorPrimario };
            var lblSis = new Label { Name = "lblSis",  Text = "  🏫  Academia de Inglés Bolivia", Font = new Font("Segoe UI", 12f, FontStyle.Bold), ForeColor = Color.White, Dock = DockStyle.Left, Width = 320, TextAlign = ContentAlignment.MiddleLeft };
            var lblUsr = new Label { Name = "lblUsr",  Text = $"Bienvenido, {SesionActual.NombreCompleto}  |  Docente", Font = new Font("Segoe UI", 9.5f), ForeColor = Color.FromArgb(190, 210, 235), Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleRight, Padding = new Padding(0, 0, 15, 0) };
            var btnSal = new Button { Name = "btnSal",  Text = "⏻  Cerrar Sesión", Dock = DockStyle.Right, Width = 130, BackColor = Color.FromArgb(192, 57, 43), ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 9f, FontStyle.Bold), Cursor = Cursors.Hand };
            btnSal.FlatAppearance.BorderSize = 0;
            btnSal.Click += (s, e) => this.Close();
            pnlTop.Controls.AddRange(new Control[] { lblSis, lblUsr, btnSal });

            // Sidebar
            pnlSidebar = new Panel { Name = "pnlSidebar",  Dock = DockStyle.Left, Width = 210, BackColor = Color.FromArgb(20, 45, 75) };
            var lblM = new Label { Name = "lblM",  Text = "MENÚ DOCENTE", Font = new Font("Segoe UI", 7.5f, FontStyle.Bold), ForeColor = Color.FromArgb(120, 150, 180), Dock = DockStyle.Top, Height = 36, TextAlign = ContentAlignment.BottomLeft, Padding = new Padding(15, 0, 0, 5) };
            pnlSidebar.Controls.Add(lblM);

            int sy = 36;
            void BtnSide(string txt, Action act) {
                var b = new Button { Name = "b",  Text = "  " + txt, TextAlign = ContentAlignment.MiddleLeft, Bounds = new Rectangle(0, sy, 210, 42), BackColor = Color.Transparent, ForeColor = Color.FromArgb(200, 220, 240), FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 9.5f), Cursor = Cursors.Hand };
                b.FlatAppearance.BorderSize = 0; b.FlatAppearance.MouseOverBackColor = Color.FromArgb(36, 75, 120);
                b.Click += (s, e) => { try { act(); CargarDashboard(); } catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); } };
                pnlSidebar.Controls.Add(b); sy += 42;
            }
            BtnSide("📋  Mis Clases del Día",       () => { /* refrescar dashboard */ });
            BtnSide("✏️  Calificar Temas",           () => new FrmCalificarTemas().ShowDialog());
            BtnSide("📝  Registrar Examen Módulo",   () => new FrmRegistrarExamen().ShowDialog());
            BtnSide("📊  Ver Planillas",             () => new FrmVerPlanillaDocente().ShowDialog());

            // Contenido
            pnlContent = new Panel { Name = "pnlContent",  Dock = DockStyle.Fill, BackColor = EstilosUI.ColorFondo, Padding = new Padding(20) };
            this.Controls.AddRange(new Control[] { pnlContent, pnlSidebar, pnlTop });
        }

        private void CargarDashboard()
        {
            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(EstilosUI.CrearPanelEncabezado(
                "Mis Clases de Hoy",
                $"{DateTime.Now:dddd, dd MMMM yyyy}"));

            var dgv = new DataGridView { Name = "dgv",  Dock = DockStyle.Fill };
            EstilosUI.EstilizarDataGrid(dgv);
            try
            {
                var dt = DocenteBLL.ListarClasesDocente(SesionActual.IdDocente);
                // Filtrar solo las de hoy
                if (dt.Columns.Contains("Fecha"))
                {
                    var hoy = DateTime.Today.ToString("yyyy-MM-dd");
                    dt.DefaultView.RowFilter = $"CONVERT(Fecha, 'System.String') LIKE '%{hoy}%'";
                }
                dgv.DataSource = dt;
            }
            catch { /* sin conexión */ }

            var pnlG = new Panel { Name = "pnlG",  Dock = DockStyle.Fill, Padding = new Padding(0, 10, 0, 0) };
            pnlG.Controls.Add(dgv);
            pnlContent.Controls.Add(pnlG);
        }
    }

}
