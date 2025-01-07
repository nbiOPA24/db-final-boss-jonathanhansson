using System.Net;

public class Menu
{
    ConnectionHandler connectionHandler = new ConnectionHandler();
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
                    connectionHandler.InsertIntoProducts();
                    break;
                    

            }
        }
    }
    public static void DisplayStatisticsMenu()
    {

    }
}