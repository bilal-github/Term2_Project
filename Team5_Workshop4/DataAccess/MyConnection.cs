/*
 * Name: Bilal Ahmad
 * Purpose: Creates Connection
 * Project: Workshop 4
 * Date: Feb 12, 2020
 * 
*/
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
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
