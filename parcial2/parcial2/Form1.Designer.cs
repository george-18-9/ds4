namespace parcial2
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados deben eliminarse; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.rdbMetrosAYardas = new System.Windows.Forms.RadioButton();
            this.rdbYardasAMetros = new System.Windows.Forms.RadioButton();
            this.btnConvertir = new System.Windows.Forms.Button();
            this.lblResultado = new System.Windows.Forms.Label();
            this.lstHistorial = new System.Windows.Forms.ListBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(60, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(350, 40);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Conversor Metros ↔ Yardas";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtValor
            // 
            this.txtValor.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtValor.Location = new System.Drawing.Point(60, 80);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(200, 29);
            this.txtValor.TabIndex = 1;
            // 
            // rdbMetrosAYardas
            // 
            this.rdbMetrosAYardas.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.rdbMetrosAYardas.Location = new System.Drawing.Point(60, 130);
            this.rdbMetrosAYardas.Name = "rdbMetrosAYardas";
            this.rdbMetrosAYardas.Size = new System.Drawing.Size(150, 24);
            this.rdbMetrosAYardas.TabIndex = 2;
            this.rdbMetrosAYardas.TabStop = true;
            this.rdbMetrosAYardas.Text = "Metros a Yardas";
            this.rdbMetrosAYardas.UseVisualStyleBackColor = true;
            // 
            // rdbYardasAMetros
            // 
            this.rdbYardasAMetros.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.rdbYardasAMetros.Location = new System.Drawing.Point(220, 130);
            this.rdbYardasAMetros.Name = "rdbYardasAMetros";
            this.rdbYardasAMetros.Size = new System.Drawing.Size(150, 24);
            this.rdbYardasAMetros.TabIndex = 3;
            this.rdbYardasAMetros.TabStop = true;
            this.rdbYardasAMetros.Text = "Yardas a Metros";
            this.rdbYardasAMetros.UseVisualStyleBackColor = true;
            // 
            // btnConvertir
            // 
            this.btnConvertir.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnConvertir.Location = new System.Drawing.Point(60, 180);
            this.btnConvertir.Name = "btnConvertir";
            this.btnConvertir.Size = new System.Drawing.Size(150, 40);
            this.btnConvertir.TabIndex = 4;
            this.btnConvertir.Text = "Convertir";
            this.btnConvertir.UseVisualStyleBackColor = true;
            this.btnConvertir.Click += new System.EventHandler(this.btnConvertir_Click);
            // 
            // lblResultado
            // 
            this.lblResultado.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblResultado.Location = new System.Drawing.Point(60, 240);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(320, 30);
            this.lblResultado.TabIndex = 5;
            this.lblResultado.Text = "Resultado:";
            // 
            // lstHistorial
            // 
            this.lstHistorial.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lstHistorial.FormattingEnabled = true;
            this.lstHistorial.ItemHeight = 17;
            this.lstHistorial.Location = new System.Drawing.Point(60, 280);
            this.lstHistorial.Name = "lstHistorial";
            this.lstHistorial.Size = new System.Drawing.Size(320, 140);
            this.lstHistorial.TabIndex = 6;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnLimpiar.Location = new System.Drawing.Point(230, 180);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(150, 40);
            this.btnLimpiar.TabIndex = 7;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 450);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.lstHistorial);
            this.Controls.Add(this.lblResultado);
            this.Controls.Add(this.btnConvertir);
            this.Controls.Add(this.rdbYardasAMetros);
            this.Controls.Add(this.rdbMetrosAYardas);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Conversor Metros ↔ Yardas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.RadioButton rdbMetrosAYardas;
        private System.Windows.Forms.RadioButton rdbYardasAMetros;
        private System.Windows.Forms.Button btnConvertir;
        private System.Windows.Forms.Label lblResultado;
        private System.Windows.Forms.ListBox lstHistorial;
        private System.Windows.Forms.Button btnLimpiar;
    }
}


