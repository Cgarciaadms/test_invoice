namespace Test_Invoice.Views.Facturas
{
    using Model;
    using System;
    using System.Data;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using Test_Invoice.Controllers;
    using Test_Invoice.Views.Clientes;

    public partial class FrmFacturas : Form
    {
        #region Variables

        private int customerId;
        private bool camposValidados; //Se usará como intermedio para comprobar que todos los campos requeridos han sido completados
        private bool nuevoRegistro; //Se usará para identificar cuando se quiere crear una factura o cuando se quiere editar

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
        /// Inserta una nueva linea al datagridView
        /// </summary>
        private void NuevaLinea()
        {
            dataListadoDetalle.Rows.Add(string.Empty, string.Empty, string.Empty, true, string.Empty, string.Empty, string.Empty);
        }

        /// <summary>
        /// Calcula los totales de la factura
        /// </summary>
        private void CalcularTotales()
        {
            try
            {
                decimal subTotal = 0;
                decimal itbis = 0;
                decimal total = 0;
                int ctdLineas = 0;

                foreach (DataGridViewRow row in dataListadoDetalle.Rows)
                {
                    if (!string.IsNullOrEmpty(row.Cells["cLinea"].Value.ToString()))
                    {
                        ctdLineas++;
                        subTotal += Convert.ToDecimal(row.Cells["cSubTotal"].Value.ToString().Replace("$", string.Empty));
                        itbis += Convert.ToDecimal(row.Cells["cItbis"].Value.ToString().Replace("$", string.Empty));
                        total += Convert.ToDecimal(row.Cells["cTotal"].Value.ToString().Replace("$", string.Empty));
                    }
                }

                lbCtdRegistros.Text = $"Cantidad de lienas: {ctdLineas}";
                txtSubTotal.Text = string.Format("{0:C2}", subTotal);
                txtItbis.Text = string.Format("{0:C2}", itbis);
                txtTotal.Text = string.Format("{0:C2}", total);
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show(ex.Message, "System Invoice", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Calcula los totales de una linea del DataGridView línea Subtotal, Itbis, Total
        /// </summary>
        /// <param name="index"></param>
        private void CalcularTotalLinea(int index)
        {
            try
            {
                decimal precio = Convert.ToDecimal(dataListadoDetalle.Rows[index].Cells["cPrecio"].Value.ToString().Replace("$", string.Empty));
                decimal cantidad = Convert.ToDecimal(dataListadoDetalle.Rows[index].Cells["cCantidad"].Value.ToString());
                decimal valorItbis = string.IsNullOrEmpty(txtPorItbis.Text) ? 0 : Convert.ToDecimal(txtPorItbis.Text.Replace("%", string.Empty));
                bool gravado = Convert.ToBoolean(dataListadoDetalle.Rows[index].Cells["cGravado"].Value.ToString());
                decimal subTotal = precio * cantidad;
                decimal totalItbis = !gravado ? 0 : (subTotal * (1 + (valorItbis / 100)) - subTotal);
                decimal total = subTotal + totalItbis;

                dataListadoDetalle.Rows[index].Cells["cLinea"].Value = index + 1;
                dataListadoDetalle.Rows[index].Cells["cItbis"].Value = string.Format("{0:C2}", totalItbis);
                dataListadoDetalle.Rows[index].Cells["cSubTotal"].Value = string.Format("{0:C2}", subTotal);
                dataListadoDetalle.Rows[index].Cells["cTotal"].Value = string.Format("{0:C2}", total);
                dataListadoDetalle.Rows[index].Cells["cPrecio"].Value = string.Format("{0:C2}", precio);
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show(ex.Message, "System Invoice", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Crear los objetos de la factura y el detalle y llama el InvoiceController para crear una nueva factura
        /// </summary>
        private void InsertarFactura()
        {
            Invoice invoice = new Invoice();

            try
            {
                //Tomamos los datos calculados de las cajas de texto de los totales y el id del cliente que viene desde la seleccion del mismo por el boton de búsqueda de cliente
                invoice.CustomerId = customerId;
                invoice.TotalItbis = Convert.ToDecimal(txtItbis.Text.Replace("$", string.Empty).Replace(",", string.Empty));
                invoice.SubTotal = Convert.ToDecimal(txtSubTotal.Text.Replace("$", string.Empty).Replace(",", string.Empty));
                invoice.Total = Convert.ToDecimal(txtTotal.Text.Replace("$", string.Empty).Replace(",", string.Empty));

                //Recorremos el datagridview para crear el objeto del InvoiceDetail
                foreach (DataGridViewRow row in dataListadoDetalle.Rows)
                {
                    if (!string.IsNullOrEmpty(row.Cells["cLinea"].Value.ToString()))
                    {
                        invoice.InvoiceDetail.Add(new InvoiceDetail
                        {
                            Qty = Convert.ToInt32(row.Cells["cCantidad"].Value.ToString()),
                            Price = Convert.ToDecimal(row.Cells["cPrecio"].Value.ToString().Replace("$", string.Empty).Replace(",", string.Empty)),
                            TotalItbis = Convert.ToDecimal(row.Cells["cItbis"].Value.ToString().Replace("$", string.Empty).Replace(",", string.Empty)),
                            SubTotal = Convert.ToDecimal(row.Cells["cSubTotal"].Value.ToString().Replace("$", string.Empty).Replace(",", string.Empty)),
                            Total = Convert.ToDecimal(row.Cells["cTotal"].Value.ToString().Replace("$", string.Empty).Replace(",", string.Empty))
                        });
                    }
                }

                //Llamamos el controlador
                InvoiceController.InsertarFactura(invoice);

                //Validamos la respuesta que viene desde el controlador
                if (!VariablesSesion.ProcessResult.Equals("1"))
                {
                    _ = MessageBox.Show(VariablesSesion.ProcessResult, "System Invoice", MessageBoxButtons.OK);
                    return;
                }

                //Si todo salio correcto en la insercion de los datos limpiamos los controles del formulario
                LimpiarCampos();

                _ = MessageBox.Show("Registro creado con éxito", "Invoice System", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show(ex.Message, "System Invoice", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Crear los objetos de la factura y el detalle y llama el InvoiceController para editar la factura seleccionada
        /// </summary>
        private void ActualizarFactura()
        {
            Invoice invoice = new Invoice();

            try
            {
                //Validamos si existe un número en el campo del codigo de la factura
                if (txtCodigo.Text.Equals("POR ASIGNAR"))
                {
                    return;
                }

                //Tomamos los datos calculados de las cajas de texto de los totales y el id del cliente que viene desde la seleccion del mismo por el boton de búsqueda de cliente
                invoice.Id = Convert.ToInt32(txtCodigo.Text);
                invoice.CustomerId = customerId;
                invoice.TotalItbis = Convert.ToDecimal(txtItbis.Text.Replace("$", string.Empty).Replace(",", string.Empty));
                invoice.SubTotal = Convert.ToDecimal(txtSubTotal.Text.Replace("$", string.Empty).Replace(",", string.Empty));
                invoice.Total = Convert.ToDecimal(txtTotal.Text.Replace("$", string.Empty).Replace(",", string.Empty));

                //Recorremos el datagridview para crear el objeto del InvoiceDetail
                foreach (DataGridViewRow row in dataListadoDetalle.Rows)
                {
                    if (!string.IsNullOrEmpty(row.Cells["cLinea"].Value.ToString()))
                    {
                        invoice.InvoiceDetail.Add(new InvoiceDetail
                        {
                            Qty = Convert.ToInt32(row.Cells["cCantidad"].Value.ToString()),
                            Price = Convert.ToDecimal(row.Cells["cPrecio"].Value.ToString().Replace("$", string.Empty).Replace(",", string.Empty)),
                            TotalItbis = Convert.ToDecimal(row.Cells["cItbis"].Value.ToString().Replace("$", string.Empty).Replace(",", string.Empty)),
                            SubTotal = Convert.ToDecimal(row.Cells["cSubTotal"].Value.ToString().Replace("$", string.Empty).Replace(",", string.Empty)),
                            Total = Convert.ToDecimal(row.Cells["cTotal"].Value.ToString().Replace("$", string.Empty).Replace(",", string.Empty))
                        });
                    }
                }

                //Llamamos el controlador
                InvoiceController.ActualizarFactura(invoice);

                //Validamos la respuesta que viene desde el controlador
                if (!VariablesSesion.ProcessResult.Equals("1"))
                {
                    _ = MessageBox.Show(VariablesSesion.ProcessResult, "System Invoice", MessageBoxButtons.OK);
                    return;
                }

                //Si todo salio correcto en la insercion de los datos limpiamos los controles del formulario
                LimpiarCampos();

                _ = MessageBox.Show("Registro actualizado con éxito", "Invoice System", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show(ex.Message, "System Invoice", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Limpia los controles del formulario
        /// </summary>
        private void LimpiarCampos()
        {
            customerId = 0;
            txtNombre.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            dataListadoDetalle.Rows.Clear();
            txtCodigo.Text = "POR ASIGNAR";
            dtpFecha.Value = DateTime.Now;
            dtpHora.Value = DateTime.Now;
            lbCtdRegistros.Text = "Cantidad de lineas: 0";
            txtSubTotal.Text = string.Format("{0:C2}", 0);
            txtItbis.Text = string.Format("{0:C2}", 0);
            txtTotal.Text = string.Format("{0:C2}", 0);
            decimal porcentaje = 18;
            txtPorItbis.Text = string.Format("{0:P}", porcentaje / 100);
            camposValidados = false;
            nuevoRegistro = true;
            btnGuardar.Text = "Guardarr";

            NuevaLinea();
            dataListadoDetalle.CurrentCell = dataListadoDetalle.CurrentRow.Cells["cCantidad"];
        }

        /// <summary>
        /// Valida que los campos necesarios para crear una factura sean debidamente completados
        /// </summary>
        private void ValidarCampos()
        {
            camposValidados = false;

            //Validamos que se haya establecido e cliente
            if (customerId == 0 || string.IsNullOrEmpty(txtNombre.Text))
            {
                _ = MessageBox.Show("El cliente es obligatorio", "System Invoice", MessageBoxButtons.OK);
                return;
            }

            //Validamos que haya al menos un item en el detalle
            if ((dataListadoDetalle.Rows.Count == 1 && string.IsNullOrEmpty(dataListadoDetalle.CurrentRow.Cells["cLinea"].Value.ToString())) ||
                dataListadoDetalle.Rows.Count == 0 || Convert.ToDecimal(txtSubTotal.Text.Replace("$", string.Empty).Replace(",", string.Empty)) == 0)
            {
                _ = MessageBox.Show("No existen lineas para el detalle", "System Invoice", MessageBoxButtons.OK);
                return;
            }

            camposValidados = true;
        }

        /// <summary>
        /// Llama el controlador de Invoice para obtener la informacion de la factura seleccionada
        /// </summary>
        private void InvoiceInfo(int invoiceNo)
        {
            try
            {
                //Lamamos el controlador
                InvoiceController.GetInvoicesInfo(invoiceNo);

                //Validamos si no hubo algun error en la peticion de la información
                if (!string.IsNullOrEmpty(VariablesSesion.ProcessResult))
                {
                    _ = MessageBox.Show(VariablesSesion.ProcessResult, "System Invoice", MessageBoxButtons.OK);
                    return;
                }

                //Validamos se viene los datos tanto del Header como del detalle
                if (VariablesSesion.DtInvoiceHeader.Rows.Count > 0 && VariablesSesion.DtInvoiceDetail.Rows.Count > 0)
                {
                    nuevoRegistro = false;
                    btnGuardar.Text = "Editar";
                    dataListadoDetalle.Select();

                    //Llenamos la cabecera con sus respectivas informaciones
                    foreach (DataRow row in VariablesSesion.DtInvoiceHeader.Rows)
                    {
                        customerId = Convert.ToInt32(row["CustomerId"].ToString());
                        txtNombre.Text = row["CustName"].ToString();
                        txtDireccion.Text = row["Adress"].ToString();
                        txtSubTotal.Text = row["SubTotal"].ToString();
                        txtItbis.Text = row["TotalItbis"].ToString();
                        txtTotal.Text = row["Total"].ToString();
                        txtCodigo.Text = row["Invoice"].ToString();
                    }

                    //Limpiamos el DataGridView
                    dataListadoDetalle.Rows.Clear();

                    //Llenamos el DatagridView con el Datelle
                    foreach (DataRow row in VariablesSesion.DtInvoiceDetail.Rows)
                    {
                        _ = dataListadoDetalle.Rows.Add(row["Linea"].ToString(),
                                                    row["Cantidad"].ToString(),
                                                    row["Precio"].ToString(),
                                                    true,
                                                    row["SubTotal"].ToString(),
                                                    row["TotalItbis"].ToString(),
                                                    row["Total"].ToString());
                    }

                    //Establecemos el foco en la celda de la cantidad
                    dataListadoDetalle.CurrentCell = dataListadoDetalle.CurrentRow.Cells["cCantidad"];
                }


                lbCtdRegistros.Text = $"Cantidad de lineas: {dataListadoDetalle.Rows.Count}";
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show(ex.Message, "System Invoice", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public FrmFacturas()
        {
            InitializeComponent();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PLogo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        private void FrmFacturas_Load(object sender, EventArgs e)
        {
            nuevoRegistro = true;
            NuevaLinea();
            //Se establece el numero de la linea en 1
            dataListadoDetalle.CurrentRow.Cells["cLinea"].Value = string.Empty;

            //Se le establece el foco al celda de cantidad
            dataListadoDetalle.CurrentCell = dataListadoDetalle.CurrentRow.Cells["cCantidad"];
            lbCtdRegistros.Text = "Cantidad de lineas: 0";

            //De entrada se entablece el foco en el DataGridView
            dataListadoDetalle.Select();

            //Le damos el formato deseado a las cajas de las fechas
            dtpFecha.CustomFormat = "dd/MM/yyyy";
            dtpHora.CustomFormat = "hh:mm tt";
        }

        /// <summary>
        /// Evento que permite que solo se digiten numero en las celdas de cantidad y precio del dataGridView
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

        /// <summary>
        /// Valida en el datagridview si las teclas presionadas san numeros
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataListadoDetalle_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                e.Control.KeyPress -= new KeyPressEventHandler(SoloNumeros_KeyPress);
                if (dataListadoDetalle.CurrentCell == dataListadoDetalle.CurrentRow.Cells["cPrecio"] ||
                    dataListadoDetalle.CurrentCell == dataListadoDetalle.CurrentRow.Cells["cCantidad"])
                {
                    if (e.Control is TextBox txtDatos)
                    {
                        txtDatos.KeyPress += new KeyPressEventHandler(SoloNumeros_KeyPress);
                    }
                }
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show(ex.Message, "System Invoice", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataListadoDetalle_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //Validamos en cual celda nos encontramos

                //Si nos encontramos en la celda de la cantidad
                if (dataListadoDetalle.CurrentCell == dataListadoDetalle.CurrentRow.Cells["cCantidad"])
                {
                    //Si la celda de precio no esta vacía calculamos en precio por la cantidad digitada
                    if (!string.IsNullOrEmpty(dataListadoDetalle.CurrentRow.Cells["cPrecio"].Value.ToString()))
                    {
                        int index = dataListadoDetalle.CurrentRow.Index;

                        //Si no se digitó ningun valor en la celda establecemos el valor por defecto en 1
                        if (string.IsNullOrEmpty(dataListadoDetalle.CurrentRow.Cells["cCantidad"].Value.ToString()))
                        {
                            dataListadoDetalle.CurrentRow.Cells["cPrecio"].Value = 1;
                        }

                        CalcularTotalLinea(index);
                        CalcularTotales();

                    }
                    else
                    {
                        dataListadoDetalle.CurrentCell = dataListadoDetalle.CurrentRow.Cells["cPrecio"];
                    }

                    return;
                }

                //Si nos encontramos en la celda del precio
                if (dataListadoDetalle.CurrentCell == dataListadoDetalle.CurrentRow.Cells["cPrecio"])
                {
                    //Validamos que la celda de la cantidad tenga un valor de lo contrario lo establecemos en uno (1)
                    if (string.IsNullOrEmpty(dataListadoDetalle.CurrentRow.Cells["cCantidad"].Value.ToString()))
                    {
                        dataListadoDetalle.CurrentRow.Cells["cCantidad"].Value = 1;
                    }

                    //Validamos que la celda del precio tenga un valor
                    if (string.IsNullOrEmpty(dataListadoDetalle.CurrentRow.Cells["cPrecio"].Value.ToString()))
                    {
                        _ = MessageBox.Show("Debe de digitar un precio", "Invoice System", MessageBoxButtons.OK);
                        return;
                    }

                    CalcularTotalLinea(dataListadoDetalle.CurrentRow.Index);

                    //Se calcula el total de la factura
                    CalcularTotales();

                    //Creamos una nueva linea para poder seguir creando items
                    NuevaLinea();
                    SendKeys.Send("{down}");
                    dataListadoDetalle.CurrentCell = dataListadoDetalle.CurrentRow.Cells["cCantidad"];
                }

                //Si nos encontramos en la celda de Gravado
                if (dataListadoDetalle.CurrentCell == dataListadoDetalle.CurrentRow.Cells["cGravado"])
                {
                    if (string.IsNullOrEmpty(dataListadoDetalle.CurrentRow.Cells["cCantidad"].Value.ToString()) &&
                        string.IsNullOrEmpty(dataListadoDetalle.CurrentRow.Cells["cPrecio"].Value.ToString()))
                    {
                        return;
                    }


                    //Validamos que la celda de la cantidad tenga un valor de lo contrario lo establecemos en uno (1)
                    if (string.IsNullOrEmpty(dataListadoDetalle.CurrentRow.Cells["cCantidad"].Value.ToString()))
                    {
                        dataListadoDetalle.CurrentRow.Cells["cCantidad"].Value = 1;
                    }

                    //Validamos que la celda del precio tenga un valor
                    if (string.IsNullOrEmpty(dataListadoDetalle.CurrentRow.Cells["cPrecio"].Value.ToString()))
                    {
                        _ = MessageBox.Show("Debe de digitar un precio", "Invoice System", MessageBoxButtons.OK);
                        return;
                    }

                    CalcularTotalLinea(dataListadoDetalle.CurrentRow.Index);

                    //Se calcula el total de la factura
                    CalcularTotales();
                }
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show(ex.Message, "System Invoice", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataListadoDetalle_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataListadoDetalle.CurrentRow.Cells["cLinea"].Value == null) { return; }

                int lastIndex = dataListadoDetalle.Rows.Count - 1;

                if (string.IsNullOrEmpty(dataListadoDetalle.Rows[lastIndex].Cells["cLinea"].Value.ToString()) && !string.IsNullOrEmpty(dataListadoDetalle.CurrentRow.Cells["cLinea"].Value.ToString()))
                {
                    dataListadoDetalle.Rows.RemoveAt(lastIndex);
                }
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show(ex.Message, "System Invoice", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtPorItbis_KeyDown(object sender, KeyEventArgs e)
        {
            //Si se presiona la tecla enter de la caja de texto de txtPorItbis se procedera a los totales de las lineas en base al nuevo porcentaje de Itbis
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    decimal porcentaje = string.IsNullOrEmpty(txtPorItbis.Text) ? 0 : Convert.ToDecimal(txtPorItbis.Text);
                    txtPorItbis.Text = string.Format("{0:P}", porcentaje / 100);

                    foreach (DataGridViewRow row in dataListadoDetalle.Rows)
                    {
                        if (!string.IsNullOrEmpty(row.Cells["cLinea"].Value.ToString()))
                        {
                            //Si hay un numero de linea se calcula el total
                            CalcularTotalLinea(row.Index);
                        }
                    }

                    CalcularTotales();
                }
                catch (Exception ex)
                {
                    _ = MessageBox.Show(ex.Message, "System Invoice", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DataListadoDetalle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                int index = dataListadoDetalle.Rows.Count - 1;

                if (!string.IsNullOrEmpty(dataListadoDetalle.CurrentRow.Cells["cCantidad"].Value.ToString()) &&
                    !string.IsNullOrEmpty(dataListadoDetalle.CurrentRow.Cells["cPrecio"].Value.ToString()) &&
                    index == dataListadoDetalle.CurrentRow.Index)
                {
                    CalcularTotalLinea(dataListadoDetalle.CurrentRow.Index);
                    CalcularTotales();
                    NuevaLinea();
                    SendKeys.Send("{down}");
                }
            }

            if (e.KeyCode == Keys.Up)
            {
                CalcularTotales();
                int index = dataListadoDetalle.Rows.Count - 1;

                if (index == dataListadoDetalle.CurrentRow.Index && string.IsNullOrEmpty(dataListadoDetalle.CurrentRow.Cells["cLinea"].Value.ToString()))
                {
                    dataListadoDetalle.Rows.RemoveAt(index);

                    if (dataListadoDetalle.Rows.Count == 0)
                    {
                        NuevaLinea();
                    }

                    if (index > 1)
                    {
                        SendKeys.Send("{down}");
                    }

                    dataListadoDetalle.CurrentCell = dataListadoDetalle.CurrentRow.Cells["cCantidad"];
                }
            }

            if (e.KeyCode == Keys.Down)
            {

                int lastIndex = dataListadoDetalle.Rows.Count - 1;
                if (lastIndex == dataListadoDetalle.CurrentRow.Index && !
                    string.IsNullOrEmpty(dataListadoDetalle.CurrentRow.Cells["cLinea"].Value.ToString()))
                {
                    CalcularTotales();
                    NuevaLinea();
                    SendKeys.Send("{down}");
                    dataListadoDetalle.CurrentCell = dataListadoDetalle.CurrentRow.Cells["cCantidad"];
                    return;
                }

                CalcularTotales();

            }

            if (e.KeyCode == Keys.Delete)
            {
                dataListadoDetalle.Rows.RemoveAt(dataListadoDetalle.CurrentRow.Index);

                int lastIndex = dataListadoDetalle.Rows.Count - 1;


                if (lastIndex == -1)
                {
                    NuevaLinea();
                    dataListadoDetalle.CurrentCell = dataListadoDetalle.CurrentRow.Cells["cCantidad"];
                    return;
                }

                //Calculamos los totales de las lineas para que se reasignen los numeros de lineas y el total de la factura
                foreach (DataGridViewRow row in dataListadoDetalle.Rows)
                {
                    if (!string.IsNullOrEmpty(row.Cells["cLinea"].Value.ToString()))
                    {
                        CalcularTotalLinea(row.Index);
                    }
                }

                CalcularTotales();
            }
        }

        private void BtnBusqueda_Click(object sender, EventArgs e)
        {
            //Limpiamos las cajas de texto y las variables
            customerId = 0;
            txtNombre.Text = string.Empty;
            txtDireccion.Text = string.Empty;

            FrmConsultaClientes frmClientes = new FrmConsultaClientes();
            frmClientes.ShowDialog();

            //Si el el usuario hizo click en el boton aceptar
            if (frmClientes.DialogResult == DialogResult.OK)
            {
                //Si el cliente no está inactivo se lanzará un error
                if (!frmClientes.Activo)
                {
                    _ = MessageBox.Show("No puede seleccionar un cliente inactivo", "System Invoice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                customerId = frmClientes.CustomerId;
                txtNombre.Text = frmClientes.CustomerName;
                txtDireccion.Text = frmClientes.CustomerAdress;
            }

            dataListadoDetalle.Select();
        }

        /// <summary>
        /// Con este evento limpiamos todos los controles del formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            //Se limpian los controles del formualario
            LimpiarCampos();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            ValidarCampos();
            if (!camposValidados) { return; }

            //Validamos si se creará o si seeditará una factura
            if (nuevoRegistro) { InsertarFactura(); }
            else { ActualizarFactura(); }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            //Se limpian los campos por si se cancela la búsqueda los controles queden con sus valores por defecto
            LimpiarCampos();

            FrmConsultaFactura frmFactura = new FrmConsultaFactura();
            frmFactura.ShowDialog();

            if (frmFactura.DialogResult == DialogResult.OK)
            {
                InvoiceInfo(frmFactura.InvoiceNo);
            }
        }
    }
}
