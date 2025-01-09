using System;
using System.Data;
using Microsoft.Data.SqlClient;
using Dapper;

// This class will handle all UserInterface that lets the user insert into, update or delete from the database
public class UserInterface
{
    ConnectionHandler cH = new ConnectionHandler();

    public void InsertIntoProducts()
    {
        System.Console.WriteLine("Ange produktnamn: ");
        string productName = Console.ReadLine();

        System.Console.WriteLine("Ange hur många som finns i lager: ");
        string stock = Console.ReadLine();

        System.Console.WriteLine("Ange pris i kr/st: ");
        if (!int.TryParse(Console.ReadLine(), out int price))
        {
            System.Console.WriteLine("Ange en siffra! Startar om.");
            return;
        }

        using (var connection = cH.GetConnection())
        {
            var query = "INSERT INTO Product (Name, Stock, Price) VALUES (@Name, @Stock, @Price)";
            connection.Execute(query, new
            {
                Name = productName,
                Stock = stock,
                Price = price
            });
        }
    }

    public void InsertIntoCustomers()
    {
        System.Console.WriteLine("Ange kundens namn: ");
        string customerName = Console.ReadLine();

        System.Console.WriteLine("Ange kundens personnr: ");
        string customerPersNr = Console.ReadLine();

        System.Console.WriteLine("Ange kundens telnr: ");
        string customerTelNr = Console.ReadLine();

        System.Console.WriteLine("Ange kundens email: ");
        string customerEmail = Console.ReadLine();

        System.Console.WriteLine("Ange kundens region (1-7): ");
        if (!int.TryParse(Console.ReadLine(), out int customerRegion))
        {
            System.Console.WriteLine("Ange en siffra! Startar om.");
            return;
        }

        using (var connection = cH.GetConnection())
        {
            var query = "INSERT INTO Customer (Name, PersNr, TelNr, Email, RegionId) VALUES (@Name, @PersNr, @TelNr, @Email, @RegionId)";

            connection.Execute(query, new
            {
                Name = customerName,
                PersNr = customerPersNr,
                TelNr = customerTelNr,
                Email = customerEmail,
                RegionId = customerRegion
            });
        }
    }

    public void DisplayProducts()
    {
        var products = cH.FetchProducts();
        foreach (var product in products)
        {
            System.Console.WriteLine(product);
        }
    }

    public void DisplayCustomerWithAboveAverageSpending()
    {
        var aboveAverageCustomer = cH.GetCustomersWithAboveAverageSpending();

        foreach (var c in aboveAverageCustomer)
        {
            System.Console.WriteLine(c);
        } 
    }

    public void DisplaySalesPersons()
    {
        var salesPersons = cH.FetchSalesPersons();

        foreach (var sp in salesPersons)
        {
            System.Console.WriteLine(sp);
        }
    }

    public void DisplaySalesPersonsRankedAfterSales()
    {
        var rankedSP = cH.FetchRankBySales();

        foreach (var rsp in rankedSP)
        System.Console.WriteLine(rsp);
    }
}