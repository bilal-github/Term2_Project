using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team5_Workshop4
{
    public static class SuppliersDB
    {
        public static List<Suppliers> GetSuppliers()
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
                            sp.SupplierId = (int)reader["SupplierId"];
                            sp.SupName = reader["SupName"].ToString();
                            supplier.Add(sp);

                        }
                    } // closes reader and recycles object
                } // cmd object recycled
            } // conncection object recycled
            return supplier;
        }// end method
    }// end class
}// end namespace
