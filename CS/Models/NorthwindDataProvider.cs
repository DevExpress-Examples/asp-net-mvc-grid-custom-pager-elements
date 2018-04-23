using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Web.Configuration;

public class NorthwindDataProvider {
    public static IEnumerable GetProducts() {
        List<Product> products = new List<Product>();
            
        using (OleDbConnection connection = new OleDbConnection(WebConfigurationManager.ConnectionStrings["Northwind"].ConnectionString)) {
            OleDbCommand selectCommand = new OleDbCommand("SELECT * FROM Products ORDER BY ProductID", connection);

            connection.Open();

            OleDbDataReader reader = selectCommand.ExecuteReader(CommandBehavior.CloseConnection);

            while (reader.Read()) {
                products.Add(new Product() {
                    ProductID = (int)reader["ProductID"],
                    ProductName = (string)reader["ProductName"],
                    UnitPrice = (reader["UnitPrice"] == DBNull.Value ? null : (decimal?)reader["UnitPrice"]),
                    UnitsOnOrder = (reader["UnitsOnOrder"] == DBNull.Value ? null : (short?)reader["UnitsOnOrder"])
                });
            }

            reader.Close();
        }

        return products;
    }
}
