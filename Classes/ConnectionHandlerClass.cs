using System;
using Microsoft.Data.SqlClient;
using Dapper;
public class ConnectionHandler
{
    private string connectionString;

    public ConnectionHandler()
    {
        connectionString = File.ReadAllText("connectionstring.txt");
    }
    
    public SqlConnection GetConnection()
    {
        var connection = new SqlConnection(connectionString);
        return connection;
    }

    public void ExecuteQuery(string query)
    {
        using (var connection = GetConnection())
        {
            connection.Open();
            connection.Execute(query);
        }
    }

    public void FetchProducts()
    {
        using (var connection = GetConnection())
        {
            connection.Open();

            var products = connection.Query<Product>("SELECT * FROM Product");

            foreach (var product in products)
            {
                System.Console.WriteLine(product);
            }
        }
    }
}


