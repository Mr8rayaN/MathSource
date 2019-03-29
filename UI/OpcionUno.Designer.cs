namespace UI
{
    partial class OpcionUno
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
            this.BtnSave = new System.Windows.Forms.Button();
            this.BtnOperar = new System.Windows.Forms.Button();
            this.PnEntrada = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.CBVariables = new System.Windows.Forms.ComboBox();
            this.CBEstados = new System.Windows.Forms.ComboBox();
            this.CBProcesos = new System.Windows.Forms.ComboBox();
            this.TBResultado = new System.Windows.Forms.TextBox();
            this.TBExpresion = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.PnSalida = new System.Windows.Forms.Panel();
            this.LbResultados = new System.Windows.Forms.Label();
            this.PnSalidaTitulo = new System.Windows.Forms.Label();
            this.PnEntradaTitulo = new System.Windows.Forms.Label();
            this.PnEntrada.SuspendLayout();
            this.PnSalida.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnSave
            // 
            this.BtnSave.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnSave.FlatAppearance.BorderSize = 0;
            this.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSave.Location = new System.Drawing.Point(202, 129);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(86, 34);
            this.BtnSave.TabIndex = 4;
            this.BtnSave.Text = "Save";
            this.BtnSave.UseVisualStyleBackColor = false;
            this.BtnSave.Click += new System.EventHandler(this.Save_Click);
            // 
            // BtnOperar
            // 
            this.BtnOperar.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnOperar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnOperar.FlatAppearance.BorderSize = 0;
            this.BtnOperar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnOperar.Location = new System.Drawing.Point(199, 173);
            this.BtnOperar.Name = "BtnOperar";
            this.BtnOperar.Size = new System.Drawing.Size(86, 34);
            this.BtnOperar.TabIndex = 9;
            this.BtnOperar.Text = "Operar";
            this.BtnOperar.UseVisualStyleBackColor = false;
            this.BtnOperar.Click += new System.EventHandler(this.Operar_Click);
            // 
            // PnEntrada
            // 
            this.PnEntrada.Controls.Add(this.PnEntradaTitulo);
            this.PnEntrada.Controls.Add(this.label6);
            this.PnEntrada.Controls.Add(this.label5);
            this.PnEntrada.Controls.Add(this.BtnOperar);
            this.PnEntrada.Controls.Add(this.CBProcesos);
            this.PnEntrada.Controls.Add(this.CBVariables);
            this.PnEntrada.Controls.Add(this.label1);
            this.PnEntrada.Controls.Add(this.TBExpresion);
            this.PnEntrada.Controls.Add(this.label2);
            this.PnEntrada.Location = new System.Drawing.Point(66, 108);
            this.PnEntrada.Name = "PnEntrada";
            this.PnEntrada.Size = new System.Drawing.Size(297, 216);
            this.PnEntrada.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Variables";
            // 
            // CBVariables
            // 
            this.CBVariables.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CBVariables.FormattingEnabled = true;
            this.CBVariables.Location = new System.Drawing.Point(107, 78);
            this.CBVariables.Name = "CBVariables";
            this.CBVariables.Size = new System.Drawing.Size(178, 21);
            this.CBVariables.TabIndex = 22;
            this.CBVariables.Text = "Variables";
            // 
            // CBEstados
            // 
            this.CBEstados.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CBEstados.FormattingEnabled = true;
            this.CBEstados.Location = new System.Drawing.Point(112, 80);
            this.CBEstados.Name = "CBEstados";
            this.CBEstados.Size = new System.Drawing.Size(178, 21);
            this.CBEstados.TabIndex = 19;
            this.CBEstados.Text = "Estados";
            // 
            // CBProcesos
            // 
            this.CBProcesos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CBProcesos.FormattingEnabled = true;
            this.CBProcesos.Location = new System.Drawing.Point(107, 125);
            this.CBProcesos.Name = "CBProcesos";
            this.CBProcesos.Size = new System.Drawing.Size(178, 21);
            this.CBProcesos.TabIndex = 18;
            this.CBProcesos.Text = "Lista Procesos";
            // 
            // TBResultado
            // 
            this.TBResultado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TBResultado.Font = new System.Drawing.Font("Garamond", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBResultado.Location = new System.Drawing.Point(110, 37);
            this.TBResultado.Name = "TBResultado";
            this.TBResultado.Size = new System.Drawing.Size(178, 22);
            this.TBResultado.TabIndex = 17;
            // 
            // TBExpresion
            // 
            this.TBExpresion.Font = new System.Drawing.Font("Garamond", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBExpresion.Location = new System.Drawing.Point(107, 33);
            this.TBExpresion.Name = "TBExpresion";
            this.TBExpresion.Size = new System.Drawing.Size(178, 22);
            this.TBExpresion.TabIndex = 16;
            this.TBExpresion.Leave += new System.EventHandler(this.TBExpresion_Left);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Estado";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = " Resultado";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = " Proceso";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Expresion";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 194);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(182, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Todos los campos son obligatorios (*)";
            // 
            // PnSalida
            // 
            this.PnSalida.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PnSalida.Controls.Add(this.PnSalidaTitulo);
            this.PnSalida.Controls.Add(this.LbResultados);
            this.PnSalida.Controls.Add(this.label3);
            this.PnSalida.Controls.Add(this.CBEstados);
            this.PnSalida.Controls.Add(this.TBResultado);
            this.PnSalida.Controls.Add(this.label4);
            this.PnSalida.Controls.Add(this.BtnSave);
            this.PnSalida.Location = new System.Drawing.Point(425, 108);
            this.PnSalida.Name = "PnSalida";
            this.PnSalida.Size = new System.Drawing.Size(303, 171);
            this.PnSalida.TabIndex = 0;
            // 
            // LbResultados
            // 
            this.LbResultados.AutoSize = true;
            this.LbResultados.Location = new System.Drawing.Point(3, 150);
            this.LbResultados.Name = "LbResultados";
            this.LbResultados.Size = new System.Drawing.Size(182, 13);
            this.LbResultados.TabIndex = 22;
            this.LbResultados.Text = "Todos los campos son obligatorios (*)";
            // 
            // PnSalidaTitulo
            // 
            this.PnSalidaTitulo.AutoSize = true;
            this.PnSalidaTitulo.Location = new System.Drawing.Point(3, 3);
            this.PnSalidaTitulo.Name = "PnSalidaTitulo";
            this.PnSalidaTitulo.Size = new System.Drawing.Size(60, 13);
            this.PnSalidaTitulo.TabIndex = 23;
            this.PnSalidaTitulo.Text = "Resultados";
            // 
            // PnEntradaTitulo
            // 
            this.PnEntradaTitulo.AutoSize = true;
            this.PnEntradaTitulo.Location = new System.Drawing.Point(3, 1);
            this.PnEntradaTitulo.Name = "PnEntradaTitulo";
            this.PnEntradaTitulo.Size = new System.Drawing.Size(49, 13);
            this.PnEntradaTitulo.TabIndex = 24;
            this.PnEntradaTitulo.Text = "Entradas";
            // 
            // OpcionUno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 450);
            this.Controls.Add(this.PnEntrada);
            this.Controls.Add(this.PnSalida);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OpcionUno";
            this.Text = "OpcionUno";
            this.PnEntrada.ResumeLayout(false);
            this.PnEntrada.PerformLayout();
            this.PnSalida.ResumeLayout(false);
            this.PnSalida.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button BtnOperar;
        private System.Windows.Forms.Panel PnEntrada;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CBVariables;
        private System.Windows.Forms.ComboBox CBEstados;
        private System.Windows.Forms.ComboBox CBProcesos;
        private System.Windows.Forms.TextBox TBResultado;
        private System.Windows.Forms.TextBox TBExpresion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label LbResultados;
        private System.Windows.Forms.Panel PnSalida;
        private System.Windows.Forms.Label PnEntradaTitulo;
        private System.Windows.Forms.Label PnSalidaTitulo;
    }
}