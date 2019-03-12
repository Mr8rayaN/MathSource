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
            this.GBElementos = new System.Windows.Forms.GroupBox();
            this.CBEstados = new System.Windows.Forms.ComboBox();
            this.CBProcesos = new System.Windows.Forms.ComboBox();
            this.TBResultado = new System.Windows.Forms.TextBox();
            this.TBExpresion = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.CBVariables = new System.Windows.Forms.ComboBox();
            this.PnVariables = new System.Windows.Forms.Panel();
            this.GBElementos.SuspendLayout();
            this.PnVariables.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnSave
            // 
            this.BtnSave.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnSave.FlatAppearance.BorderSize = 0;
            this.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSave.Location = new System.Drawing.Point(515, 318);
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
            this.BtnOperar.Location = new System.Drawing.Point(412, 318);
            this.BtnOperar.Name = "BtnOperar";
            this.BtnOperar.Size = new System.Drawing.Size(86, 34);
            this.BtnOperar.TabIndex = 9;
            this.BtnOperar.Text = "Operar";
            this.BtnOperar.UseVisualStyleBackColor = false;
            this.BtnOperar.Click += new System.EventHandler(this.Operar_Click);
            // 
            // GBElementos
            // 
            this.GBElementos.Controls.Add(this.PnVariables);
            this.GBElementos.Controls.Add(this.CBEstados);
            this.GBElementos.Controls.Add(this.CBProcesos);
            this.GBElementos.Controls.Add(this.TBResultado);
            this.GBElementos.Controls.Add(this.TBExpresion);
            this.GBElementos.Controls.Add(this.label4);
            this.GBElementos.Controls.Add(this.label3);
            this.GBElementos.Controls.Add(this.label2);
            this.GBElementos.Controls.Add(this.label1);
            this.GBElementos.Location = new System.Drawing.Point(61, 55);
            this.GBElementos.Name = "GBElementos";
            this.GBElementos.Size = new System.Drawing.Size(309, 297);
            this.GBElementos.TabIndex = 10;
            this.GBElementos.TabStop = false;
            this.GBElementos.Text = "Elementos";
            // 
            // CBEstados
            // 
            this.CBEstados.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CBEstados.FormattingEnabled = true;
            this.CBEstados.Location = new System.Drawing.Point(113, 186);
            this.CBEstados.Name = "CBEstados";
            this.CBEstados.Size = new System.Drawing.Size(178, 21);
            this.CBEstados.TabIndex = 19;
            this.CBEstados.Text = "Estados";
            // 
            // CBProcesos
            // 
            this.CBProcesos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CBProcesos.FormattingEnabled = true;
            this.CBProcesos.Location = new System.Drawing.Point(113, 84);
            this.CBProcesos.Name = "CBProcesos";
            this.CBProcesos.Size = new System.Drawing.Size(178, 21);
            this.CBProcesos.TabIndex = 18;
            this.CBProcesos.Text = "Lista Procesos";
            // 
            // TBResultado
            // 
            this.TBResultado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TBResultado.Font = new System.Drawing.Font("Garamond", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBResultado.Location = new System.Drawing.Point(113, 135);
            this.TBResultado.Name = "TBResultado";
            this.TBResultado.Size = new System.Drawing.Size(178, 22);
            this.TBResultado.TabIndex = 17;
            // 
            // TBExpresion
            // 
            this.TBExpresion.Font = new System.Drawing.Font("Garamond", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBExpresion.Location = new System.Drawing.Point(113, 33);
            this.TBExpresion.Name = "TBExpresion";
            this.TBExpresion.Size = new System.Drawing.Size(178, 22);
            this.TBExpresion.TabIndex = 16;
            this.TBExpresion.Leave += new System.EventHandler(this.TBExpresion_Left);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 189);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Estado";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = " Resultado";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = " Proceso";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = " Expresion";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Variables";
            // 
            // CBVariables
            // 
            this.CBVariables.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CBVariables.FormattingEnabled = true;
            this.CBVariables.Location = new System.Drawing.Point(107, 14);
            this.CBVariables.Name = "CBVariables";
            this.CBVariables.Size = new System.Drawing.Size(178, 21);
            this.CBVariables.TabIndex = 22;
            this.CBVariables.Text = "Variables";
            // 
            // PnVariables
            // 
            this.PnVariables.Controls.Add(this.label5);
            this.PnVariables.Controls.Add(this.CBVariables);
            this.PnVariables.Location = new System.Drawing.Point(6, 228);
            this.PnVariables.Name = "PnVariables";
            this.PnVariables.Size = new System.Drawing.Size(297, 49);
            this.PnVariables.TabIndex = 20;
            // 
            // OpcionUno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.GBElementos);
            this.Controls.Add(this.BtnOperar);
            this.Controls.Add(this.BtnSave);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OpcionUno";
            this.Text = "OpcionUno";
            this.GBElementos.ResumeLayout(false);
            this.GBElementos.PerformLayout();
            this.PnVariables.ResumeLayout(false);
            this.PnVariables.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button BtnOperar;
        private System.Windows.Forms.GroupBox GBElementos;
        private System.Windows.Forms.Panel PnVariables;
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
    }
}