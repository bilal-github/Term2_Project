using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team5_Workshop4
{
    public static class ProductsDB
    {
        public static List<Products> GetProducts()
        {
            List<Products> products = new List<Products>();// an empty list
            Products pr; // auxiliary for reading
            // create connection
            using (SqlConnection connection = TravelExpertsDB.GetConnection())
            {
                // create command
                string query = "SELECT ProductID, ProdName from Products " +
                               "ORDER BY ProdName ";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    // run the command and process results
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            // proccess next record from data reader
                            pr = new Products();
                            pr.ProductID =(int)reader["ProductID"];
                            pr.ProdName = reader["ProdName"].ToString();
                            products.Add(pr);
                        }
                    } // closes reader and recycles object
                } // cmd object recycled
            } // conncection object recycled
            return products;
        }// end method

        public static Products GetProductByID(int id)
        {
            Products product = new Products();// an empty object
            List<Products> products = new List<Products>();// an empty list
            Products pr; // auxiliary for reading
            //create connection
            using (SqlConnection connection = TravelExpertsDB.GetConnection())
            {
                // create command
                string query = "SELECT ProductID, ProdName from Products WHERE ProductID = @ProdID";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    // run the command and process results
                    connection.Open();
                    cmd.Parameters.AddWithValue("@ProdID", id);

                    using (SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            // proccess next record from data reader
                            pr = new Products();
                            pr.ProductID =
                                (int)reader["ProductID"];
                            pr.ProdName = reader["ProdName"].ToString();
                            products.Add(pr);
                        }
                        product = products[0];
                    } // closes reader and recycles object
                } // cmd object recycled
            } // conncection object recycled
            return product;
        }// end class

        public static bool UpdateProduct(Products oldProd, Products newProd)
        {
            int count;
            using (SqlConnection connection = TravelExpertsDB.GetConnection())
            {
                string updateStatement =
                    "UPDATE Products SET " +
                    " ProdName = @newProdName " +
                    "WHERE ProductID = @oldProdID " +
                    "AND ProdName = @oldProdName";
                using (SqlCommand cmd = new SqlCommand(updateStatement, connection))
                {
                    cmd.Parameters.AddWithValue("@newProdName", newProd.ProdName);
                    cmd.Parameters.AddWithValue("@oldProdName", oldProd.ProdName);
                    cmd.Parameters.AddWithValue("@oldProdID", oldProd.ProductID);
                    connection.Open();
                    count = cmd.ExecuteNonQuery();
                }
            }
            return (count > 0);
        }

        public static bool AddProduct(Products newProd)
        {
            int count;
            using (SqlConnection connection = TravelExpertsDB.GetConnection())
            {
                string updateStatement =
                    "INSERT INTO Products (ProdName) " +
                    "VALUES (@ProdName)";
                using (SqlCommand cmd = new SqlCommand(updateStatement, connection))
                {
                    cmd.Parameters.AddWithValue("@ProdName", newProd.ProdName);
                    connection.Open();
                    count = cmd.ExecuteNonQuery();
                }
            }
            return (count > 0);
        }
    }
}