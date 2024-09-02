using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppProject
{
    internal class Singer : Entertainer, IEntertainer
    {
        private static int counter = 0;
        private int Id {  get; set; }
        private string? MusicGenre {  get; set; }
        private string? MostFamousSong {  get; set; }
        private bool IsGrammyWinner {  get; set; }
        public double Price {  get; set; }

        public Singer()
        {

        }

        public Singer(string? name, string? surname, DateTime dob, string? placeOfBirth, List<string>? languages, bool isControversial, bool isAvailable,
                  string? musicGenre, string? mostFamousSong, bool isGrammyWinner, double price)
        : base(name, surname, dob, placeOfBirth, languages, isControversial, isAvailable)
        {
            Id = counter;
            MusicGenre = musicGenre;
            MostFamousSong = mostFamousSong;
            IsGrammyWinner = isGrammyWinner;
            Price = price;
        }

        public string Entertain()
        {
          
            Random random = new Random();

            int randomNumber = random.Next(1, 6);

            string lyrics = randomNumber switch
            {
                1 => "Is this the real life? Is this just fantasy? - Bohemian Rhapsody",
                2 => "I'm on the highway to hell - AC/DC",
                3 => "Hey Jude, don't make it bad - The Beatles",
                4 => "Like a rolling stone, like a rolling stone - Bob Dylan",
                5 => "Shake it off, shake it off - Taylor Swift",
                _ => "No lyrics available."
            };

            
            return lyrics;
        }


        public override void PrintInfo()
        {
            Console.WriteLine($"Id : {Id}");
            Console.WriteLine("Singer Information:");
            Console.WriteLine($"Name: {Name} {Surname}");
            Console.WriteLine($"Date of Birth: {DOB.ToShortDateString()}");
            Console.WriteLine($"Place of Birth: {PlaceOfBirth}");
            Console.WriteLine($"Languages : {string.Join(", ", Languages ?? new List<string>())}");
            Console.WriteLine($"Controversial: {(IsControversial ? "Yes" : "No")}");
            Console.WriteLine($"Available: {(IsAvailable ? "Yes" : "No")}");
            Console.WriteLine($"Music Genre: {MusicGenre}");
            Console.WriteLine($"Most Famous Song: {MostFamousSong}");
            Console.WriteLine($"Grammy Winner: {(IsGrammyWinner ? "Yes" : "No")}");
            Console.WriteLine($"Price: ${Price:N2}");
            Console.WriteLine($"The singer {Name} will entertain you by saying: " + Entertain());
        }
    

        public static List<Singer> GenerateSingers()
        {
            // Create a list to hold the Singer objects
            List<Singer> singers = new List<Singer>();

            // Add some example Singer objects to the list
            singers.Add(new Singer(
                name: "John",
                surname: "Doe",
                dob: new DateTime(1990, 5, 1),
                placeOfBirth: "New York",
                languages: new List<string> { "English", "Spanish" },
                isControversial: false,
                isAvailable: true,
                musicGenre: "Pop",
                mostFamousSong: "Hit Song 1",
                isGrammyWinner: true,
                price: 10000
            ));

            singers.Add(new Singer(
                name: "Jane",
                surname: "Smith",
                dob: new DateTime(1985, 7, 23),
                placeOfBirth: "Los Angeles",
                languages: new List<string> { "English" },
                isControversial: true,
                isAvailable: false,
                musicGenre: "Rock",
                mostFamousSong: "Rock Anthem",
                isGrammyWinner: false,
                price: 15000
            ));

            singers.Add(new Singer(
                name: "Alice",
                surname: "Johnson",
                dob: new DateTime(1993, 12, 14),
                placeOfBirth: "London",
                languages: new List<string> { "English", "French" },
                isControversial: false,
                isAvailable: true,
                musicGenre: "Jazz",
                mostFamousSong: "Smooth Jazz Tune",
                isGrammyWinner: true,
                price: 12000
            ));

            // Return the populated list of singers
            return singers;
        }

    }
}
