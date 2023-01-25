namespace Test_Invoice.Controllers
{
    using Model;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public static class InvoiceDetailController
    {
        /// <summary>
        /// Valida si la respuesta de la ejecuvion de los procedimientos es un numero (Si devuelve un numero la ejecución fue exitosa)
        /// </summary>
        /// <param name="texto"></param>
        /// <returns></returns>
        private static bool IsNumeric(string texto)
        {
            try
            {
                char[] respuesta = texto.ToCharArray();
                foreach (char caracter in respuesta)
                {
                    if (!char.IsDigit(caracter) && caracter != '-' && caracter != '.' && caracter != ',')
                    {
                        return false;
                    }
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Inserta el detalle de la Factura
        /// </summary>
        /// <param name="detalle"></param>
        /// <param name="sqlCon"></param>
        /// <param name="sqlTran"></param>
        public static void InsertarDelalle(InvoiceDetail detalle, ref SqlConnection sqlCon, ref SqlTransaction sqlTran)
        {
            VariablesSesion.ProcessResult = string.Empty;

            try
            {
                SqlCommand sqlCommand = new SqlCommand
                {
                    Connection = sqlCon,
                    Transaction = sqlTran,
                    CommandText = "sp_Insert_Invoice_Detail",
                    CommandType = CommandType.StoredProcedure
                };

                sqlCommand.Parameters.Add("@Id", SqlDbType.Int).Direction = ParameterDirection.Output;
                sqlCommand.Parameters.Add("@CustomerId", SqlDbType.Int).Value = detalle.CustomerId;
                sqlCommand.Parameters.Add("@Qty", SqlDbType.Int).Value = detalle.Qty;
                sqlCommand.Parameters.Add("@Price", SqlDbType.Decimal).Value = detalle.Price;
                sqlCommand.Parameters.Add("@TotalItbis", SqlDbType.Decimal).Value = detalle.TotalItbis;
                sqlCommand.Parameters.Add("@SubTotal", SqlDbType.Decimal).Value = detalle.SubTotal;
                sqlCommand.Parameters.Add("@Total", SqlDbType.Decimal).Value = detalle.Total;

                VariablesSesion.ProcessResult = IsNumeric(sqlCommand.ExecuteNonQuery().ToString()) ? "1" : "0";
            }
            catch (Exception ex)
            {
                VariablesSesion.ProcessResult = ex.Message;
            }
        }

        /// <summary>
        /// Elimina el detalle de una factura en especifico para poder insertar un nuevo detalle si la factura fue modificada
        /// </summary>
        /// <param name="detaill"></param>
        /// <param name="sqlCon"></param>
        /// <param name="sqlTran"></param>
        public static void EliminarDetalle(InvoiceDetail detail, ref SqlConnection sqlCon, ref SqlTransaction sqlTran)
        {
            VariablesSesion.ProcessResult = string.Empty;
            string query = "DELETE InvoiceDetail WHERE CustomerId = @Invoice";

            try
            {
                SqlCommand sqlCommand = new SqlCommand
                {
                    Connection = sqlCon,
                    Transaction = sqlTran,
                    CommandText = query,
                    CommandType = CommandType.Text
                };

                sqlCommand.Parameters.Add("@Invoice", SqlDbType.Int).Value = detail.CustomerId;

                VariablesSesion.ProcessResult = IsNumeric(sqlCommand.ExecuteNonQuery().ToString()) ? "1" : "0";
            }
            catch (Exception ex)
            {
                VariablesSesion.ProcessResult = ex.Message;
            }
        }
    }
}
