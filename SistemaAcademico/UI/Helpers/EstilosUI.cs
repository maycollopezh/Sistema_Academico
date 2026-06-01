using System.Drawing;
using System.Windows.Forms;

namespace SistemaAcademico.UI.Helpers
{
    /// <summary>
    /// Clase de utilidades para estandarizar el estilo visual de toda la aplicación.
    /// Proporciona colores, fuentes y métodos para estilizar controles.
    /// </summary>
    public static class EstilosUI
    {
        // ── Paleta de colores ────────────────────────────────────────────────
        public static readonly Color ColorPrimario    = Color.FromArgb(27,  58,  95);  // Azul marino oscuro
        public static readonly Color ColorSecundario  = Color.FromArgb(46, 109, 164);  // Azul medio
        public static readonly Color ColorAcento      = Color.FromArgb(232, 137,  26); // Naranja
        public static readonly Color ColorFondo       = Color.FromArgb(240, 244, 248); // Gris claro
        public static readonly Color ColorPanel       = Color.FromArgb(255, 255, 255); // Blanco
        public static readonly Color ColorExito       = Color.FromArgb( 39, 174,  96); // Verde
        public static readonly Color ColorPeligro     = Color.FromArgb(192,  57,  43); // Rojo
        public static readonly Color ColorAdvertencia = Color.FromArgb(243, 156,  18); // Amarillo
        public static readonly Color ColorTexto       = Color.FromArgb( 44,  62,  80); // Gris oscuro
        public static readonly Color ColorSidebarItem = Color.FromArgb( 36,  75, 120); // Azul sidebar hover

        // ── Fuentes ──────────────────────────────────────────────────────────
        public static readonly Font FuenteNormal  = new Font("Segoe UI", 9.5f);
        public static readonly Font FuenteTitulo  = new Font("Segoe UI", 16f, FontStyle.Bold);
        public static readonly Font FuenteSubtit  = new Font("Segoe UI", 10f, FontStyle.Bold);
        public static readonly Font FuentePequeña = new Font("Segoe UI",  8.5f);
        public static readonly Font FuenteBoton   = new Font("Segoe UI", 9.5f, FontStyle.Bold);

        // ── Métodos de estilo para botones ───────────────────────────────────

        /// <summary>Estiliza un botón con el color primario (azul).</summary>
        public static void EstilizarBotonPrimario(Button btn)
        {
            btn.BackColor  = ColorSecundario;
            btn.ForeColor  = Color.White;
            btn.FlatStyle  = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font       = FuenteBoton;
            btn.Cursor     = Cursors.Hand;
            btn.Height     = 36;
        }

        /// <summary>Estiliza un botón de peligro (rojo).</summary>
        public static void EstilizarBotonPeligro(Button btn)
        {
            btn.BackColor  = ColorPeligro;
            btn.ForeColor  = Color.White;
            btn.FlatStyle  = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font       = FuenteBoton;
            btn.Cursor     = Cursors.Hand;
            btn.Height     = 36;
        }

        /// <summary>Estiliza un botón de éxito (verde).</summary>
        public static void EstilizarBotonExito(Button btn)
        {
            btn.BackColor  = ColorExito;
            btn.ForeColor  = Color.White;
            btn.FlatStyle  = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font       = FuenteBoton;
            btn.Cursor     = Cursors.Hand;
            btn.Height     = 36;
        }

        /// <summary>Estiliza un botón secundario (gris).</summary>
        public static void EstilizarBotonSecundario(Button btn)
        {
            btn.BackColor  = Color.FromArgb(149, 165, 166);
            btn.ForeColor  = Color.White;
            btn.FlatStyle  = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font       = FuenteBoton;
            btn.Cursor     = Cursors.Hand;
            btn.Height     = 36;
        }

        /// <summary>Botón naranja (advertencia/acción especial).</summary>
        public static void EstilizarBotonAdvertencia(Button btn)
        {
            btn.BackColor  = ColorAcento;
            btn.ForeColor  = Color.White;
            btn.FlatStyle  = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font       = FuenteBoton;
            btn.Cursor     = Cursors.Hand;
            btn.Height     = 36;
        }

        /// <summary>
        /// Aplica el estilo estándar a un DataGridView:
        /// cabecera azul marino, filas alternadas, sin bordes agresivos.
        /// </summary>
        public static void EstilizarDataGrid(DataGridView dgv)
        {
            dgv.BackgroundColor             = Color.White;
            dgv.BorderStyle                 = BorderStyle.FixedSingle;
            // Encabezado
            dgv.ColumnHeadersDefaultCellStyle.BackColor  = ColorPrimario;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor  = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font       = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Padding    = new Padding(5, 0, 0, 0);
            dgv.ColumnHeadersHeight         = 35;
            dgv.ColumnHeadersBorderStyle    = DataGridViewHeaderBorderStyle.Single;
            dgv.EnableHeadersVisualStyles   = false;
            // Celdas
            dgv.DefaultCellStyle.Font       = new Font("Segoe UI", 9.5f);
            dgv.DefaultCellStyle.ForeColor  = ColorTexto;
            dgv.DefaultCellStyle.SelectionBackColor = ColorSecundario;
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv.DefaultCellStyle.Padding    = new Padding(3, 0, 0, 0);
            dgv.RowTemplate.Height          = 32;
            // Filas alternadas
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 248, 255);
            // Bordes
            dgv.GridColor                   = Color.FromArgb(200, 210, 220);
            dgv.CellBorderStyle             = DataGridViewCellBorderStyle.Single;
            // Comportamiento
            dgv.ReadOnly                    = true;
            dgv.SelectionMode               = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect                 = false;
            dgv.AllowUserToAddRows          = false;
            dgv.AllowUserToDeleteRows       = false;
            dgv.AutoSizeColumnsMode         = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.RowHeadersVisible           = true;
            dgv.RowHeadersWidth             = 25;
        }

        /// <summary>
        /// Crea el panel de encabezado estándar azul marino con título y subtítulo.
        /// </summary>
        public static Panel CrearPanelEncabezado(string titulo, string subtitulo = "")
        {
            var panel = new Panel
            {
                Dock      = DockStyle.Top,
                Height    = subtitulo == "" ? 60 : 75,
                BackColor = ColorPrimario,
                Padding   = new Padding(15, 10, 15, 10)
            };
            // Al agregarse al formulario, se envía al fondo del z-order para que ocupe el Dock.Top primero y no solape a otros controles.
            panel.ParentChanged += (s, e) => {
                if (panel.Parent != null) panel.SendToBack();
            };
            var lbl = new Label
            {
                Text      = titulo,
                Font      = FuenteTitulo,
                ForeColor = Color.White,
                AutoSize  = true,
                Location  = new System.Drawing.Point(15, 10)
            };
            panel.Controls.Add(lbl);
            if (!string.IsNullOrEmpty(subtitulo))
            {
                var sub = new Label
                {
                    Text      = subtitulo,
                    Font      = FuentePequeña,
                    ForeColor = Color.FromArgb(170, 200, 230),
                    AutoSize  = true,
                    Location  = new System.Drawing.Point(17, 42)
                };
                panel.Controls.Add(sub);
            }
            return panel;
        }

        /// <summary>Crea una tarjeta de estadísticas para el dashboard.</summary>
        public static Panel CrearTarjetaStat(string titulo, string valor, Color color)
        {
            var card = new Panel
            {
                Width     = 180,
                Height    = 100,
                BackColor = color,
                Margin    = new Padding(8)
            };
            var lblVal = new Label
            {
                Text      = valor,
                Font      = new Font("Segoe UI", 24f, FontStyle.Bold),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock      = DockStyle.Fill
            };
            var lblTit = new Label
            {
                Text      = titulo,
                Font      = new Font("Segoe UI", 8.5f),
                ForeColor = Color.FromArgb(220, 240, 255),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock      = DockStyle.Bottom,
                Height    = 28
            };
            card.Controls.Add(lblVal);
            card.Controls.Add(lblTit);
            return card;
        }
    }
}
