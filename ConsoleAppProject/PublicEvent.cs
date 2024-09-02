using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppProject
{
    internal abstract class PublicEvent
    {
        public string? EventName
        {
            get; set;
        }
        public DateTime? StartOfEvent
        {
            get; set;
        }
        public DateTime? EndOfEvent
        {
            get; set;
        }
        public City? EventCity
        {
            get; set;
        }

        public PublicEvent() : this("New York Public Event")
        {
           
        }

        // Parameterized constructor
        public PublicEvent(string? eventName, DateTime? startOfEvent, DateTime? endOfEvent, City? eventCity)
        {
            EventName = eventName;
            StartOfEvent = startOfEvent;
            EndOfEvent = endOfEvent;
            EventCity = eventCity;
        }

        public PublicEvent(string? eventName)
        {
            EventName = eventName;
            StartOfEvent = new DateTime(2000, 1, 1);
            EndOfEvent = new DateTime(2000, 1, 10);
            EventCity = new City();
        }


        public abstract void PrintDetails();

        public abstract void RemoveControversialArtists();

        public abstract double DisplayFullPrice();

        public abstract void DisplayInfoAboutArtists();
        public abstract void AddNewArtist();

    }
}
