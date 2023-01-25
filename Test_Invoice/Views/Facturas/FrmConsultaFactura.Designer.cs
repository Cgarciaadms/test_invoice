
namespace Test_Invoice.Views.Facturas
{
    partial class FrmConsultaFactura
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConsultaFactura));
            this.dataListadoFacturas = new System.Windows.Forms.DataGridView();
            this.cFactura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cSubTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cItbis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.lbCtdRegistros = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pLogo = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataListadoFacturas)).BeginInit();
            this.pLogo.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataListadoFacturas
            // 
            this.dataListadoFacturas.AllowUserToAddRows = false;
            this.dataListadoFacturas.AllowUserToDeleteRows = false;
            this.dataListadoFacturas.AllowUserToResizeColumns = false;
            this.dataListadoFacturas.AllowUserToResizeRows = false;
            this.dataListadoFacturas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataListadoFacturas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataListadoFacturas.BackgroundColor = System.Drawing.Color.White;
            this.dataListadoFacturas.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataListadoFacturas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataListadoFacturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataListadoFacturas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cFactura,
            this.cCliente,
            this.cSubTotal,
            this.cItbis,
            this.cTotal});
            this.dataListadoFacturas.Location = new System.Drawing.Point(16, 45);
            this.dataListadoFacturas.MultiSelect = false;
            this.dataListadoFacturas.Name = "dataListadoFacturas";
            this.dataListadoFacturas.ReadOnly = true;
            this.dataListadoFacturas.RowHeadersWidth = 25;
            this.dataListadoFacturas.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataListadoFacturas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataListadoFacturas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataListadoFacturas.Size = new System.Drawing.Size(657, 669);
            this.dataListadoFacturas.TabIndex = 154;
            // 
            // cFactura
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.cFactura.DefaultCellStyle = dataGridViewCellStyle2;
            this.cFactura.FillWeight = 60F;
            this.cFactura.HeaderText = "Factura";
            this.cFactura.Name = "cFactura";
            this.cFactura.ReadOnly = true;
            this.cFactura.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cFactura.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // cCliente
            // 
            this.cCliente.FillWeight = 200F;
            this.cCliente.HeaderText = "Cliente";
            this.cCliente.Name = "cCliente";
            this.cCliente.ReadOnly = true;
            this.cCliente.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cCliente.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // cSubTotal
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.cSubTotal.DefaultCellStyle = dataGridViewCellStyle3;
            this.cSubTotal.FillWeight = 80F;
            this.cSubTotal.HeaderText = "Sub Total";
            this.cSubTotal.Name = "cSubTotal";
            this.cSubTotal.ReadOnly = true;
            this.cSubTotal.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cSubTotal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // cItbis
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.cItbis.DefaultCellStyle = dataGridViewCellStyle4;
            this.cItbis.FillWeight = 80F;
            this.cItbis.HeaderText = "Itbis";
            this.cItbis.Name = "cItbis";
            this.cItbis.ReadOnly = true;
            this.cItbis.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cItbis.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // cTotal
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.cTotal.DefaultCellStyle = dataGridViewCellStyle5;
            this.cTotal.FillWeight = 80F;
            this.cTotal.HeaderText = "Total";
            this.cTotal.Name = "cTotal";
            this.cTotal.ReadOnly = true;
            this.cTotal.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cTotal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptar.Location = new System.Drawing.Point(541, 718);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(132, 25);
            this.btnAceptar.TabIndex = 156;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // lbCtdRegistros
            // 
            this.lbCtdRegistros.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbCtdRegistros.AutoSize = true;
            this.lbCtdRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCtdRegistros.Location = new System.Drawing.Point(17, 724);
            this.lbCtdRegistros.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbCtdRegistros.Name = "lbCtdRegistros";
            this.lbCtdRegistros.Size = new System.Drawing.Size(75, 13);
            this.lbCtdRegistros.TabIndex = 155;
            this.lbCtdRegistros.Text = "lbCtdRegistros";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(106)))), ((int)(((byte)(228)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 39);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(10, 710);
            this.panel2.TabIndex = 150;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(106)))), ((int)(((byte)(228)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(681, 39);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(10, 710);
            this.panel4.TabIndex = 152;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrar.Image")));
            this.btnCerrar.Location = new System.Drawing.Point(660, 7);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(25, 25);
            this.btnCerrar.TabIndex = 2;
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.BtnCerrar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Listado de Facturas";
            // 
            // pLogo
            // 
            this.pLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.pLogo.Controls.Add(this.btnCerrar);
            this.pLogo.Controls.Add(this.label1);
            this.pLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pLogo.ForeColor = System.Drawing.Color.Black;
            this.pLogo.Location = new System.Drawing.Point(0, 0);
            this.pLogo.Name = "pLogo";
            this.pLogo.Size = new System.Drawing.Size(691, 39);
            this.pLogo.TabIndex = 149;
            this.pLogo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PLogo_MouseDown);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(106)))), ((int)(((byte)(228)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 749);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(691, 10);
            this.panel3.TabIndex = 151;
            // 
            // FrmConsultaFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(691, 759);
            this.Controls.Add(this.dataListadoFacturas);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lbCtdRegistros);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.pLogo);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmConsultaFactura";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listado de Facturas";
            this.Load += new System.EventHandler(this.FrmConsultaFactura_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataListadoFacturas)).EndInit();
            this.pLogo.ResumeLayout(false);
            this.pLogo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataListadoFacturas;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label lbCtdRegistros;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pLogo;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridViewTextBoxColumn cFactura;
        private System.Windows.Forms.DataGridViewTextBoxColumn cCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn cSubTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn cItbis;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTotal;
    }
}