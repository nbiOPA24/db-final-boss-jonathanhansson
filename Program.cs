using Microsoft.VisualBasic;
using System;
using Microsoft.Data.SqlClient;
using Dapper;

class Program
{
    string connectionString = File.ReadAllText("connectionstring.txt");
    
    static void Main()
    {
        ConnectionHandler connectionHandler = new ConnectionHandler();

        connectionHandler.FetchProducts();
    }
}