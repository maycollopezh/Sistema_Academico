namespace SistemaAcademico.UI.Admin
{
    partial class FrmGestionHorarios
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
            this.btnPublicar = new System.Windows.Forms.Button();
            this.btnVerClases = new System.Windows.Forms.Button();
            this.btnRefrescar = new System.Windows.Forms.Button();
            this.lblEstado = new System.Windows.Forms.Label();
            this.dgvHorarios = new System.Windows.Forms.DataGridView();
            this.pnlBotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHorarios)).BeginInit();
            this.SuspendLayout();
            // pnlBotones
            this.pnlBotones.BackColor = System.Drawing.Color.White;
            this.pnlBotones.Controls.Add(this.lblEstado);
            this.pnlBotones.Controls.Add(this.btnRefrescar);
            this.pnlBotones.Controls.Add(this.btnVerClases);
            this.pnlBotones.Controls.Add(this.btnPublicar);
            this.pnlBotones.Controls.Add(this.btnNuevo);
            this.pnlBotones.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBotones.Location = new System.Drawing.Point(0, 0);
            this.pnlBotones.Name = "pnlBotones";
            this.pnlBotones.Padding = new System.Windows.Forms.Padding(8);
            this.pnlBotones.Size = new System.Drawing.Size(900, 52);
            this.pnlBotones.TabIndex = 0;
            // btnNuevo
            this.btnNuevo.Location = new System.Drawing.Point(8, 8);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(140, 30);
            this.btnNuevo.TabIndex = 0;
            this.btnNuevo.Text = "Nuevo Horario";
            // btnPublicar
            this.btnPublicar.Location = new System.Drawing.Point(156, 8);
            this.btnPublicar.Name = "btnPublicar";
            this.btnPublicar.Size = new System.Drawing.Size(155, 30);
            this.btnPublicar.TabIndex = 1;
            this.btnPublicar.Text = "Publicar/Ocultar";
            // btnVerClases
            this.btnVerClases.Location = new System.Drawing.Point(319, 8);
            this.btnVerClases.Name = "btnVerClases";
            this.btnVerClases.Size = new System.Drawing.Size(120, 30);
            this.btnVerClases.TabIndex = 2;
            this.btnVerClases.Text = "Ver Clases";
            // btnRefrescar
            this.btnRefrescar.Location = new System.Drawing.Point(447, 8);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(110, 30);
            this.btnRefrescar.TabIndex = 3;
            this.btnRefrescar.Text = "Refrescar";
            // lblEstado
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(580, 14);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.TabIndex = 4;
            this.lblEstado.Text = "";
            // dgvHorarios
            this.dgvHorarios.AllowUserToAddRows = false;
            this.dgvHorarios.AllowUserToDeleteRows = false;
            this.dgvHorarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHorarios.Location = new System.Drawing.Point(0, 52);
            this.dgvHorarios.Name = "dgvHorarios";
            this.dgvHorarios.ReadOnly = true;
            this.dgvHorarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHorarios.Size = new System.Drawing.Size(900, 508);
            this.dgvHorarios.TabIndex = 1;
            // FrmGestionHorarios
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.ClientSize = new System.Drawing.Size(900, 560);
            this.Controls.Add(this.dgvHorarios);
            this.Controls.Add(this.pnlBotones);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "FrmGestionHorarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Gestión de Horarios";
            this.pnlBotones.ResumeLayout(false);
            this.pnlBotones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHorarios)).EndInit();
            this.ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.Panel pnlBotones;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnPublicar;
        private System.Windows.Forms.Button btnVerClases;
        private System.Windows.Forms.Button btnRefrescar;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.DataGridView dgvHorarios;
    }
}