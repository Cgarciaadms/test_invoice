namespace Test_Invoice.Views.Clientes
{
    using System;
    using System.Data;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using Test_Invoice.Controllers;

    public partial class FrmListadoClientes : Form
    {
        /// <summary>
        /// Servirá para poder mover el formulario si se deja presionado el click izquierdo del mouse en la barra del titulo
        /// </summary>
        #region Movimiento Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        public extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        public extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        #endregion

        /// <summary>
        /// Servirá para consultar los clientes creados y llenar el DataGridView
        /// </summary>
        private void ConsultaCliente()
        {
            dataListadoClientes.Rows.Clear();
            CustomersController.GetCustomers(ctdRegistros: 100, criterio: string.Empty, status: ckSoloActivos.Checked, customerType: 0);
            if (!string.IsNullOrEmpty(VariablesSesion.ProcessResult))
            {
                _ = MessageBox.Show(VariablesSesion.ProcessResult, "Invoice System", MessageBoxButtons.OK);
                return;
            }

            try
            {
                if (VariablesSesion.DtCustomers.Rows.Count > 0) 
                {
                    foreach (DataRow row in VariablesSesion.DtCustomers.Rows)
                    {
                        _ = dataListadoClientes.Rows.Add(row["Id"].ToString(),
                                                     row["CustName"].ToString(),
                                                     Convert.ToBoolean(row["Status"].ToString()),
                                                     row["CustomerTypeId"].ToString(),
                                                     row["Description"].ToString());
                    }
                }

                Formato();
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show(ex.Message, "Invoice System", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// Establecera el formato del DatagridView y establecerá la cantidad de registros devueltos en el label lbCtdRegistros
        /// </summary>
        private void Formato()
        {
            dataListadoClientes.AlternatingRowsDefaultCellStyle.BackColor = Color.LightCyan;
            lbCtdRegistros.Text = $"Cantidad de Registros: {dataListadoClientes.Rows.Count}";

        }

        public FrmListadoClientes()
        {
            InitializeComponent();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnMinimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void FrmListadoClientes_Load(object sender, EventArgs e)
        {
            ckSoloActivos.Checked = true;
            ConsultaCliente();
        }

        private void PLogo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            FrmCliente frmCliente = new FrmCliente(nuevoRegistro: true, customerId: 0, activo: true);
            frmCliente.ShowDialog();

            if (frmCliente.DialogResult == DialogResult.OK)
            {
                ConsultaCliente();
            }
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataListadoClientes.Rows.Count == 0) { return; }

                int customerId = Convert.ToInt32(dataListadoClientes.CurrentRow.Cells["cCodigo"].Value.ToString());

                FrmCliente frmCliente = new FrmCliente(nuevoRegistro: false, customerId, activo: ckSoloActivos.Checked);
                frmCliente.ShowDialog();

                if (frmCliente.DialogResult == DialogResult.OK) 
                {
                    ConsultaCliente();
                }
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show(ex.Message, "System Invoice", MessageBoxButtons.OK);
            }
        }

        private void CkSoloActivos_CheckedChanged(object sender, EventArgs e)
        {
            ConsultaCliente();
        }
    }
}
