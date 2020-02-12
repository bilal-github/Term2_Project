/*
 * Author: Bilal Ahmad
 * Date: January 24, 2020
 * Purpose: Database methods for packageManager
 */
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public static class PackageManagerPackageDB
    {
        const string connectionStringName = "TravelExperts";
        /// <summary>
        /// retrieves all packages from the database
        /// </summary>
        /// <returns></returns>
        public static List<PackageManagerPackage> GetPackages()
        {
            //initialize packages list
            List<PackageManagerPackage> packages = new List<PackageManagerPackage>();
            PackageManagerPackage package; // initialize package object

            try
            {
                using (SqlConnection connection = MyConnection.GetConnection("TravelExperts"))
                {
                    string selectQuery = "SELECT PackageId, PkgName, PkgStartDate, PkgEndDate, " +
                                        "PkgDesc, PkgBasePrice, PkgAgencyCommission " +
                                    "FROM Packages";
                    using (SqlCommand command = new SqlCommand(selectQuery, connection))
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                        while (reader.Read())
                        {
                            package = new PackageManagerPackage();
                            package.PackageID = (int)reader["PackageId"];
                            package.PkgName = (string)reader["PkgName"];
                            package.PkgDesc = (string)reader["PkgDesc"];
                            package.PkgBasePrice = (decimal)reader["PkgBasePrice"];
                            //Nullable Datetime
                            if (reader["PkgStartDate"] == DBNull.Value)
                            {
                                package.PkgStartDate = null;
                            }
                            else
                            {
                                package.PkgStartDate = (DateTime)reader["PkgStartDate"];
                            }

                            if (reader["PkgEndDate"] == DBNull.Value)
                            {
                                package.PkgEndDate = null;
                            }
                            else
                            {
                                package.PkgEndDate = (DateTime)reader["PkgEndDate"];
                            }

                            if (reader["PkgAgencyCommission"] == DBNull.Value)
                            {
                                package.PkgAgencyCommission = null;
                            }
                            else
                            {
                                package.PkgAgencyCommission = (decimal)reader["PkgAgencyCommission"];
                            }

                            packages.Add(package); // add package to packages
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //returns packages list
            return packages;
        }

        /// <summary>
        /// retrieves all product Names and supplier names in the selected package
        /// </summary>
        /// <param name="PackageID"></param>
        /// <returns></returns>
        public static List<PackageMangerProductSuppliers> GetProductsSuppliersByPackageID(int PackageID)
        {
            List<PackageMangerProductSuppliers> productsSuppliers = new List<PackageMangerProductSuppliers>();
            PackageMangerProductSuppliers productSupplier;
            try
            {
                using (SqlConnection connection = MyConnection.GetConnection("TravelExperts"))
                {
                    string selectQuery = "select pr.ProdName, s.SupName from Packages p " +
                                        "inner join Packages_Products_Suppliers pps on p.PackageId = pps.PackageId " +
                                        "inner join Products_Suppliers ps on pps.ProductSupplierId = ps.ProductSupplierId " +
                                        "inner join Products pr on pr.ProductId = ps.ProductId " +
                                        "inner join Suppliers s on s.SupplierId = ps.SupplierId " +
                                        "Where p.PackageId = @PackageID " +
                                        "group by pr.ProdName,s.SupName";
                    using (SqlCommand command = new SqlCommand(selectQuery, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("PackageID", PackageID);
                        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                        while (reader.Read())
                        {
                            productSupplier = new PackageMangerProductSuppliers();
                            productSupplier.ProdName = (string)reader[0];
                            productSupplier.SupplierName = (string)reader[1];
                            productsSuppliers.Add(productSupplier); // add package to packages
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return productsSuppliers;
        }
        /// <summary>
        /// Adds a package to the database
        /// </summary>
        /// <param name="package"></param>
        /// <returns></returns>
        public static int AddPackage(PackageManagerPackage package)
        {
            int PackageID = -1;

            try
            {
                using (SqlConnection connection = MyConnection.GetConnection("TravelExperts"))
                {
                    string insertQuery = "INSERT INTO Packages(PkgName, PkgStartDate, PkgEndDate, " +
                                            "PkgDesc, PkgBasePrice, PkgAgencyCommission) " +
                                          "OUTPUT INSERTED.PackageId " +
                                        "VALUES(@PkgName, @PkgStartDate, @PkgEndDate, " +
                                            "@PkgDesc, @PkgBasePrice, @PkgAgencyCommission)";
                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        connection.Open();

                        //not nullable
                        command.Parameters.AddWithValue("PkgName", package.PkgName);
                        command.Parameters.AddWithValue("PkgDesc", package.PkgDesc);
                        command.Parameters.AddWithValue("PkgBasePrice", package.PkgBasePrice);

                        //nullable
                        if (package.PkgStartDate == null)
                        {
                            command.Parameters.AddWithValue("PkgStartDate", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("PkgStartDate", package.PkgStartDate);
                        }
                        if (package.PkgEndDate == null)
                        {
                            command.Parameters.AddWithValue("PkgEndDate", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("PkgEndDate", package.PkgEndDate);
                        }


                        if (package.PkgAgencyCommission == null)
                        {
                            command.Parameters.AddWithValue("PkgAgencyCommission", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("PkgAgencyCommission", package.PkgAgencyCommission);
                        }

                        //command.ExecuteNonQuery();
                        PackageID = (int)command.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return PackageID;
        }

        /// <summary>
        /// Updates selected package
        /// </summary>
        /// <param name="editPackage"></param>
        public static void UpdatePackage(PackageManagerPackage editPackage)
        {

            try
            {
                //populate packages list from the travel experts database
                using (SqlConnection connection = MyConnection.GetConnection("TravelExperts"))
                {
                    string updateQuery = "UPDATE Packages SET PkgName = @PkgName," +
                                        "PkgStartDate=@PkgStartDate,PkgEndDate = @PkgEndDate, " +
                                        "PkgDesc = @PkgDesc,PkgBasePrice = @PkgBasePrice, " +
                                        "PkgAgencyCommission = @PkgAgencyCommission " +
                                        "WHERE PackageId = @PackageID";

                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        connection.Open();

                        //not nullable
                        command.Parameters.AddWithValue("PackageID", editPackage.PackageID);
                        command.Parameters.AddWithValue("PkgName", editPackage.PkgName);
                        command.Parameters.AddWithValue("PkgDesc", editPackage.PkgDesc);
                        command.Parameters.AddWithValue("PkgBasePrice", editPackage.PkgBasePrice);

                        //nullable
                        if (editPackage.PkgStartDate == null)
                        {
                            command.Parameters.AddWithValue("PkgStartDate", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("PkgStartDate", editPackage.PkgStartDate);
                        }
                        if (editPackage.PkgEndDate == null)
                        {
                            command.Parameters.AddWithValue("PkgEndDate", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("PkgEndDate", editPackage.PkgEndDate);
                        }


                        if (editPackage.PkgAgencyCommission == null)
                        {
                            command.Parameters.AddWithValue("PkgAgencyCommission", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("PkgAgencyCommission", editPackage.PkgAgencyCommission);
                        }

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Checks if there are any linked products and suppliers for the selected package
        /// </summary>
        /// <param name="packageID"></param>
        /// <returns></returns>
        public static bool ProductsExist(int packageID)
        {
            int count = 0;
            try
            {
                using (SqlConnection connection = MyConnection.GetConnection(connectionStringName))
                {
                    string selectString = "SELECT * from Packages_Products_Suppliers where PackageId = @PackageID";
                    using (SqlCommand command = new SqlCommand(selectString, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("PackageID", packageID);
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            count++;
                        }
                        if (count > 0)
                        {
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return false;
        }

        /// <summary>
        /// Removes selected package from the database and removes the Package and product supplier reference
        /// </summary>
        /// <param name="packageID"></param>
        public static void RemovePackage(int packageID)
        {
            try
            {


                using (SqlConnection connection = MyConnection.GetConnection(connectionStringName))
                {
                    string deleteProductSupplier = "DELETE FROM Packages_Products_Suppliers where PackageId = @PackageID";
                    using (SqlCommand command = new SqlCommand(deleteProductSupplier, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("PackageID", packageID);

                        command.ExecuteNonQuery();
                    }
                }
                using (SqlConnection connection = MyConnection.GetConnection(connectionStringName))
                {
                    string deletePackage = "DELETE FROM Packages where PackageId = @PackageID";
                    using (SqlCommand command = new SqlCommand(deletePackage, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("PackageID", packageID);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
