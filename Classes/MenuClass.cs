using System.Net;

public class Menu
{
    UserInterface ui = new UserInterface();
    ConnectionHandler connectionHandler = new ConnectionHandler();

    public void DisplayMainMenu()
    {
        while (true)
        {
            Menu menu = new Menu();

            System.Console.WriteLine("1. Ändra info i databasen\n2. Hämta ut statistik\n3. Ranka säljare efter antal ordrar\n4. Visa alla blabla\n5. Avsluta");

            int answer = int.Parse(Console.ReadLine());

            switch (answer)
            {
                case 1:
                    menu.LetPlayerInsert();
                    break;

                case 2:
                    ui.DisplayCustomerWithAboveAverageSpending();
                    break;

                case 3:
                    ui.DisplaySalesPersonsRankedAfterSales();
                    break;

                case 4:
                    ui.DisplayProducts();
                    break;
                
                case 5:
                    Environment.Exit(0);
                    return;
            }
        }
    }
    public void LetPlayerInsert()
    {
        while (true)
        {
            System.Console.WriteLine("Vad vill du lägga till?\n1. Produkt\n2. Kund");
            string answer = Console.ReadLine();

            if (answer != "1" && answer != "2")
            {
                System.Console.WriteLine("Du måste svara 1 eller 2.");
                continue;
            }

            switch (answer)
            {
                case "1":
                    ui.InsertIntoProducts();
                    break;

                case "2":
                    ui.InsertIntoCustomers();
                    break;

                default:
                    return;
            }

        break;
        }
    }
    public static void DisplayStatisticsMenu()
    {
        
    }
}