namespace UI
{
    partial class OpcionDos
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
            this.components = new System.ComponentModel.Container();
            this.LbTitulo = new System.Windows.Forms.Label();
            this.pasosBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.funcionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pasosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DGVPasos = new System.Windows.Forms.DataGridView();
            this.nombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.entradaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salidaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pasosBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pasosBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.funcionesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pasosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVPasos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pasosBindingSource2)).BeginInit();
            this.SuspendLayout();
            // 
            // LbTitulo
            // 
            this.LbTitulo.AutoSize = true;
            this.LbTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbTitulo.Location = new System.Drawing.Point(87, 41);
            this.LbTitulo.Name = "LbTitulo";
            this.LbTitulo.Size = new System.Drawing.Size(85, 29);
            this.LbTitulo.TabIndex = 2;
            this.LbTitulo.Text = "Pasos";
            // 
            // pasosBindingSource1
            // 
            this.pasosBindingSource1.DataSource = typeof(ENTITY.Pasos);
            // 
            // funcionesBindingSource
            // 
            this.funcionesBindingSource.DataSource = typeof(ENTITY.Funciones);
            // 
            // pasosBindingSource
            // 
            this.pasosBindingSource.DataSource = typeof(ENTITY.Pasos);
            // 
            // DGVPasos
            // 
            this.DGVPasos.AllowUserToAddRows = false;
            this.DGVPasos.AllowUserToDeleteRows = false;
            this.DGVPasos.AutoGenerateColumns = false;
            this.DGVPasos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DGVPasos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.DGVPasos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DGVPasos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVPasos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nombreDataGridViewTextBoxColumn,
            this.entradaDataGridViewTextBoxColumn,
            this.salidaDataGridViewTextBoxColumn});
            this.DGVPasos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DGVPasos.DataSource = this.pasosBindingSource2;
            this.DGVPasos.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.DGVPasos.Location = new System.Drawing.Point(90, 95);
            this.DGVPasos.Name = "DGVPasos";
            this.DGVPasos.ReadOnly = true;
            this.DGVPasos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DGVPasos.RowHeadersVisible = false;
            this.DGVPasos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DGVPasos.Size = new System.Drawing.Size(598, 317);
            this.DGVPasos.TabIndex = 3;
            // 
            // nombreDataGridViewTextBoxColumn
            // 
            this.nombreDataGridViewTextBoxColumn.DataPropertyName = "Nombre";
            this.nombreDataGridViewTextBoxColumn.HeaderText = "Nombre";
            this.nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
            this.nombreDataGridViewTextBoxColumn.ReadOnly = true;
            this.nombreDataGridViewTextBoxColumn.Width = 200;
            // 
            // entradaDataGridViewTextBoxColumn
            // 
            this.entradaDataGridViewTextBoxColumn.DataPropertyName = "Entrada";
            this.entradaDataGridViewTextBoxColumn.HeaderText = "Entrada";
            this.entradaDataGridViewTextBoxColumn.Name = "entradaDataGridViewTextBoxColumn";
            this.entradaDataGridViewTextBoxColumn.ReadOnly = true;
            this.entradaDataGridViewTextBoxColumn.Width = 200;
            // 
            // salidaDataGridViewTextBoxColumn
            // 
            this.salidaDataGridViewTextBoxColumn.DataPropertyName = "Salida";
            this.salidaDataGridViewTextBoxColumn.HeaderText = "Salida";
            this.salidaDataGridViewTextBoxColumn.Name = "salidaDataGridViewTextBoxColumn";
            this.salidaDataGridViewTextBoxColumn.ReadOnly = true;
            this.salidaDataGridViewTextBoxColumn.Width = 200;
            // 
            // pasosBindingSource2
            // 
            this.pasosBindingSource2.DataSource = typeof(ENTITY.Pasos);
            // 
            // OpcionDos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 450);
            this.Controls.Add(this.DGVPasos);
            this.Controls.Add(this.LbTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OpcionDos";
            this.Text = "OpcionDos";
            ((System.ComponentModel.ISupportInitialize)(this.pasosBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.funcionesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pasosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVPasos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pasosBindingSource2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.BindingSource pasosBindingSource;
        private System.Windows.Forms.BindingSource funcionesBindingSource;
        private System.Windows.Forms.Label LbTitulo;
        private System.Windows.Forms.BindingSource pasosBindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn entradaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn salidaDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource pasosBindingSource2;
        private System.Windows.Forms.DataGridView DGVPasos;
    }
}