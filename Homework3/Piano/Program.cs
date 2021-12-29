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
        static void Main(string[] args)
        {
            var c = new Key(Note.C, Accidental.Sharp, Octave.First);
            var d = new Key(Note.D, Accidental.Flat, Octave.First);

            Console.WriteLine(c);
            Console.WriteLine(d);
            Console.WriteLine(c.Equals(d));
            Console.WriteLine(c.CompareTo(d));
        }
    }
}
