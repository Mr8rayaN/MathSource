namespace UI
{
    partial class OpcionCinco
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
            this.DGVResultados = new System.Windows.Forms.DataGridView();
            this.LbTitulo = new System.Windows.Forms.Label();
            this.resultadosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contenidoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DGVResultados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultadosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // DGVResultados
            // 
            this.DGVResultados.AllowUserToAddRows = false;
            this.DGVResultados.AllowUserToDeleteRows = false;
            this.DGVResultados.AutoGenerateColumns = false;
            this.DGVResultados.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DGVResultados.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.DGVResultados.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DGVResultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVResultados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nombreDataGridViewTextBoxColumn,
            this.contenidoDataGridViewTextBoxColumn,
            this.estadoDataGridViewTextBoxColumn});
            this.DGVResultados.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DGVResultados.DataSource = this.resultadosBindingSource;
            this.DGVResultados.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.DGVResultados.Location = new System.Drawing.Point(92, 97);
            this.DGVResultados.Name = "DGVResultados";
            this.DGVResultados.ReadOnly = true;
            this.DGVResultados.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DGVResultados.RowHeadersVisible = false;
            this.DGVResultados.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DGVResultados.Size = new System.Drawing.Size(500, 317);
            this.DGVResultados.TabIndex = 7;
            // 
            // LbTitulo
            // 
            this.LbTitulo.AutoSize = true;
            this.LbTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbTitulo.Location = new System.Drawing.Point(89, 40);
            this.LbTitulo.Name = "LbTitulo";
            this.LbTitulo.Size = new System.Drawing.Size(144, 29);
            this.LbTitulo.TabIndex = 6;
            this.LbTitulo.Text = "Resultados";
            // 
            // resultadosBindingSource
            // 
            this.resultadosBindingSource.DataSource = typeof(ENTITY.Resultados);
            // 
            // nombreDataGridViewTextBoxColumn
            // 
            this.nombreDataGridViewTextBoxColumn.DataPropertyName = "Nombre";
            this.nombreDataGridViewTextBoxColumn.HeaderText = "Nombre";
            this.nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
            this.nombreDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // contenidoDataGridViewTextBoxColumn
            // 
            this.contenidoDataGridViewTextBoxColumn.DataPropertyName = "Contenido";
            this.contenidoDataGridViewTextBoxColumn.HeaderText = "Contenido";
            this.contenidoDataGridViewTextBoxColumn.Name = "contenidoDataGridViewTextBoxColumn";
            this.contenidoDataGridViewTextBoxColumn.ReadOnly = true;
            this.contenidoDataGridViewTextBoxColumn.Width = 200;
            // 
            // estadoDataGridViewTextBoxColumn
            // 
            this.estadoDataGridViewTextBoxColumn.DataPropertyName = "Estado";
            this.estadoDataGridViewTextBoxColumn.HeaderText = "Estado";
            this.estadoDataGridViewTextBoxColumn.Name = "estadoDataGridViewTextBoxColumn";
            this.estadoDataGridViewTextBoxColumn.ReadOnly = true;
            this.estadoDataGridViewTextBoxColumn.Width = 200;
            // 
            // OpcionCinco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DGVResultados);
            this.Controls.Add(this.LbTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OpcionCinco";
            this.Text = "OpcionCinco";
            ((System.ComponentModel.ISupportInitialize)(this.DGVResultados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultadosBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DGVResultados;
        private System.Windows.Forms.Label LbTitulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn contenidoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn estadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource resultadosBindingSource;
    }
}