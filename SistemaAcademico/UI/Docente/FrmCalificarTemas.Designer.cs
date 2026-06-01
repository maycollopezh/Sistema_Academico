namespace SistemaAcademico.UI.Docente
{
    partial class FrmCalificarTemas
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
            this.pnlSel = new System.Windows.Forms.Panel();
            this.btnRefrescar = new System.Windows.Forms.Button();
            this.lblInfoModulo = new System.Windows.Forms.Label();
            this.cmbEstudiante = new System.Windows.Forms.ComboBox();
            this.lblEstudiante = new System.Windows.Forms.Label();
            this.pnlNota = new System.Windows.Forms.Panel();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.nudReading = new System.Windows.Forms.NumericUpDown();
            this.lblReading = new System.Windows.Forms.Label();
            this.nudListening = new System.Windows.Forms.NumericUpDown();
            this.lblListening = new System.Windows.Forms.Label();
            this.nudWriting = new System.Windows.Forms.NumericUpDown();
            this.lblWriting = new System.Windows.Forms.Label();
            this.nudSpeaking = new System.Windows.Forms.NumericUpDown();
            this.lblSpeaking = new System.Windows.Forms.Label();
            this.nudTema = new System.Windows.Forms.NumericUpDown();
            this.lblTema = new System.Windows.Forms.Label();
            this.pnlG = new System.Windows.Forms.Panel();
            this.dgvNotas = new System.Windows.Forms.DataGridView();
            this.pnlSel.SuspendLayout();
            this.pnlNota.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudReading)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudListening)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWriting)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpeaking)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTema)).BeginInit();
            this.pnlG.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNotas)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSel
            // 
            this.pnlSel.BackColor = System.Drawing.Color.White;
            this.pnlSel.Controls.Add(this.btnRefrescar);
            this.pnlSel.Controls.Add(this.lblInfoModulo);
            this.pnlSel.Controls.Add(this.cmbEstudiante);
            this.pnlSel.Controls.Add(this.lblEstudiante);
            this.pnlSel.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSel.Location = new System.Drawing.Point(0, 0);
            this.pnlSel.Name = "pnlSel";
            this.pnlSel.Padding = new System.Windows.Forms.Padding(10);
            this.pnlSel.Size = new System.Drawing.Size(960, 55);
            this.pnlSel.TabIndex = 0;
            // 
            // btnRefrescar
            // 
            this.btnRefrescar.Location = new System.Drawing.Point(700, 12);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(45, 27);
            this.btnRefrescar.TabIndex = 3;
            this.btnRefrescar.Text = "🔄";
            // 
            // lblInfoModulo
            // 
            this.lblInfoModulo.AutoSize = true;
            this.lblInfoModulo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblInfoModulo.Location = new System.Drawing.Point(385, 18);
            this.lblInfoModulo.Name = "lblInfoModulo";
            this.lblInfoModulo.Size = new System.Drawing.Size(0, 21);
            this.lblInfoModulo.TabIndex = 2;
            // 
            // cmbEstudiante
            // 
            this.cmbEstudiante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstudiante.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbEstudiante.Location = new System.Drawing.Point(90, 14);
            this.cmbEstudiante.Name = "cmbEstudiante";
            this.cmbEstudiante.Size = new System.Drawing.Size(280, 29);
            this.cmbEstudiante.TabIndex = 1;
            // 
            // lblEstudiante
            // 
            this.lblEstudiante.AutoSize = true;
            this.lblEstudiante.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblEstudiante.Location = new System.Drawing.Point(10, 18);
            this.lblEstudiante.Name = "lblEstudiante";
            this.lblEstudiante.Size = new System.Drawing.Size(85, 21);
            this.lblEstudiante.TabIndex = 0;
            this.lblEstudiante.Text = "Estudiante:";
            // 
            // pnlNota
            // 
            this.pnlNota.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(255)))));
            this.pnlNota.Controls.Add(this.btnRegistrar);
            this.pnlNota.Controls.Add(this.nudReading);
            this.pnlNota.Controls.Add(this.lblReading);
            this.pnlNota.Controls.Add(this.nudListening);
            this.pnlNota.Controls.Add(this.lblListening);
            this.pnlNota.Controls.Add(this.nudWriting);
            this.pnlNota.Controls.Add(this.lblWriting);
            this.pnlNota.Controls.Add(this.nudSpeaking);
            this.pnlNota.Controls.Add(this.lblSpeaking);
            this.pnlNota.Controls.Add(this.nudTema);
            this.pnlNota.Controls.Add(this.lblTema);
            this.pnlNota.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlNota.Location = new System.Drawing.Point(0, 55);
            this.pnlNota.Name = "pnlNota";
            this.pnlNota.Padding = new System.Windows.Forms.Padding(10, 6, 10, 6);
            this.pnlNota.Size = new System.Drawing.Size(960, 68);
            this.pnlNota.TabIndex = 1;
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Location = new System.Drawing.Point(740, 15);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(130, 30);
            this.btnRegistrar.TabIndex = 10;
            this.btnRegistrar.Text = "Guardar Nota";
            // 
            // nudReading
            // 
            this.nudReading.DecimalPlaces = 2;
            this.nudReading.Location = new System.Drawing.Point(670, 18);
            this.nudReading.Name = "nudReading";
            this.nudReading.Size = new System.Drawing.Size(60, 27);
            this.nudReading.TabIndex = 9;
            // 
            // lblReading
            // 
            this.lblReading.AutoSize = true;
            this.lblReading.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblReading.Location = new System.Drawing.Point(600, 22);
            this.lblReading.Name = "lblReading";
            this.lblReading.Size = new System.Drawing.Size(70, 20);
            this.lblReading.TabIndex = 8;
            this.lblReading.Text = "Reading:";
            // 
            // nudListening
            // 
            this.nudListening.DecimalPlaces = 2;
            this.nudListening.Location = new System.Drawing.Point(510, 18);
            this.nudListening.Name = "nudListening";
            this.nudListening.Size = new System.Drawing.Size(60, 27);
            this.nudListening.TabIndex = 7;
            // 
            // lblListening
            // 
            this.lblListening.AutoSize = true;
            this.lblListening.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblListening.Location = new System.Drawing.Point(440, 22);
            this.lblListening.Name = "lblListening";
            this.lblListening.Size = new System.Drawing.Size(77, 20);
            this.lblListening.TabIndex = 6;
            this.lblListening.Text = "Listening:";
            // 
            // nudWriting
            // 
            this.nudWriting.DecimalPlaces = 2;
            this.nudWriting.Location = new System.Drawing.Point(365, 18);
            this.nudWriting.Name = "nudWriting";
            this.nudWriting.Size = new System.Drawing.Size(60, 27);
            this.nudWriting.TabIndex = 5;
            // 
            // lblWriting
            // 
            this.lblWriting.AutoSize = true;
            this.lblWriting.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblWriting.Location = new System.Drawing.Point(295, 22);
            this.lblWriting.Name = "lblWriting";
            this.lblWriting.Size = new System.Drawing.Size(66, 20);
            this.lblWriting.TabIndex = 4;
            this.lblWriting.Text = "Writing:";
            // 
            // nudSpeaking
            // 
            this.nudSpeaking.DecimalPlaces = 2;
            this.nudSpeaking.Location = new System.Drawing.Point(220, 18);
            this.nudSpeaking.Name = "nudSpeaking";
            this.nudSpeaking.Size = new System.Drawing.Size(60, 27);
            this.nudSpeaking.TabIndex = 3;
            // 
            // lblSpeaking
            // 
            this.lblSpeaking.AutoSize = true;
            this.lblSpeaking.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblSpeaking.Location = new System.Drawing.Point(150, 22);
            this.lblSpeaking.Name = "lblSpeaking";
            this.lblSpeaking.Size = new System.Drawing.Size(76, 20);
            this.lblSpeaking.TabIndex = 2;
            this.lblSpeaking.Text = "Speaking:";
            // 
            // nudTema
            // 
            this.nudTema.Location = new System.Drawing.Point(78, 18);
            this.nudTema.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.nudTema.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudTema.Name = "nudTema";
            this.nudTema.Size = new System.Drawing.Size(55, 27);
            this.nudTema.TabIndex = 1;
            this.nudTema.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblTema
            // 
            this.lblTema.AutoSize = true;
            this.lblTema.Location = new System.Drawing.Point(10, 22);
            this.lblTema.Name = "lblTema";
            this.lblTema.Size = new System.Drawing.Size(69, 20);
            this.lblTema.TabIndex = 0;
            this.lblTema.Text = "Tema N°:";
            // 
            // pnlG
            // 
            this.pnlG.Controls.Add(this.dgvNotas);
            this.pnlG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlG.Location = new System.Drawing.Point(0, 123);
            this.pnlG.Name = "pnlG";
            this.pnlG.Padding = new System.Windows.Forms.Padding(10);
            this.pnlG.Size = new System.Drawing.Size(960, 497);
            this.pnlG.TabIndex = 2;
            // 
            // dgvNotas
            // 
            this.dgvNotas.AllowUserToAddRows = false;
            this.dgvNotas.AllowUserToDeleteRows = false;
            this.dgvNotas.ColumnHeadersHeight = 29;
            this.dgvNotas.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvNotas.Location = new System.Drawing.Point(10, 83);
            this.dgvNotas.Name = "dgvNotas";
            this.dgvNotas.ReadOnly = true;
            this.dgvNotas.RowHeadersWidth = 51;
            this.dgvNotas.Size = new System.Drawing.Size(940, 404);
            this.dgvNotas.TabIndex = 0;
            // 
            // FrmCalificarTemas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(960, 620);
            this.Controls.Add(this.pnlG);
            this.Controls.Add(this.pnlNota);
            this.Controls.Add(this.pnlSel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "FrmCalificarTemas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Calificar Temas";
            this.pnlSel.ResumeLayout(false);
            this.pnlSel.PerformLayout();
            this.pnlNota.ResumeLayout(false);
            this.pnlNota.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudReading)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudListening)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWriting)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpeaking)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTema)).EndInit();
            this.pnlG.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNotas)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Panel pnlSel;
        private System.Windows.Forms.Label lblEstudiante;
        private System.Windows.Forms.ComboBox cmbEstudiante;
        private System.Windows.Forms.Label lblInfoModulo;
        private System.Windows.Forms.Button btnRefrescar;
        private System.Windows.Forms.Panel pnlNota;
        private System.Windows.Forms.Label lblTema;
        private System.Windows.Forms.NumericUpDown nudTema;
        private System.Windows.Forms.Label lblSpeaking;
        private System.Windows.Forms.NumericUpDown nudSpeaking;
        private System.Windows.Forms.Label lblWriting;
        private System.Windows.Forms.NumericUpDown nudWriting;
        private System.Windows.Forms.Label lblListening;
        private System.Windows.Forms.NumericUpDown nudListening;
        private System.Windows.Forms.Label lblReading;
        private System.Windows.Forms.NumericUpDown nudReading;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Panel pnlG;
        private System.Windows.Forms.DataGridView dgvNotas;
        private int _idPlanilla;
    }
}