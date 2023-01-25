namespace Test_Invoice
{
    using System.Data;

    /// <summary>
    /// Esta clase servirá para compartir datos entre los controladores y las vistas
    /// </summary>
    public static class VariablesSesion
    {
        private static DataTable _dtCustomers;
        private static DataTable _dtCustomersTypes;
        private static DataTable _dtInvoiceHeader;
        private static DataTable _dtInvoiceDetail;
        private static string _processResult;

        public static DataTable DtCustomers { get => _dtCustomers; set => _dtCustomers = value; }

        //Se usará para capturar los errores de las consultas ejecutadas en la base de datos y se llevará el mensaje a las vistas
        public static string ProcessResult { get => _processResult; set => _processResult = value; }
        public static DataTable DtCustomersTypes { get => _dtCustomersTypes; set => _dtCustomersTypes = value; }
        public static DataTable DtInvoiceHeader { get => _dtInvoiceHeader; set => _dtInvoiceHeader = value; }
        public static DataTable DtInvoiceDetail { get => _dtInvoiceDetail; set => _dtInvoiceDetail = value; }
    }
}
