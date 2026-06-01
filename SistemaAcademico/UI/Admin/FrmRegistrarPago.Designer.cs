namespace SistemaAcademico.UI.Admin
{
    partial class FrmRegistrarPago
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
            this.dtpVencimiento = new System.Windows.Forms.DateTimePicker();
            this.lblVencimiento = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblFecha = new System.Windows.Forms.Label();
            this.nudMonto = new System.Windows.Forms.NumericUpDown();
            this.lblMonto = new System.Windows.Forms.Label();
            this.nudNumeroCuota = new System.Windows.Forms.NumericUpDown();
            this.lblNumeroCuota = new System.Windows.Forms.Label();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.pnlBotones.SuspendLayout();
            this.pnlForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumeroCuota)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBotones
            // 
            this.pnlBotones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.pnlBotones.Controls.Add(this.btnGuardar);
            this.pnlBotones.Controls.Add(this.btnCancelar);
            this.pnlBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotones.Location = new System.Drawing.Point(0, 368);
            this.pnlBotones.Name = "pnlBotones";
            this.pnlBotones.Size = new System.Drawing.Size(420, 52);
            this.pnlBotones.TabIndex = 1;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(10, 8);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(120, 36);
            this.btnGuardar.TabIndex = 0;
            this.btnGuardar.Text = "Registrar";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(140, 8);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(120, 36);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            // 
            // pnlForm
            // 
            this.pnlForm.AutoScroll = true;
            this.pnlForm.Controls.Add(this.dtpVencimiento);
            this.pnlForm.Controls.Add(this.lblVencimiento);
            this.pnlForm.Controls.Add(this.dtpFecha);
            this.pnlForm.Controls.Add(this.lblFecha);
            this.pnlForm.Controls.Add(this.nudMonto);
            this.pnlForm.Controls.Add(this.lblMonto);
            this.pnlForm.Controls.Add(this.nudNumeroCuota);
            this.pnlForm.Controls.Add(this.lblNumeroCuota);
            this.pnlForm.Controls.Add(this.cmbTipo);
            this.pnlForm.Controls.Add(this.lblTipo);
            this.pnlForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlForm.Location = new System.Drawing.Point(0, 0);
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.Padding = new System.Windows.Forms.Padding(20, 15, 20, 10);
            this.pnlForm.Size = new System.Drawing.Size(420, 368);
            this.pnlForm.TabIndex = 0;
            // 
            // dtpVencimiento
            // 
            this.dtpVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpVencimiento.Location = new System.Drawing.Point(12, 313);
            this.dtpVencimiento.Name = "dtpVencimiento";
            this.dtpVencimiento.Size = new System.Drawing.Size(360, 27);
            this.dtpVencimiento.TabIndex = 9;
            // 
            // lblVencimiento
            // 
            this.lblVencimiento.AutoSize = true;
            this.lblVencimiento.Location = new System.Drawing.Point(12, 295);
            this.lblVencimiento.Name = "lblVencimiento";
            this.lblVencimiento.Size = new System.Drawing.Size(200, 20);
            this.lblVencimiento.TabIndex = 8;
            this.lblVencimiento.Text = "Nueva Fecha de Vencimiento";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(12, 261);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(360, 27);
            this.dtpFecha.TabIndex = 7;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(12, 243);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(115, 20);
            this.lblFecha.TabIndex = 6;
            this.lblFecha.Text = "Fecha de Pago *";
            // 
            // nudMonto
            // 
            this.nudMonto.DecimalPlaces = 2;
            this.nudMonto.Location = new System.Drawing.Point(12, 209);
            this.nudMonto.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudMonto.Name = "nudMonto";
            this.nudMonto.Size = new System.Drawing.Size(360, 27);
            this.nudMonto.TabIndex = 5;
            this.nudMonto.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            // 
            // lblMonto
            // 
            this.lblMonto.AutoSize = true;
            this.lblMonto.Location = new System.Drawing.Point(12, 191);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(95, 20);
            this.lblMonto.TabIndex = 4;
            this.lblMonto.Text = "Monto (Bs.) *";
            // 
            // nudNumeroCuota
            // 
            this.nudNumeroCuota.Location = new System.Drawing.Point(12, 157);
            this.nudNumeroCuota.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.nudNumeroCuota.Name = "nudNumeroCuota";
            this.nudNumeroCuota.Size = new System.Drawing.Size(360, 27);
            this.nudNumeroCuota.TabIndex = 3;
            this.nudNumeroCuota.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblNumeroCuota
            // 
            this.lblNumeroCuota.AutoSize = true;
            this.lblNumeroCuota.Location = new System.Drawing.Point(12, 139);
            this.lblNumeroCuota.Name = "lblNumeroCuota";
            this.lblNumeroCuota.Size = new System.Drawing.Size(224, 20);
            this.lblNumeroCuota.TabIndex = 2;
            this.lblNumeroCuota.Text = "Número de Cuota (0 = Contado)";
            // 
            // cmbTipo
            // 
            this.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipo.Items.AddRange(new object[] {
            "Cuota",
            "Contado"});
            this.cmbTipo.Location = new System.Drawing.Point(12, 105);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(360, 28);
            this.cmbTipo.TabIndex = 1;
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(12, 87);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(107, 20);
            this.lblTipo.TabIndex = 0;
            this.lblTipo.Text = "Tipo de Pago *";
            // 
            // FrmRegistrarPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(420, 420);
            this.Controls.Add(this.pnlForm);
            this.Controls.Add(this.pnlBotones);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmRegistrarPago";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Registrar Pago";
            this.pnlBotones.ResumeLayout(false);
            this.pnlForm.ResumeLayout(false);
            this.pnlForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumeroCuota)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Panel pnlBotones;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.Label lblNumeroCuota;
        private System.Windows.Forms.NumericUpDown nudNumeroCuota;
        private System.Windows.Forms.Label lblMonto;
        private System.Windows.Forms.NumericUpDown nudMonto;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label lblVencimiento;
        private System.Windows.Forms.DateTimePicker dtpVencimiento;
        private int _idInscripcion;
    }
}