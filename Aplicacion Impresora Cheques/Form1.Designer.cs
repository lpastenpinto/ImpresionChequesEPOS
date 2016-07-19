namespace Aplicacion_Impresora_Cheques
{
    partial class Form1
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
            this.buttonProbarConexion = new System.Windows.Forms.Button();
            this.buttonImprimir = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonProbarOtraConect = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonProbarConexion
            // 
            this.buttonProbarConexion.Location = new System.Drawing.Point(70, 54);
            this.buttonProbarConexion.Name = "buttonProbarConexion";
            this.buttonProbarConexion.Size = new System.Drawing.Size(139, 23);
            this.buttonProbarConexion.TabIndex = 0;
            this.buttonProbarConexion.Text = "Probar Conexion";
            this.buttonProbarConexion.UseVisualStyleBackColor = true;
            this.buttonProbarConexion.Click += new System.EventHandler(this.buttonProbarConexion_Click);
            // 
            // buttonImprimir
            // 
            this.buttonImprimir.Location = new System.Drawing.Point(70, 149);
            this.buttonImprimir.Name = "buttonImprimir";
            this.buttonImprimir.Size = new System.Drawing.Size(139, 23);
            this.buttonImprimir.TabIndex = 1;
            this.buttonImprimir.Text = "Imprimir Cheque";
            this.buttonImprimir.UseVisualStyleBackColor = true;
            this.buttonImprimir.Click += new System.EventHandler(this.buttonImprimir_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(70, 209);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(139, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Imprimir Formato nuevo";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonProbarOtraConect
            // 
            this.buttonProbarOtraConect.Location = new System.Drawing.Point(70, 107);
            this.buttonProbarOtraConect.Name = "buttonProbarOtraConect";
            this.buttonProbarOtraConect.Size = new System.Drawing.Size(139, 23);
            this.buttonProbarOtraConect.TabIndex = 3;
            this.buttonProbarOtraConect.Text = "Probar otra conexion";
            this.buttonProbarOtraConect.UseVisualStyleBackColor = true;
            this.buttonProbarOtraConect.Click += new System.EventHandler(this.buttonProbarOtraConect_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(95, 248);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Abrir App";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 297);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.buttonProbarOtraConect);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonImprimir);
            this.Controls.Add(this.buttonProbarConexion);
            this.Name = "Form1";
            this.Text = "Aplicacion Impresora Cheques";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonProbarConexion;
        private System.Windows.Forms.Button buttonImprimir;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonProbarOtraConect;
        private System.Windows.Forms.Button button2;
    }
}

