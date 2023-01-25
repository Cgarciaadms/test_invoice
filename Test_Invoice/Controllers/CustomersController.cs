namespace Test_Invoice.Controllers
{
    using System;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    using Model;

    public class CustomersController
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
        /// Obtiene los datos del cliente
        /// </summary>
        /// <param name="ctdRegistros"></param>
        /// <param name="criterio"></param>
        /// <param name="status"></param>
        /// <param name="customerType"></param>
        public static void GetCustomers(int ctdRegistros, string criterio, bool status, int customerType)
        {
            VariablesSesion.DtCustomers = new DataTable("dt");
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
                    CommandText = "sp_Search_Customer",
                    CommandType = CommandType.StoredProcedure
                };

                sqlCommand.Parameters.Add("@CtdRegistros", sqlDbType: SqlDbType.Int).Value = ctdRegistros;
                sqlCommand.Parameters.Add("@Criterio", sqlDbType: SqlDbType.VarChar, size: 70).Value = criterio;
                sqlCommand.Parameters.Add("@Status", sqlDbType: SqlDbType.Bit).Value = status;
                sqlCommand.Parameters.Add("@CustomerIdType", sqlDbType: SqlDbType.Int).Value = customerType;

                //Se llena la tabla con los datos obtenidos de la consulta
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                adapter.Fill(VariablesSesion.DtCustomers);

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
        /// Obtiene los Tipos de clientes
        /// </summary>
        public static void GetCustomerType()
        {
            VariablesSesion.DtCustomersTypes = new DataTable("dt");
            VariablesSesion.ProcessResult = string.Empty;
            string query = "SELECT Id, Description FROM CustomerTypes";

            //Creamos la conxión a la base de datos, la cadena de conexión se guarda en el App.config
            SqlConnection sqlCon = new SqlConnection { ConnectionString = ConfigurationManager.ConnectionStrings["TestInvConn"].ConnectionString };

            try
            {
                sqlCon.Open();

                //Esto nos servirá para enviar los parametros y ejecutar la consulta
                SqlCommand sqlCommand = new SqlCommand
                {
                    Connection = sqlCon,
                    CommandText = query,
                    CommandType = CommandType.Text
                };

                //Se llena la tabla con los datos obtenidos de la consulta
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                adapter.Fill(VariablesSesion.DtCustomersTypes);

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
        /// Crea un nuevo cliente
        /// </summary>
        /// <param name="customer"></param>
        public static void CreateCustomer(Customers customer)
        {
            VariablesSesion.ProcessResult = string.Empty;

            //Creamos la conxión a la base de datos, la cadena de conexión se guarda en el App.config
            SqlConnection sqlCon = new SqlConnection { ConnectionString = ConfigurationManager.ConnectionStrings["TestInvConn"].ConnectionString };
            SqlTransaction sqlTran = null;

            try
            {
                sqlCon.Open();
                sqlTran = sqlCon.BeginTransaction();

                //Esto nos servirá para enviar los parametros y ejecutar la consulta
                SqlCommand sqlCommand = new SqlCommand
                {
                    Connection = sqlCon,
                    Transaction = sqlTran,
                    CommandText = "sp_Insert_Customer",
                    CommandType = CommandType.StoredProcedure
                };

                sqlCommand.Parameters.Add("@Id", sqlDbType: SqlDbType.Int).Direction = ParameterDirection.Output;
                sqlCommand.Parameters.Add("@Custname", sqlDbType: SqlDbType.VarChar, size: 70).Value = customer.CustName;
                sqlCommand.Parameters.Add("@Adress", sqlDbType: SqlDbType.VarChar, size: 120).Value = customer.Adress;
                sqlCommand.Parameters.Add("@Status", sqlDbType: SqlDbType.Bit).Value = customer.Status;
                sqlCommand.Parameters.Add("@CustomerTypeId", sqlDbType: SqlDbType.Int).Value = customer.CustomerTypeId;

                //Si es un 
                VariablesSesion.ProcessResult = IsNumeric(sqlCommand.ExecuteNonQuery().ToString()) ? "1" : "0";
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
        /// Actualiza un cliente en especifico
        /// </summary>
        /// <param name="customer"></param>
        public static void UpdateCustomer(Customers customer)
        {
            VariablesSesion.ProcessResult = string.Empty;

            //Creamos la conxión a la base de datos, la cadena de conexión se guarda en el App.config
            SqlConnection sqlCon = new SqlConnection { ConnectionString = ConfigurationManager.ConnectionStrings["TestInvConn"].ConnectionString };
            SqlTransaction sqlTran = null;

            try
            {
                sqlCon.Open();
                sqlTran = sqlCon.BeginTransaction();

                //Esto nos servirá para enviar los parametros y ejecutar la consulta
                SqlCommand sqlCommand = new SqlCommand
                {
                    Connection = sqlCon,
                    Transaction = sqlTran,
                    CommandText = "sp_Update_Customer",
                    CommandType = CommandType.StoredProcedure
                };

                sqlCommand.Parameters.Add("@Id", sqlDbType: SqlDbType.Int).Value = customer.Id;
                sqlCommand.Parameters.Add("@Custname", sqlDbType: SqlDbType.VarChar, size: 70).Value = customer.CustName;
                sqlCommand.Parameters.Add("@Adress", sqlDbType: SqlDbType.VarChar, size: 120).Value = customer.Adress;
                sqlCommand.Parameters.Add("@Status", sqlDbType: SqlDbType.Bit).Value = customer.Status;
                sqlCommand.Parameters.Add("@CustomerTypeId", sqlDbType: SqlDbType.Int).Value = customer.CustomerTypeId;

                VariablesSesion.ProcessResult = IsNumeric(sqlCommand.ExecuteNonQuery().ToString()) ? "1" : "0";
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
