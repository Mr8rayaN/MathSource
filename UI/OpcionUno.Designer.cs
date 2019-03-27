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
            this.PnEntradaTitulo = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.CBProcesos = new System.Windows.Forms.ComboBox();
            this.CBVariables = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TBExpresion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CBEstados = new System.Windows.Forms.ComboBox();
            this.TBResultado = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.PnSalida = new System.Windows.Forms.Panel();
            this.PnSalidaTitulo = new System.Windows.Forms.Label();
            this.LbResultados = new System.Windows.Forms.Label();
            this.PnEntrada.SuspendLayout();
            this.PnSalida.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnSave
            // 
            this.BtnSave.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnSave.FlatAppearance.BorderSize = 0;
            this.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSave.Location = new System.Drawing.Point(217, 156);
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
            this.BtnOperar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.BtnOperar.Location = new System.Drawing.Point(209, 207);
            this.BtnOperar.Name = "BtnOperar";
            this.BtnOperar.Size = new System.Drawing.Size(86, 34);
            this.BtnOperar.TabIndex = 9;
            this.BtnOperar.Text = "Operar";
            this.BtnOperar.UseVisualStyleBackColor = false;
            this.BtnOperar.Click += new System.EventHandler(this.Operar_Click);
            // 
            // PnEntrada
            // 
            this.PnEntrada.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.PnEntrada.Controls.Add(this.PnEntradaTitulo);
            this.PnEntrada.Controls.Add(this.label6);
            this.PnEntrada.Controls.Add(this.label5);
            this.PnEntrada.Controls.Add(this.BtnOperar);
            this.PnEntrada.Controls.Add(this.CBProcesos);
            this.PnEntrada.Controls.Add(this.CBVariables);
            this.PnEntrada.Controls.Add(this.label1);
            this.PnEntrada.Controls.Add(this.TBExpresion);
            this.PnEntrada.Controls.Add(this.label2);
            this.PnEntrada.Location = new System.Drawing.Point(124, 108);
            this.PnEntrada.Name = "PnEntrada";
            this.PnEntrada.Size = new System.Drawing.Size(309, 249);
            this.PnEntrada.TabIndex = 20;
            // 
            // PnEntradaTitulo
            // 
            this.PnEntradaTitulo.AutoSize = true;
            this.PnEntradaTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.PnEntradaTitulo.Location = new System.Drawing.Point(3, 1);
            this.PnEntradaTitulo.Name = "PnEntradaTitulo";
            this.PnEntradaTitulo.Size = new System.Drawing.Size(107, 26);
            this.PnEntradaTitulo.TabIndex = 24;
            this.PnEntradaTitulo.Text = "Entradas";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 226);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(182, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Todos los campos son obligatorios (*)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label5.Location = new System.Drawing.Point(12, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 24);
            this.label5.TabIndex = 23;
            this.label5.Text = "Variables";
            // 
            // CBProcesos
            // 
            this.CBProcesos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CBProcesos.Font = new System.Drawing.Font("Gill Sans MT", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBProcesos.FormattingEnabled = true;
            this.CBProcesos.Location = new System.Drawing.Point(118, 141);
            this.CBProcesos.Name = "CBProcesos";
            this.CBProcesos.Size = new System.Drawing.Size(178, 31);
            this.CBProcesos.TabIndex = 18;
            this.CBProcesos.Text = "Lista Procesos";
            // 
            // CBVariables
            // 
            this.CBVariables.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CBVariables.Font = new System.Drawing.Font("Gill Sans MT", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBVariables.FormattingEnabled = true;
            this.CBVariables.Location = new System.Drawing.Point(118, 94);
            this.CBVariables.Name = "CBVariables";
            this.CBVariables.Size = new System.Drawing.Size(178, 31);
            this.CBVariables.TabIndex = 22;
            this.CBVariables.Text = "Variables";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 24);
            this.label1.TabIndex = 12;
            this.label1.Text = "Expresion";
            // 
            // TBExpresion
            // 
            this.TBExpresion.Font = new System.Drawing.Font("Gill Sans MT", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBExpresion.ForeColor = System.Drawing.Color.Black;
            this.TBExpresion.Location = new System.Drawing.Point(118, 49);
            this.TBExpresion.Name = "TBExpresion";
            this.TBExpresion.Size = new System.Drawing.Size(178, 30);
            this.TBExpresion.TabIndex = 16;
            this.TBExpresion.Leave += new System.EventHandler(this.TBExpresion_Left);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label2.Location = new System.Drawing.Point(12, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 24);
            this.label2.TabIndex = 13;
            this.label2.Text = " Proceso";
            // 
            // CBEstados
            // 
            this.CBEstados.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CBEstados.Font = new System.Drawing.Font("Gill Sans MT", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBEstados.FormattingEnabled = true;
            this.CBEstados.Location = new System.Drawing.Point(126, 91);
            this.CBEstados.Name = "CBEstados";
            this.CBEstados.Size = new System.Drawing.Size(178, 31);
            this.CBEstados.TabIndex = 19;
            this.CBEstados.Text = "Estados";
            // 
            // TBResultado
            // 
            this.TBResultado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TBResultado.Font = new System.Drawing.Font("Gill Sans MT", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBResultado.ForeColor = System.Drawing.Color.Black;
            this.TBResultado.Location = new System.Drawing.Point(124, 48);
            this.TBResultado.Name = "TBResultado";
            this.TBResultado.Size = new System.Drawing.Size(178, 30);
            this.TBResultado.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 24);
            this.label4.TabIndex = 15;
            this.label4.Text = "Estado";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 24);
            this.label3.TabIndex = 14;
            this.label3.Text = " Resultado";
            // 
            // PnSalida
            // 
            this.PnSalida.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.PnSalida.Controls.Add(this.PnSalidaTitulo);
            this.PnSalida.Controls.Add(this.LbResultados);
            this.PnSalida.Controls.Add(this.label3);
            this.PnSalida.Controls.Add(this.CBEstados);
            this.PnSalida.Controls.Add(this.TBResultado);
            this.PnSalida.Controls.Add(this.label4);
            this.PnSalida.Controls.Add(this.BtnSave);
            this.PnSalida.Location = new System.Drawing.Point(483, 108);
            this.PnSalida.Name = "PnSalida";
            this.PnSalida.Size = new System.Drawing.Size(314, 199);
            this.PnSalida.TabIndex = 0;
            // 
            // PnSalidaTitulo
            // 
            this.PnSalidaTitulo.AutoSize = true;
            this.PnSalidaTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnSalidaTitulo.Location = new System.Drawing.Point(3, 3);
            this.PnSalidaTitulo.Name = "PnSalidaTitulo";
            this.PnSalidaTitulo.Size = new System.Drawing.Size(130, 25);
            this.PnSalidaTitulo.TabIndex = 23;
            this.PnSalidaTitulo.Text = "Resultados";
            // 
            // LbResultados
            // 
            this.LbResultados.AutoSize = true;
            this.LbResultados.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbResultados.Location = new System.Drawing.Point(3, 177);
            this.LbResultados.Name = "LbResultados";
            this.LbResultados.Size = new System.Drawing.Size(182, 13);
            this.LbResultados.TabIndex = 22;
            this.LbResultados.Text = "Todos los campos son obligatorios (*)";
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