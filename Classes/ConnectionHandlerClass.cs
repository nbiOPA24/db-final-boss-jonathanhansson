using System;
using System.Data;
using Microsoft.Data.SqlClient;
using Dapper;
public class ConnectionHandler
{
    private string connectionString;

    public ConnectionHandler()
    {
        connectionString = File.ReadAllText("connectionstring.txt");
    }
    
    public IDbConnection GetConnection()
    {
        return new SqlConnection(connectionString);
    }

    public void ExecuteQuery(string query) // används för att UPDATE, DELETE eller INSERT
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

    public void FetchSalesPersons()
    {
        using (var connection = GetConnection())
        {
            connection.Open();

            var salesPersons = connection.Query<SalesPerson>("SELECT * FROM SalesPerson");

            foreach (var salesperson in salesPersons)
            {
                System.Console.WriteLine(salesperson);
            }
        }
    }

    public void RankBySales()
    {
        using (var connection = GetConnection())
        {
            connection.Open();

            // här använder vi typen <dynamic> för att SalesPerson i SQL inte ser ut på samma sätt som i C#
            var rankedSalesPersons = connection.Query<dynamic>("SELECT SalesPerson.Name, COUNT([Order].Id) AS NumberOfOrders FROM [Order] JOIN SalesPerson ON [Order].SalesPersonId = SalesPerson.Id GROUP BY SalesPerson.Name");

            foreach (var rankedSP in rankedSalesPersons)
            {
                System.Console.WriteLine($"{rankedSP.Name}: {rankedSP.NumberOfOrders} ordrar");
            }
        }
    }

    public void InsertIntoProducts()
    {
        System.Console.WriteLine("Ange produktnamn: ");
        string productName = Console.ReadLine();

        System.Console.WriteLine("Ange hur många som finns i lager: ");
        string stock = Console.ReadLine();

        System.Console.WriteLine("Ange pris i kr/st: ");
        int price = int.Parse(Console.ReadLine());

        using (var connection = GetConnection())
        {
            connection.Execute($"INSERT INTO Product (Name, Stock, Price) VALUES ('{productName}', '{stock}', '{price}')");
        }
    }
}


