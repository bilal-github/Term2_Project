using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team5_Workshop4
{
    public static class TravelExpertsDB
    {
        public static SqlConnection GetConnection()
        {
            string connectionString = @"Data Source=localhost\sqlexpress;Initial Catalog=TravelExperts;Integrated Security=True";
            return new SqlConnection(connectionString);
        }
    }
}
