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

    public IEnumerable<Product> FetchProducts()
    {
        using (var connection = GetConnection())
        {
            connection.Open();

            var products = connection.Query<Product>("SELECT * FROM Product");

            return products;
        }
    }

    // This method lets the user of this software display the
    public IEnumerable<Customer> GetCustomersWithAboveAverageSpending()
    {
        using (var connection = GetConnection())
        {
            connection.Open();

            var customerList = connection.Query<Customer>("SELECT Customer.Name, SUM(ProductInOrder.TotalPrice) AS TotalRevenue FROM Customer JOIN [Order] ON Customer.Id = [Order].CustomerId JOIN ProductInOrder ON [Order].Id = ProductInOrder.OrderId GROUP BY Customer.Name HAVING SUM(ProductInOrder.TotalPrice) > (SELECT AVG(TotalPrice) FROM ProductInOrder JOIN [Order] ON ProductInOrder.OrderId = [Order].Id);");

            return customerList;
        }
    }

    public IEnumerable<SalesPerson> RankBySales()
    {
        using (var connection = GetConnection())
        {
            connection.Open();

            var rankedSalesPersons = connection.Query<SalesPerson>("SELECT SalesPerson.Name, COUNT([Order].Id) AS NumberOfOrders FROM [Order] JOIN SalesPerson ON [Order].SalesPersonId = SalesPerson.Id GROUP BY SalesPerson.Name");

            return rankedSalesPersons;           
        }
    }

    public IEnumerable<SalesPerson> FetchSalesPersons()
    {
        using (var connection = GetConnection())
        {
            connection.Open();

            var salesPersons = connection.Query<SalesPerson>("SELECT * FROM SalesPerson");

            return salesPersons;
        }
    }
}