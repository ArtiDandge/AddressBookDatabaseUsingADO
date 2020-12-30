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

        public void EditContactUsingPersonName(AddressBookModel model)
        {
            try
            {
                using (this.connection)
                {
                    string updateQuery = @"UPDATE address_book SET last_name = @last_name, city = @city, state = @state, email = @email, addressbook_name = @addressbook_name, addressbook_type = @addressbook_type WHERE first_name = @first_name;";
                    SqlCommand command = new SqlCommand(updateQuery, connection);
                    command.Parameters.AddWithValue("@first_name", model.first_name);
                    command.Parameters.AddWithValue("@last_name", model.last_name);
                    command.Parameters.AddWithValue("@city", model.city);
                    command.Parameters.AddWithValue("@state", model.state);
                    command.Parameters.AddWithValue("email", model.email);
                    command.Parameters.AddWithValue("@addressbook_name", model.addressbook_name);
                    command.Parameters.AddWithValue("@addressbook_type", model.addressbook_type);

                    connection.Open();
                    command.ExecuteNonQuery();
                    Console.WriteLine("Contact Updated successfully");
                    this.connection.Close();
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

        public void DeleteContactUsingName(AddressBookModel model)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("SpDeleteContactBasedOnName", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@first_name", model.first_name);
                    connection.Open();
                    command.ExecuteNonQuery();
                    Console.WriteLine("Contact Deleted successfully");
                    connection.Close();
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

        public void RetrievePersonFromPErticulatCityOrState()
        {
            try
            {
                AddressBookModel model = new AddressBookModel();
                using (this.connection)
                {
                    using (SqlCommand command = new SqlCommand(
                        @"SELECT * FROM address_book WHERE city = 'Pune' OR state = 'Maharashtra';
                        SELECT * FROM address_book WHERE city = 'Jodhpur' OR state = 'Rajasthan'; ", connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                model.first_name = reader.GetString(0);
                                model.last_name = reader.GetString(1);
                                model.address = reader.GetString(2);
                                model.city = reader.GetString(3);
                                model.state = reader.GetString(4);
                                model.zip = reader.GetInt32(5);
                                model.phone_number = reader.GetString(6);
                                model.email = reader.GetString(7);

                                Console.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}", model.first_name, model.last_name, model.address, model.city,
                                    model.state, model.zip, model.phone_number, model.email);
                                Console.WriteLine("\n");
                            }
                            if (reader.NextResult())
                            {
                                while (reader.Read())
                                {
                                    model.first_name = reader.GetString(0);
                                    model.last_name = reader.GetString(1);
                                    model.address = reader.GetString(2);
                                    model.city = reader.GetString(3);
                                    model.state = reader.GetString(4);
                                    model.zip = reader.GetInt32(5);
                                    model.phone_number = reader.GetString(6);
                                    model.email = reader.GetString(7);

                                    Console.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}", model.first_name, model.last_name, model.address, model.city,
                                        model.state, model.zip, model.phone_number, model.email);
                                    Console.WriteLine("\n");
                                }
                            }
                        }
                    }
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

        public void AddressBookSizeByCityANDState()
        {
            try
            {
                using (this.connection)
                {
                    using (SqlCommand command = new SqlCommand(
                        @"SELECT COUNT(first_name) FROM address_book WHERE city = 'Pune' AND state = 'Maharashtra'; 
                        SELECT COUNT(first_name) FROM address_book WHERE city = 'Satara' AND state = 'Maharashtra';", connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                               var count = reader.GetInt32(0);
                               Console.WriteLine("Number of Persons belonging to City 'Pune' And State 'Maharashtra' : {0}", count);
                                Console.WriteLine("\n");
                            }
                            if (reader.NextResult())
                            {
                                while (reader.Read())
                                {
                                    var count = reader.GetInt32(0);
                                    Console.WriteLine("Number of Persons belonging to City 'Satara' And State 'Maharashtra' : {0}", count);
                                    Console.WriteLine("\n");
                                }
                            }
                        }
                    }
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

        public void SortPersonNameByCity()
        {
            try
            {
                AddressBookModel model = new AddressBookModel();
                using (this.connection)
                {
                    using (SqlCommand command = new SqlCommand(
                        @"SELECT * FROM address_book WHERE city = 'Pune' order by first_name; 
                        SELECT * FROM address_book WHERE city = 'Satara' order by first_name, last_name;", connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            Console.WriteLine("------Sorted Contact based of first name of person belonging to city Pune-----");
                            while (reader.Read())
                            {
                                model.first_name = reader.GetString(0);
                                model.last_name = reader.GetString(1);
                                model.address = reader.GetString(2);
                                model.city = reader.GetString(3);
                                model.state = reader.GetString(4);
                                model.zip = reader.GetInt32(5);
                                model.phone_number = reader.GetString(6);
                                model.email = reader.GetString(7);

                                Console.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}", model.first_name, model.last_name, model.address, model.city,
                                    model.state, model.zip, model.phone_number, model.email);
                                Console.WriteLine("\n");
                            }
                            if (reader.NextResult())
                            {
                                Console.WriteLine("------Sorted Contact based of first name of person belonging to city Satara-----");
                                while (reader.Read())
                                {
                                    model.first_name = reader.GetString(0);
                                    model.last_name = reader.GetString(1);
                                    model.address = reader.GetString(2);
                                    model.city = reader.GetString(3);
                                    model.state = reader.GetString(4);
                                    model.zip = reader.GetInt32(5);
                                    model.phone_number = reader.GetString(6);
                                    model.email = reader.GetString(7);

                                    Console.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}", model.first_name, model.last_name, model.address, model.city,
                                        model.state, model.zip, model.phone_number, model.email);
                                    Console.WriteLine("\n");
                                }
                            }
                        }
                    }
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

        public void GetNumberOfPersonsCountByType()
        {
            try
            {
                using (this.connection)
                {
                    using (SqlCommand command = new SqlCommand(
                        @"SELECT COUNT(first_name) FROM address_book WHERE addressbook_type = 'Family'; 
                        SELECT COUNT(first_name) FROM address_book WHERE addressbook_type = 'Friends';", connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var count = reader.GetInt32(0);
                                Console.WriteLine("Number of Persons belonging to Addressbook Type 'Family' : {0}", count);
                                Console.WriteLine("\n");
                            }
                            if (reader.NextResult())
                            {
                                while (reader.Read())
                                {
                                    var count = reader.GetInt32(0);
                                    Console.WriteLine("Number of Persons belonging to Addressbook Type 'Friends' : {0}", count);
                                    Console.WriteLine("\n");
                                }
                            }
                        }
                    }
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
