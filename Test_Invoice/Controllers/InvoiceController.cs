namespace Test_Invoice.Controllers
{
    using Model;
    using System;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;

    public static class InvoiceController
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
        /// Obtiene la informacion de la factura seleccionada
        /// </summary>
        public static void GetInvoicesInfo(int invoiceNo)
        {
            VariablesSesion.DtInvoiceHeader = new DataTable("dtHeader");
            VariablesSesion.DtInvoiceDetail = new DataTable("dtDetails");
            VariablesSesion.ProcessResult = string.Empty;

            //Creamos la conxión a la base de datos, la cadena de conexión se guarda en el App.config
            SqlConnection sqlCon = new SqlConnection { ConnectionString = ConfigurationManager.ConnectionStrings["TestInvConn"].ConnectionString };

            try
            {
                sqlCon.Open();

                //Esto nos servirá para enviar los parametros y ejecutar la consulta
                SqlCommand sqlCommand = new SqlCommand
                {
                    Connection = sqlCon,
                    CommandText = "sp_Invoice_Info",
                    CommandType = CommandType.StoredProcedure
                };

                sqlCommand.Parameters.Add("@Invoice", SqlDbType.Int).Value = invoiceNo;

                //LLenamos la tabla con los datos obtenidos
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                adapter.Fill(VariablesSesion.DtInvoiceHeader);

                sqlCommand.Dispose();
                adapter.Dispose();

                //Instanciamos el comando de SQL para traer los datos del detalle
                sqlCommand = new SqlCommand
                {
                    Connection = sqlCon,
                    CommandText = "sp_Invoice_Detail_Info",
                    CommandType = CommandType.StoredProcedure
                };

                sqlCommand.Parameters.Add("@Invoice", SqlDbType.Int).Value = invoiceNo;

                //LLenamos la tabla con los datos obtenidos
                adapter = new SqlDataAdapter(sqlCommand);
                adapter.Fill(VariablesSesion.DtInvoiceDetail);

                sqlCommand.Dispose();
                adapter.Dispose();
            }
            catch (Exception ex)
            {
                VariablesSesion.ProcessResult = ex.Message;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open) { sqlCon.Close(); }
                sqlCon.Dispose();
            }
        }

        /// <summary>
        /// Consulta las facturas realizadas
        /// </summary>
        public static void GetInvoices()
        {
            VariablesSesion.DtInvoiceHeader = new DataTable("dtHeader");
            VariablesSesion.ProcessResult = string.Empty;

            //Creamos la conxión a la base de datos, la cadena de conexión se guarda en el App.config
            SqlConnection sqlCon = new SqlConnection { ConnectionString = ConfigurationManager.ConnectionStrings["TestInvConn"].ConnectionString };

            try
            {
                sqlCon.Open();

                //Esto nos servirá para enviar los parametros y ejecutar la consulta
                SqlCommand sqlCommand = new SqlCommand
                {
                    Connection = sqlCon,
                    CommandText = "sp_Invoice_Info",
                    CommandType = CommandType.StoredProcedure
                };

                sqlCommand.Parameters.Add("@Invoice", SqlDbType.Int).Value = 0; //Se envía 0 para que se obtengan todos los registros gusradados en la base de datos

                //Se llena la tabla con los datos obtenidos de la consulta
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                _ = adapter.Fill(VariablesSesion.DtInvoiceHeader);

                sqlCommand.Dispose();
                adapter.Dispose();
            }
            catch (Exception ex)
            {
                VariablesSesion.ProcessResult = ex.Message;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open) { sqlCon.Close(); }
                sqlCon.Dispose();
            }
        }

        /// <summary>
        /// Crea una nueva factura.
        /// </summary>
        /// <param name="invoice"></param>
        public static void InsertarFactura(Invoice invoice)
        {
            VariablesSesion.ProcessResult = string.Empty;
            SqlConnection sqlCon = new SqlConnection { ConnectionString = ConfigurationManager.ConnectionStrings["TestInvConn"].ConnectionString };
            SqlTransaction sqlTran = null;
            int invoiceId = 0;

            try
            {
                //Abrimos la conexion
                sqlCon.Open();

                //Empezamos la transaccion
                sqlTran = sqlCon.BeginTransaction();

                //Esto nos servirá para enviar los parametros y ejecutar la consulta
                SqlCommand sqlCommand = new SqlCommand
                {
                    Connection = sqlCon,
                    Transaction = sqlTran,
                    CommandText = "sp_Insert_Invoice",
                    CommandType = CommandType.StoredProcedure
                };

                //Creamos los parametros
                sqlCommand.Parameters.Add("@Id", SqlDbType.Int).Direction = ParameterDirection.Output;
                sqlCommand.Parameters.Add("@CustomerId", SqlDbType.Int).Value = invoice.CustomerId;
                sqlCommand.Parameters.Add("@TotalItbis", SqlDbType.Int).Value = invoice.TotalItbis;
                sqlCommand.Parameters.Add("@SubTotal", SqlDbType.Int).Value = invoice.SubTotal;
                sqlCommand.Parameters.Add("@Total", SqlDbType.Int).Value = invoice.Total;

                //Ejecutamos la consulta
                VariablesSesion.ProcessResult = IsNumeric(sqlCommand.ExecuteNonQuery().ToString()) ? "1" : "0";

                if (VariablesSesion.ProcessResult.Equals("1"))
                {
                    invoiceId = Convert.ToInt32(sqlCommand.Parameters["@Id"].Value);

                    foreach (InvoiceDetail detail in invoice.InvoiceDetail)
                    {
                        detail.CustomerId = invoiceId;
                        InvoiceDetailController.InsertarDelalle(detail, ref sqlCon, ref sqlTran);

                        if (!VariablesSesion.ProcessResult.Equals("1")) { break; }
                    }
                }
            }
            catch (Exception ex)
            {
                VariablesSesion.ProcessResult = ex.Message;
            }
            finally
            {
                //Si el resultado de la ejecucion de la inserción es correcto se hace el commit de la transacción
                if (VariablesSesion.ProcessResult.Equals("1")) { sqlTran.Commit(); }
                else { sqlTran.Rollback(); }

                if (sqlCon.State == ConnectionState.Open) { sqlCon.Close(); }
                sqlCon.Dispose();
            }
        }

        /// <summary>
        /// Edita una factura creada
        /// </summary>
        /// <param name="invoice"></param>
        public static void ActualizarFactura(Invoice invoice)
        {
            VariablesSesion.ProcessResult = string.Empty;
            SqlConnection sqlCon = new SqlConnection { ConnectionString = ConfigurationManager.ConnectionStrings["TestInvConn"].ConnectionString };
            SqlTransaction sqlTran = null;

            try
            {
                //Abrimos la conexion
                sqlCon.Open();

                //Empezamos la transaccion
                sqlTran = sqlCon.BeginTransaction();

                //Esto nos servirá para enviar los parametros y ejecutar la consulta
                SqlCommand sqlCommand = new SqlCommand
                {
                    Connection = sqlCon,
                    Transaction = sqlTran,
                    CommandText = "sp_Update_Invoice",
                    CommandType = CommandType.StoredProcedure
                };

                //Creamos los parametros
                sqlCommand.Parameters.Add("@Id", SqlDbType.Int).Value = invoice.Id;
                sqlCommand.Parameters.Add("@CustomerId", SqlDbType.Int).Value = invoice.CustomerId;
                sqlCommand.Parameters.Add("@TotalItbis", SqlDbType.Int).Value = invoice.TotalItbis;
                sqlCommand.Parameters.Add("@SubTotal", SqlDbType.Int).Value = invoice.SubTotal;
                sqlCommand.Parameters.Add("@Total", SqlDbType.Int).Value = invoice.Total;

                //Ejecutamos la consulta
                VariablesSesion.ProcessResult = IsNumeric(sqlCommand.ExecuteNonQuery().ToString()) ? "1" : "0";

                if (VariablesSesion.ProcessResult.Equals("1"))
                {
                    InvoiceDetail invDetail = new InvoiceDetail
                    {
                        CustomerId = invoice.Id
                    };
                    InvoiceDetailController.EliminarDetalle(invDetail, ref sqlCon, ref sqlTran);

                    //Si no hubo problemas en la eliminación del detalle pasamos a insertar el nuevo detalle de la factura
                    if (VariablesSesion.ProcessResult.Equals("1"))
                    {
                        foreach (InvoiceDetail detail in invoice.InvoiceDetail)
                        {
                            detail.CustomerId = invoice.Id;
                            InvoiceDetailController.InsertarDelalle(detail, ref sqlCon, ref sqlTran);

                            if (!VariablesSesion.ProcessResult.Equals("1")) { break; }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                VariablesSesion.ProcessResult = ex.Message;
            }
            finally
            {
                //Si el resultado de la ejecucion de la inserción es correcto se hace el commit de la transacción
                if (VariablesSesion.ProcessResult.Equals("1")) { sqlTran.Commit(); }
                else { sqlTran.Rollback(); }

                if (sqlCon.State == ConnectionState.Open) { sqlCon.Close(); }
                sqlCon.Dispose();
            }
        }
    }
}
