using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SistemaAcademico.BLL;
using SistemaAcademico.UI.Helpers;

namespace SistemaAcademico.UI.Estudiante
{
    // ═══════════════════════════════════════════════════════════════════════════
    // PANEL PRINCIPAL DEL ESTUDIANTE
    // ═══════════════════════════════════════════════════════════════════════════
    /// <summary>
    /// Formulario principal del Estudiante.
    /// Muestra bienvenida, datos del módulo actual y menú lateral de navegación.
    /// </summary>
    public partial class FrmPrincipalEstudiante : Form
    {

        public FrmPrincipalEstudiante()
        {
            InitializeComponent();
            ConfigurarInterfaz();
            CargarDashboard();
        }

        private void ConfigurarInterfaz()
        {
            // ── Barra superior ───────────────────────────────────────────────
            pnlTop = new Panel { Name = "pnlTop",  Dock = DockStyle.Top, Height = 56, BackColor = EstilosUI.ColorPrimario };
            var lblSis = new Label { Name = "lblSis", 
                Text      = "  🏫  Academia de Inglés Bolivia",
                Font      = new Font("Segoe UI", 12f, FontStyle.Bold),
                ForeColor = Color.White,
                Dock      = DockStyle.Left,
                Width     = 320,
                TextAlign = ContentAlignment.MiddleLeft
            };
            var lblUsr = new Label { Name = "lblUsr", 
                Text      = $"Bienvenido/a, {SesionActual.NombreCompleto}",
                Font      = new Font("Segoe UI", 9.5f),
                ForeColor = Color.FromArgb(190, 210, 235),
                Dock      = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleRight,
                Padding   = new Padding(0, 0, 15, 0)
            };
            var btnSalir = new Button { Name = "btnSalir", 
                Text      = "⏻  Salir",
                Dock      = DockStyle.Right,
                Width     = 110,
                BackColor = Color.FromArgb(192, 57, 43),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font      = new Font("Segoe UI", 9f, FontStyle.Bold),
                Cursor    = Cursors.Hand
            };
            btnSalir.FlatAppearance.BorderSize = 0;
            btnSalir.Click += (s, e) => this.Close();
            pnlTop.Controls.AddRange(new Control[] { lblSis, lblUsr, btnSalir });

            // ── Barra lateral ────────────────────────────────────────────────
            pnlSidebar = new Panel { Name = "pnlSidebar",  Dock = DockStyle.Left, Width = 210, BackColor = Color.FromArgb(20, 45, 75) };
            pnlSidebar.Controls.Add(new Label
            {
                Text      = "MI MENÚ",
                Font      = new Font("Segoe UI", 7.5f, FontStyle.Bold),
                ForeColor = Color.FromArgb(120, 150, 180),
                Dock      = DockStyle.Top,
                Height    = 36,
                TextAlign = ContentAlignment.BottomLeft,
                Padding   = new Padding(15, 0, 0, 5)
            });

            int sy = 36;
            void BtnSide(string txt, Action act)
            {
                var b = new Button { Name = "b", 
                    Text      = "  " + txt,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Bounds    = new Rectangle(0, sy, 210, 42),
                    BackColor = Color.Transparent,
                    ForeColor = Color.FromArgb(200, 220, 240),
                    FlatStyle = FlatStyle.Flat,
                    Font      = new Font("Segoe UI", 9.5f),
                    Cursor    = Cursors.Hand
                };
                b.FlatAppearance.BorderSize            = 0;
                b.FlatAppearance.MouseOverBackColor    = Color.FromArgb(36, 75, 120);
                b.Click += (s, e) => { try { act(); } catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); } };
                pnlSidebar.Controls.Add(b);
                sy += 42;
            }

            BtnSide("🏠  Mi Módulo Actual",     CargarDashboard);
            BtnSide("📅  Mi Horario",           () => new FrmHorarioEstudiante().ShowDialog());
            BtnSide("➕  Reservar Clase",        () => new FrmReservarClase().ShowDialog());
            BtnSide("🗓️  Mis Reservas",          () => new FrmMisReservas().ShowDialog());
            BtnSide("📊  Mis Planillas",         () => new FrmMisPlanillas().ShowDialog());
            BtnSide("💰  Estado Financiero",     () => new FrmEstadoFinanciero().ShowDialog());
            BtnSide("✅  Mi Asistencia",         () => new FrmMiAsistencia().ShowDialog());

            // ── Área de contenido ────────────────────────────────────────────
            pnlContent = new Panel { Name = "pnlContent",  Dock = DockStyle.Fill, BackColor = EstilosUI.ColorFondo, Padding = new Padding(20) };

            this.Controls.AddRange(new Control[] { pnlContent, pnlSidebar, pnlTop });
        }

        // ── Dashboard del estudiante ─────────────────────────────────────────
        private void CargarDashboard()
        {
            pnlContent.Controls.Clear();

            pnlContent.Controls.Add(EstilosUI.CrearPanelEncabezado(
                $"Bienvenido/a, {SesionActual.NombreCompleto}",
                $"Fecha: {DateTime.Now:dddd, dd MMMM yyyy}"));

            // Tarjetas con información del módulo y horas
            var pnlCards = new FlowLayoutPanel { Name = "pnlCards", 
                Dock          = DockStyle.Top,
                Height        = 120,
                BackColor     = Color.Transparent,
                Padding       = new Padding(0, 12, 0, 0),
                FlowDirection = FlowDirection.LeftToRight
            };

            try
            {
                // Módulo actual
                var dtMod = EstudianteBLL.ObtenerModuloActual(SesionActual.IdEstudiante);
                string modulo = dtMod.Rows.Count > 0 ? dtMod.Rows[0]["NombreModulo"]?.ToString() : "Sin módulo";

                // Horas reservadas esta semana
                var dtHoras = ReservaBLL.ContarHorasSemana(SesionActual.IdEstudiante);
                string horas = dtHoras.Rows.Count > 0 ? dtHoras.Rows[0]["HorasSemana"]?.ToString() ?? "0" : "0";
                int horasInt = int.TryParse(horas, out int h) ? h : 0;

                // Estado financiero rápido
                var dtFin = InscripcionBLL.EstadoFinanciero(SesionActual.IdEstudiante);
                string saldo = dtFin.Rows.Count > 0 ? $"Bs. {dtFin.Rows[0]["Saldo"]:N2}" : "--";

                pnlCards.Controls.Add(EstilosUI.CrearTarjetaStat("MÓDULO ACTUAL",   modulo,                        Color.FromArgb(46, 109, 164)));
                pnlCards.Controls.Add(EstilosUI.CrearTarjetaStat("HORAS ESTA SEM.", horas + " h",                  horasInt >= 5 ? EstilosUI.ColorExito : EstilosUI.ColorAdvertencia));
                pnlCards.Controls.Add(EstilosUI.CrearTarjetaStat("SALDO PENDIENTE", saldo,                         EstilosUI.ColorPeligro));
                pnlCards.Controls.Add(EstilosUI.CrearTarjetaStat("ESTADO",          "Activo",                      EstilosUI.ColorExito));
            }
            catch { /* sin datos */ }

            pnlContent.Controls.Add(pnlCards);

            // Advertencia de horas si < 5
            try
            {
                var dtHoras = ReservaBLL.ContarHorasSemana(SesionActual.IdEstudiante);
                int horas   = dtHoras.Rows.Count > 0 ? Convert.ToInt32(dtHoras.Rows[0]["HorasSemana"]) : 0;
                if (horas < 5)
                {
                    var lblAviso = new Label { Name = "lblAviso", 
                        Text      = $"⚠  Atención: llevas solo {horas} hora(s) esta semana. El mínimo requerido es 5 horas. ¡Reserva más clases!",
                        Font      = new Font("Segoe UI", 9.5f, FontStyle.Bold),
                        ForeColor = Color.White,
                        BackColor = EstilosUI.ColorAdvertencia,
                        Dock      = DockStyle.Top,
                        Height    = 36,
                        TextAlign = ContentAlignment.MiddleLeft,
                        Padding   = new Padding(12, 0, 0, 0)
                    };
                    pnlContent.Controls.Add(lblAviso);
                }
            }
            catch { /* ok */ }

            // Mis próximas reservas
            pnlContent.Controls.Add(new Label
            {
                Text      = "📅  Mis Próximas Clases Reservadas",
                Font      = new Font("Segoe UI", 10f, FontStyle.Bold),
                ForeColor = EstilosUI.ColorPrimario,
                Dock      = DockStyle.Top,
                Height    = 32,
                TextAlign = ContentAlignment.MiddleLeft
            });

            var dgvReservas = new DataGridView { Name = "dgvReservas",  Dock = DockStyle.Fill };
            EstilosUI.EstilizarDataGrid(dgvReservas);
            try
            {
                dgvReservas.DataSource = ReservaBLL.ListarReservasEstudiante(SesionActual.IdEstudiante);
                OcultarColumnas(dgvReservas, new[] { "idReserva", "idClase", "idEstudiante", "LinkZoom" });
            }
            catch { /* ok */ }
            pnlContent.Controls.Add(dgvReservas);
        }

        private static void OcultarColumnas(DataGridView dgv, string[] cols)
        {
            foreach (DataGridViewColumn col in dgv.Columns)
                if (Array.IndexOf(cols, col.Name) >= 0)
                    col.Visible = false;
        }
    }

}
