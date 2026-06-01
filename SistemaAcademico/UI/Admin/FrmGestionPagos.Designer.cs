namespace SistemaAcademico.UI.Admin
{
    partial class FrmGestionPagos
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
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblEstudiante = new System.Windows.Forms.Label();
            this.cmbEstudiante = new System.Windows.Forms.ComboBox();
            this.btnRegistrarPago = new System.Windows.Forms.Button();
            this.btnRefrescar = new System.Windows.Forms.Button();
            this.lblSaldo = new System.Windows.Forms.Label();
            this.splitter = new System.Windows.Forms.SplitContainer();
            this.dgvInscripcion = new System.Windows.Forms.DataGridView();
            this.dgvPagos = new System.Windows.Forms.DataGridView();

            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitter)).BeginInit();
            this.splitter.Panel1.SuspendLayout();
            this.splitter.Panel2.SuspendLayout();
            this.splitter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInscripcion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPagos)).BeginInit();
            this.SuspendLayout();
            
            // pnlTop
            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.Controls.Add(this.lblSaldo);
            this.pnlTop.Controls.Add(this.btnRefrescar);
            this.pnlTop.Controls.Add(this.btnRegistrarPago);
            this.pnlTop.Controls.Add(this.cmbEstudiante);
            this.pnlTop.Controls.Add(this.lblEstudiante);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new System.Windows.Forms.Padding(10);
            this.pnlTop.Size = new System.Drawing.Size(960, 58);
            this.pnlTop.TabIndex = 0;
            
            // lblEstudiante
            this.lblEstudiante.AutoSize = true;
            this.lblEstudiante.Location = new System.Drawing.Point(10, 20);
            this.lblEstudiante.Name = "lblEstudiante";
            this.lblEstudiante.Size = new System.Drawing.Size(66, 15);
            this.lblEstudiante.TabIndex = 0;
            this.lblEstudiante.Text = "Estudiante:";
            
            // cmbEstudiante
            this.cmbEstudiante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstudiante.Location = new System.Drawing.Point(90, 16);
            this.cmbEstudiante.Name = "cmbEstudiante";
            this.cmbEstudiante.Size = new System.Drawing.Size(280, 23);
            this.cmbEstudiante.TabIndex = 1;
            
            // btnRegistrarPago
            this.btnRegistrarPago.Location = new System.Drawing.Point(390, 12);
            this.btnRegistrarPago.Name = "btnRegistrarPago";
            this.btnRegistrarPago.Size = new System.Drawing.Size(150, 32);
            this.btnRegistrarPago.TabIndex = 2;
            this.btnRegistrarPago.Text = "Registrar Pago";
            
            // btnRefrescar
            this.btnRefrescar.Location = new System.Drawing.Point(550, 12);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(110, 32);
            this.btnRefrescar.TabIndex = 3;
            this.btnRefrescar.Text = "Refrescar";
            
            // lblSaldo
            this.lblSaldo.AutoSize = true;
            this.lblSaldo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblSaldo.Location = new System.Drawing.Point(680, 19);
            this.lblSaldo.Name = "lblSaldo";
            this.lblSaldo.Size = new System.Drawing.Size(115, 17);
            this.lblSaldo.TabIndex = 4;
            this.lblSaldo.Text = "Saldo Pendiente:";
            
            // splitter
            this.splitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitter.Location = new System.Drawing.Point(0, 58);
            this.splitter.Name = "splitter";
            this.splitter.Orientation = System.Windows.Forms.Orientation.Horizontal;
            
            // splitter.Panel1
            this.splitter.Panel1.Controls.Add(this.dgvInscripcion);
            
            // splitter.Panel2
            this.splitter.Panel2.Controls.Add(this.dgvPagos);
            this.splitter.Size = new System.Drawing.Size(960, 562);
            this.splitter.SplitterDistance = 120;
            this.splitter.TabIndex = 1;
            
            // dgvInscripcion
            this.dgvInscripcion.AllowUserToAddRows = false;
            this.dgvInscripcion.AllowUserToDeleteRows = false;
            this.dgvInscripcion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInscripcion.Location = new System.Drawing.Point(0, 0);
            this.dgvInscripcion.Name = "dgvInscripcion";
            this.dgvInscripcion.ReadOnly = true;
            this.dgvInscripcion.Size = new System.Drawing.Size(960, 120);
            this.dgvInscripcion.TabIndex = 0;
            
            // dgvPagos
            this.dgvPagos.AllowUserToAddRows = false;
            this.dgvPagos.AllowUserToDeleteRows = false;
            this.dgvPagos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPagos.Location = new System.Drawing.Point(0, 0);
            this.dgvPagos.Name = "dgvPagos";
            this.dgvPagos.ReadOnly = true;
            this.dgvPagos.Size = new System.Drawing.Size(960, 438);
            this.dgvPagos.TabIndex = 0;
            
            // FrmGestionPagos
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.ClientSize = new System.Drawing.Size(960, 620);
            this.Controls.Add(this.splitter);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "FrmGestionPagos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Gestión de Pagos";
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.splitter.Panel1.ResumeLayout(false);
            this.splitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitter)).EndInit();
            this.splitter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInscripcion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPagos)).EndInit();
            this.ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblEstudiante;
        private System.Windows.Forms.ComboBox cmbEstudiante;
        private System.Windows.Forms.Button btnRegistrarPago;
        private System.Windows.Forms.Button btnRefrescar;
        private System.Windows.Forms.Label lblSaldo;
        private System.Windows.Forms.SplitContainer splitter;
        private System.Windows.Forms.DataGridView dgvInscripcion;
        private System.Windows.Forms.DataGridView dgvPagos;
    }
}