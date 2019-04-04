namespace UI
{
    partial class OpcionCuatro
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
            this.resultadosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DGVPasos = new System.Windows.Forms.DataGridView();
            this.LbTitulo = new System.Windows.Forms.Label();
            this.pasosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.entradaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salidaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.resultadosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVPasos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pasosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // resultadosBindingSource
            // 
            this.resultadosBindingSource.DataSource = typeof(ENTITY.Resultados);
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
            this.DGVPasos.DataSource = this.pasosBindingSource;
            this.DGVPasos.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.DGVPasos.Location = new System.Drawing.Point(103, 94);
            this.DGVPasos.Name = "DGVPasos";
            this.DGVPasos.ReadOnly = true;
            this.DGVPasos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DGVPasos.RowHeadersVisible = false;
            this.DGVPasos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DGVPasos.Size = new System.Drawing.Size(500, 317);
            this.DGVPasos.TabIndex = 5;
            // 
            // LbTitulo
            // 
            this.LbTitulo.AutoSize = true;
            this.LbTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbTitulo.Location = new System.Drawing.Point(100, 40);
            this.LbTitulo.Name = "LbTitulo";
            this.LbTitulo.Size = new System.Drawing.Size(85, 29);
            this.LbTitulo.TabIndex = 4;
            this.LbTitulo.Text = "Pasos";
            // 
            // pasosBindingSource
            // 
            this.pasosBindingSource.DataSource = typeof(ENTITY.Pasos);
            // 
            // nombreDataGridViewTextBoxColumn
            // 
            this.nombreDataGridViewTextBoxColumn.DataPropertyName = "Nombre";
            this.nombreDataGridViewTextBoxColumn.HeaderText = "Nombre";
            this.nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
            this.nombreDataGridViewTextBoxColumn.ReadOnly = true;
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
            // OpcionCuatro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DGVPasos);
            this.Controls.Add(this.LbTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OpcionCuatro";
            this.Text = "OpcionCuatro";
            ((System.ComponentModel.ISupportInitialize)(this.resultadosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVPasos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pasosBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.BindingSource resultadosBindingSource;
        private System.Windows.Forms.DataGridView DGVPasos;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn entradaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn salidaDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource pasosBindingSource;
        private System.Windows.Forms.Label LbTitulo;
    }
}