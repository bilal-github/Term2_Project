using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Team5_Workshop4
{
    public static class ProductsSuppliersDB
    {
        public static List<Products> GetExistingProdBySupID(int id)
        {
            List<Products> products = new List<Products>(); // an empty list
            Products pr; // auxiliary for reading
            // create connection
            using (SqlConnection connection = TravelExpertsDB.GetConnection())
            {
                // create command
                string query = "SELECT p.ProductID, p.ProdName " +
                               "FROM Products p " +
                               "INNER JOIN Products_Suppliers p_s " +
                               "ON p.ProductId = p_s.ProductId " +
                               "WHERE p_s.SupplierID = @SupplierID " +
                               "ORDER BY p.ProdName";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    // run the command and process results
                    connection.Open();
                    cmd.Parameters.AddWithValue("@SupplierID", id);

                    using (SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            // process next record from data reader
                            pr = new Products();
                            pr.ProductID = (int)reader["ProductID"];
                            pr.ProdName = reader["ProdName"].ToString();
                            products.Add(pr);
                        }
                    } // closes reader and recycles object
                } // cmd object recycled
            } // conncection object recycled
            return products;
        }// end method

        public static List<Products> GetAvailableProdBySupID(int id)
        {
            List<Products> products = new List<Products>(); // an empty list
            Products pr; // auxiliary for reading
            // create connection
            using (SqlConnection connection = TravelExpertsDB.GetConnection())
            {
                // create command
                string query = "SELECT p.ProductID, p.ProdName " +
                               "FROM Products p " +
                               "WHERE p.ProductID NOT IN " +
                               "( " +
                               "    SELECT p.ProductID " +
                               "    FROM Products p " +
                               "    INNER JOIN Products_Suppliers p_s " +
                               "    ON p.ProductId = p_s.ProductId " +
                               "    WHERE p_s.SupplierID = @SupplierID " +
                               ") " +
                               "ORDER BY p.ProdName";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    // run the command and process results
                    connection.Open();
                    cmd.Parameters.AddWithValue("@SupplierID", id);

                    using (SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            // process next record from data reader
                            pr = new Products();
                            pr.ProductID = (int)reader["ProductID"];
                            pr.ProdName = reader["ProdName"].ToString();
                            products.Add(pr);
                        }
                    } // closes reader and recycles object
                } // cmd object recycled
            } // conncection object recycled
            return products;
        }// end method

        public static bool AddProductToSupplier(int prodID, int supID)
        {
            int count;
            using (SqlConnection connection = TravelExpertsDB.GetConnection())
            {
                string updateStatement =
                    "INSERT INTO Products_Suppliers (ProductID, SupplierID) " +
                    "VALUES (@ProductID, @SupplierID)";
                using (SqlCommand cmd = new SqlCommand(updateStatement, connection))
                {
                    cmd.Parameters.AddWithValue("@ProductID", prodID);
                    cmd.Parameters.AddWithValue("@SupplierID", supID);
                    connection.Open();
                    count = cmd.ExecuteNonQuery();
                }
            }
            return (count > 0);
        }

        public static bool DeleteProductFromSupplier(int prodID, int supID)
        {
            int count = 0;
            using (SqlConnection connection = TravelExpertsDB.GetConnection())
            {
                string deleteStatement =
                    "DELETE FROM Products_Suppliers " +
                    "WHERE ProductID = @ProductID AND SupplierID = @SupplierID";
                using (SqlCommand cmd = new SqlCommand(deleteStatement, connection))
                {
                    cmd.Parameters.AddWithValue("@ProductID", prodID);
                    cmd.Parameters.AddWithValue("@SupplierID", supID);

                    try
                    {
                        connection.Open();
                        count = cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("The product you are trying to delete exists in a package and cannot be deleted.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("there was another issue!");
                    }
                }
            }
            return (count > 0);
        }

    }
}
