namespace SistemaAcademico.UI.Admin
{
    partial class FrmAlertasAsistencia
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
            this.btnMarcarRevisado = new System.Windows.Forms.Button();
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
            this.pnlB.Controls.Add(this.btnMarcarRevisado);
            this.pnlB.Controls.Add(this.btnRefrescar);
            this.pnlB.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlB.Location = new System.Drawing.Point(0, 0);
            this.pnlB.Name = "pnlB";
            this.pnlB.Padding = new System.Windows.Forms.Padding(8);
            this.pnlB.Size = new System.Drawing.Size(900, 52);
            this.pnlB.TabIndex = 0;
            // 
            // btnMarcarRevisado
            // 
            this.btnMarcarRevisado.Location = new System.Drawing.Point(8, 8);
            this.btnMarcarRevisado.Name = "btnMarcarRevisado";
            this.btnMarcarRevisado.Size = new System.Drawing.Size(185, 36);
            this.btnMarcarRevisado.TabIndex = 0;
            this.btnMarcarRevisado.Text = "Marcar como Revisado";
            // 
            // btnRefrescar
            // 
            this.btnRefrescar.Location = new System.Drawing.Point(201, 8);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(110, 36);
            this.btnRefrescar.TabIndex = 1;
            this.btnRefrescar.Text = "Refrescar";
            // 
            // pnlG
            // 
            this.pnlG.Controls.Add(this.dgv);
            this.pnlG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlG.Location = new System.Drawing.Point(0, 52);
            this.pnlG.Name = "pnlG";
            this.pnlG.Padding = new System.Windows.Forms.Padding(10);
            this.pnlG.Size = new System.Drawing.Size(900, 468);
            this.pnlG.TabIndex = 1;
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.ColumnHeadersHeight = 29;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgv.Location = new System.Drawing.Point(10, 77);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersWidth = 51;
            this.dgv.Size = new System.Drawing.Size(880, 381);
            this.dgv.TabIndex = 0;
            // 
            // FrmAlertasAsistencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(900, 520);
            this.Controls.Add(this.pnlG);
            this.Controls.Add(this.pnlB);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "FrmAlertasAsistencia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Alertas de Asistencia";
            this.pnlB.ResumeLayout(false);
            this.pnlG.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Panel pnlB;
        private System.Windows.Forms.Button btnMarcarRevisado;
        private System.Windows.Forms.Button btnRefrescar;
        private System.Windows.Forms.Panel pnlG;
        private System.Windows.Forms.DataGridView dgv;
    }
}