namespace SistemaAcademico.UI.Docente
{
    partial class FrmVerPlanillaDocente
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
            this.lblResumen = new System.Windows.Forms.Label();
            this.btnCargar = new System.Windows.Forms.Button();
            this.cmbEstudiante = new System.Windows.Forms.ComboBox();
            this.lblEstudiante = new System.Windows.Forms.Label();
            this.pnlG = new System.Windows.Forms.Panel();
            this.split = new System.Windows.Forms.SplitContainer();
            this.pnlT = new System.Windows.Forms.Panel();
            this.dgvTemas = new System.Windows.Forms.DataGridView();
            this.lblTemas = new System.Windows.Forms.Label();
            this.pnlE = new System.Windows.Forms.Panel();
            this.dgvExamenes = new System.Windows.Forms.DataGridView();
            this.lblExamenes = new System.Windows.Forms.Label();
            this.pnlSel.SuspendLayout();
            this.pnlG.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.split)).BeginInit();
            this.split.Panel1.SuspendLayout();
            this.split.Panel2.SuspendLayout();
            this.split.SuspendLayout();
            this.pnlT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTemas)).BeginInit();
            this.pnlE.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExamenes)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSel
            // 
            this.pnlSel.BackColor = System.Drawing.Color.White;
            this.pnlSel.Controls.Add(this.lblResumen);
            this.pnlSel.Controls.Add(this.btnCargar);
            this.pnlSel.Controls.Add(this.cmbEstudiante);
            this.pnlSel.Controls.Add(this.lblEstudiante);
            this.pnlSel.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSel.Location = new System.Drawing.Point(0, 0);
            this.pnlSel.Name = "pnlSel";
            this.pnlSel.Padding = new System.Windows.Forms.Padding(10);
            this.pnlSel.Size = new System.Drawing.Size(960, 55);
            this.pnlSel.TabIndex = 0;
            // 
            // lblResumen
            // 
            this.lblResumen.AutoSize = true;
            this.lblResumen.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblResumen.Location = new System.Drawing.Point(545, 18);
            this.lblResumen.Name = "lblResumen";
            this.lblResumen.Size = new System.Drawing.Size(0, 20);
            this.lblResumen.TabIndex = 3;
            // 
            // btnCargar
            // 
            this.btnCargar.Location = new System.Drawing.Point(385, 12);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(145, 27);
            this.btnCargar.TabIndex = 2;
            this.btnCargar.Text = "Cargar Planilla";
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
            this.lblEstudiante.Location = new System.Drawing.Point(10, 18);
            this.lblEstudiante.Name = "lblEstudiante";
            this.lblEstudiante.Size = new System.Drawing.Size(81, 20);
            this.lblEstudiante.TabIndex = 0;
            this.lblEstudiante.Text = "Estudiante:";
            // 
            // pnlG
            // 
            this.pnlG.Controls.Add(this.split);
            this.pnlG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlG.Location = new System.Drawing.Point(0, 55);
            this.pnlG.Name = "pnlG";
            this.pnlG.Padding = new System.Windows.Forms.Padding(10);
            this.pnlG.Size = new System.Drawing.Size(960, 565);
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
            this.split.Panel1.Controls.Add(this.pnlT);
            // 
            // split.Panel2
            // 
            this.split.Panel2.Controls.Add(this.pnlE);
            this.split.Size = new System.Drawing.Size(940, 545);
            this.split.SplitterDistance = 350;
            this.split.TabIndex = 0;
            // 
            // pnlT
            // 
            this.pnlT.Controls.Add(this.dgvTemas);
            this.pnlT.Controls.Add(this.lblTemas);
            this.pnlT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlT.Location = new System.Drawing.Point(0, 0);
            this.pnlT.Name = "pnlT";
            this.pnlT.Size = new System.Drawing.Size(940, 350);
            this.pnlT.TabIndex = 0;
            // 
            // dgvTemas
            // 
            this.dgvTemas.AllowUserToAddRows = false;
            this.dgvTemas.AllowUserToDeleteRows = false;
            this.dgvTemas.ColumnHeadersHeight = 29;
            this.dgvTemas.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvTemas.Location = new System.Drawing.Point(0, 91);
            this.dgvTemas.Name = "dgvTemas";
            this.dgvTemas.ReadOnly = true;
            this.dgvTemas.RowHeadersWidth = 51;
            this.dgvTemas.Size = new System.Drawing.Size(940, 259);
            this.dgvTemas.TabIndex = 1;
            // 
            // lblTemas
            // 
            this.lblTemas.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTemas.Location = new System.Drawing.Point(-2, 54);
            this.lblTemas.Name = "lblTemas";
            this.lblTemas.Padding = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.lblTemas.Size = new System.Drawing.Size(940, 34);
            this.lblTemas.TabIndex = 0;
            this.lblTemas.Text = "📝 Notas por Tema";
            this.lblTemas.Click += new System.EventHandler(this.lblTemas_Click);
            // 
            // pnlE
            // 
            this.pnlE.Controls.Add(this.dgvExamenes);
            this.pnlE.Controls.Add(this.lblExamenes);
            this.pnlE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlE.Location = new System.Drawing.Point(0, 0);
            this.pnlE.Name = "pnlE";
            this.pnlE.Size = new System.Drawing.Size(940, 191);
            this.pnlE.TabIndex = 0;
            // 
            // dgvExamenes
            // 
            this.dgvExamenes.AllowUserToAddRows = false;
            this.dgvExamenes.AllowUserToDeleteRows = false;
            this.dgvExamenes.ColumnHeadersHeight = 29;
            this.dgvExamenes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvExamenes.Location = new System.Drawing.Point(0, 28);
            this.dgvExamenes.Name = "dgvExamenes";
            this.dgvExamenes.ReadOnly = true;
            this.dgvExamenes.RowHeadersWidth = 51;
            this.dgvExamenes.Size = new System.Drawing.Size(940, 163);
            this.dgvExamenes.TabIndex = 1;
            // 
            // lblExamenes
            // 
            this.lblExamenes.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblExamenes.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblExamenes.Location = new System.Drawing.Point(0, 0);
            this.lblExamenes.Name = "lblExamenes";
            this.lblExamenes.Padding = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.lblExamenes.Size = new System.Drawing.Size(940, 28);
            this.lblExamenes.TabIndex = 0;
            this.lblExamenes.Text = "📋 Exámenes de Módulo";
            // 
            // FrmVerPlanillaDocente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(960, 620);
            this.Controls.Add(this.pnlG);
            this.Controls.Add(this.pnlSel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "FrmVerPlanillaDocente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ver Planilla de Evaluación";
            this.pnlSel.ResumeLayout(false);
            this.pnlSel.PerformLayout();
            this.pnlG.ResumeLayout(false);
            this.split.Panel1.ResumeLayout(false);
            this.split.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.split)).EndInit();
            this.split.ResumeLayout(false);
            this.pnlT.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTemas)).EndInit();
            this.pnlE.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExamenes)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Panel pnlSel;
        private System.Windows.Forms.Label lblEstudiante;
        private System.Windows.Forms.ComboBox cmbEstudiante;
        private System.Windows.Forms.Button btnCargar;
        private System.Windows.Forms.Label lblResumen;
        private System.Windows.Forms.Panel pnlG;
        private System.Windows.Forms.SplitContainer split;
        private System.Windows.Forms.Panel pnlT;
        private System.Windows.Forms.DataGridView dgvTemas;
        private System.Windows.Forms.Label lblTemas;
        private System.Windows.Forms.Panel pnlE;
        private System.Windows.Forms.DataGridView dgvExamenes;
        private System.Windows.Forms.Label lblExamenes;
    }
}