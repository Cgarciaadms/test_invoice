
namespace Test_Invoice.Views.Clientes
{
    partial class FrmConsultaClientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConsultaClientes));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pLogo = new System.Windows.Forms.Panel();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ckActivo = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbCustomerType = new System.Windows.Forms.ComboBox();
            this.btnBusqueda = new System.Windows.Forms.Button();
            this.txtCtdRegistros = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.lbCtdRegistros = new System.Windows.Forms.Label();
            this.dataListadoClientes = new System.Windows.Forms.DataGridView();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.cCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cActivo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cCustomerType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCostumerTypeDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDireccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pLogo.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataListadoClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(106)))), ((int)(((byte)(228)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(10, 751);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(671, 10);
            this.panel3.TabIndex = 7;
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
            this.pLogo.TabIndex = 5;
            this.pLogo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PLogo_MouseDown);
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
            this.label1.Size = new System.Drawing.Size(144, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Listado de Clientes";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(106)))), ((int)(((byte)(228)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 39);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(10, 722);
            this.panel2.TabIndex = 6;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(106)))), ((int)(((byte)(228)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(681, 39);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(10, 722);
            this.panel4.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ckActivo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbCustomerType);
            this.groupBox1.Controls.Add(this.btnBusqueda);
            this.groupBox1.Controls.Add(this.txtCtdRegistros);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtBusqueda);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(16, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(657, 71);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Critério de Búsqueda";
            // 
            // ckActivo
            // 
            this.ckActivo.AutoSize = true;
            this.ckActivo.Location = new System.Drawing.Point(6, 41);
            this.ckActivo.Name = "ckActivo";
            this.ckActivo.Size = new System.Drawing.Size(56, 17);
            this.ckActivo.TabIndex = 21;
            this.ckActivo.Text = "Activo";
            this.ckActivo.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(212, 43);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Tipo de Cliente";
            // 
            // cbCustomerType
            // 
            this.cbCustomerType.FormattingEnabled = true;
            this.cbCustomerType.Location = new System.Drawing.Point(295, 40);
            this.cbCustomerType.Name = "cbCustomerType";
            this.cbCustomerType.Size = new System.Drawing.Size(121, 21);
            this.cbCustomerType.TabIndex = 18;
            this.cbCustomerType.DropDown += new System.EventHandler(this.CbCustomerType_DropDown);
            this.cbCustomerType.DropDownClosed += new System.EventHandler(this.CbCustomerType_DropDownClosed);
            // 
            // btnBusqueda
            // 
            this.btnBusqueda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBusqueda.Image = ((System.Drawing.Image)(resources.GetObject("btnBusqueda.Image")));
            this.btnBusqueda.Location = new System.Drawing.Point(422, 16);
            this.btnBusqueda.Name = "btnBusqueda";
            this.btnBusqueda.Size = new System.Drawing.Size(21, 21);
            this.btnBusqueda.TabIndex = 17;
            this.btnBusqueda.UseVisualStyleBackColor = true;
            this.btnBusqueda.Click += new System.EventHandler(this.BtnBusqueda_Click);
            // 
            // txtCtdRegistros
            // 
            this.txtCtdRegistros.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCtdRegistros.Location = new System.Drawing.Point(569, 16);
            this.txtCtdRegistros.Margin = new System.Windows.Forms.Padding(2);
            this.txtCtdRegistros.MaxLength = 10;
            this.txtCtdRegistros.Name = "txtCtdRegistros";
            this.txtCtdRegistros.Size = new System.Drawing.Size(83, 20);
            this.txtCtdRegistros.TabIndex = 16;
            this.txtCtdRegistros.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCtdRegistros.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SoloNumeros_KeyPress);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(461, 20);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Registros a devolver";
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.Location = new System.Drawing.Point(6, 16);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(410, 20);
            this.txtBusqueda.TabIndex = 0;
            this.txtBusqueda.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtBusqueda_KeyDown);
            // 
            // lbCtdRegistros
            // 
            this.lbCtdRegistros.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbCtdRegistros.AutoSize = true;
            this.lbCtdRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCtdRegistros.Location = new System.Drawing.Point(17, 726);
            this.lbCtdRegistros.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbCtdRegistros.Name = "lbCtdRegistros";
            this.lbCtdRegistros.Size = new System.Drawing.Size(75, 13);
            this.lbCtdRegistros.TabIndex = 147;
            this.lbCtdRegistros.Text = "lbCtdRegistros";
            // 
            // dataListadoClientes
            // 
            this.dataListadoClientes.AllowUserToAddRows = false;
            this.dataListadoClientes.AllowUserToDeleteRows = false;
            this.dataListadoClientes.AllowUserToResizeColumns = false;
            this.dataListadoClientes.AllowUserToResizeRows = false;
            this.dataListadoClientes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataListadoClientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataListadoClientes.BackgroundColor = System.Drawing.Color.White;
            this.dataListadoClientes.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataListadoClientes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataListadoClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataListadoClientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cCodigo,
            this.cNombre,
            this.cActivo,
            this.cCustomerType,
            this.cCostumerTypeDesc,
            this.cDireccion});
            this.dataListadoClientes.Location = new System.Drawing.Point(16, 125);
            this.dataListadoClientes.MultiSelect = false;
            this.dataListadoClientes.Name = "dataListadoClientes";
            this.dataListadoClientes.ReadOnly = true;
            this.dataListadoClientes.RowHeadersWidth = 25;
            this.dataListadoClientes.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataListadoClientes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataListadoClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataListadoClientes.Size = new System.Drawing.Size(657, 591);
            this.dataListadoClientes.TabIndex = 146;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptar.Location = new System.Drawing.Point(541, 720);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(132, 25);
            this.btnAceptar.TabIndex = 148;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // cCodigo
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.cCodigo.DefaultCellStyle = dataGridViewCellStyle2;
            this.cCodigo.FillWeight = 50F;
            this.cCodigo.HeaderText = "Código";
            this.cCodigo.Name = "cCodigo";
            this.cCodigo.ReadOnly = true;
            this.cCodigo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cCodigo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // cNombre
            // 
            this.cNombre.FillWeight = 150F;
            this.cNombre.HeaderText = "Nombre";
            this.cNombre.Name = "cNombre";
            this.cNombre.ReadOnly = true;
            this.cNombre.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cNombre.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // cActivo
            // 
            this.cActivo.FillWeight = 70F;
            this.cActivo.HeaderText = "Activo";
            this.cActivo.Name = "cActivo";
            this.cActivo.ReadOnly = true;
            this.cActivo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // cCustomerType
            // 
            this.cCustomerType.HeaderText = "CostumerTypeIId";
            this.cCustomerType.Name = "cCustomerType";
            this.cCustomerType.ReadOnly = true;
            this.cCustomerType.Visible = false;
            // 
            // cCostumerTypeDesc
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.cCostumerTypeDesc.DefaultCellStyle = dataGridViewCellStyle3;
            this.cCostumerTypeDesc.HeaderText = "Costume Type";
            this.cCostumerTypeDesc.Name = "cCostumerTypeDesc";
            this.cCostumerTypeDesc.ReadOnly = true;
            // 
            // cDireccion
            // 
            this.cDireccion.HeaderText = "Direccion";
            this.cDireccion.Name = "cDireccion";
            this.cDireccion.ReadOnly = true;
            this.cDireccion.Visible = false;
            // 
            // FrmConsultaClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(691, 761);
            this.Controls.Add(this.lbCtdRegistros);
            this.Controls.Add(this.dataListadoClientes);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.pLogo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmConsultaClientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listado de Clientes";
            this.Load += new System.EventHandler(this.FrmConsultaClientes_Load);
            this.pLogo.ResumeLayout(false);
            this.pLogo.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataListadoClientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel pLogo;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBusqueda;
        private System.Windows.Forms.TextBox txtCtdRegistros;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBusqueda;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbCustomerType;
        private System.Windows.Forms.Label lbCtdRegistros;
        private System.Windows.Forms.DataGridView dataListadoClientes;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.CheckBox ckActivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNombre;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cActivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cCustomerType;
        private System.Windows.Forms.DataGridViewTextBoxColumn cCostumerTypeDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDireccion;
    }
}