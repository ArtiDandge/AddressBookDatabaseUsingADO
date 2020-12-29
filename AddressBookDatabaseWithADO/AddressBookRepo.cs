using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace AddressBookDatabaseWithADO
{
    public class AddressBookRepo
    {
        public static string connectionString = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = addressbook_service; Integrated Security = True";
        SqlConnection connection = new SqlConnection(connectionString);

        public void CheckConnection()
        {
            try
            {
                using (this.connection)
                {
                    connection.Open();
                    Console.WriteLine("Database Connection OK");
                }
            }
            catch
            {
                Console.WriteLine("Database not connected");
            }
            finally
            {
                this.connection.Close();
            }
        }
    }
}
