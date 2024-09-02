using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleAppProject
{

    internal abstract class Entertainer
    {
        public string? Name {  get; set; }
        public string? Surname {  get; set; }
        public DateTime DOB { get; set; }
        public string? PlaceOfBirth {  get; set; }
        public List<string>? Languages {  get; set; }
        public bool IsControversial {  get; set; }
        public bool IsAvailable {  get; set; }

        public Entertainer(string? name, string? surname, DateTime dob, string? placeOfBirth, List<string>? languages, bool isControversial, bool isAvailable)
        {
            Name = name;
            Surname = surname;
            DOB = dob;
            PlaceOfBirth = placeOfBirth;
            Languages = languages;
            IsControversial = isControversial;
            IsAvailable = isAvailable;
        }
        public Entertainer() { }
        public abstract void PrintInfo();


    }
}
