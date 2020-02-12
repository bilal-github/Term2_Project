using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Common;
using System.Data;

namespace DataAccess
{
    public static class DatabaseUtil
    {
        /*
        public static SqlConnection GetConnection(string connectionStringName)
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
            return new SqlConnection(ConnectionString);
        }
        */
        private static DbProviderFactory factory = DbProviderFactories.GetFactory("System.Data.SqlClient");


        public static DataTable GetDataTable(string select_Update_Insert, string connectionStringName, string query, SqlParameter[] sqlParameters)
        {
            string connectionString = ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;

            try
            {
                using (DbConnection sqlConnection = factory.CreateConnection())
                {
                    sqlConnection.ConnectionString = connectionString;

                    using (DbCommand sqlCommand = factory.CreateCommand())
                    {
                        sqlCommand.Connection = sqlConnection;
                        sqlCommand.CommandType = CommandType.Text;
                        sqlCommand.CommandText = query;

                        if (sqlParameters != null)
                        {
                            foreach (var parameter in sqlParameters)
                            {
                                if (parameter != null)
                                {
                                    sqlCommand.Parameters.Add(parameter);
                                }
                            }
                        }
                        if (select_Update_Insert == "SELECT")
                        {
                            using (DbDataAdapter adapter = factory.CreateDataAdapter())
                            {
                                adapter.SelectCommand = sqlCommand;

                                DataTable dt = new DataTable();
                                adapter.Fill(dt);

                                return dt;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Query didn't run as planned");
                        }

                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
