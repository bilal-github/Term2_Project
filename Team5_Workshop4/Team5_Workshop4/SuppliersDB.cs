/*
 * Author: Ivan Lo
 * Date: January 24, 2020
 * Purpose: Suppliers Database
 */
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Team5_Workshop4
{
    public static class SuppliersDB
    {
        /// <summary>
        /// Get Supplier Data query
        /// </summary>
        /// <returns></returns>
        public static List<Suppliers> GetSupplier()
        {
            List<Suppliers> supplier = new List<Suppliers>();// an empty list
            Suppliers sp; // auxiliary for reading
            //create connection
            using (SqlConnection connection = TravelExpertsDB.GetConnection())
            {
                // create command
                string query = "SELECT SupplierId, SupName from Suppliers " + "ORDER BY SupplierId ";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    // run the command and process results
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            // proccess next record from data reader
                            sp = new Suppliers();
                            sp.SupplierId = 
                                (int)reader["SupplierId"];
                            sp.SupName = reader["SupName"].ToString();
                            supplier.Add(sp);

                        }
                    } // closes reader and recycles object
                } // cmd object recycled
            } // conncection object recycled
            return supplier;
        }// end method

        /// <summary>
        /// Get Supplier by ID query
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List<Suppliers> GetSuppliersBYID(int id)
        {
            List<Suppliers> supplier = new List<Suppliers>();// an empty list
            //Suppliers supplier = new Suppliers();
            Suppliers sp; // auxiliary for reading
            //create connection
            using (SqlConnection connection = TravelExpertsDB.GetConnection())
            {
                // create command
                string query = "SELECT SupplierId, SupName from Suppliers WHERE SupplierId ='" + id + "' ORDER BY SupplieriD";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    // run the command and process results
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            // proccess next record from data reader
                            sp = new Suppliers();
                            sp.SupplierId = (int)reader["SupplierId"];
                            sp.SupName = reader["SupName"].ToString();

                            supplier.Add(sp);

                        }
                    } // closes reader and recycles object
                } // cmd object recycled
            } // conncection object recycled
            return supplier;
        }// end class


        /// <summary>
        /// Get Supplier by Name query
        /// </summary>
        /// <param name="supname"></param>
        /// <returns></returns>
        public static List<Suppliers> GetSuppliersBYName(string supname)
        {
            List<Suppliers> supplier = new List<Suppliers>();// an empty list
            //Suppliers supplier = new Suppliers();
            Suppliers sp; // auxiliary for reading
            //create connection
            using (SqlConnection connection = TravelExpertsDB.GetConnection())
            {
                // create command
                string query = "SELECT SupplierId, SupName from Suppliers WHERE SupName ='" + supname + "' ORDER BY SupName";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    // run the command and process results
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            // proccess next record from data reader
                            sp = new Suppliers();
                            sp.SupplierId = (int)reader["SupplierId"];
                            sp.SupName = reader["SupName"].ToString();

                            supplier.Add(sp);

                        }
                    } // closes reader and recycles object
                } // cmd object recycled
            } // conncection object recycled
            return supplier;
        }// end class

        // Added by Elias Nahas to get list of suppliers sorted by name
        // Used on frmProductsSuppliers.cs combobox
        public static List<Suppliers> GetSuppliers()
        {
            List<Suppliers> suppliers = new List<Suppliers>();// an empty list
            Suppliers sp; // auxiliary for reading
            //create connection
            using (SqlConnection connection = TravelExpertsDB.GetConnection())
            {
                // create command
                string query = "SELECT SupplierId, SupName " +
                               "FROM Suppliers " +
                               "ORDER BY SupName";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    // run the command and process results
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            // proccess next record from data reader
                            sp = new Suppliers();
                            sp.SupplierId =
                                (int)reader["SupplierId"];
                            sp.SupName = reader["SupName"].ToString();
                            suppliers.Add(sp);
                        }
                    } // closes reader and recycles object
                } // cmd object recycled
            } // conncection object recycled
            return suppliers;
        }// end method

        public static int GetNextSupplier()
        {
            int nxtSup = 0;
            using (SqlConnection connection = TravelExpertsDB.GetConnection())
            {
                string SelectString = "SELECT MAX(SupplierID) AS SupplierID FROM Suppliers";

                using (SqlCommand command = new SqlCommand(SelectString, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine(reader["SupplierID"].ToString());
                        nxtSup = Convert.ToInt32(reader["SupplierID"]);
                        nxtSup++;
                    }
                }
            }
            return nxtSup;
        }

        /// <summary>
        /// Add Supplier Query
        /// </summary>
        /// <param name="sup"></param>
        public static void AddSupplier(Suppliers sup)
        {
            bool isPresent = false;
            int count = 0;
            using (SqlConnection connection1 = TravelExpertsDB.GetConnection())
            {
                string SelectString = "SELECT SupplierID from suppliers where SupplierID = @SupplierID";

                using (SqlCommand command = new SqlCommand(SelectString, connection1))
                {
                    command.Parameters.AddWithValue("SupplierID", sup.SupplierId);
                    connection1.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        count++;
                    }
                    if (count > 0)
                    {
                        isPresent = true;
                    }
                }
            }
            int supId = 0;
            if(isPresent == false)
            {
                using (SqlConnection connection = TravelExpertsDB.GetConnection())
                {     
                    string insertStatement =
                  
                        "INSERT INTO Suppliers(SupplierId, SupName) "+    
                        "Values(@SupplierId, @SupName)";
                    using(SqlCommand cmd = new SqlCommand(insertStatement, connection))
                    {
                        cmd.Parameters.AddWithValue("@SupplierId", sup.SupplierId);
                        cmd.Parameters.AddWithValue("@SupName", sup.SupName);
                        connection.Open();
                        cmd.ExecuteNonQuery() ;
                    }
                }
            }
            else
            {
                MessageBox.Show("Id already exists, please enter a new one");
                
                
            }
        }


        /// <summary>
        /// Update Supplier query
        /// </summary>
        /// <param name="oldSup"></param>
        /// <param name="newSup"></param>
        /// <returns></returns>
        public static bool UpdateSupplier(Suppliers oldSup, Suppliers newSup)
        {
            int count;
            using(SqlConnection connection = TravelExpertsDB.GetConnection())
            {
                string updateStatement =
                    "UPDATE Suppliers SET " +
                    " SupplierId = @newSupplierId, " +
                    " SupName = @newSupName " +
                    "WHERE SupplierId = @oldSupplierId " +
                    "AND SupName = @oldSupName";
                using(SqlCommand cmd = new SqlCommand(updateStatement, connection))
                {
                    cmd.Parameters.AddWithValue("@newSupplierId", newSup.SupplierId);
                    cmd.Parameters.AddWithValue("@oldSupplierId", oldSup.SupplierId);
                    cmd.Parameters.AddWithValue("@newSupName", newSup.SupName);
                    cmd.Parameters.AddWithValue("@oldSupName", oldSup.SupName);
                    connection.Open();
                    count = cmd.ExecuteNonQuery();
                    
                }
                
            }
            return true; 
        }

        /// <summary>
        /// Delete Supplier Query
        /// </summary>
        /// <param name="sup"></param>
        /// <returns></returns>
        public static bool DeleteSupplier(Suppliers sup)
        {
            int count = 0;
            using (SqlConnection connection = TravelExpertsDB.GetConnection())
            {
                string deleteStatement =
                    "Delete From Suppliers " +
                    "Where SupplierId = @SupplierId " +
                    "AND SupName = @SupName";   
                using(SqlCommand cmd = new SqlCommand(deleteStatement, connection))
                {
                    cmd.Parameters.AddWithValue("@SupplierId", sup.SupplierId);
                    cmd.Parameters.AddWithValue("@SupName", sup.SupName);
                    connection.Open();
                    count = cmd.ExecuteNonQuery();
                }
            }
            return (count > 0);
        }
    }// end namespace
}
