namespace SistemaAcademico.UI.Estudiante
{
    partial class FrmEstadoFinanciero
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.pnlResumen = new System.Windows.Forms.Panel();
            this.lblMonto = new System.Windows.Forms.Label();
            this.lblPagado = new System.Windows.Forms.Label();
            this.lblSaldo = new System.Windows.Forms.Label();
            this.pnlB = new System.Windows.Forms.Panel();
            this.btnRefrescar = new System.Windows.Forms.Button();
            this.pnlG = new System.Windows.Forms.Panel();
            this.dgvPagos = new System.Windows.Forms.DataGridView();
            this.lblHistorial = new System.Windows.Forms.Label();
            this.pnlResumen.SuspendLayout();
            this.pnlB.SuspendLayout();
            this.pnlG.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPagos)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlResumen
            // 
            this.pnlResumen.BackColor = System.Drawing.Color.White;
            this.pnlResumen.Controls.Add(this.lblMonto);
            this.pnlResumen.Controls.Add(this.lblPagado);
            this.pnlResumen.Controls.Add(this.lblSaldo);
            this.pnlResumen.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlResumen.Location = new System.Drawing.Point(0, 0);
            this.pnlResumen.Name = "pnlResumen";
            this.pnlResumen.Padding = new System.Windows.Forms.Padding(15, 10, 15, 10);
            this.pnlResumen.Size = new System.Drawing.Size(860, 90);
            this.pnlResumen.TabIndex = 0;
            // 
            // lblMonto
            // 
            this.lblMonto.AutoSize = true;
            this.lblMonto.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMonto.Location = new System.Drawing.Point(15, 10);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(0, 23);
            this.lblMonto.TabIndex = 0;
            // 
            // lblPagado
            // 
            this.lblPagado.AutoSize = true;
            this.lblPagado.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPagado.Location = new System.Drawing.Point(15, 34);
            this.lblPagado.Name = "lblPagado";
            this.lblPagado.Size = new System.Drawing.Size(0, 23);
            this.lblPagado.TabIndex = 1;
            // 
            // lblSaldo
            // 
            this.lblSaldo.AutoSize = true;
            this.lblSaldo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSaldo.Location = new System.Drawing.Point(15, 56);
            this.lblSaldo.Name = "lblSaldo";
            this.lblSaldo.Size = new System.Drawing.Size(0, 23);
            this.lblSaldo.TabIndex = 2;
            // 
            // pnlB
            // 
            this.pnlB.BackColor = System.Drawing.Color.White;
            this.pnlB.Controls.Add(this.btnRefrescar);
            this.pnlB.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlB.Location = new System.Drawing.Point(0, 90);
            this.pnlB.Name = "pnlB";
            this.pnlB.Padding = new System.Windows.Forms.Padding(8);
            this.pnlB.Size = new System.Drawing.Size(860, 50);
            this.pnlB.TabIndex = 1;
            // 
            // btnRefrescar
            // 
            this.btnRefrescar.Location = new System.Drawing.Point(8, 8);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(110, 34);
            this.btnRefrescar.TabIndex = 0;
            this.btnRefrescar.Text = "Refrescar";
            // 
            // pnlG
            // 
            this.pnlG.Controls.Add(this.dgvPagos);
            this.pnlG.Controls.Add(this.lblHistorial);
            this.pnlG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlG.Location = new System.Drawing.Point(0, 140);
            this.pnlG.Name = "pnlG";
            this.pnlG.Padding = new System.Windows.Forms.Padding(10);
            this.pnlG.Size = new System.Drawing.Size(860, 420);
            this.pnlG.TabIndex = 2;
            // 
            // dgvPagos
            // 
            this.dgvPagos.AllowUserToAddRows = false;
            this.dgvPagos.AllowUserToDeleteRows = false;
            this.dgvPagos.ColumnHeadersHeight = 29;
            this.dgvPagos.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvPagos.Location = new System.Drawing.Point(10, 95);
            this.dgvPagos.Name = "dgvPagos";
            this.dgvPagos.ReadOnly = true;
            this.dgvPagos.RowHeadersWidth = 51;
            this.dgvPagos.Size = new System.Drawing.Size(840, 315);
            this.dgvPagos.TabIndex = 1;
            // 
            // lblHistorial
            // 
            this.lblHistorial.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblHistorial.Location = new System.Drawing.Point(7, 64);
            this.lblHistorial.Name = "lblHistorial";
            this.lblHistorial.Padding = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.lblHistorial.Size = new System.Drawing.Size(840, 28);
            this.lblHistorial.TabIndex = 0;
            this.lblHistorial.Text = "📋 Historial de Pagos";
            // 
            // FrmEstadoFinanciero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(860, 560);
            this.Controls.Add(this.pnlG);
            this.Controls.Add(this.pnlB);
            this.Controls.Add(this.pnlResumen);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "FrmEstadoFinanciero";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Mi Estado Financiero";
            this.pnlResumen.ResumeLayout(false);
            this.pnlResumen.PerformLayout();
            this.pnlB.ResumeLayout(false);
            this.pnlG.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPagos)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Panel pnlResumen;
        private System.Windows.Forms.Label lblMonto;
        private System.Windows.Forms.Label lblPagado;
        private System.Windows.Forms.Label lblSaldo;
        private System.Windows.Forms.Panel pnlB;
        private System.Windows.Forms.Button btnRefrescar;
        private System.Windows.Forms.Panel pnlG;
        private System.Windows.Forms.Label lblHistorial;
        private System.Windows.Forms.DataGridView dgvPagos;
    }
}