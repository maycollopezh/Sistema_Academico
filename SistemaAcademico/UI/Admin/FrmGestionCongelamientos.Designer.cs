namespace SistemaAcademico.UI.Admin
{
    partial class FrmGestionCongelamientos
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
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnLevantar = new System.Windows.Forms.Button();
            this.btnRefrescar = new System.Windows.Forms.Button();
            this.pnlG = new System.Windows.Forms.Panel();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.pnlBotones.SuspendLayout();
            this.pnlG.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBotones
            // 
            this.pnlBotones.BackColor = System.Drawing.Color.White;
            this.pnlBotones.Controls.Add(this.btnNuevo);
            this.pnlBotones.Controls.Add(this.btnLevantar);
            this.pnlBotones.Controls.Add(this.btnRefrescar);
            this.pnlBotones.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBotones.Location = new System.Drawing.Point(0, 0);
            this.pnlBotones.Name = "pnlBotones";
            this.pnlBotones.Padding = new System.Windows.Forms.Padding(8);
            this.pnlBotones.Size = new System.Drawing.Size(920, 52);
            this.pnlBotones.TabIndex = 0;
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(8, 8);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(175, 36);
            this.btnNuevo.TabIndex = 0;
            this.btnNuevo.Text = "Nuevo Congelamiento";
            // 
            // btnLevantar
            // 
            this.btnLevantar.Location = new System.Drawing.Point(191, 8);
            this.btnLevantar.Name = "btnLevantar";
            this.btnLevantar.Size = new System.Drawing.Size(110, 36);
            this.btnLevantar.TabIndex = 1;
            this.btnLevantar.Text = "Levantar";
            // 
            // btnRefrescar
            // 
            this.btnRefrescar.Location = new System.Drawing.Point(309, 8);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(110, 36);
            this.btnRefrescar.TabIndex = 2;
            this.btnRefrescar.Text = "Refrescar";
            // 
            // pnlG
            // 
            this.pnlG.Controls.Add(this.dgv);
            this.pnlG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlG.Location = new System.Drawing.Point(0, 52);
            this.pnlG.Name = "pnlG";
            this.pnlG.Padding = new System.Windows.Forms.Padding(10);
            this.pnlG.Size = new System.Drawing.Size(920, 488);
            this.pnlG.TabIndex = 1;
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(10, 10);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.Size = new System.Drawing.Size(900, 468);
            this.dgv.TabIndex = 0;
            // 
            // FrmGestionCongelamientos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.ClientSize = new System.Drawing.Size(920, 540);
            this.Controls.Add(this.pnlG);
            this.Controls.Add(this.pnlBotones);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "FrmGestionCongelamientos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Congelamientos";
            this.pnlBotones.ResumeLayout(false);
            this.pnlG.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Panel pnlBotones;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnLevantar;
        private System.Windows.Forms.Button btnRefrescar;
        private System.Windows.Forms.Panel pnlG;
        private System.Windows.Forms.DataGridView dgv;
    }
}