using Microsoft.VisualBasic;
using System;
using Microsoft.Data.SqlClient;
using Dapper;
using System.Runtime.InteropServices;

class Program
{
    string connectionString = File.ReadAllText("connectionstring.txt");
    
    static void Main()
    {
        ConnectionHandler connectionHandler = new ConnectionHandler();
        Menu menu = new Menu();

        System.Console.WriteLine("1. Ändra info i databasen\n2. Hämta ut statistik\n3. Avsluta");
        
        int answer = int.Parse(Console.ReadLine());

        switch (answer)
        {
            case 1:
                menu.LetPlayerInsert();
                break;

            case 2:
                connectionHandler.FetchSalesPersons();
                break;

            case 3:
                connectionHandler.RankBySales();
                break;
        }     
    }
}