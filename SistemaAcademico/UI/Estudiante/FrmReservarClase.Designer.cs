namespace SistemaAcademico.UI.Estudiante
{
    partial class FrmReservarClase
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
            this.lblHorasSemana = new System.Windows.Forms.Label();
            this.btnReservar = new System.Windows.Forms.Button();
            this.btnRefrescar = new System.Windows.Forms.Button();
            this.pnlG = new System.Windows.Forms.Panel();
            this.dgvClases = new System.Windows.Forms.DataGridView();
            this.pnlBotones.SuspendLayout();
            this.pnlG.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClases)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBotones
            // 
            this.pnlBotones.BackColor = System.Drawing.Color.White;
            this.pnlBotones.Controls.Add(this.lblHorasSemana);
            this.pnlBotones.Controls.Add(this.btnReservar);
            this.pnlBotones.Controls.Add(this.btnRefrescar);
            this.pnlBotones.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBotones.Location = new System.Drawing.Point(0, 0);
            this.pnlBotones.Name = "pnlBotones";
            this.pnlBotones.Padding = new System.Windows.Forms.Padding(8);
            this.pnlBotones.Size = new System.Drawing.Size(900, 56);
            this.pnlBotones.TabIndex = 0;
            // 
            // lblHorasSemana
            // 
            this.lblHorasSemana.AutoSize = true;
            this.lblHorasSemana.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblHorasSemana.Location = new System.Drawing.Point(8, 18);
            this.lblHorasSemana.Name = "lblHorasSemana";
            this.lblHorasSemana.Size = new System.Drawing.Size(0, 21);
            this.lblHorasSemana.TabIndex = 0;
            // 
            // btnReservar
            // 
            this.btnReservar.Location = new System.Drawing.Point(500, 10);
            this.btnReservar.Name = "btnReservar";
            this.btnReservar.Size = new System.Drawing.Size(145, 36);
            this.btnReservar.TabIndex = 1;
            this.btnReservar.Text = "Reservar Clase";
            // 
            // btnRefrescar
            // 
            this.btnRefrescar.Location = new System.Drawing.Point(653, 10);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(110, 36);
            this.btnRefrescar.TabIndex = 2;
            this.btnRefrescar.Text = "Refrescar";
            // 
            // pnlG
            // 
            this.pnlG.Controls.Add(this.dgvClases);
            this.pnlG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlG.Location = new System.Drawing.Point(0, 56);
            this.pnlG.Name = "pnlG";
            this.pnlG.Padding = new System.Windows.Forms.Padding(10);
            this.pnlG.Size = new System.Drawing.Size(900, 504);
            this.pnlG.TabIndex = 1;
            // 
            // dgvClases
            // 
            this.dgvClases.AllowUserToAddRows = false;
            this.dgvClases.AllowUserToDeleteRows = false;
            this.dgvClases.ColumnHeadersHeight = 29;
            this.dgvClases.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvClases.Location = new System.Drawing.Point(10, 82);
            this.dgvClases.Name = "dgvClases";
            this.dgvClases.ReadOnly = true;
            this.dgvClases.RowHeadersWidth = 51;
            this.dgvClases.Size = new System.Drawing.Size(880, 412);
            this.dgvClases.TabIndex = 0;
            // 
            // FrmReservarClase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(900, 560);
            this.Controls.Add(this.pnlG);
            this.Controls.Add(this.pnlBotones);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "FrmReservarClase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Reservar una Clase";
            this.pnlBotones.ResumeLayout(false);
            this.pnlBotones.PerformLayout();
            this.pnlG.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClases)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Panel pnlBotones;
        private System.Windows.Forms.Label lblHorasSemana;
        private System.Windows.Forms.Button btnReservar;
        private System.Windows.Forms.Button btnRefrescar;
        private System.Windows.Forms.Panel pnlG;
        private System.Windows.Forms.DataGridView dgvClases;
    }
}