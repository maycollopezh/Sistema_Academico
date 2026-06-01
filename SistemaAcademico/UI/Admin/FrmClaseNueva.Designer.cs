namespace SistemaAcademico.UI.Admin
{
    partial class FrmClaseNueva
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
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.pnlForm = new System.Windows.Forms.Panel();
            this.txtAula = new System.Windows.Forms.TextBox();
            this.lblAula = new System.Windows.Forms.Label();
            this.txtLinkZoom = new System.Windows.Forms.TextBox();
            this.lblLinkZoom = new System.Windows.Forms.Label();
            this.cmbDocente = new System.Windows.Forms.ComboBox();
            this.lblDocente = new System.Windows.Forms.Label();
            this.cmbModalidad = new System.Windows.Forms.ComboBox();
            this.lblModalidad = new System.Windows.Forms.Label();
            this.cmbHora = new System.Windows.Forms.ComboBox();
            this.lblHora = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblFecha = new System.Windows.Forms.Label();
            this.pnlBotones.SuspendLayout();
            this.pnlForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBotones
            // 
            this.pnlBotones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.pnlBotones.Controls.Add(this.btnGuardar);
            this.pnlBotones.Controls.Add(this.btnCancelar);
            this.pnlBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotones.Location = new System.Drawing.Point(0, 448);
            this.pnlBotones.Name = "pnlBotones";
            this.pnlBotones.Size = new System.Drawing.Size(460, 52);
            this.pnlBotones.TabIndex = 1;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(10, 8);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(120, 36);
            this.btnGuardar.TabIndex = 0;
            this.btnGuardar.Text = "Crear Clase";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(138, 8);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(110, 36);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            // 
            // pnlForm
            // 
            this.pnlForm.AutoScroll = true;
            this.pnlForm.Controls.Add(this.txtAula);
            this.pnlForm.Controls.Add(this.lblAula);
            this.pnlForm.Controls.Add(this.txtLinkZoom);
            this.pnlForm.Controls.Add(this.lblLinkZoom);
            this.pnlForm.Controls.Add(this.cmbDocente);
            this.pnlForm.Controls.Add(this.lblDocente);
            this.pnlForm.Controls.Add(this.cmbModalidad);
            this.pnlForm.Controls.Add(this.lblModalidad);
            this.pnlForm.Controls.Add(this.cmbHora);
            this.pnlForm.Controls.Add(this.lblHora);
            this.pnlForm.Controls.Add(this.dtpFecha);
            this.pnlForm.Controls.Add(this.lblFecha);
            this.pnlForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlForm.Location = new System.Drawing.Point(0, 0);
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.pnlForm.Size = new System.Drawing.Size(460, 448);
            this.pnlForm.TabIndex = 0;
            // 
            // txtAula
            // 
            this.txtAula.Enabled = false;
            this.txtAula.Location = new System.Drawing.Point(23, 377);
            this.txtAula.Name = "txtAula";
            this.txtAula.Size = new System.Drawing.Size(400, 27);
            this.txtAula.TabIndex = 11;
            // 
            // lblAula
            // 
            this.lblAula.AutoSize = true;
            this.lblAula.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblAula.Location = new System.Drawing.Point(23, 359);
            this.lblAula.Name = "lblAula";
            this.lblAula.Size = new System.Drawing.Size(142, 20);
            this.lblAula.TabIndex = 10;
            this.lblAula.Text = "Aula (si Presencial)";
            // 
            // txtLinkZoom
            // 
            this.txtLinkZoom.Location = new System.Drawing.Point(23, 325);
            this.txtLinkZoom.Name = "txtLinkZoom";
            this.txtLinkZoom.Size = new System.Drawing.Size(400, 27);
            this.txtLinkZoom.TabIndex = 9;
            // 
            // lblLinkZoom
            // 
            this.lblLinkZoom.AutoSize = true;
            this.lblLinkZoom.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblLinkZoom.Location = new System.Drawing.Point(23, 307);
            this.lblLinkZoom.Name = "lblLinkZoom";
            this.lblLinkZoom.Size = new System.Drawing.Size(161, 20);
            this.lblLinkZoom.TabIndex = 8;
            this.lblLinkZoom.Text = "Link Zoom (si Virtual)";
            // 
            // cmbDocente
            // 
            this.cmbDocente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDocente.Location = new System.Drawing.Point(23, 273);
            this.cmbDocente.Name = "cmbDocente";
            this.cmbDocente.Size = new System.Drawing.Size(400, 28);
            this.cmbDocente.TabIndex = 7;
            // 
            // lblDocente
            // 
            this.lblDocente.AutoSize = true;
            this.lblDocente.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblDocente.Location = new System.Drawing.Point(23, 255);
            this.lblDocente.Name = "lblDocente";
            this.lblDocente.Size = new System.Drawing.Size(78, 20);
            this.lblDocente.TabIndex = 6;
            this.lblDocente.Text = "Docente *";
            // 
            // cmbModalidad
            // 
            this.cmbModalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbModalidad.Items.AddRange(new object[] {
            "Virtual",
            "Presencial"});
            this.cmbModalidad.Location = new System.Drawing.Point(23, 221);
            this.cmbModalidad.Name = "cmbModalidad";
            this.cmbModalidad.Size = new System.Drawing.Size(400, 28);
            this.cmbModalidad.TabIndex = 5;
            // 
            // lblModalidad
            // 
            this.lblModalidad.AutoSize = true;
            this.lblModalidad.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblModalidad.Location = new System.Drawing.Point(23, 203);
            this.lblModalidad.Name = "lblModalidad";
            this.lblModalidad.Size = new System.Drawing.Size(94, 20);
            this.lblModalidad.TabIndex = 4;
            this.lblModalidad.Text = "Modalidad *";
            // 
            // cmbHora
            // 
            this.cmbHora.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHora.Location = new System.Drawing.Point(23, 169);
            this.cmbHora.Name = "cmbHora";
            this.cmbHora.Size = new System.Drawing.Size(400, 28);
            this.cmbHora.TabIndex = 3;
            // 
            // lblHora
            // 
            this.lblHora.AutoSize = true;
            this.lblHora.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblHora.Location = new System.Drawing.Point(23, 151);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(117, 20);
            this.lblHora.TabIndex = 2;
            this.lblHora.Text = "Hora de Inicio *";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(23, 117);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(400, 27);
            this.dtpFecha.TabIndex = 1;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblFecha.Location = new System.Drawing.Point(23, 99);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(60, 20);
            this.lblFecha.TabIndex = 0;
            this.lblFecha.Text = "Fecha *";
            // 
            // FrmClaseNueva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(460, 500);
            this.Controls.Add(this.pnlForm);
            this.Controls.Add(this.pnlBotones);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmClaseNueva";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nueva Clase";
            this.pnlBotones.ResumeLayout(false);
            this.pnlForm.ResumeLayout(false);
            this.pnlForm.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Panel pnlBotones;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.ComboBox cmbHora;
        private System.Windows.Forms.Label lblModalidad;
        private System.Windows.Forms.ComboBox cmbModalidad;
        private System.Windows.Forms.Label lblDocente;
        private System.Windows.Forms.ComboBox cmbDocente;
        private System.Windows.Forms.Label lblLinkZoom;
        private System.Windows.Forms.TextBox txtLinkZoom;
        private System.Windows.Forms.Label lblAula;
        private System.Windows.Forms.TextBox txtAula;
    }
}