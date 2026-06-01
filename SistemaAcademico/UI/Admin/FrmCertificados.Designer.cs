namespace SistemaAcademico.UI.Admin
{
    partial class FrmCertificados
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
            this.pnlB = new System.Windows.Forms.Panel();
            this.lblEstudiante = new System.Windows.Forms.Label();
            this.cmbEstudiante = new System.Windows.Forms.ComboBox();
            this.btnEmitir = new System.Windows.Forms.Button();
            this.btnRefrescar = new System.Windows.Forms.Button();
            this.pnlG = new System.Windows.Forms.Panel();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.pnlB.SuspendLayout();
            this.pnlG.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlB
            // 
            this.pnlB.BackColor = System.Drawing.Color.White;
            this.pnlB.Controls.Add(this.lblEstudiante);
            this.pnlB.Controls.Add(this.cmbEstudiante);
            this.pnlB.Controls.Add(this.btnEmitir);
            this.pnlB.Controls.Add(this.btnRefrescar);
            this.pnlB.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlB.Location = new System.Drawing.Point(0, 0);
            this.pnlB.Name = "pnlB";
            this.pnlB.Padding = new System.Windows.Forms.Padding(8);
            this.pnlB.Size = new System.Drawing.Size(900, 58);
            this.pnlB.TabIndex = 0;
            // 
            // lblEstudiante
            // 
            this.lblEstudiante.AutoSize = true;
            this.lblEstudiante.Location = new System.Drawing.Point(8, 18);
            this.lblEstudiante.Name = "lblEstudiante";
            this.lblEstudiante.Size = new System.Drawing.Size(65, 15);
            this.lblEstudiante.TabIndex = 0;
            this.lblEstudiante.Text = "Estudiante:";
            // 
            // cmbEstudiante
            // 
            this.cmbEstudiante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstudiante.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbEstudiante.Location = new System.Drawing.Point(85, 14);
            this.cmbEstudiante.Name = "cmbEstudiante";
            this.cmbEstudiante.Size = new System.Drawing.Size(280, 25);
            this.cmbEstudiante.TabIndex = 1;
            // 
            // btnEmitir
            // 
            this.btnEmitir.Location = new System.Drawing.Point(375, 12);
            this.btnEmitir.Name = "btnEmitir";
            this.btnEmitir.Size = new System.Drawing.Size(165, 27);
            this.btnEmitir.TabIndex = 2;
            this.btnEmitir.Text = "Emitir Certificado";
            // 
            // btnRefrescar
            // 
            this.btnRefrescar.Location = new System.Drawing.Point(548, 12);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(110, 27);
            this.btnRefrescar.TabIndex = 3;
            this.btnRefrescar.Text = "Refrescar";
            // 
            // pnlG
            // 
            this.pnlG.Controls.Add(this.dgv);
            this.pnlG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlG.Location = new System.Drawing.Point(0, 58);
            this.pnlG.Name = "pnlG";
            this.pnlG.Padding = new System.Windows.Forms.Padding(10);
            this.pnlG.Size = new System.Drawing.Size(900, 482);
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
            this.dgv.Size = new System.Drawing.Size(880, 462);
            this.dgv.TabIndex = 0;
            // 
            // FrmCertificados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.ClientSize = new System.Drawing.Size(900, 540);
            this.Controls.Add(this.pnlG);
            this.Controls.Add(this.pnlB);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "FrmCertificados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Certificados";
            this.pnlB.ResumeLayout(false);
            this.pnlB.PerformLayout();
            this.pnlG.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Panel pnlB;
        private System.Windows.Forms.Label lblEstudiante;
        private System.Windows.Forms.ComboBox cmbEstudiante;
        private System.Windows.Forms.Button btnEmitir;
        private System.Windows.Forms.Button btnRefrescar;
        private System.Windows.Forms.Panel pnlG;
        private System.Windows.Forms.DataGridView dgv;
    }
}