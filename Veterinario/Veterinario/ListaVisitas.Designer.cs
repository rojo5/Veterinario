namespace Veterinario
{
    partial class ListaVisitas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lbTitulo = new System.Windows.Forms.Label();
            this.dataGridViewVisitas = new System.Windows.Forms.DataGridView();
            this.btnNuevaVisita = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVisitas)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTitulo
            // 
            this.lbTitulo.AutoSize = true;
            this.lbTitulo.Location = new System.Drawing.Point(13, 13);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(109, 13);
            this.lbTitulo.TabIndex = 0;
            this.lbTitulo.Text = "Listado de visitas de: ";
            // 
            // dataGridViewVisitas
            // 
            this.dataGridViewVisitas.AllowUserToAddRows = false;
            this.dataGridViewVisitas.AllowUserToDeleteRows = false;
            this.dataGridViewVisitas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewVisitas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewVisitas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewVisitas.Location = new System.Drawing.Point(13, 73);
            this.dataGridViewVisitas.Name = "dataGridViewVisitas";
            this.dataGridViewVisitas.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewVisitas.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewVisitas.Size = new System.Drawing.Size(725, 287);
            this.dataGridViewVisitas.TabIndex = 1;
            this.dataGridViewVisitas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewVisitas_CellDoubleClick);
            // 
            // btnNuevaVisita
            // 
            this.btnNuevaVisita.Location = new System.Drawing.Point(663, 12);
            this.btnNuevaVisita.Name = "btnNuevaVisita";
            this.btnNuevaVisita.Size = new System.Drawing.Size(75, 46);
            this.btnNuevaVisita.TabIndex = 2;
            this.btnNuevaVisita.Text = "Nueva visita";
            this.btnNuevaVisita.UseVisualStyleBackColor = true;
            this.btnNuevaVisita.Click += new System.EventHandler(this.btnNuevaVisita_Click);
            // 
            // ListaVisitas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 372);
            this.Controls.Add(this.btnNuevaVisita);
            this.Controls.Add(this.dataGridViewVisitas);
            this.Controls.Add(this.lbTitulo);
            this.Name = "ListaVisitas";
            this.Text = "Visitas";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVisitas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTitulo;
        private System.Windows.Forms.DataGridView dataGridViewVisitas;
        private System.Windows.Forms.Button btnNuevaVisita;
    }
}