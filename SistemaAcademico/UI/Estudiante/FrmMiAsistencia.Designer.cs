namespace SistemaAcademico.UI.Estudiante
{
    partial class FrmMiAsistencia
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
            this.pnlBotones = new System.Windows.Forms.Panel();
            this.lblResumen = new System.Windows.Forms.Label();
            this.btnExportar = new System.Windows.Forms.Button();
            this.btnRefrescar = new System.Windows.Forms.Button();
            this.pnlG = new System.Windows.Forms.Panel();
            this.split = new System.Windows.Forms.SplitContainer();
            this.pnlDet = new System.Windows.Forms.Panel();
            this.dgvAsistencia = new System.Windows.Forms.DataGridView();
            this.lblDetalle = new System.Windows.Forms.Label();
            this.pnlSem = new System.Windows.Forms.Panel();
            this.dgvResumenSemanal = new System.Windows.Forms.DataGridView();
            this.lblSemanal = new System.Windows.Forms.Label();
            this.pnlBotones.SuspendLayout();
            this.pnlG.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.split)).BeginInit();
            this.split.Panel1.SuspendLayout();
            this.split.Panel2.SuspendLayout();
            this.split.SuspendLayout();
            this.pnlDet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsistencia)).BeginInit();
            this.pnlSem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResumenSemanal)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBotones
            // 
            this.pnlBotones.BackColor = System.Drawing.Color.White;
            this.pnlBotones.Controls.Add(this.lblResumen);
            this.pnlBotones.Controls.Add(this.btnExportar);
            this.pnlBotones.Controls.Add(this.btnRefrescar);
            this.pnlBotones.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBotones.Location = new System.Drawing.Point(0, 0);
            this.pnlBotones.Name = "pnlBotones";
            this.pnlBotones.Padding = new System.Windows.Forms.Padding(8);
            this.pnlBotones.Size = new System.Drawing.Size(960, 56);
            this.pnlBotones.TabIndex = 0;
            // 
            // lblResumen
            // 
            this.lblResumen.AutoSize = true;
            this.lblResumen.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblResumen.Location = new System.Drawing.Point(8, 18);
            this.lblResumen.Name = "lblResumen";
            this.lblResumen.Size = new System.Drawing.Size(0, 21);
            this.lblResumen.TabIndex = 0;
            // 
            // btnExportar
            // 
            this.btnExportar.Location = new System.Drawing.Point(500, 10);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(160, 36);
            this.btnExportar.TabIndex = 1;
            this.btnExportar.Text = "Exportar a Excel";
            // 
            // btnRefrescar
            // 
            this.btnRefrescar.Location = new System.Drawing.Point(668, 10);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(110, 36);
            this.btnRefrescar.TabIndex = 2;
            this.btnRefrescar.Text = "Refrescar";
            // 
            // pnlG
            // 
            this.pnlG.Controls.Add(this.split);
            this.pnlG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlG.Location = new System.Drawing.Point(0, 56);
            this.pnlG.Name = "pnlG";
            this.pnlG.Padding = new System.Windows.Forms.Padding(10);
            this.pnlG.Size = new System.Drawing.Size(960, 564);
            this.pnlG.TabIndex = 1;
            // 
            // split
            // 
            this.split.Dock = System.Windows.Forms.DockStyle.Fill;
            this.split.Location = new System.Drawing.Point(10, 10);
            this.split.Name = "split";
            this.split.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // split.Panel1
            // 
            this.split.Panel1.Controls.Add(this.pnlDet);
            // 
            // split.Panel2
            // 
            this.split.Panel2.Controls.Add(this.pnlSem);
            this.split.Size = new System.Drawing.Size(940, 544);
            this.split.SplitterDistance = 300;
            this.split.TabIndex = 0;
            // 
            // pnlDet
            // 
            this.pnlDet.Controls.Add(this.dgvAsistencia);
            this.pnlDet.Controls.Add(this.lblDetalle);
            this.pnlDet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDet.Location = new System.Drawing.Point(0, 0);
            this.pnlDet.Name = "pnlDet";
            this.pnlDet.Size = new System.Drawing.Size(940, 300);
            this.pnlDet.TabIndex = 0;
            // 
            // dgvAsistencia
            // 
            this.dgvAsistencia.AllowUserToAddRows = false;
            this.dgvAsistencia.AllowUserToDeleteRows = false;
            this.dgvAsistencia.ColumnHeadersHeight = 29;
            this.dgvAsistencia.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvAsistencia.Location = new System.Drawing.Point(0, 83);
            this.dgvAsistencia.Name = "dgvAsistencia";
            this.dgvAsistencia.ReadOnly = true;
            this.dgvAsistencia.RowHeadersWidth = 51;
            this.dgvAsistencia.Size = new System.Drawing.Size(940, 217);
            this.dgvAsistencia.TabIndex = 1;
            // 
            // lblDetalle
            // 
            this.lblDetalle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblDetalle.Location = new System.Drawing.Point(-2, 52);
            this.lblDetalle.Name = "lblDetalle";
            this.lblDetalle.Padding = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.lblDetalle.Size = new System.Drawing.Size(940, 28);
            this.lblDetalle.TabIndex = 0;
            this.lblDetalle.Text = "📋 Detalle de Clases Reservadas";
            // 
            // pnlSem
            // 
            this.pnlSem.Controls.Add(this.dgvResumenSemanal);
            this.pnlSem.Controls.Add(this.lblSemanal);
            this.pnlSem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSem.Location = new System.Drawing.Point(0, 0);
            this.pnlSem.Name = "pnlSem";
            this.pnlSem.Size = new System.Drawing.Size(940, 240);
            this.pnlSem.TabIndex = 0;
            // 
            // dgvResumenSemanal
            // 
            this.dgvResumenSemanal.AllowUserToAddRows = false;
            this.dgvResumenSemanal.AllowUserToDeleteRows = false;
            this.dgvResumenSemanal.ColumnHeadersHeight = 29;
            this.dgvResumenSemanal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvResumenSemanal.Location = new System.Drawing.Point(0, 28);
            this.dgvResumenSemanal.Name = "dgvResumenSemanal";
            this.dgvResumenSemanal.ReadOnly = true;
            this.dgvResumenSemanal.RowHeadersWidth = 51;
            this.dgvResumenSemanal.Size = new System.Drawing.Size(940, 212);
            this.dgvResumenSemanal.TabIndex = 1;
            // 
            // lblSemanal
            // 
            this.lblSemanal.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSemanal.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblSemanal.Location = new System.Drawing.Point(0, 0);
            this.lblSemanal.Name = "lblSemanal";
            this.lblSemanal.Padding = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.lblSemanal.Size = new System.Drawing.Size(940, 28);
            this.lblSemanal.TabIndex = 0;
            this.lblSemanal.Text = "📅 Resumen Semanal de Horas";
            // 
            // FrmMiAsistencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(960, 620);
            this.Controls.Add(this.pnlG);
            this.Controls.Add(this.pnlBotones);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "FrmMiAsistencia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Mi Asistencia";
            this.pnlBotones.ResumeLayout(false);
            this.pnlBotones.PerformLayout();
            this.pnlG.ResumeLayout(false);
            this.split.Panel1.ResumeLayout(false);
            this.split.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.split)).EndInit();
            this.split.ResumeLayout(false);
            this.pnlDet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsistencia)).EndInit();
            this.pnlSem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResumenSemanal)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Panel pnlBotones;
        private System.Windows.Forms.Label lblResumen;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Button btnRefrescar;
        private System.Windows.Forms.Panel pnlG;
        private System.Windows.Forms.SplitContainer split;
        private System.Windows.Forms.Panel pnlDet;
        private System.Windows.Forms.DataGridView dgvAsistencia;
        private System.Windows.Forms.Label lblDetalle;
        private System.Windows.Forms.Panel pnlSem;
        private System.Windows.Forms.DataGridView dgvResumenSemanal;
        private System.Windows.Forms.Label lblSemanal;
        private System.Data.DataTable _dtAsistencia;
    }
}