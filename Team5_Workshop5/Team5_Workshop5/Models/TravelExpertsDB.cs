using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Team5_Workshop5.Models
{
    public static class TravelExpertsDB
    {
        public static SqlConnection GetConnection()
        {
            string connectionString =  ConfigurationManager.ConnectionStrings["TravelExpertsConnection"].ConnectionString;

            return new SqlConnection(connectionString);
        }
        
    }
}