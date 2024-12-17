using System.Data;
using System.Data.SqlClient;
using Dapper;

string connectionString = File.ReadAllText("connectionstring.txt");
