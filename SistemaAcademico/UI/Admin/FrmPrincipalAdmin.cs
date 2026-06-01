using System;
using System.Drawing;
using System.Windows.Forms;
using SistemaAcademico.BLL;
using SistemaAcademico.UI.Helpers;

namespace SistemaAcademico.UI.Admin
{
    /// <summary>
    /// Formulario principal del Administrador.
    /// Presenta el dashboard con estadísticas y la barra lateral de navegación.
    /// </summary>
    public partial class FrmPrincipalAdmin : Form
    {

        public FrmPrincipalAdmin()
        {
            InitializeComponent();
            lblBienvenida.Text = $"Bienvenido, {SesionActual.NombreCompleto}  |  Administrador";
            CargarBotonesSidebar();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CargarBotonesSidebar()
        {
            AgregarBotonSidebar("📋  Gestión Estudiantes",  () => new FrmGestionEstudiantes().ShowDialog());
            AgregarBotonSidebar("👩‍🏫  Gestión Docentes",    () => new FrmGestionDocentes().ShowDialog());
            AgregarBotonSidebar("📅  Horarios y Clases",    () => new FrmGestionHorarios().ShowDialog());
            AgregarBotonSidebar("📝  Inscripciones",        () => new FrmGestionInscripciones().ShowDialog());
            AgregarBotonSidebar("💰  Gestión de Pagos",     () => new FrmGestionPagos().ShowDialog());
            AgregarBotonSidebar("❄️  Congelamientos",       () => new FrmGestionCongelamientos().ShowDialog());
            AgregarBotonSidebar("🗓️  Reservas",             () => new FrmReservasAdmin().ShowDialog());
            AgregarBotonSidebar("⚠️  Alertas Asistencia",  () => new FrmAlertasAsistencia().ShowDialog());
            AgregarBotonSidebar("🔬  Examen Diagnóstico",  () => new FrmDiagnostico().ShowDialog());
            AgregarBotonSidebar("🏆  Certificados",        () => new FrmCertificados().ShowDialog());
        }

        private void AgregarBotonSidebar(string texto, Action accion)
        {
            var btn = new Button { Name = "btn", 
                Text      = "  " + texto,
                TextAlign = ContentAlignment.MiddleLeft,
                Bounds    = new Rectangle(0, _sidebarY, 215, 42),
                BackColor = Color.Transparent,
                ForeColor = Color.FromArgb(200, 220, 240),
                FlatStyle = FlatStyle.Flat,
                Font      = new Font("Segoe UI", 9.5f),
                Cursor    = Cursors.Hand
            };
            btn.FlatAppearance.BorderSize    = 0;
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(36, 75, 120);
            btn.Click += (s, e) => {
                try { accion(); CargarDashboard(); }
                catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
            };
            pnlSidebar.Controls.Add(btn);
            _sidebarY += 42;
        }

        private void CargarDashboard()
        {
            pnlContent.Controls.Clear();

            var encabezado = EstilosUI.CrearPanelEncabezado(
                "Dashboard – Administrador",
                $"Fecha: {DateTime.Now:dddd, dd MMMM yyyy}");
            pnlContent.Controls.Add(encabezado);

            // Tarjetas de estadísticas
            var pnlStats = new FlowLayoutPanel { Name = "pnlStats", 
                Dock      = DockStyle.Top,
                Height    = 120,
                BackColor = Color.Transparent,
                Padding   = new Padding(0, 12, 0, 0),
                FlowDirection = FlowDirection.LeftToRight
            };

            try
            {
                var estudiantes  = EstudianteBLL.ListarEstudiantes();
                var docentes     = DocenteBLL.ListarDocentes();
                var alertas      = ReservaBLL.ListarAlertasActivas();
                var certificados = CertificadoBLL.ListarCertificados();

                pnlStats.Controls.Add(EstilosUI.CrearTarjetaStat(
                    "ESTUDIANTES", estudiantes.Rows.Count.ToString(), Color.FromArgb(46, 109, 164)));
                pnlStats.Controls.Add(EstilosUI.CrearTarjetaStat(
                    "DOCENTES", docentes.Rows.Count.ToString(), Color.FromArgb(39, 174, 96)));
                pnlStats.Controls.Add(EstilosUI.CrearTarjetaStat(
                    "ALERTAS", alertas.Rows.Count.ToString(), Color.FromArgb(192, 57, 43)));
                pnlStats.Controls.Add(EstilosUI.CrearTarjetaStat(
                    "CERTIFICADOS", certificados.Rows.Count.ToString(), Color.FromArgb(232, 137, 26)));
            }
            catch { /* Sin conexión – mostrar ceros */ }

            pnlContent.Controls.Add(pnlStats);

            // Sección de estudiantes morosos
            var lblMorosos = new Label { Name = "lblMorosos", 
                Text      = "⚠  Estudiantes con Pago Vencido (> 30 días)",
                Font      = new Font("Segoe UI", 10f, FontStyle.Bold),
                ForeColor = Color.FromArgb(192, 57, 43),
                Dock      = DockStyle.Top,
                Height    = 30,
                TextAlign = ContentAlignment.MiddleLeft
            };
            pnlContent.Controls.Add(lblMorosos);

            var dgvMorosos = new DataGridView { Name = "dgvMorosos",  Dock = DockStyle.Fill };
            EstilosUI.EstilizarDataGrid(dgvMorosos);
            try
            {
                dgvMorosos.DataSource = InscripcionBLL.ListarMorosos();
            }
            catch { /* Sin datos */ }
            pnlContent.Controls.Add(dgvMorosos);
        }
    }

}
