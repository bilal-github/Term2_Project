using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Data.SqlClient;

namespace Team5_Workshop5.Models
{
    public static class ProductDetailsDB
    {
        public static List<ProductDetails> GetProductDetails(int custId)
        {
            List<ProductDetails> pdList = new List<ProductDetails>();
            ProductDetails pd;

            using (SqlConnection connection = TravelExpertsDB.GetConnection())
            {
                // create command
                string query = "SELECT b.CustomerId, b.PackageId, bd.Description, pk.PkgDesc, " +
                               "       p.ProdName, s.SupName, bd.TripStart, bd.TripEnd, " +
                               "       bd.BasePrice + bd.AgencyCommission + f.FeeAmt as Price  " +
                               "FROM Bookings b " +
                               "FULL OUTER JOIN Packages pk " +
                               "ON b.PackageId = pk.PackageId " +
                               "   INNER JOIN BookingDetails bd " +
                               "   ON b.BookingId = bd.BookingId " +
                               "       INNER JOIN Products_Suppliers p_s " +
                               "       ON bd.ProductSupplierId = p_s.ProductSupplierId " +
                               "           INNER JOIN Products p " +
                               "           ON p_s.ProductId = p.ProductId " +
                               "               INNER JOIN Suppliers s " +
                               "               ON p_s.SupplierId = s.SupplierId " +
                               "                   INNER JOIN Fees f " +
                               "                   ON bd.FeeId = f.FeeId where b.customerID = @customerID " +
                               "ORDER BY bd.TripStart";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    // run the command and process results
                    connection.Open();
                    cmd.Parameters.AddWithValue("@customerID", custId);
                    SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                    
                    while (reader.Read())
                    {
                        // proccess next record from data reader.
                        pd = new ProductDetails();
                        //pd.CustomerId = Convert.ToInt32(reader["CustomerId"]);
                        //pd.PackageId = Convert.ToInt32(reader["PackageId"]);
                        if (reader["PackageId"].ToString() != "")
                        {
                            pd.Description = reader["PkgDesc"].ToString();
                            Console.WriteLine("Package ID Not Null!");
                        }
                        else
                        {
                            pd.Description = reader["Description"].ToString(); // use packageid as logic to pull from tables
                            Console.WriteLine("Package ID Is indeed null!");
                        }
                        pd.ProdName = reader["ProdName"].ToString();
                        pd.SupName = reader["SupName"].ToString();
                        pd.TripStart = Convert.ToDateTime(reader["TripStart"]);
                        pd.TripEnd = Convert.ToDateTime(reader["TripEnd"]);
                        pd.Price = Convert.ToDecimal(reader["Price"]);

                        pdList.Add(pd);
                    }
                    //} // closes reader and recycles object
                } // cmd object recycled
            } // conncection object recycled

            return pdList;
        }

        //public static decimal GetProductsTotal(decimal total)
        //{
        //    ProductsTotal pTotal 

        //    retu
        //}
    }
}
