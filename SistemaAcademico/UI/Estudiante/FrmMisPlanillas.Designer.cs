namespace SistemaAcademico.UI.Estudiante
{
    partial class FrmMisPlanillas
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
            this.cmbModulo = new System.Windows.Forms.ComboBox();
            this.lblModulo = new System.Windows.Forms.Label();
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
            this.pnlSel.Controls.Add(this.cmbModulo);
            this.pnlSel.Controls.Add(this.lblModulo);
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
            this.lblResumen.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblResumen.Location = new System.Drawing.Point(495, 18);
            this.lblResumen.Name = "lblResumen";
            this.lblResumen.Size = new System.Drawing.Size(0, 21);
            this.lblResumen.TabIndex = 3;
            // 
            // btnCargar
            // 
            this.btnCargar.Location = new System.Drawing.Point(345, 12);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(130, 27);
            this.btnCargar.TabIndex = 2;
            this.btnCargar.Text = "Ver Planilla";
            // 
            // cmbModulo
            // 
            this.cmbModulo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbModulo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbModulo.Location = new System.Drawing.Point(70, 14);
            this.cmbModulo.Name = "cmbModulo";
            this.cmbModulo.Size = new System.Drawing.Size(260, 29);
            this.cmbModulo.TabIndex = 1;
            // 
            // lblModulo
            // 
            this.lblModulo.AutoSize = true;
            this.lblModulo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblModulo.Location = new System.Drawing.Point(10, 18);
            this.lblModulo.Name = "lblModulo";
            this.lblModulo.Size = new System.Drawing.Size(67, 21);
            this.lblModulo.TabIndex = 0;
            this.lblModulo.Text = "Módulo:";
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
            this.split.SplitterDistance = 280;
            this.split.TabIndex = 0;
            // 
            // pnlT
            // 
            this.pnlT.Controls.Add(this.dgvTemas);
            this.pnlT.Controls.Add(this.lblTemas);
            this.pnlT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlT.Location = new System.Drawing.Point(0, 0);
            this.pnlT.Name = "pnlT";
            this.pnlT.Size = new System.Drawing.Size(940, 280);
            this.pnlT.TabIndex = 0;
            // 
            // dgvTemas
            // 
            this.dgvTemas.AllowUserToAddRows = false;
            this.dgvTemas.AllowUserToDeleteRows = false;
            this.dgvTemas.ColumnHeadersHeight = 29;
            this.dgvTemas.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvTemas.Location = new System.Drawing.Point(0, 87);
            this.dgvTemas.Name = "dgvTemas";
            this.dgvTemas.ReadOnly = true;
            this.dgvTemas.RowHeadersWidth = 51;
            this.dgvTemas.Size = new System.Drawing.Size(940, 193);
            this.dgvTemas.TabIndex = 1;
            // 
            // lblTemas
            // 
            this.lblTemas.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTemas.Location = new System.Drawing.Point(0, 56);
            this.lblTemas.Name = "lblTemas";
            this.lblTemas.Padding = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.lblTemas.Size = new System.Drawing.Size(940, 28);
            this.lblTemas.TabIndex = 0;
            this.lblTemas.Text = "📝 Notas por Tema (Speaking / Writing / Listening / Reading)";
            // 
            // pnlE
            // 
            this.pnlE.Controls.Add(this.dgvExamenes);
            this.pnlE.Controls.Add(this.lblExamenes);
            this.pnlE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlE.Location = new System.Drawing.Point(0, 0);
            this.pnlE.Name = "pnlE";
            this.pnlE.Size = new System.Drawing.Size(940, 261);
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
            this.dgvExamenes.Size = new System.Drawing.Size(940, 233);
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
            this.lblExamenes.Text = "📋 Exámenes de Módulo (Teórico / Oral)";
            // 
            // FrmMisPlanillas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(960, 620);
            this.Controls.Add(this.pnlG);
            this.Controls.Add(this.pnlSel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "FrmMisPlanillas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Mis Planillas de Evaluación";
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
        private System.Windows.Forms.Label lblModulo;
        private System.Windows.Forms.ComboBox cmbModulo;
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