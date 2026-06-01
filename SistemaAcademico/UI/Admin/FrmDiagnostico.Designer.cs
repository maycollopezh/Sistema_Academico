namespace SistemaAcademico.UI.Admin
{
    partial class FrmDiagnostico
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
            this.pnlG = new System.Windows.Forms.Panel();
            this.splitter = new System.Windows.Forms.SplitContainer();
            this.pnlForm = new System.Windows.Forms.Panel();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.lblObservaciones = new System.Windows.Forms.Label();
            this.cmbModulo = new System.Windows.Forms.ComboBox();
            this.lblModulo = new System.Windows.Forms.Label();
            this.txtNivel = new System.Windows.Forms.TextBox();
            this.lblNivel = new System.Windows.Forms.Label();
            this.nudPuntaje = new System.Windows.Forms.NumericUpDown();
            this.lblPuntaje = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblFecha = new System.Windows.Forms.Label();
            this.cmbEstudiante = new System.Windows.Forms.ComboBox();
            this.lblEstudiante = new System.Windows.Forms.Label();
            this.pnlR = new System.Windows.Forms.Panel();
            this.dgvDiagnosticos = new System.Windows.Forms.DataGridView();
            this.lblRegistrados = new System.Windows.Forms.Label();
            this.pnlG.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitter)).BeginInit();
            this.splitter.Panel1.SuspendLayout();
            this.splitter.Panel2.SuspendLayout();
            this.splitter.SuspendLayout();
            this.pnlForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPuntaje)).BeginInit();
            this.pnlR.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiagnosticos)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlG
            // 
            this.pnlG.Controls.Add(this.splitter);
            this.pnlG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlG.Location = new System.Drawing.Point(0, 0);
            this.pnlG.Name = "pnlG";
            this.pnlG.Padding = new System.Windows.Forms.Padding(10, 60, 10, 10);
            this.pnlG.Size = new System.Drawing.Size(900, 580);
            this.pnlG.TabIndex = 0;
            // 
            // splitter
            // 
            this.splitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitter.Location = new System.Drawing.Point(10, 60);
            this.splitter.Name = "splitter";
            // 
            // splitter.Panel1
            // 
            this.splitter.Panel1.Controls.Add(this.pnlForm);
            // 
            // splitter.Panel2
            // 
            this.splitter.Panel2.Controls.Add(this.pnlR);
            this.splitter.Size = new System.Drawing.Size(880, 510);
            this.splitter.SplitterDistance = 350;
            this.splitter.TabIndex = 0;
            // 
            // pnlForm
            // 
            this.pnlForm.BackColor = System.Drawing.Color.White;
            this.pnlForm.Controls.Add(this.btnRegistrar);
            this.pnlForm.Controls.Add(this.txtObservaciones);
            this.pnlForm.Controls.Add(this.lblObservaciones);
            this.pnlForm.Controls.Add(this.cmbModulo);
            this.pnlForm.Controls.Add(this.lblModulo);
            this.pnlForm.Controls.Add(this.txtNivel);
            this.pnlForm.Controls.Add(this.lblNivel);
            this.pnlForm.Controls.Add(this.nudPuntaje);
            this.pnlForm.Controls.Add(this.lblPuntaje);
            this.pnlForm.Controls.Add(this.dtpFecha);
            this.pnlForm.Controls.Add(this.lblFecha);
            this.pnlForm.Controls.Add(this.cmbEstudiante);
            this.pnlForm.Controls.Add(this.lblEstudiante);
            this.pnlForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlForm.Location = new System.Drawing.Point(0, 0);
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.Padding = new System.Windows.Forms.Padding(15, 10, 15, 10);
            this.pnlForm.Size = new System.Drawing.Size(350, 510);
            this.pnlForm.TabIndex = 0;
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Location = new System.Drawing.Point(12, 404);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(200, 36);
            this.btnRegistrar.TabIndex = 12;
            this.btnRegistrar.Text = "Registrar Diagnóstico";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Location = new System.Drawing.Point(12, 343);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(320, 55);
            this.txtObservaciones.TabIndex = 11;
            // 
            // lblObservaciones
            // 
            this.lblObservaciones.AutoSize = true;
            this.lblObservaciones.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblObservaciones.Location = new System.Drawing.Point(12, 325);
            this.lblObservaciones.Name = "lblObservaciones";
            this.lblObservaciones.Size = new System.Drawing.Size(111, 20);
            this.lblObservaciones.TabIndex = 10;
            this.lblObservaciones.Text = "Observaciones";
            // 
            // cmbModulo
            // 
            this.cmbModulo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbModulo.Location = new System.Drawing.Point(12, 296);
            this.cmbModulo.Name = "cmbModulo";
            this.cmbModulo.Size = new System.Drawing.Size(320, 28);
            this.cmbModulo.TabIndex = 9;
            // 
            // lblModulo
            // 
            this.lblModulo.AutoSize = true;
            this.lblModulo.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblModulo.Location = new System.Drawing.Point(12, 278);
            this.lblModulo.Name = "lblModulo";
            this.lblModulo.Size = new System.Drawing.Size(144, 20);
            this.lblModulo.TabIndex = 8;
            this.lblModulo.Text = "Módulo Asignado *";
            // 
            // txtNivel
            // 
            this.txtNivel.Location = new System.Drawing.Point(12, 249);
            this.txtNivel.Name = "txtNivel";
            this.txtNivel.Size = new System.Drawing.Size(320, 27);
            this.txtNivel.TabIndex = 7;
            // 
            // lblNivel
            // 
            this.lblNivel.AutoSize = true;
            this.lblNivel.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblNivel.Location = new System.Drawing.Point(12, 231);
            this.lblNivel.Name = "lblNivel";
            this.lblNivel.Size = new System.Drawing.Size(141, 20);
            this.lblNivel.TabIndex = 6;
            this.lblNivel.Text = "Nivel Determinado";
            // 
            // nudPuntaje
            // 
            this.nudPuntaje.Location = new System.Drawing.Point(12, 202);
            this.nudPuntaje.Name = "nudPuntaje";
            this.nudPuntaje.Size = new System.Drawing.Size(320, 27);
            this.nudPuntaje.TabIndex = 5;
            // 
            // lblPuntaje
            // 
            this.lblPuntaje.AutoSize = true;
            this.lblPuntaje.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblPuntaje.Location = new System.Drawing.Point(12, 184);
            this.lblPuntaje.Name = "lblPuntaje";
            this.lblPuntaje.Size = new System.Drawing.Size(131, 20);
            this.lblPuntaje.TabIndex = 4;
            this.lblPuntaje.Text = "Puntaje (0-100) *";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(12, 155);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(320, 27);
            this.dtpFecha.TabIndex = 3;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblFecha.Location = new System.Drawing.Point(12, 137);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(144, 20);
            this.lblFecha.TabIndex = 2;
            this.lblFecha.Text = "Fecha del Examen *";
            // 
            // cmbEstudiante
            // 
            this.cmbEstudiante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstudiante.Location = new System.Drawing.Point(12, 108);
            this.cmbEstudiante.Name = "cmbEstudiante";
            this.cmbEstudiante.Size = new System.Drawing.Size(320, 28);
            this.cmbEstudiante.TabIndex = 1;
            // 
            // lblEstudiante
            // 
            this.lblEstudiante.AutoSize = true;
            this.lblEstudiante.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblEstudiante.Location = new System.Drawing.Point(12, 90);
            this.lblEstudiante.Name = "lblEstudiante";
            this.lblEstudiante.Size = new System.Drawing.Size(94, 20);
            this.lblEstudiante.TabIndex = 0;
            this.lblEstudiante.Text = "Estudiante *";
            // 
            // pnlR
            // 
            this.pnlR.Controls.Add(this.dgvDiagnosticos);
            this.pnlR.Controls.Add(this.lblRegistrados);
            this.pnlR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlR.Location = new System.Drawing.Point(0, 0);
            this.pnlR.Name = "pnlR";
            this.pnlR.Padding = new System.Windows.Forms.Padding(5);
            this.pnlR.Size = new System.Drawing.Size(526, 510);
            this.pnlR.TabIndex = 0;
            // 
            // dgvDiagnosticos
            // 
            this.dgvDiagnosticos.AllowUserToAddRows = false;
            this.dgvDiagnosticos.AllowUserToDeleteRows = false;
            this.dgvDiagnosticos.ColumnHeadersHeight = 29;
            this.dgvDiagnosticos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDiagnosticos.Location = new System.Drawing.Point(5, 35);
            this.dgvDiagnosticos.Name = "dgvDiagnosticos";
            this.dgvDiagnosticos.ReadOnly = true;
            this.dgvDiagnosticos.RowHeadersWidth = 51;
            this.dgvDiagnosticos.Size = new System.Drawing.Size(516, 470);
            this.dgvDiagnosticos.TabIndex = 1;
            // 
            // lblRegistrados
            // 
            this.lblRegistrados.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRegistrados.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblRegistrados.Location = new System.Drawing.Point(5, 5);
            this.lblRegistrados.Name = "lblRegistrados";
            this.lblRegistrados.Size = new System.Drawing.Size(516, 30);
            this.lblRegistrados.TabIndex = 0;
            this.lblRegistrados.Text = "Diagnósticos Registrados";
            // 
            // FrmDiagnostico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(900, 580);
            this.Controls.Add(this.pnlG);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "FrmDiagnostico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Examen Diagnóstico";
            this.pnlG.ResumeLayout(false);
            this.splitter.Panel1.ResumeLayout(false);
            this.splitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitter)).EndInit();
            this.splitter.ResumeLayout(false);
            this.pnlForm.ResumeLayout(false);
            this.pnlForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPuntaje)).EndInit();
            this.pnlR.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiagnosticos)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Panel pnlG;
        private System.Windows.Forms.SplitContainer splitter;
        private System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.Label lblEstudiante;
        private System.Windows.Forms.ComboBox cmbEstudiante;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label lblPuntaje;
        private System.Windows.Forms.NumericUpDown nudPuntaje;
        private System.Windows.Forms.Label lblNivel;
        private System.Windows.Forms.TextBox txtNivel;
        private System.Windows.Forms.Label lblModulo;
        private System.Windows.Forms.ComboBox cmbModulo;
        private System.Windows.Forms.Label lblObservaciones;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Panel pnlR;
        private System.Windows.Forms.Label lblRegistrados;
        private System.Windows.Forms.DataGridView dgvDiagnosticos;
    }
}