using System.Data;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace SistemaAcademico.UI.Helpers
{
    /// <summary>
    /// Utilidad para exportar DataTable a un archivo Excel (.xlsx)
    /// usando la librería ClosedXML (no requiere Office instalado).
    /// </summary>
    public static class ExcelHelper
    {
        /// <summary>
        /// Abre un diálogo para guardar y exporta el DataTable al archivo Excel elegido.
        /// </summary>
        /// <param name="dt">Datos a exportar</param>
        /// <param name="nombreArchivo">Nombre sugerido del archivo (sin extensión)</param>
        /// <param name="nombreHoja">Nombre de la hoja en Excel</param>
        public static void ExportarDataTable(DataTable dt, string nombreArchivo, string nombreHoja = "Datos")
        {
            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.", "Sin datos",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var dlg = new SaveFileDialog())
            {
                dlg.Title    = "Exportar a Excel";
                dlg.Filter   = "Archivo Excel (*.xlsx)|*.xlsx";
                dlg.FileName = nombreArchivo;

                if (dlg.ShowDialog() != DialogResult.OK) return;

                using (var wb = new XLWorkbook())
                {
                    var ws = wb.Worksheets.Add(nombreHoja);

                    // ── Encabezados ──────────────────────────────────────────
                    for (int col = 0; col < dt.Columns.Count; col++)
                    {
                        var cell = ws.Cell(1, col + 1);
                        cell.Value = dt.Columns[col].ColumnName;
                        cell.Style.Font.Bold            = true;
                        cell.Style.Font.FontSize        = 11;
                        cell.Style.Font.FontColor       = XLColor.White;
                        cell.Style.Fill.BackgroundColor = XLColor.FromHtml("#1B3A5F");
                        cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        cell.Style.Border.BottomBorder  = XLBorderStyleValues.Thin;
                    }

                    // ── Datos ────────────────────────────────────────────────
                    for (int row = 0; row < dt.Rows.Count; row++)
                    {
                        for (int col = 0; col < dt.Columns.Count; col++)
                        {
                            ws.Cell(row + 2, col + 1).Value =
                                dt.Rows[row][col]?.ToString() ?? "";
                        }
                        // Filas alternadas
                        if (row % 2 == 1)
                        {
                            ws.Row(row + 2).Cells(1, dt.Columns.Count)
                              .Style.Fill.BackgroundColor = XLColor.FromHtml("#EBF2FA");
                        }
                    }

                    // Ajustar ancho de columnas automáticamente
                    ws.Columns().AdjustToContents();

                    wb.SaveAs(dlg.FileName);
                }

                MessageBox.Show($"Archivo exportado correctamente:\n{dlg.FileName}",
                    "Exportación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
