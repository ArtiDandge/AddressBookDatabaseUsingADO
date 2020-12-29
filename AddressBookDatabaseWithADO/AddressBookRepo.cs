using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace AddressBookDatabaseWithADO
{
    public class AddressBookRepo
    {
        public static string connectionString = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = addressbook_service; Integrated Security = True";
        SqlConnection connection = new SqlConnection(connectionString);

        public bool AddContact(AddressBookModel model)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("SpAddContactInAddressBook", this.connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@first_name", model.first_name);
                    command.Parameters.AddWithValue("@last_name", model.last_name);
                    command.Parameters.AddWithValue("@address", model.address);
                    command.Parameters.AddWithValue("@city", model.city);
                    command.Parameters.AddWithValue("@state", model.state);
                    command.Parameters.AddWithValue("@zip", model.zip);
                    command.Parameters.AddWithValue("@phone_number", model.phone_number);
                    command.Parameters.AddWithValue("@email", model.email);
                    command.Parameters.AddWithValue("@addressbook_name", model.addressbook_name);
                    command.Parameters.AddWithValue("@addressbook_type", model.addressbook_type);
                    this.connection.Open();
                    var result = command.ExecuteNonQuery();
                    this.connection.Close();
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }
    }
}
