/*
 * Name: Bilal Ahmad
 * Date: Feb 13, 2020
 * Purpose: Database access and password encryption methods
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Text;

namespace Team5_Workshop5.Models
{
    public static class CustomerModel
    {
        const string connectionStringName = "TravelExperts";
        /// <summary>
        /// Registers a new Customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public static Customer RegisterCustomer(Customer customer)
        {
            try
            {
                using (SqlConnection conn = MyConnection.GetConnection(connectionStringName))
                {
                    string query = "INSERT into Customers(CustFirstName,CustLastName,CustAddress,CustCity,CustProv,CustPostal," +
                                    "CustCountry,CustHomePhone,CustBusPhone,CustEmail,UserID,Password) " +
                                    "Values(@CustFirstName,@CustLastName,@CustAddress,@CustCity,@CustProv,@CustPostal," +
                                    "@CustCountry,@CustHomePhone,@CustBusPhone,@CustEmail,@UserID,@Password)";
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        conn.Open();
                        //not null
                        command.Parameters.AddWithValue("CustFirstName", customer.CustFirstName);
                        command.Parameters.AddWithValue("CustLastName", customer.CustLastName);
                        command.Parameters.AddWithValue("CustAddress", customer.CustAddress);
                        command.Parameters.AddWithValue("CustCity", customer.CustCity);
                        command.Parameters.AddWithValue("CustProv", customer.CustProv);
                        command.Parameters.AddWithValue("CustPostal", customer.CustPostal);
                        command.Parameters.AddWithValue("CustCountry", customer.CustCountry);

                        //home phone
                        if (customer.CustHomePhone == null)
                        {
                            command.Parameters.AddWithValue("CustHomePhone", "                  ");
                        }
                        else
                        {
                            command.Parameters.AddWithValue("CustHomePhone", customer.CustHomePhone);
                        }
                        //business phone
                        if (customer.CustBusPhone == null)
                        {
                            command.Parameters.AddWithValue("CustBusPhone", "                  ");
                        }
                        else
                        {
                            command.Parameters.AddWithValue("CustBusPhone", customer.CustBusPhone);
                        }
                        //email
                        if (customer.CustEmail == null)
                        {
                            command.Parameters.AddWithValue("CustEmail", "                                                  ");
                        }
                        else
                        {
                            command.Parameters.AddWithValue("CustEmail", customer.CustEmail);
                        }
                        command.Parameters.AddWithValue("UserID", customer.UserID);
                        command.Parameters.AddWithValue("Password", customer.Password);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return customer;
        }

        internal static string retrievePasswordHash(string userID)
        {
            string Password = "";
            string SelectString = "Select Password from Customers where UserID = @UserID";
            try
            {
                using (SqlConnection connection = MyConnection.GetConnection(connectionStringName))
                {
                    using (SqlCommand command = new SqlCommand(SelectString, connection))
                    {
                        command.Parameters.AddWithValue("UserID", userID);
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Password = reader[0].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Password;
        }
        /// <summary>
        /// Checks if the credentials are correct during login
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public static Customer Authenticate(Customer customer)
        {
            int count = 0;
            try
            {
                using (SqlConnection conn = MyConnection.GetConnection(connectionStringName))
                {
                    string query = "SELECT CustFirstName,CustLastName,UserID,Password from Customers " +
                        "WHERE UserID = @UserID AND Password = @Password";

                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        conn.Open();
                        command.Parameters.AddWithValue("UserID", customer.UserID);
                        command.Parameters.AddWithValue("Password", customer.Password);

                        SqlDataReader reader;

                        reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            count++;
                            customer.CustFirstName = (string)reader[0];
                            customer.CustLastName = (string)reader[1];
                            customer.UserID = (string)reader[2];
                            customer.Password = (string)reader[3];
                        }
                        reader.Close();
                    }
                }
                if (count == 0) // for comparison in the controller
                {
                    return new Customer { UserID = "", Password = "" };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return customer;

        }
        /// <summary>
        /// Retrieves CustomerID to ensure the proper customer is updated
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static int RetrieveCustomerID(string userID)
        {
            int customerID = 0;
            Customer customer = new Customer();
            string SelectString = "Select customerID from Customers where UserID = @UserID";
            try
            {
                using (SqlConnection connection = MyConnection.GetConnection(connectionStringName))
                {
                    using (SqlCommand command = new SqlCommand(SelectString, connection))
                    {
                        command.Parameters.AddWithValue("UserID", userID);
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            customerID = Convert.ToInt32(reader[0]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return customerID;
        }
        /// <summary>
        /// Updates bio details for existing customer
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="customerID"></param>
        /// <returns></returns>
        public static Customer UpdateCustomer(Customer customer, int customerID)
        {
            try
            {
                using (SqlConnection conn = MyConnection.GetConnection(connectionStringName))
                {
                    string query = "Update Customers Set CustFirstName = @CustFirstName,CustLastName=@CustLastName,CustAddress=@CustAddress, " +
                                    "CustCity=@CustCity,CustProv =@CustProv,CustCountry=@CustCountry,CustHomePhone=@CustHomePhone,CustBusPhone=@CustBusPhone, " +
                                    "CustEmail=@CustEmail,UserID=@UserID,[Password]=@Password where CustomerId = @CustomerID";
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        conn.Open();
                        command.Parameters.AddWithValue("CustomerID", customerID);
                        command.Parameters.AddWithValue("CustFirstName", customer.CustFirstName);
                        command.Parameters.AddWithValue("CustLastName", customer.CustLastName);
                        command.Parameters.AddWithValue("CustAddress", customer.CustAddress);
                        command.Parameters.AddWithValue("CustCity", customer.CustCity);
                        command.Parameters.AddWithValue("CustProv", customer.CustProv);
                        command.Parameters.AddWithValue("CustPostal", customer.CustPostal);
                        command.Parameters.AddWithValue("CustCountry", customer.CustCountry);
                        //home phone
                        if (customer.CustHomePhone == null)
                        {
                            command.Parameters.AddWithValue("CustHomePhone", "                  ");
                        }
                        else
                        {
                            command.Parameters.AddWithValue("CustHomePhone", customer.CustHomePhone);
                        }
                        //business phone
                        if (customer.CustBusPhone == null)
                        {
                            command.Parameters.AddWithValue("CustBusPhone", "                  ");
                        }
                        else
                        {
                            command.Parameters.AddWithValue("CustBusPhone", customer.CustBusPhone);
                        }
                        //email
                        if (customer.CustEmail == null)
                        {
                            command.Parameters.AddWithValue("CustEmail", "                                                  ");
                        }
                        else
                        {
                            command.Parameters.AddWithValue("CustEmail", customer.CustEmail);
                        }
                        command.Parameters.AddWithValue("UserID", customer.UserID);
                        command.Parameters.AddWithValue("Password", customer.Password);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return customer;
        }
        /// <summary>
        /// Gets all the customer info for one customer so that it can be edited or updated
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public static Customer GetCustomerInfo(string UserID)
        {
            Customer customer = new Customer();
            string SelectString = "Select CustFirstName,CustLastName,CustAddress,CustCity,CustProv,CustPostal,CustCountry, " +
                                    "CustHomePhone,CustBusPhone,CustEmail,UserID from Customers where UserID = @UserID";
            try
            {
                using (SqlConnection connection = MyConnection.GetConnection(connectionStringName))
                {
                    using (SqlCommand command = new SqlCommand(SelectString, connection))
                    {
                        command.Parameters.AddWithValue("UserID", UserID);
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            decimal result = 0;
                            customer.CustFirstName = reader[0].ToString();
                            customer.CustLastName = reader[1].ToString();
                            customer.CustAddress = reader[2].ToString();
                            customer.CustCity = reader[3].ToString();
                            customer.CustProv = reader[4].ToString();
                            customer.CustPostal = reader[5].ToString();
                            customer.CustCountry = reader[6].ToString();
                            if (!decimal.TryParse(reader[7].ToString(), out result))
                            {
                                customer.CustHomePhone = null;
                            }
                            else
                            {
                                customer.CustHomePhone = reader[7].ToString();
                            }
                            if (!decimal.TryParse(reader[8].ToString(), out result))
                            {
                                customer.CustBusPhone = null;
                            }
                            else
                            {
                                customer.CustBusPhone = reader[8].ToString();
                            }
                            if ((reader[9].ToString()).Contains("@"))
                            {
                                customer.CustEmail = reader[9].ToString();
                            }
                            else
                            {
                                customer.CustEmail = null;
                            }

                            customer.UserID = reader[10].ToString();
                        }

                    }


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return customer;
        }

    }
}