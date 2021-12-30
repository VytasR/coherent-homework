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
            var c1 = new Key(Note.C, Accidental.Sharp, Octave.First);
            var d1 = new Key(Note.D, Accidental.Flat, Octave.First);
            var b4 = new Key(Note.B, Accidental.NoSign, Octave.Fourth);

            Console.WriteLine(c1);
            Console.WriteLine(d1);
            Console.WriteLine(b4);
            Console.WriteLine($"Key {c1} equals key {d1} : {c1.Equals(d1)}");
            Console.WriteLine($"Key {d1} equals key {b4} : {d1.Equals(b4)}");
            Console.WriteLine(c1.CompareTo(d1));
            Console.WriteLine(d1.CompareTo(b4));

            Console.ReadKey();
        }
    }
}
