using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppProject
{
    internal class Actor : Entertainer, IEntertainer
    {
        private static int counter = 1;
        private int Id { get; set; }
        private string? FilmGenre { get; set; }
        private string? MostFamousMovie {  get; set; }
        private bool IsAcademyAwardWinner {  get; set; }
        public double Price {  get; set; }

        public Actor() { }

        public Actor(string? name, string? surname, DateTime dob, string? placeOfBirth, List<string>? languages, bool isControversial, bool isAvailable,
                     string? filmGenre, string? mostFamousMovie, bool isAcademyAwardWinner, double price)
            : base(name, surname, dob, placeOfBirth, languages, isControversial, isAvailable)
        {
            Id = counter;
            FilmGenre = filmGenre;
            MostFamousMovie = mostFamousMovie;
            IsAcademyAwardWinner = isAcademyAwardWinner;
            Price = price;
            counter++;
        }

        public string Entertain()
        {
         
            Random random = new Random();

            // Generate a random number between 1 and 5
            int randomNumber = random.Next(1, 6); // 6 is exclusive, so it generates numbers 1 to 5

            // Choose a movie quote based on the random number
            string quote = randomNumber switch
            {
                1 => "Here's looking at you, kid. - Casablanca (1942)",
                2 => "May the Force be with you. - Star Wars (1977)",
                3 => "I'm gonna make him an offer he can't refuse. - The Godfather (1972)",
                4 => "You talking to me? - Taxi Driver (1976)",
                5 => "E.T. phone home. - E.T. the Extra-Terrestrial (1982)",
                _ => "No quote available." 
            };

         
            return quote;
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"Id : {Id}");
            Console.WriteLine($"Name: {Name} {Surname}");
            Console.WriteLine($"Date of Birth: {DOB.ToShortDateString()}");
            Console.WriteLine($"Place of Birth: {PlaceOfBirth}");
            Console.WriteLine($"Languages: {string.Join(", ", Languages ?? new List<string>())}");
            Console.WriteLine($"Is Controversial: {IsControversial}");
            Console.WriteLine($"Is Available: {IsAvailable}");
            Console.WriteLine($"Film Genre: {FilmGenre}");
            Console.WriteLine($"Most Famous Movie: {MostFamousMovie}");
            Console.WriteLine($"Is Academy Award Winner: {IsAcademyAwardWinner}");
            Console.WriteLine($"Price: {Price}");
            Console.WriteLine($"The actor {Name} will entertain you by saying: " + Entertain());
        }

        public static List<Actor> GenerateActors()
        {
            // Create a list to hold the Actor objects
            List<Actor> actors = new List<Actor>();

            // Add some example Actor objects to the list
            actors.Add(new Actor(
                name: "Leonardo",
                surname: "DiCaprio",
                dob: new DateTime(1974, 11, 11),
                placeOfBirth: "Los Angeles",
                languages: new List<string> { "English" },
                isControversial: false,
                isAvailable: true,
                filmGenre: "Drama",
                mostFamousMovie: "Inception",
                isAcademyAwardWinner: true,
                price: 20000000
            ));

            actors.Add(new Actor(
                name: "Meryl",
                surname: "Streep",
                dob: new DateTime(1949, 6, 22),
                placeOfBirth: "Summit",
                languages: new List<string> { "English" },
                isControversial: false,
                isAvailable: true,
                filmGenre: "Drama",
                mostFamousMovie: "The Devil Wears Prada",
                isAcademyAwardWinner: true,
                price: 15000000
            ));

            actors.Add(new Actor(
                name: "Tom",
                surname: "Hanks",
                dob: new DateTime(1956, 7, 9),
                placeOfBirth: "Concord",
                languages: new List<string> { "English" },
                isControversial: false,
                isAvailable: true,
                filmGenre: "Drama",
                mostFamousMovie: "Forrest Gump",
                isAcademyAwardWinner: true,
                price: 25000000
            ));

            return actors;
        }
    }
}
