﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team5_Workshop4
{
    public static class SuppliersDB
    {
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




















        // Add Supplier
        public static int AddSupplier(Suppliers sup)
        {

            int supId = 0;
            using (SqlConnection connection = TravelExpertsDB.GetConnection())
            {
                
                
                string insertStatement =
                  
                    "INSERT INTO Suppliers(SupplierId, SupName) " +
                    "OUTPUT inserted.SupplierId " +    
                    "Values(@SupplierId, @SupName)";
                using(SqlCommand cmd = new SqlCommand(insertStatement, connection))
                {
                    cmd.Parameters.AddWithValue("@SupplierId", sup.SupplierId);
                    cmd.Parameters.AddWithValue("@SupName", sup.SupName);
                    connection.Open();
                    supId = (int)cmd.ExecuteScalar();
                }
            }
            return supId;
        }


        // Update Supplier
        public static bool UpdateSupplier(Suppliers oldSup, Suppliers newSup)
        {
            int count;
            using(SqlConnection connection = TravelExpertsDB.GetConnection())
            {
                string updateStatement =
                    "UPDATE Suppliers SET " +
                    " SupName = @newSupName " +
                    "WHERE SupplierId = @oldSupplierId " +
                    "AND SupName = @oldSupName";
                using(SqlCommand cmd = new SqlCommand(updateStatement, connection))
                {
                    cmd.Parameters.AddWithValue("@newSupName", newSup.SupName);
                    cmd.Parameters.AddWithValue("@oldSupName", oldSup.SupName);
                    connection.Open();
                    count = cmd.ExecuteNonQuery();
                }
            }
            return (count > 0);
        }


        public static bool DeleteSupplier(Suppliers sup)
        {
            int count = 0;
            using (SqlConnection connection = TravelExpertsDB.GetConnection())
            {
                string deleteStatement =
                    "Delete From Suppliers " +
                    "Where SupplierId - @SupplierId " +
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