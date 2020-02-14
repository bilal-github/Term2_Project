using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;

namespace Team5_Workshop5.Models
{
    public static class ProductDetailsDB
    {
        public static List<ProductDetails> GetProductDetails()
        {
            List<ProductDetails> pdList = new List<ProductDetails>();
            ProductDetails pd;

            using (SqlConnection connection = TravelExpertsDB.GetConnection())
            {
                // create command
                string query = "SELECT b.CustomerId, b.PackageId, bd.Description, pk.PkgDesc " +
                               "       p.ProdName, s.SupName, bd.TripStart, bd.TripEnd, " +
                               "       bd.BasePrice + f.FeeAmt as Price " +
                               "FROM Bookings.b " +
                               "FULL OUTER JOIN Packages pk " +
                               "ON b.PackageId = PKCS1MaskGenerationMethod.PackageId " +
                               "   INNER JOIN BookingDetails.bd " +
                               "   ON b.BookingId = bd.BookingId " +
                               "       INNER JOIN Products_Suppliers p_s " +
                               "       ON p_s.ProductId = pd.ProductId " +
                               "           INNER JOIN Suppliers s " +
                               "           ON p_s.SupplierId = s.SupplierId " +
                               "               INNER JOIN Fees f " +
                               "               ON bd.FeeId = f.FeeId ";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    // run the command and process results
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            // proccess next record from data reader.
                            pd = new ProductDetails();
                            pd.SupplierId = (int)reader["SupplierId"];
                            pdList.Add(pd);

                        }
                    } // closes reader and recycles object
                } // cmd object recycled
            } // conncection object recycled

            return pdList;
        }
    }
}
