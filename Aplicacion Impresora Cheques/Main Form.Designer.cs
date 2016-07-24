namespace Aplicacion_Impresora_Cheques
{
    partial class Main_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main_Form));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxDiasProximoVencimiento = new System.Windows.Forms.TextBox();
            this.textBoxNumeroDeCheques = new System.Windows.Forms.TextBox();
            this.dateTimePickerFechaVencimiento = new System.Windows.Forms.DateTimePicker();
            this.textBoxPagueseNombre = new System.Windows.Forms.TextBox();
            this.textBoxMontoCheque = new System.Windows.Forms.TextBox();
            this.labelDiasProximos = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxSucursal = new System.Windows.Forms.TextBox();
            this.textBoxNumBoleta = new System.Windows.Forms.TextBox();
            this.textBoxTelefono = new System.Windows.Forms.TextBox();
            this.textBoxNumeroSerie = new System.Windows.Forms.TextBox();
            this.textBoxRut = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonGenerarCheques = new System.Windows.Forms.Button();
            this.buttonLimpiar = new System.Windows.Forms.Button();
            this.dataGridViewCheques = new System.Windows.Forms.DataGridView();
            this.numeroCheque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaVencimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigoAutorizacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pagueseNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numSerie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numBoleta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sucursal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonImprimir = new System.Windows.Forms.Button();
            this.buttonVolver = new System.Windows.Forms.Button();
            this.comboBoxFormatoCheque = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.buttonTest = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCheques)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxDiasProximoVencimiento);
            this.groupBox1.Controls.Add(this.textBoxNumeroDeCheques);
            this.groupBox1.Controls.Add(this.dateTimePickerFechaVencimiento);
            this.groupBox1.Controls.Add(this.textBoxPagueseNombre);
            this.groupBox1.Controls.Add(this.textBoxMontoCheque);
            this.groupBox1.Controls.Add(this.labelDiasProximos);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(24, 53);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(410, 250);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " Datos de Cheque";
            // 
            // textBoxDiasProximoVencimiento
            // 
            this.textBoxDiasProximoVencimiento.Location = new System.Drawing.Point(175, 207);
            this.textBoxDiasProximoVencimiento.Name = "textBoxDiasProximoVencimiento";
            this.textBoxDiasProximoVencimiento.Size = new System.Drawing.Size(174, 20);
            this.textBoxDiasProximoVencimiento.TabIndex = 9;
            this.textBoxDiasProximoVencimiento.Visible = false;
            this.textBoxDiasProximoVencimiento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxDiasProximoVencimiento_KeyPress);
            // 
            // textBoxNumeroDeCheques
            // 
            this.textBoxNumeroDeCheques.Location = new System.Drawing.Point(175, 167);
            this.textBoxNumeroDeCheques.Name = "textBoxNumeroDeCheques";
            this.textBoxNumeroDeCheques.Size = new System.Drawing.Size(174, 20);
            this.textBoxNumeroDeCheques.TabIndex = 8;
            this.textBoxNumeroDeCheques.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxNumeroDeCheques_KeyPress);
            this.textBoxNumeroDeCheques.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxNumeroDeCheques_KeyUp);
            // 
            // dateTimePickerFechaVencimiento
            // 
            this.dateTimePickerFechaVencimiento.Location = new System.Drawing.Point(175, 120);
            this.dateTimePickerFechaVencimiento.Name = "dateTimePickerFechaVencimiento";
            this.dateTimePickerFechaVencimiento.Size = new System.Drawing.Size(174, 20);
            this.dateTimePickerFechaVencimiento.TabIndex = 7;
            // 
            // textBoxPagueseNombre
            // 
            this.textBoxPagueseNombre.Location = new System.Drawing.Point(175, 75);
            this.textBoxPagueseNombre.Name = "textBoxPagueseNombre";
            this.textBoxPagueseNombre.Size = new System.Drawing.Size(174, 20);
            this.textBoxPagueseNombre.TabIndex = 6;
            // 
            // textBoxMontoCheque
            // 
            this.textBoxMontoCheque.Location = new System.Drawing.Point(175, 34);
            this.textBoxMontoCheque.Name = "textBoxMontoCheque";
            this.textBoxMontoCheque.Size = new System.Drawing.Size(174, 20);
            this.textBoxMontoCheque.TabIndex = 5;
            this.textBoxMontoCheque.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxMontoCheque_KeyPress);
            // 
            // labelDiasProximos
            // 
            this.labelDiasProximos.AutoSize = true;
            this.labelDiasProximos.Location = new System.Drawing.Point(22, 210);
            this.labelDiasProximos.Name = "labelDiasProximos";
            this.labelDiasProximos.Size = new System.Drawing.Size(129, 13);
            this.labelDiasProximos.TabIndex = 4;
            this.labelDiasProximos.Text = "Dias Proximo Vencimiento";
            this.labelDiasProximos.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Numero de Cheques";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Fecha de Vencimiento";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Paguese a Nombre de";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Monto del Cheque";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxSucursal);
            this.groupBox2.Controls.Add(this.textBoxNumBoleta);
            this.groupBox2.Controls.Add(this.textBoxTelefono);
            this.groupBox2.Controls.Add(this.textBoxNumeroSerie);
            this.groupBox2.Controls.Add(this.textBoxRut);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(485, 53);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(394, 250);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos del Endoso";
            // 
            // textBoxSucursal
            // 
            this.textBoxSucursal.Location = new System.Drawing.Point(166, 207);
            this.textBoxSucursal.Name = "textBoxSucursal";
            this.textBoxSucursal.Size = new System.Drawing.Size(177, 20);
            this.textBoxSucursal.TabIndex = 10;
            // 
            // textBoxNumBoleta
            // 
            this.textBoxNumBoleta.Location = new System.Drawing.Point(166, 167);
            this.textBoxNumBoleta.Name = "textBoxNumBoleta";
            this.textBoxNumBoleta.Size = new System.Drawing.Size(177, 20);
            this.textBoxNumBoleta.TabIndex = 9;
            // 
            // textBoxTelefono
            // 
            this.textBoxTelefono.Location = new System.Drawing.Point(166, 120);
            this.textBoxTelefono.Name = "textBoxTelefono";
            this.textBoxTelefono.Size = new System.Drawing.Size(177, 20);
            this.textBoxTelefono.TabIndex = 8;
            // 
            // textBoxNumeroSerie
            // 
            this.textBoxNumeroSerie.Location = new System.Drawing.Point(166, 75);
            this.textBoxNumeroSerie.Name = "textBoxNumeroSerie";
            this.textBoxNumeroSerie.Size = new System.Drawing.Size(177, 20);
            this.textBoxNumeroSerie.TabIndex = 7;
            // 
            // textBoxRut
            // 
            this.textBoxRut.Location = new System.Drawing.Point(166, 38);
            this.textBoxRut.Name = "textBoxRut";
            this.textBoxRut.Size = new System.Drawing.Size(177, 20);
            this.textBoxRut.TabIndex = 6;
            this.textBoxRut.Leave += new System.EventHandler(this.textBoxRut_Leave);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(50, 207);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 13);
            this.label10.TabIndex = 5;
            this.label10.Text = "Sucursal";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(50, 170);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "N° Boleta/Factura";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(50, 128);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Telefono";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(50, 83);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "N° Serie C.I";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(50, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "RUT";
            // 
            // buttonGenerarCheques
            // 
            this.buttonGenerarCheques.Location = new System.Drawing.Point(557, 336);
            this.buttonGenerarCheques.Name = "buttonGenerarCheques";
            this.buttonGenerarCheques.Size = new System.Drawing.Size(122, 23);
            this.buttonGenerarCheques.TabIndex = 3;
            this.buttonGenerarCheques.Text = "Generar Cheques";
            this.buttonGenerarCheques.UseVisualStyleBackColor = true;
            this.buttonGenerarCheques.Click += new System.EventHandler(this.buttonGenerarCheques_Click);
            // 
            // buttonLimpiar
            // 
            this.buttonLimpiar.Location = new System.Drawing.Point(761, 336);
            this.buttonLimpiar.Name = "buttonLimpiar";
            this.buttonLimpiar.Size = new System.Drawing.Size(118, 23);
            this.buttonLimpiar.TabIndex = 4;
            this.buttonLimpiar.Text = "Limpiar";
            this.buttonLimpiar.UseVisualStyleBackColor = true;
            this.buttonLimpiar.Click += new System.EventHandler(this.buttonLimpiar_Click);
            // 
            // dataGridViewCheques
            // 
            this.dataGridViewCheques.AllowUserToAddRows = false;
            this.dataGridViewCheques.AllowUserToDeleteRows = false;
            this.dataGridViewCheques.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCheques.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numeroCheque,
            this.monto,
            this.fechaVencimiento,
            this.codigoAutorizacion,
            this.pagueseNombre,
            this.Rut,
            this.numSerie,
            this.numBoleta,
            this.sucursal,
            this.Telefono});
            this.dataGridViewCheques.Location = new System.Drawing.Point(24, 375);
            this.dataGridViewCheques.Name = "dataGridViewCheques";
            this.dataGridViewCheques.Size = new System.Drawing.Size(855, 150);
            this.dataGridViewCheques.TabIndex = 5;
            this.dataGridViewCheques.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCheques_CellValueChanged);
            // 
            // numeroCheque
            // 
            this.numeroCheque.HeaderText = "NumeroCheque";
            this.numeroCheque.Name = "numeroCheque";
            this.numeroCheque.ReadOnly = true;
            // 
            // monto
            // 
            this.monto.HeaderText = "Monto";
            this.monto.Name = "monto";
            // 
            // fechaVencimiento
            // 
            this.fechaVencimiento.HeaderText = "Fecha de Vencimiento";
            this.fechaVencimiento.Name = "fechaVencimiento";
            this.fechaVencimiento.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // codigoAutorizacion
            // 
            this.codigoAutorizacion.HeaderText = "Codigo de Autorizacion";
            this.codigoAutorizacion.Name = "codigoAutorizacion";
            // 
            // pagueseNombre
            // 
            this.pagueseNombre.HeaderText = "Paguese a Nombre de";
            this.pagueseNombre.Name = "pagueseNombre";
            this.pagueseNombre.Width = 200;
            // 
            // Rut
            // 
            this.Rut.HeaderText = "Rut";
            this.Rut.Name = "Rut";
            // 
            // numSerie
            // 
            this.numSerie.HeaderText = "N° Serie CI";
            this.numSerie.Name = "numSerie";
            // 
            // numBoleta
            // 
            this.numBoleta.HeaderText = "Numero de Boleta";
            this.numBoleta.Name = "numBoleta";
            // 
            // sucursal
            // 
            this.sucursal.HeaderText = "Sucursal";
            this.sucursal.Name = "sucursal";
            // 
            // Telefono
            // 
            this.Telefono.HeaderText = "Telefono";
            this.Telefono.Name = "Telefono";
            // 
            // buttonImprimir
            // 
            this.buttonImprimir.Enabled = false;
            this.buttonImprimir.Image = ((System.Drawing.Image)(resources.GetObject("buttonImprimir.Image")));
            this.buttonImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonImprimir.Location = new System.Drawing.Point(552, 554);
            this.buttonImprimir.Name = "buttonImprimir";
            this.buttonImprimir.Size = new System.Drawing.Size(148, 44);
            this.buttonImprimir.TabIndex = 6;
            this.buttonImprimir.Text = "Imprimir";
            this.buttonImprimir.UseVisualStyleBackColor = true;
            this.buttonImprimir.Click += new System.EventHandler(this.buttonImprimir_Click);
            // 
            // buttonVolver
            // 
            this.buttonVolver.Enabled = false;
            this.buttonVolver.Location = new System.Drawing.Point(761, 554);
            this.buttonVolver.Name = "buttonVolver";
            this.buttonVolver.Size = new System.Drawing.Size(118, 44);
            this.buttonVolver.TabIndex = 7;
            this.buttonVolver.Text = "Volver";
            this.buttonVolver.UseVisualStyleBackColor = true;
            this.buttonVolver.Click += new System.EventHandler(this.buttonVolver_Click);
            // 
            // comboBoxFormatoCheque
            // 
            this.comboBoxFormatoCheque.FormattingEnabled = true;
            this.comboBoxFormatoCheque.Items.AddRange(new object[] {
            "ANTIGUO",
            "NUEVO"});
            this.comboBoxFormatoCheque.Location = new System.Drawing.Point(199, 553);
            this.comboBoxFormatoCheque.Name = "comboBoxFormatoCheque";
            this.comboBoxFormatoCheque.Size = new System.Drawing.Size(174, 21);
            this.comboBoxFormatoCheque.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(20, 554);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(143, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Formato Cheque";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(343, 11);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(222, 24);
            this.label11.TabIndex = 10;
            this.label11.Text = "Impresion de Cheques";
            // 
            // buttonTest
            // 
            this.buttonTest.Location = new System.Drawing.Point(718, 11);
            this.buttonTest.Name = "buttonTest";
            this.buttonTest.Size = new System.Drawing.Size(110, 23);
            this.buttonTest.TabIndex = 11;
            this.buttonTest.Text = "Abrir Test";
            this.buttonTest.UseVisualStyleBackColor = true;
            this.buttonTest.Visible = false;
            this.buttonTest.Click += new System.EventHandler(this.buttonTest_Click);
            // 
            // Main_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 621);
            this.Controls.Add(this.buttonTest);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBoxFormatoCheque);
            this.Controls.Add(this.buttonVolver);
            this.Controls.Add(this.buttonImprimir);
            this.Controls.Add(this.dataGridViewCheques);
            this.Controls.Add(this.buttonLimpiar);
            this.Controls.Add(this.buttonGenerarCheques);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Impresion de Cheques";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_Form_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCheques)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelDiasProximos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonGenerarCheques;
        private System.Windows.Forms.Button buttonLimpiar;
        private System.Windows.Forms.TextBox textBoxDiasProximoVencimiento;
        private System.Windows.Forms.TextBox textBoxNumeroDeCheques;
        private System.Windows.Forms.DateTimePicker dateTimePickerFechaVencimiento;
        private System.Windows.Forms.TextBox textBoxPagueseNombre;
        private System.Windows.Forms.TextBox textBoxMontoCheque;
        private System.Windows.Forms.TextBox textBoxSucursal;
        private System.Windows.Forms.TextBox textBoxNumBoleta;
        private System.Windows.Forms.TextBox textBoxTelefono;
        private System.Windows.Forms.TextBox textBoxNumeroSerie;
        private System.Windows.Forms.TextBox textBoxRut;
        private System.Windows.Forms.DataGridView dataGridViewCheques;
        private System.Windows.Forms.Button buttonImprimir;
        private System.Windows.Forms.Button buttonVolver;
        private System.Windows.Forms.ComboBox comboBoxFormatoCheque;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeroCheque;
        private System.Windows.Forms.DataGridViewTextBoxColumn monto;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaVencimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoAutorizacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn pagueseNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rut;
        private System.Windows.Forms.DataGridViewTextBoxColumn numSerie;
        private System.Windows.Forms.DataGridViewTextBoxColumn numBoleta;
        private System.Windows.Forms.DataGridViewTextBoxColumn sucursal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefono;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button buttonTest;
    }
}