/*
 * Name: Bilal Ahmad
 * Purpose: Database methods for managing products and suppliers in package
 * Project: Workshop 4
 * Date: Feb 12, 2020
 * 
*/using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public static class PackageManagerProductsDB
    {
        /// <summary>
        /// Returns Products to be displayed in the comboBox
        /// </summary>
        /// <returns></returns>
        public static List<PackageManagerProducts> GetProducts()
        {
            //initialize Products list
            List<PackageManagerProducts> products = new List<PackageManagerProducts>();
            PackageManagerProducts product; // initialize package object

            try
            {
                using (SqlConnection connection = MyConnection.GetConnection("TravelExperts"))
                {
                    string selectQuery = "SELECT ProdName FROM Products";
                    using (SqlCommand command = new SqlCommand(selectQuery, connection))
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                        while (reader.Read())
                        {
                            product = new PackageManagerProducts();
                            product.ProdName = (string)reader[0];
                            products.Add(product); // add package to packages
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //returns packages list
            return products;
        }

        /// <summary>
        /// returns all suppliers for the selected product that are not already added to the package
        /// </summary>
        /// <param name="packageID"></param>
        /// <param name="productName"></param>
        /// <returns></returns>
        public static List<PackageManagerSuppliers> GetSuppliersByProductName(int packageID,string productName)
        {
            List<PackageManagerSuppliers> suppliers = new List<PackageManagerSuppliers>();
            PackageManagerSuppliers supplier = new PackageManagerSuppliers();
            try
            {
                using (SqlConnection connection = MyConnection.GetConnection("TravelExperts"))
                {
                    string selectQuery = "SELECT SupName FROM Suppliers S " +
                                        "INNER JOIN Products_Suppliers PS on S.SupplierId = PS.SupplierId " +
                                        "INNER JOIN Products P on P.ProductId = PS.ProductId " +
                                        "WHERE P.ProdName = @ProductName and PS.SupplierId " +
                                        "NOT IN(select SupplierId from Products_Suppliers PS " +
                                        "INNER JOIN Packages_Products_Suppliers PPS on PS.ProductSupplierId = PPS.ProductSupplierId " +
                                        "Where PackageId = @PackageID) order by 1"; 
                    using (SqlCommand command = new SqlCommand(selectQuery, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("PackageID", packageID);
                        command.Parameters.AddWithValue("ProductName", productName);
                        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                        while (reader.Read())
                        {
                            supplier = new PackageManagerSuppliers();
                            supplier.SupName = (string)reader[0];
                            suppliers.Add(supplier); // add supplier to suppliers
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //returns packages list
            return suppliers;

        }

        /// <summary>
        /// Add Supplier and Product to the selected package
        /// </summary>
        /// <param name="packageID"></param>
        /// <param name="productName"></param>
        /// <param name="supplierName"></param>
        public static void AddSupplierAndProduct(int packageID, string productName, string supplierName)
        {
            int productSupplierID = 0;
            try
            {
                using(SqlConnection connection1 = MyConnection.GetConnection("TravelExperts"))
                {
                    string select = "select ProductSupplierID from Products_Suppliers PS " +
                                        "INNER JOIN Products P on P.ProductId = PS.ProductId " +
                                        "INNER JOIN Suppliers S on PS.SupplierId = S.SupplierId " +
                                        "WHERE S.SupName = @SupplierName AND P.ProdName = @ProductName";
                    using (SqlCommand command = new SqlCommand(select, connection1))
                    {
                        connection1.Open();
                        command.Parameters.AddWithValue("ProductName", productName);
                        command.Parameters.AddWithValue("SupplierName", supplierName);
                        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                        while (reader.Read())
                        {
                            productSupplierID = (int)reader[0];
                            //add code for unize combinations
                        }
                    }
                }

                using (SqlConnection connection = MyConnection.GetConnection("TravelExperts"))
                {
                    string insertQuery = "Insert into Packages_Products_Suppliers(PackageId,ProductSupplierId) Values(@PackageID,@ProductSupplierID)";
                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("PackageID", packageID);
                        command.Parameters.AddWithValue("ProductSupplierID", productSupplierID);
                        //command.Parameters.AddWithValue("SupplierName", supplierName);
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
        /// Removes the selected Supplier and Product from the selected package
        /// </summary>
        /// <param name="packageID"></param>
        /// <param name="productName"></param>
        /// <param name="supplierName"></param>
        public static void RemoveSupplierAndProduct(int packageID, string productName, string supplierName)
        {
            PackageMangerProductSuppliers productSupplier = new PackageMangerProductSuppliers();
            int productSupplierID = -1;
            try
            {
                using (SqlConnection connection = MyConnection.GetConnection("TravelExperts"))
                {
                    string select = "select ProductSupplierID from Products_Suppliers PS " +
                                        "INNER JOIN Products P on P.ProductId = PS.ProductId " +
                                        "INNER JOIN Suppliers S on PS.SupplierId = S.SupplierId " +
                                        "WHERE S.SupName = @SupplierName AND P.ProdName = @ProductName";
                    using (SqlCommand command = new SqlCommand(select, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("ProductName", productName);
                        command.Parameters.AddWithValue("SupplierName", supplierName);
                        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                        while (reader.Read())
                        {
                            productSupplierID = (int)reader[0];
                        }
                    }
                }
                using (SqlConnection connection = MyConnection.GetConnection("TravelExperts"))
                {
                    string insertQuery = "DELETE FROM Packages_Products_Suppliers " +
                                        "WHERE ProductSupplierId = @ProductSupplierID and PackageId = @PackageID";
                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("PackageID", packageID);
                        command.Parameters.AddWithValue("ProductSupplierID", productSupplierID);
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
