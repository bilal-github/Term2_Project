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
            //create connection
            using (SqlConnection connection = TravelExpertsDB.GetConnection())
            {
                // create command
                string query = "SELECT ProductID, ProdName from Products " + "ORDER BY ProductID ";
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
                            pr.ProductID =
                                (int)reader["ProductID"];
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
            //create connection
            using (SqlConnection connection = TravelExpertsDB.GetConnection())
            {
                // create command
                string query = "SELECT ProductID, ProdName from Products WHERE ProductID ='" + id + "' ORDER BY ProductID";
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                product = (Products)cmd.ExecuteScalar();
                connection.Close();
            } // conncection object recycled
            return product;
        }// end class
    }
}
