using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppProject
{
    internal class FilmFestival : PublicEvent
    {
    

        List<Actor>? Actors {  get; set; }
        public FilmFestival(string? eventName, DateTime? startOfEvent, DateTime? endOfEvent, City? eventCity, List<Actor>? actors)
            : base(eventName, startOfEvent, endOfEvent, eventCity)
        {
            Actors = actors;
        }


        public override void PrintDetails()
        {
            Console.WriteLine($"Event Name: {EventName}");
            Console.WriteLine($"Start of Event: {StartOfEvent}");
            Console.WriteLine($"End of Event: {EndOfEvent}");
            Console.WriteLine($"Event City: {EventCity?.CityName}");

            if (Actors != null && Actors.Any())
            {
                Console.WriteLine("Featured Actors:");
                foreach (var actor in Actors)
                {
                    Console.WriteLine($"- {actor.Name} {actor.Surname}");
                }
            }
            else
            {
                Console.WriteLine("No actors are scheduled for this festival.");
            }
        }

        public static FilmFestival CreateBasicFestival()
        {
            DateTime festivalStartDate;
            DateTime festivalEndDate;


            Console.WriteLine("Write the name of the festival: ");
            string? festivalName = Console.ReadLine();


            while (true)
            {
                Console.WriteLine("Write the start date of the festival (e.g., DD/MM/YYYY): ");



                string? festivalStartString = Console.ReadLine();

                // Try to parse the input string into a DateTime object
                if (DateTime.TryParse(festivalStartString, out festivalStartDate))
                {
                    Console.WriteLine($"Festival Start Date: {festivalStartDate.ToShortDateString()}");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid date format. Please enter the date in the format DD/MM/YYYY.");
                }
            }

            while (true)
            {
                Console.WriteLine("Write the end date of the festival (e.g., DD/MM/YYYY): ");



                string? festivalEndString = Console.ReadLine();

                // Try to parse the input string into a DateTime object
                if (DateTime.TryParse(festivalEndString, out festivalEndDate))
                {
                    Console.WriteLine($"Festival End Date: {festivalEndDate.ToShortDateString()}");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid date format. Please enter the date in the format DD/MM/YYYY.");
                }
            }
            Console.WriteLine("Write the location of the festival");
            City festivalCity = new City(Console.ReadLine());

            List<Actor> actors = Actor.GenerateActors();

            return new FilmFestival(festivalName, festivalStartDate, festivalEndDate, festivalCity, actors);
        }

        public override void AddNewArtist()
        {
            // Ensure the Actors list is initialized
            if (Actors == null)
            {
                Actors = new List<Actor>();
            }

            // Prompt the user for actor details
            Console.WriteLine("Adding a new Actor...");

            Console.Write("Enter the actor's first name: ");
            string? name = Console.ReadLine();

            Console.Write("Enter the actor's surname: ");
            string? surname = Console.ReadLine();

            Console.Write("Enter the actor's date of birth (e.g., DD/MM/YYYY): ");
            DateTime dob;
            while (!DateTime.TryParse(Console.ReadLine(), out dob))
            {
                Console.WriteLine("Invalid date format. Please enter the date in the format DD/MM/YYYY.");
            }

            Console.Write("Enter the place of birth: ");
            string? placeOfBirth = Console.ReadLine();

            Console.Write("Enter the languages spoken (comma separated): ");
            List<string> languages = Console.ReadLine()?.Split(',').Select(lang => lang.Trim()).ToList() ?? new List<string>();

            Console.Write("Is the actor controversial? (yes/no): ");
            bool isControversial = Console.ReadLine()?.Trim().ToLower() == "yes";

            Console.Write("Is the actor available? (yes/no): ");
            bool isAvailable = Console.ReadLine()?.Trim().ToLower() == "yes";

            Console.Write("Enter the film genre: ");
            string? filmGenre = Console.ReadLine();

            Console.Write("Enter the most famous movie: ");
            string? mostFamousMovie = Console.ReadLine();

            Console.Write("Is the actor an Academy Award winner? (yes/no): ");
            bool isAcademyAwardWinner = Console.ReadLine()?.Trim().ToLower() == "yes";

            Console.Write("Enter the price for hiring the actor: ");
            double price;
            while (!double.TryParse(Console.ReadLine(), out price))
            {
                Console.WriteLine("Invalid price format. Please enter a valid number.");
            }

            // Create a new Actor object with the provided details
            Actor newActor = new Actor(
                name: name,
                surname: surname,
                dob: dob,
                placeOfBirth: placeOfBirth,
                languages: languages,
                isControversial: isControversial,
                isAvailable: isAvailable,
                filmGenre: filmGenre,
                mostFamousMovie: mostFamousMovie,
                isAcademyAwardWinner: isAcademyAwardWinner,
                price: price
            );

            // Add the new Actor to the list
            Actors.Add(newActor);

            Console.WriteLine("The new actor has been successfully added to the festival!");
        }
        public override void RemoveControversialArtists()
        {
            if (Actors == null || !Actors.Any())
            {
                Console.WriteLine("There are no actors to remove.");
                return;
            }

            int initialCount = Actors.Count;

            // Remove all actors who are controversial
            Actors.RemoveAll(actor => actor.IsControversial);

            int removedCount = initialCount - Actors.Count;

            Console.WriteLine($"{removedCount} controversial actor(s) have been removed from the festival.");
        }

        public override double DisplayFullPrice()
        {
            double sum = 0;

            if (Actors == null || !Actors.Any())
            {
                Console.WriteLine("There are no actors to calculate the full price.");
                return 0;
            }

            foreach (var actor in Actors)
            {
                sum += actor.Price;
            }

            return sum;
        }

        public override void DisplayInfoAboutArtists()
        {
            if (Actors == null || !Actors.Any())
            {
                Console.WriteLine("There are no actors to display information about.");
                return;
            }

            Console.WriteLine("Information about actors:");

            foreach (var actor in Actors)
            {
                actor.PrintInfo();
                Console.WriteLine(); // Add an empty line between each actor's info for better readability
            }
        }
    }
}
