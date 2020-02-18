 /** Name: Bilal Ahmad
 * Date: Feb 13, 2020
 * Purpose: Returns a connection to the database
    */
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Team5_Workshop5.Models
{
    public class MyConnection
    {
        public static SqlConnection GetConnection(string connectionStringName)
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
            return new SqlConnection(ConnectionString);
        }
    }
}