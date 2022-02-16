using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackingDemoApp.DemoEntities;
using TrackingLib;

namespace TrackingDemoApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var addres = new Address() { StreetName = "5 Avenue", HouseNumber = "295", ZipCode = "10016-7103" };
            var pets = new Pet[] { new Pet() { Type = "dog", Name = "Daisy", Age = 5 }, 
                                   new Pet() { Type = "cat", Name = "Max", Age = 7 } };
            var person = new Person() { FirstName = "Leonardo", LastName = "Green", Age = 35, Address = addres, _pets = pets };

            var logger = new Logger("person.json");
            logger.Track(person);
        }
    }
}
