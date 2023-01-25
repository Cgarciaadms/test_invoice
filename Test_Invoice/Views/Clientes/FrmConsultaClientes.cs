namespace Test_Invoice.Views.Clientes
{
    using System;
    using System.Data;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using Test_Invoice.Controllers;

    public partial class FrmConsultaClientes : Form
    {
        #region Variables

        int customerType;

        #endregion

        #region Atributos y Propiedades

        private int _customerId;
        private string _customerName;
        private string _customerAdress;
        private bool _activo;

        public int CustomerId { get => _customerId; set => _customerId = value; }
        public string CustomerName { get => _customerName; set => _customerName = value; }
        public string CustomerAdress { get => _customerAdress; set => _customerAdress = value; }
        public bool Activo { get => _activo; set => _activo = value; }

        #endregion

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
        /// Establecera el formato del DatagridView y establecerá la cantidad de registros devueltos en el label lbCtdRegistros
        /// </summary>
        private void Formato()
        {
            dataListadoClientes.AlternatingRowsDefaultCellStyle.BackColor = Color.LightCyan;
            lbCtdRegistros.Text = $"Cantidad de Registros: {dataListadoClientes.Rows.Count}";

        }

        /// <summary>
        /// Consulta los clientes creados. Por defecto solo mostrará los activos
        /// </summary>
        private void ConsultaCliente(string criterio)
        {
            int ctdRegistros = string.IsNullOrEmpty(txtCtdRegistros.Text) ? 0 : Convert.ToInt32(txtCtdRegistros.Text);

            dataListadoClientes.Rows.Clear();
            CustomersController.GetCustomers(ctdRegistros, criterio: criterio, status: ckActivo.Checked, customerType: customerType);
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
                                                     row["Description"].ToString(),
                                                     row["Adress"].ToString());
                    }

                    Formato();
                }
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show(ex.Message, "Invoice System", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// Consulta los CustumerTypes
        /// </summary>
        private void ConsultaCustomerType()
        {
            CustomersController.GetCustomerType();
            if (!string.IsNullOrEmpty(VariablesSesion.ProcessResult))
            {
                _ = MessageBox.Show(VariablesSesion.ProcessResult, "System Invoice", MessageBoxButtons.OK);
                return;
            }

            if (VariablesSesion.DtCustomersTypes.Rows.Count > 0)
            {
                cbCustomerType.DataSource = VariablesSesion.DtCustomersTypes;
                cbCustomerType.DisplayMember = "Description";
                cbCustomerType.ValueMember = "Id";
            }
        }

        public FrmConsultaClientes()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Evento que permite que solo se digiten numero en la caja de texto de txtCtdRegistros
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && (sender as TextBox).Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            //Si existen datos en el datagridview se tomara el id del cliente
            if (dataListadoClientes.Rows.Count > 0)
            {
                CustomerId = Convert.ToInt32(dataListadoClientes.CurrentRow.Cells["cCodigo"].Value.ToString());
                CustomerName = dataListadoClientes.CurrentRow.Cells["cNombre"].Value.ToString();
                CustomerAdress = dataListadoClientes.CurrentRow.Cells["cDireccion"].Value.ToString();
                Activo = Convert.ToBoolean(dataListadoClientes.CurrentRow.Cells["cActivo"].Value.ToString());
                DialogResult = DialogResult.OK;
            }

            Close();
        }

        private void PLogo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        private void FrmConsultaClientes_Load(object sender, EventArgs e)
        {
            //Valida si la altura del formulario es mayor a la altura de la resolusión de la pantalla y de ser true iguala las alturas
            if (Height > Screen.PrimaryScreen.WorkingArea.Size.Height)
            {
                Height = Screen.PrimaryScreen.WorkingArea.Size.Height;
            }

            ckActivo.Checked = true;
            txtBusqueda.Select();
            txtCtdRegistros.Text = "100";

            //De entrada se cargaran los primeros 100 clientes
            ConsultaCliente(criterio: string.Empty);
        }

        private void TxtBusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                //Si la caja de texto de la busqueda no está vacia se procede con la busqueda de lo que se encuentra digitado en la misma
                if (!string.IsNullOrEmpty(txtBusqueda.Text))
                {
                    ConsultaCliente(txtBusqueda.Text);
                }
            }
        }

        private void BtnBusqueda_Click(object sender, EventArgs e)
        {
            //Establecemos la caja de texto en blanco y procedemos a buscar todos los registros de los clientes
            ConsultaCliente(txtBusqueda.Text = string.Empty);
        }

        private void CbCustomerType_DropDown(object sender, EventArgs e)
        {
            ConsultaCustomerType();
        }

        /// <summary>
        /// Cuando se cierra el DropDown se le asignará el valor seleccionado a la variable CustumerType la cual servirá en el filtro dela busqueda los clientes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CbCustomerType_DropDownClosed(object sender, EventArgs e)
        {
            customerType = Convert.ToInt32(cbCustomerType.SelectedValue.ToString());
        }
    }
}
