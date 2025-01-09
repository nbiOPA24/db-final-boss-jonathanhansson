using Microsoft.VisualBasic;
using System;
using Microsoft.Data.SqlClient;
using Dapper;
using System.Runtime.InteropServices;

class Program
{
    static void Main()
    {
        Menu menu = new Menu();
        menu.DisplayMainMenu();
    }
}