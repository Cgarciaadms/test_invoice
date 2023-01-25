namespace Test_Invoice.Views.Facturas
{
    using System;
    using System.Data;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using Test_Invoice.Controllers;

    public partial class FrmConsultaFactura : Form
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

        #region Atributos y Propiedades

        private int _invoiceNo;

        //Se usará para pasar la factura seleccionada al formulario padre
        public int InvoiceNo { get => _invoiceNo; set => _invoiceNo = value; }

        #endregion

        /// <summary>
        /// Llama el controller para obtener los invoices creados
        /// </summary>
        private void ConsultaFactura()
        {
            //Se llama el controlador
            InvoiceController.GetInvoices();

            //Validamos si ocuurrio un error en la petición de los datos
            if (!string.IsNullOrEmpty(VariablesSesion.ProcessResult))
            {
                _ = MessageBox.Show(VariablesSesion.ProcessResult, "System Invoice", MessageBoxButtons.OK);
                return;
            }

            //Si tenemos resultados en llenamos el DatagridView
            if (VariablesSesion.DtInvoiceHeader.Rows.Count > 0)
            {
                foreach (DataRow row in VariablesSesion.DtInvoiceHeader.Rows)
                {
                    dataListadoFacturas.Rows.Add(row["Invoice"].ToString(),
                                                 row["CustName"].ToString(),
                                                 row["SubTotal"].ToString(),
                                                 row["TotalItbis"].ToString(),
                                                 row["Total"].ToString());
                }
            }

            lbCtdRegistros.Text = $"Cantidad de lineas: {dataListadoFacturas.Rows.Count}";
        }

        public FrmConsultaFactura()
        {
            InitializeComponent();
        }

        private void FrmConsultaFactura_Load(object sender, EventArgs e)
        {
            //Valida si la altura del formulario es mayor a la altura de la resolusión de la pantalla y de ser true iguala las alturas
            if (Height > Screen.PrimaryScreen.WorkingArea.Size.Height)
            {
                Height = Screen.PrimaryScreen.WorkingArea.Size.Height;
            }

            ConsultaFactura();
            dataListadoFacturas.Select();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataListadoFacturas.Rows.Count == 0) { return; }

                InvoiceNo = Convert.ToInt32(dataListadoFacturas.CurrentRow.Cells["cFactura"].Value.ToString());
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show(ex.Message, "Invoice System", MessageBoxButtons.OK);
            }
        }

        private void PLogo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }
    }
}
