
namespace Test_Invoice.Views.Clientes
{
    partial class FrmListadoClientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmListadoClientes));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pLogo = new System.Windows.Forms.Panel();
            this.btnMinimizar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dataListadoClientes = new System.Windows.Forms.DataGridView();
            this.lbCtdRegistros = new System.Windows.Forms.Label();
            this.ttInfo = new System.Windows.Forms.ToolTip(this.components);
            this.cCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cRnc = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cCustomerType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCostumerTypeDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ckSoloActivos = new System.Windows.Forms.CheckBox();
            this.panel2.SuspendLayout();
            this.pLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataListadoClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(106)))), ((int)(((byte)(228)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(127, 549);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(631, 10);
            this.panel3.TabIndex = 11;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(106)))), ((int)(((byte)(228)))));
            this.panel2.Controls.Add(this.ckSoloActivos);
            this.panel2.Controls.Add(this.btnEditar);
            this.panel2.Controls.Add(this.btnNuevo);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 39);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(127, 520);
            this.panel2.TabIndex = 10;
            // 
            // btnEditar
            // 
            this.btnEditar.FlatAppearance.BorderSize = 0;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.ForeColor = System.Drawing.Color.White;
            this.btnEditar.Image = ((System.Drawing.Image)(resources.GetObject("btnEditar.Image")));
            this.btnEditar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditar.Location = new System.Drawing.Point(12, 125);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(96, 47);
            this.btnEditar.TabIndex = 13;
            this.btnEditar.Text = "Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttInfo.SetToolTip(this.btnEditar, "Editar cliente Seleccionado");
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.BtnEditar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.FlatAppearance.BorderSize = 0;
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.ForeColor = System.Drawing.Color.White;
            this.btnNuevo.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevo.Image")));
            this.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevo.Location = new System.Drawing.Point(12, 66);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(96, 47);
            this.btnNuevo.TabIndex = 12;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttInfo.SetToolTip(this.btnNuevo, "Crear nuevo cliente");
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.BtnNuevo_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(106)))), ((int)(((byte)(228)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(758, 39);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(10, 520);
            this.panel4.TabIndex = 12;
            // 
            // pLogo
            // 
            this.pLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.pLogo.Controls.Add(this.btnMinimizar);
            this.pLogo.Controls.Add(this.btnCerrar);
            this.pLogo.Controls.Add(this.label1);
            this.pLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pLogo.ForeColor = System.Drawing.Color.Black;
            this.pLogo.Location = new System.Drawing.Point(0, 0);
            this.pLogo.Name = "pLogo";
            this.pLogo.Size = new System.Drawing.Size(768, 39);
            this.pLogo.TabIndex = 9;
            this.pLogo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PLogo_MouseDown);
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimizar.FlatAppearance.BorderSize = 0;
            this.btnMinimizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimizar.Image = ((System.Drawing.Image)(resources.GetObject("btnMinimizar.Image")));
            this.btnMinimizar.Location = new System.Drawing.Point(706, 8);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(25, 25);
            this.btnMinimizar.TabIndex = 3;
            this.ttInfo.SetToolTip(this.btnMinimizar, "Minimizar");
            this.btnMinimizar.UseVisualStyleBackColor = true;
            this.btnMinimizar.Click += new System.EventHandler(this.BtnMinimizar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrar.Image")));
            this.btnCerrar.Location = new System.Drawing.Point(737, 7);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(25, 25);
            this.btnCerrar.TabIndex = 2;
            this.ttInfo.SetToolTip(this.btnCerrar, "Cerrar");
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
            // dataListadoClientes
            // 
            this.dataListadoClientes.AllowUserToAddRows = false;
            this.dataListadoClientes.AllowUserToDeleteRows = false;
            this.dataListadoClientes.AllowUserToResizeColumns = false;
            this.dataListadoClientes.AllowUserToResizeRows = false;
            this.dataListadoClientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataListadoClientes.BackgroundColor = System.Drawing.Color.White;
            this.dataListadoClientes.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataListadoClientes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dataListadoClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataListadoClientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cCodigo,
            this.cNombre,
            this.cRnc,
            this.cCustomerType,
            this.cCostumerTypeDesc});
            this.dataListadoClientes.Location = new System.Drawing.Point(133, 45);
            this.dataListadoClientes.MultiSelect = false;
            this.dataListadoClientes.Name = "dataListadoClientes";
            this.dataListadoClientes.ReadOnly = true;
            this.dataListadoClientes.RowHeadersWidth = 25;
            this.dataListadoClientes.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataListadoClientes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataListadoClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataListadoClientes.Size = new System.Drawing.Size(619, 485);
            this.dataListadoClientes.TabIndex = 147;
            this.ttInfo.SetToolTip(this.dataListadoClientes, "Haga doble click para editar el cliente");
            // 
            // lbCtdRegistros
            // 
            this.lbCtdRegistros.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbCtdRegistros.AutoSize = true;
            this.lbCtdRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCtdRegistros.Location = new System.Drawing.Point(133, 533);
            this.lbCtdRegistros.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbCtdRegistros.Name = "lbCtdRegistros";
            this.lbCtdRegistros.Size = new System.Drawing.Size(75, 13);
            this.lbCtdRegistros.TabIndex = 148;
            this.lbCtdRegistros.Text = "lbCtdRegistros";
            // 
            // cCodigo
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.cCodigo.DefaultCellStyle = dataGridViewCellStyle8;
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
            // cRnc
            // 
            this.cRnc.FillWeight = 70F;
            this.cRnc.HeaderText = "Activo";
            this.cRnc.Name = "cRnc";
            this.cRnc.ReadOnly = true;
            this.cRnc.Resizable = System.Windows.Forms.DataGridViewTriState.False;
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
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.cCostumerTypeDesc.DefaultCellStyle = dataGridViewCellStyle9;
            this.cCostumerTypeDesc.HeaderText = "Costume Type";
            this.cCostumerTypeDesc.Name = "cCostumerTypeDesc";
            this.cCostumerTypeDesc.ReadOnly = true;
            // 
            // ckSoloActivos
            // 
            this.ckSoloActivos.AutoSize = true;
            this.ckSoloActivos.ForeColor = System.Drawing.Color.White;
            this.ckSoloActivos.Location = new System.Drawing.Point(12, 209);
            this.ckSoloActivos.Name = "ckSoloActivos";
            this.ckSoloActivos.Size = new System.Drawing.Size(76, 30);
            this.ckSoloActivos.TabIndex = 14;
            this.ckSoloActivos.Text = "Ver solo \r\nlos activos";
            this.ckSoloActivos.UseVisualStyleBackColor = true;
            this.ckSoloActivos.CheckedChanged += new System.EventHandler(this.CkSoloActivos_CheckedChanged);
            // 
            // FrmListadoClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(768, 559);
            this.Controls.Add(this.lbCtdRegistros);
            this.Controls.Add(this.dataListadoClientes);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.pLogo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmListadoClientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listado de Clientes";
            this.Load += new System.EventHandler(this.FrmListadoClientes_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pLogo.ResumeLayout(false);
            this.pLogo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataListadoClientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel pLogo;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnMinimizar;
        private System.Windows.Forms.DataGridView dataListadoClientes;
        private System.Windows.Forms.Label lbCtdRegistros;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.ToolTip ttInfo;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.DataGridViewTextBoxColumn cCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNombre;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cRnc;
        private System.Windows.Forms.DataGridViewTextBoxColumn cCustomerType;
        private System.Windows.Forms.DataGridViewTextBoxColumn cCostumerTypeDesc;
        private System.Windows.Forms.CheckBox ckSoloActivos;
    }
}