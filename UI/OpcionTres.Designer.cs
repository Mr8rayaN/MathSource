namespace UI
{
    partial class OpcionTres
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
            this.funcionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pasosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.DGVEntradas = new System.Windows.Forms.DataGridView();
            this.nombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contenidoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.funcionesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pasosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVEntradas)).BeginInit();
            this.SuspendLayout();
            // 
            // funcionesBindingSource
            // 
            this.funcionesBindingSource.DataSource = typeof(ENTITY.Funciones);
            // 
            // pasosBindingSource
            // 
            this.pasosBindingSource.DataSource = typeof(ENTITY.Pasos);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(88, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Entradas";
            // 
            // DGVEntradas
            // 
            this.DGVEntradas.AllowUserToAddRows = false;
            this.DGVEntradas.AllowUserToDeleteRows = false;
            this.DGVEntradas.AutoGenerateColumns = false;
            this.DGVEntradas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DGVEntradas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.DGVEntradas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DGVEntradas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVEntradas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nombreDataGridViewTextBoxColumn,
            this.contenidoDataGridViewTextBoxColumn});
            this.DGVEntradas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DGVEntradas.DataSource = this.funcionesBindingSource;
            this.DGVEntradas.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.DGVEntradas.Location = new System.Drawing.Point(91, 96);
            this.DGVEntradas.Name = "DGVEntradas";
            this.DGVEntradas.ReadOnly = true;
            this.DGVEntradas.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DGVEntradas.RowHeadersVisible = false;
            this.DGVEntradas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DGVEntradas.Size = new System.Drawing.Size(400, 317);
            this.DGVEntradas.TabIndex = 4;
            // 
            // nombreDataGridViewTextBoxColumn
            // 
            this.nombreDataGridViewTextBoxColumn.DataPropertyName = "Nombre";
            this.nombreDataGridViewTextBoxColumn.HeaderText = "Nombre";
            this.nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
            this.nombreDataGridViewTextBoxColumn.ReadOnly = true;
            this.nombreDataGridViewTextBoxColumn.Width = 200;
            // 
            // contenidoDataGridViewTextBoxColumn
            // 
            this.contenidoDataGridViewTextBoxColumn.DataPropertyName = "Contenido";
            this.contenidoDataGridViewTextBoxColumn.HeaderText = "Contenido";
            this.contenidoDataGridViewTextBoxColumn.Name = "contenidoDataGridViewTextBoxColumn";
            this.contenidoDataGridViewTextBoxColumn.ReadOnly = true;
            this.contenidoDataGridViewTextBoxColumn.Width = 200;
            // 
            // OpcionTres
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DGVEntradas);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OpcionTres";
            this.Text = "OpcionTres";
            ((System.ComponentModel.ISupportInitialize)(this.funcionesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pasosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVEntradas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.BindingSource funcionesBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idFuncionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idResultadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource pasosBindingSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DGVEntradas;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn contenidoDataGridViewTextBoxColumn;
    }
}