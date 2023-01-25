namespace Test_Invoice.Views.Clientes
{
    using System;
    using System.Data;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using Test_Invoice.Controllers;
    using Model;

    public partial class FrmCliente : Form
    {
        #region Variables

        private bool nuevoRegistro;
        private int customerId;
        private int customerType;
        private bool camposValidados;
        private bool activo;

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

        private void CreateCustomer()
        {
            try
            {
                //Definimos las propiedades para crear el objeto tipo Customer
                string nombre = txtNombre.Text;
                string direccion = txtDireccion.Text;
                bool activo = ckActivo.Checked;

                Customers customer = new Customers 
                {
                    CustName = nombre,
                    Adress = direccion,
                    Status = activo,
                    CustomerTypeId = customerType
                };

                CustomersController.CreateCustomer(customer);

                //Si hubo algun problema en la insercion del cliente nos desplegará el mensaje en la pantalla
                if (!string.IsNullOrEmpty(VariablesSesion.ProcessResult) &&
                    !VariablesSesion.ProcessResult.Equals("1")) 
                {
                    _ = MessageBox.Show(VariablesSesion.ProcessResult, "System Invoice", MessageBoxButtons.OK);
                }

            }
            catch (Exception ex)
            {
                _ = MessageBox.Show(ex.Message, "System Invoice", MessageBoxButtons.OK);
            }
        }

        private void UpdateCustomer()
        {
            try
            {
                //Definimos las propiedades para crear el objeto tipo Customer
                string nombre = txtNombre.Text;
                string direccion = txtDireccion.Text;
                bool activo = ckActivo.Checked;

                Customers customer = new Customers
                {
                    Id = customerId,
                    CustName = nombre,
                    Adress = direccion,
                    Status = activo,
                    CustomerTypeId = customerType
                };

                CustomersController.UpdateCustomer(customer);

                //Si hubo algun problema en la insercion del cliente nos desplegará el mensaje en la pantalla
                if (!string.IsNullOrEmpty(VariablesSesion.ProcessResult) &&
                    !VariablesSesion.ProcessResult.Equals("1"))
                {
                    _ = MessageBox.Show(VariablesSesion.ProcessResult, "System Invoice", MessageBoxButtons.OK);
                }

            }
            catch (Exception ex)
            {
                _ = MessageBox.Show(ex.Message, "System Invoice", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// Valida los componentes del formulario no esten vacios
        /// </summary>
        private void ValidarCampos()
        {
            camposValidados = false;

            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                _ = MessageBox.Show("El nombre del cliente es obligatorio", "System Invoice", MessageBoxButtons.OK);
                txtNombre.Select();
                return;
            }

            if (string.IsNullOrEmpty(txtDireccion.Text))
            {
                _ = MessageBox.Show("La dirección del cliente es obligatoria", "System Invoice", MessageBoxButtons.OK);
                txtDireccion.Select();
                return;
            }

            if (customerType == 0)
            {
                _ = MessageBox.Show("Debe de definir el tipo de cliente", "System Invoice", MessageBoxButtons.OK);
                txtDireccion.Select();
                return;
            }

            btnGuardar.DialogResult = DialogResult.OK;
            camposValidados = true;
        }

        /// <summary>
        /// Servirá para consultar los clientes creados y llenar los controles del formulario
        /// </summary>
        private void ConsultaCliente()
        {
            //Se envia el customer id y el estado para que traiga solo el cliente especificado 
            CustomersController.GetCustomers(ctdRegistros: 100, criterio: customerId.ToString(), status: activo, customerType: 0);
            if (!string.IsNullOrEmpty(VariablesSesion.ProcessResult))
            {
                _ = MessageBox.Show(VariablesSesion.ProcessResult, "Invoice System", MessageBoxButtons.OK);
                return;
            }

            try
            {
                if (VariablesSesion.DtCustomers.Rows.Count > 0)
                {
                    foreach(DataRow row in VariablesSesion.DtCustomers.Rows)
                    {
                        txtCodigo.Text = row["Id"].ToString();
                        txtNombre.Text = row["CustName"].ToString();
                        txtDireccion.Text = row["Adress"].ToString();
                        ckActivo.Checked = Convert.ToBoolean(row["Status"].ToString());
                        customerType = Convert.ToInt32(row["CustomerTypeId"].ToString());
                    }

                    //Como solo traerá un registro se establece en el comboBox el CustomerType
                    cbCustomerType.DataSource = VariablesSesion.DtCustomers;
                    cbCustomerType.DisplayMember = "Description";
                    cbCustomerType.ValueMember = "CustomerTypeId";
                }
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show(ex.Message, "Invoice System", MessageBoxButtons.OK);
            }
        }

        public FrmCliente(bool nuevoRegistro, int customerId, bool activo)
        {
            InitializeComponent();
            this.nuevoRegistro = nuevoRegistro;
            this.customerId = customerId;
            this.activo = activo; //Se recibe este argumento para enviarlo a la busqueda y traiga el cliente por el ID y por el status
        }

        private void PLogo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Establecerá los controles a sus valores por defecto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            txtCodigo.Text = "POR ASIGNAR";
            txtNombre.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            ckActivo.Checked = false;

            DataTable dtType = new DataTable("dt");
            dtType.Columns.Add("Id", typeof(string));
            dtType.Columns.Add("Descripcion", typeof(string));

            cbCustomerType.DataSource = dtType;
            cbCustomerType.DisplayMember = "Descripcion";
            cbCustomerType.ValueMember = "Id";

            nuevoRegistro = true;
            customerId = 0;
            camposValidados = false;
        }

        private void CbCustomerType_DropDown(object sender, EventArgs e)
        {
            ConsultaCustomerType();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            ValidarCampos();
            if(!camposValidados) { return; }

            if (nuevoRegistro)
            {
                CreateCustomer();
            }
            else
            {
                UpdateCustomer();
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void CbCustomerType_DropDownClosed(object sender, EventArgs e)
        {
            customerType = Convert.ToInt32(cbCustomerType.SelectedValue.ToString());
        }

        private void FrmCliente_Load(object sender, EventArgs e)
        {
            txtNombre.Select();

            if (!nuevoRegistro) 
            {
                txtCodigo.Text = customerId.ToString();
                ConsultaCliente();
            }
            else
            {
                ckActivo.Checked = true;
            }
        }
    }
}
