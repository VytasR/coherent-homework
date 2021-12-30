using Piano.KeyEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piano
{
    internal class Program
    {
        /*
         * This program demonstrates the use of structure Key.
         */
        static void Main(string[] args)
        {
            var c1Sharp = new Key(Note.C, Accidental.Sharp, Octave.First);
            var d1Flat = new Key(Note.D, Accidental.Flat, Octave.First);
            var Sharp = new Key(Note.B, Accidental.Sharp, Octave.Fourth);
            var c5Natural = new Key(Note.C, Accidental.NoSign, Octave.Fifth);

            Console.WriteLine(c1Sharp);
            Console.WriteLine(d1Flat);
            Console.WriteLine(Sharp);
            Console.WriteLine(c5Natural);
            Console.WriteLine($"Key {c1Sharp} equals key {d1Flat} : {c1Sharp.Equals(d1Flat)}");
            Console.WriteLine($"Key {d1Flat} equals key {Sharp} : {d1Flat.Equals(Sharp)}");
            Console.WriteLine($"Key {Sharp} equals key {c5Natural} : {Sharp.Equals(c5Natural)}");
            Console.WriteLine(c1Sharp.CompareTo(d1Flat));
            Console.WriteLine(d1Flat.CompareTo(Sharp));

            Console.ReadKey();
        }
    }
}
