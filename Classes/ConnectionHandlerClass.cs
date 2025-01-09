using System;
using System.Data;
using Microsoft.Data.SqlClient;
using Dapper;
public class ConnectionHandler
{
    private string connectionString;

    // konstruktorn sätter värdet till connectionString direkt
    public ConnectionHandler()
    {
        connectionString = FetchConnectionString();
    }

    // returnerar en instans av SqlConnection. Vid skapandet av en instans av denna klass måste man skicka in en connection string
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

    // hämtar "connectionstringen" som kopplar C# och SQL
    public string FetchConnectionString()
    {
        var connectionString = File.ReadAllText("connectionstring.txt");
        return connectionString;
    }

    // hämtar alla produkter från shopen (OBS, skriver inte ut dem, det görs i klassen UI)
    public IEnumerable<Product> FetchProducts()
    {
        using (var connection = GetConnection())
        {
            connection.Open();

            var products = connection.Query<Product>("SELECT * FROM Product");

            return products;
        }
    }

    // hämtar alla kunder som spenderat mer än genomsnittet av alla kunders spenderade summa (OBS, skriver inte ut dem, det görs i klassen UI)
    public IEnumerable<Customer> GetCustomersWithAboveAverageSpending()
    {
        using (var connection = GetConnection())
        {
            connection.Open();

            var customerList = connection.Query<Customer>("SELECT Customer.Name, SUM(ProductInOrder.TotalPrice) AS TotalRevenue FROM Customer JOIN [Order] ON Customer.Id = [Order].CustomerId JOIN ProductInOrder ON [Order].Id = ProductInOrder.OrderId GROUP BY Customer.Name HAVING SUM(ProductInOrder.TotalPrice) > (SELECT AVG(TotalPrice) FROM ProductInOrder JOIN [Order] ON ProductInOrder.OrderId = [Order].Id);");

            return customerList;
        }
    }

    // hämtar alla säljare och rangordnar dem efter hur mycket de sålt för (OBS, skriver inte ut dem, det görs i klassen UI)
    public IEnumerable<SalesPerson> FetchRankBySales()
    {
        using (var connection = GetConnection())
        {
            connection.Open();

            var rankedSalesPersons = connection.Query<SalesPerson>("SELECT SalesPerson.Name, COUNT([Order].Id) AS NumberOfOrders FROM [Order] JOIN SalesPerson ON [Order].SalesPersonId = SalesPerson.Id GROUP BY SalesPerson.Name");

            return rankedSalesPersons;           
        }
    }

    // hämtar alla säljare från databasen (OBS, skriver inte ut dem, det görs i klassen UI)
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