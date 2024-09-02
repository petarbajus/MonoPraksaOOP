using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppProject
{
    internal class Concert:PublicEvent
    {
        public List<Singer>? Singers {  get; set; }
        public Concert()
        {

        }

        public Concert(string? eventName, DateTime? startOfEvent, DateTime? endOfEvent, City? eventCity, List<Singer>? singers)
           : base(eventName, startOfEvent, endOfEvent, eventCity) 
        {
            Singers = singers;
        }
       
        public override void PrintDetails()
        {
            Console.WriteLine("Concert Details:");
            Console.WriteLine($"Event Name: {EventName}");
            Console.WriteLine($"Start of Event: {StartOfEvent?.ToString("dd/MM/yyyy")}");
            Console.WriteLine($"End of Event: {EndOfEvent?.ToString("dd/MM/yyyy")}");
            Console.WriteLine($"Event City: {EventCity?.CityName}");

            if (Singers == null || !Singers.Any())
            {
                Console.WriteLine("There are no singers scheduled for this concert.");
            }
            else
            {
                Console.WriteLine("Scheduled Singers:");
                foreach (var singer in Singers)
                {
                    singer.PrintInfo();
                    Console.WriteLine();  // Add spacing between singers for better readability
                }
            }
        }

        public static Concert CreateBasicConcert()
        {
            DateTime concertStartDate;
            DateTime concertEndDate;



            Console.WriteLine("Write the name of the concert: ");
            string? concertName = Console.ReadLine();


            while (true)
            {
                Console.WriteLine("Write the start date of the concert (e.g.,DD/MM/YYYY): ");



                string? concertStartString = Console.ReadLine();

                // Try to parse the input string into a DateTime object
                if (DateTime.TryParse(concertStartString, out concertStartDate))
                {
                    Console.WriteLine($"Concert Date: {concertStartDate.ToShortDateString()}");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid date format. Please enter the date in the format DD/MM/YYYY.");
                }
            }

            while (true)
            {
                Console.WriteLine("Write the end date of the concert (e.g., DD/MM/YYYY): ");



                string? concertEndString = Console.ReadLine();

                // Try to parse the input string into a DateTime object
                if (DateTime.TryParse(concertEndString, out concertEndDate))
                {
                    Console.WriteLine($"Concert Date: {concertEndDate.ToShortDateString()}");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid date format. Please enter the date in the format DD/MM/YYYY.");
                }
            }
            Console.WriteLine("Write the location of the concert");
            City concertCity = new City(Console.ReadLine());

            List<Singer> singers = Singer.GenerateSingers();

            return new Concert(concertName, concertStartDate, concertEndDate, concertCity, singers);
        }

        public override void AddNewArtist()
        {
            // Ensure the Singers list is initialized
            if (Singers == null)
            {
                Singers = new List<Singer>();
            }

            // Prompt the user for singer details
            Console.WriteLine("Adding a new Singer...");

            Console.Write("Enter the singer's first name: ");
            string? name = Console.ReadLine();

            Console.Write("Enter the singer's surname: ");
            string? surname = Console.ReadLine();

            Console.Write("Enter the singer's date of birth (e.g., DD/MM/YYYY): ");
            DateTime dob;
            while (!DateTime.TryParse(Console.ReadLine(), out dob))
            {
                Console.WriteLine("Invalid date format. Please enter the date in the format DD/MM/YYYY.");
            }

            Console.Write("Enter the place of birth: ");
            string? placeOfBirth = Console.ReadLine();

            Console.Write("Enter the languages the singer speaks (comma separated): ");
            List<string> languages = Console.ReadLine()?.Split(',').Select(lang => lang.Trim()).ToList() ?? new List<string>();

            Console.Write("Is the singer controversial? (yes/no): ");
            bool isControversial = Console.ReadLine()?.Trim().ToLower() == "yes";

            Console.Write("Is the singer available? (yes/no): ");
            bool isAvailable = Console.ReadLine()?.Trim().ToLower() == "yes";

            Console.Write("Enter the music genre: ");
            string? musicGenre = Console.ReadLine();

            Console.Write("Enter the most famous song: ");
            string? mostFamousSong = Console.ReadLine();

            Console.Write("Is the singer a Grammy winner? (yes/no): ");
            bool isGrammyWinner = Console.ReadLine()?.Trim().ToLower() == "yes";

            Console.Write("Enter the price for hiring the singer: ");
            double price;
            while (!double.TryParse(Console.ReadLine(), out price))
            {
                Console.WriteLine("Invalid price format. Please enter a valid number.");
            }

            // Create a new Singer object with the provided details
            Singer newSinger = new Singer(
                name: name,
                surname: surname,
                dob: dob,
                placeOfBirth: placeOfBirth,
                languages: languages,
                isControversial: isControversial,
                isAvailable: isAvailable,
                musicGenre: musicGenre,
                mostFamousSong: mostFamousSong,
                isGrammyWinner: isGrammyWinner,
                price: price
            );

            // Add the new Singer to the list
            Singers.Add(newSinger);

            Console.WriteLine("The new singer has been successfully added to the concert!");
        }
        public override void DisplayInfoAboutArtists()
        {
            if (Singers == null || !Singers.Any())
            {
                Console.WriteLine("There are no singers to display information about.");
                return;
            }

            Console.WriteLine("Information about singers:");

            foreach (var singer in Singers)
            {
                singer.PrintInfo();
                Console.WriteLine(); 
            }
        }
        public override double DisplayFullPrice()
        {
            double sum = 0;
            if (Singers == null || !Singers.Any())
            {
                Console.WriteLine("There are no singers to display information about.");
                return 0;
            }


            foreach (var singer in Singers)
            {
                sum += singer.Price;
            }
            return sum;
        }
        public override void RemoveControversialArtists()
        {
            if (Singers == null || !Singers.Any())
            {
                Console.WriteLine("There are no singers to remove.");
                return;
            }

            int initialCount = Singers.Count;

            // Remove all singers who are controversial
            Singers.RemoveAll(singer => singer.IsControversial);

            int removedCount = initialCount - Singers.Count;

            Console.WriteLine($"{removedCount} controversial singer(s) have been removed from the concert.");
        }
    }
}
