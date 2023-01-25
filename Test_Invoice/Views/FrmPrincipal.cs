namespace Test_Invoice.Views
{
    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using Test_Invoice.Views.Clientes;
    using Test_Invoice.Views.Facturas;

    public partial class FrmPrincipal : Form
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
        /// Servirá para poder cambiar el tamaño al formulario
        /// </summary>
        #region Form Resize

        private const int cGrip = 25;      // Grip size
        private const int cCaption = 32;   // Caption bar height;

        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rc = new Rectangle(this.ClientSize.Width - cGrip, this.ClientSize.Height - cGrip, cGrip, cGrip);
            ControlPaint.DrawSizeGrip(e.Graphics, this.BackColor, rc);
            rc = new Rectangle(0, 0, this.ClientSize.Width, cCaption);
            e.Graphics.FillRectangle(Brushes.DarkBlue, rc);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x84)
            {  // Trap WM_NCHITTEST
                Point pos = new Point(m.LParam.ToInt32());
                pos = this.PointToClient(pos);
                if (pos.Y < cCaption)
                {
                    m.Result = (IntPtr)2;  // HTCAPTION
                    return;
                }
                if (pos.X >= this.ClientSize.Width - cGrip && pos.Y >= this.ClientSize.Height - cGrip)
                {
                    m.Result = (IntPtr)17; // HTBOTTOMRIGHT
                    return;
                }
            }
            base.WndProc(ref m);
        }

        #endregion

        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void PLogo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            string mensaje = "¿Está seguro que desea salir de la aplicación?";
            if (MessageBox.Show(mensaje, "Invoice System", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void BtnMinimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void BtnCustomers_Click(object sender, EventArgs e)
        {
            FrmListadoClientes frmClientes = new FrmListadoClientes();
            Hide();
            frmClientes.ShowDialog();
            Show();
        }

        private void BtnInvoice_Click(object sender, EventArgs e)
        {
            FrmFacturas frmFactura = new FrmFacturas();
            Hide();
            frmFactura.ShowDialog();
            Show();
        }
    }
}