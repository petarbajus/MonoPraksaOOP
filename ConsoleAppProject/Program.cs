// This is the Main method where your program starts execution
using ConsoleAppProject;
using System.ComponentModel.Design;
using System.Text;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome!\nYou have a chance to create your first public event!");

        int result;
        do
        {
            Console.WriteLine("Choose 1 (Creating a concert)\nChoose 2 (Creating a film festival)");
            bool isValidInput = int.TryParse(Console.ReadLine(), out result);

            if (!isValidInput)
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                continue;
            }

            switch (result)
            {
                case 1:
                    Console.WriteLine("Creating a concert");
                    ConcertMenu();
                    break;
                case 2:
                    Console.WriteLine("Creating a film festival");
                    FestivalMenu();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please choose once more!");
                    break;
            }

        } while (result != 1 && result != 2);

    }

    private static void ConcertMenu()
    {
        Concert myConcert = Concert.CreateBasicConcert();

        int decidingNumber;
        bool isRunning = true; // Flag to control the loop

        StringBuilder menuBuilder = new StringBuilder();

        // Build the menu
        menuBuilder.AppendLine("Menu:");
        menuBuilder.AppendLine("Choose 1 to display full price");
        menuBuilder.AppendLine("Choose 2 to remove the controversial singers");
        menuBuilder.AppendLine("Choose 3 to add a new singers");
        menuBuilder.AppendLine("Choose 4 to display info about singers");
        menuBuilder.AppendLine("Choose 5 to display info about concert");
        menuBuilder.AppendLine("Choose 6 to exit");

        while (isRunning)
        {
            Console.WriteLine(menuBuilder.ToString());
            Console.Write("Choose a number: ");

            // Validate input
            if (int.TryParse(Console.ReadLine(), out decidingNumber))
            {
                switch (decidingNumber)
                {
                    case 1:
                        Console.WriteLine("Full price is: " + myConcert.DisplayFullPrice());
                        break;
                    case 2:
                        Console.WriteLine("Removing the controversial singers...");
                        myConcert.RemoveControversialArtists();
                        break;
                    case 3:
                        Console.WriteLine("Adding new singers...");
                        myConcert.AddNewArtist();
                        break;
                    case 4:
                        Console.WriteLine("Displaying info about singers...");
                        myConcert.DisplayInfoAboutArtists();
                        break;

                    case 5:
                        Console.WriteLine("Displaying info about concert...");
                        PrintEventDetails(myConcert);
                        break;
                    case 6:
                        Console.WriteLine("Exiting the menu...");
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please choose a number between 1 and 5.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }

    }

 


    private static void FestivalMenu()
    {
        PublicEvent myFestival = FilmFestival.CreateBasicFestival();
        int decidingNumber;
        bool isRunning = true; // Flag to control the loop

        StringBuilder menuBuilder = new StringBuilder();

        // Build the menu
        menuBuilder.AppendLine("Menu:");
        menuBuilder.AppendLine("Choose 1 to display full price");
        menuBuilder.AppendLine("Choose 2 to remove the controversial actors");
        menuBuilder.AppendLine("Choose 3 to add a new actor");
        menuBuilder.AppendLine("Choose 4 to display info about actors");
        menuBuilder.AppendLine("Choose 5 to display info about festival");
        menuBuilder.AppendLine("Choose 6 to exit");

        while (isRunning)
        {
            Console.WriteLine(menuBuilder.ToString());
            Console.Write("Choose a number: ");

            // Validate input
            if (int.TryParse(Console.ReadLine(), out decidingNumber))
            {
                switch (decidingNumber)
                {
                    case 1:
                        Console.WriteLine("Full price is: " + myFestival.DisplayFullPrice());
                        break;
                    case 2:
                        Console.WriteLine("Removing the controversial actors...");
                        myFestival.RemoveControversialArtists();
                        break;
                    case 3:
                        Console.WriteLine("Adding new actor...");
                        myFestival.AddNewArtist();
                        break;
                    case 4:
                        Console.WriteLine("Displaying info about actors...");
                        myFestival.DisplayInfoAboutArtists();
                        break;
                    case 5:
                        Console.WriteLine("Displaying info about festival...");
                        PrintEventDetails(myFestival);
                        break;
                    case 6:
                        Console.WriteLine("Exiting the menu...");
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please choose a number between 1 and 5.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
    }

    //Generics and DRY principle
    private static void PrintEventDetails<T>(T publicEvent) where T : PublicEvent
    {
        publicEvent.PrintDetails();
    }

}


//City is a SRP class, only used for storing city instances, nothing else.
//Also, DisplayFullPrice methods are used only for calculating the totalPrice of the given event