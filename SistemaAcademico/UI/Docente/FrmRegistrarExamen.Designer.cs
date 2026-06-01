namespace SistemaAcademico.UI.Docente
{
    partial class FrmRegistrarExamen
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
            this.pnlForm = new System.Windows.Forms.Panel();
            this.lblResultado = new System.Windows.Forms.Label();
            this.btnVerificarAprobacion = new System.Windows.Forms.Button();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.nudNota = new System.Windows.Forms.NumericUpDown();
            this.lblNota = new System.Windows.Forms.Label();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.cmbEstudiante = new System.Windows.Forms.ComboBox();
            this.lblEstudiante = new System.Windows.Forms.Label();
            this.pnlForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNota)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlForm
            // 
            this.pnlForm.AutoScroll = true;
            this.pnlForm.Controls.Add(this.lblResultado);
            this.pnlForm.Controls.Add(this.btnVerificarAprobacion);
            this.pnlForm.Controls.Add(this.btnRegistrar);
            this.pnlForm.Controls.Add(this.nudNota);
            this.pnlForm.Controls.Add(this.lblNota);
            this.pnlForm.Controls.Add(this.cmbTipo);
            this.pnlForm.Controls.Add(this.lblTipo);
            this.pnlForm.Controls.Add(this.cmbEstudiante);
            this.pnlForm.Controls.Add(this.lblEstudiante);
            this.pnlForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlForm.Location = new System.Drawing.Point(0, 0);
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.Padding = new System.Windows.Forms.Padding(20, 15, 20, 10);
            this.pnlForm.Size = new System.Drawing.Size(520, 420);
            this.pnlForm.TabIndex = 0;
            // 
            // lblResultado
            // 
            this.lblResultado.AutoSize = true;
            this.lblResultado.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblResultado.Location = new System.Drawing.Point(23, 297);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(0, 21);
            this.lblResultado.TabIndex = 8;
            // 
            // btnVerificarAprobacion
            // 
            this.btnVerificarAprobacion.Location = new System.Drawing.Point(218, 247);
            this.btnVerificarAprobacion.Name = "btnVerificarAprobacion";
            this.btnVerificarAprobacion.Size = new System.Drawing.Size(185, 32);
            this.btnVerificarAprobacion.TabIndex = 7;
            this.btnVerificarAprobacion.Text = "Verificar Aprobación";
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Location = new System.Drawing.Point(23, 247);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(180, 32);
            this.btnRegistrar.TabIndex = 6;
            this.btnRegistrar.Text = "Registrar Examen";
            // 
            // nudNota
            // 
            this.nudNota.DecimalPlaces = 2;
            this.nudNota.Location = new System.Drawing.Point(23, 209);
            this.nudNota.Name = "nudNota";
            this.nudNota.Size = new System.Drawing.Size(440, 27);
            this.nudNota.TabIndex = 5;
            // 
            // lblNota
            // 
            this.lblNota.AutoSize = true;
            this.lblNota.Location = new System.Drawing.Point(23, 191);
            this.lblNota.Name = "lblNota";
            this.lblNota.Size = new System.Drawing.Size(104, 20);
            this.lblNota.TabIndex = 4;
            this.lblNota.Text = "Nota (0-100) *";
            // 
            // cmbTipo
            // 
            this.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipo.Items.AddRange(new object[] {
            "Teorico",
            "Oral"});
            this.cmbTipo.Location = new System.Drawing.Point(23, 157);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(440, 28);
            this.cmbTipo.TabIndex = 3;
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(23, 139);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(126, 20);
            this.lblTipo.TabIndex = 2;
            this.lblTipo.Text = "Tipo de Examen *";
            // 
            // cmbEstudiante
            // 
            this.cmbEstudiante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstudiante.Location = new System.Drawing.Point(23, 105);
            this.cmbEstudiante.Name = "cmbEstudiante";
            this.cmbEstudiante.Size = new System.Drawing.Size(440, 28);
            this.cmbEstudiante.TabIndex = 1;
            // 
            // lblEstudiante
            // 
            this.lblEstudiante.AutoSize = true;
            this.lblEstudiante.Location = new System.Drawing.Point(23, 87);
            this.lblEstudiante.Name = "lblEstudiante";
            this.lblEstudiante.Size = new System.Drawing.Size(88, 20);
            this.lblEstudiante.TabIndex = 0;
            this.lblEstudiante.Text = "Estudiante *";
            // 
            // FrmRegistrarExamen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(520, 420);
            this.Controls.Add(this.pnlForm);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmRegistrarExamen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Registrar Examen de Módulo";
            this.pnlForm.ResumeLayout(false);
            this.pnlForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNota)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.Label lblEstudiante;
        private System.Windows.Forms.ComboBox cmbEstudiante;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.Label lblNota;
        private System.Windows.Forms.NumericUpDown nudNota;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Button btnVerificarAprobacion;
        private System.Windows.Forms.Label lblResultado;
    }
}