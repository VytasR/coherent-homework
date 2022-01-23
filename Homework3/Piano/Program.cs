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
            var e3Natural = new Key(Note.E, Accidental.NoSign, Octave.Third);
            var f3Flat = new Key(Note.F, Accidental.Flat, Octave.Third);
            var f3Natural = new Key(Note.F, Accidental.NoSign, Octave.Third);
            var b4Sharp = new Key(Note.B, Accidental.Sharp, Octave.Fourth);
            var c5Natural = new Key(Note.C, Accidental.NoSign, Octave.Fifth);           
           
            Console.WriteLine($"Key {c1Sharp} equals key {d1Flat} : {c1Sharp.Equals(d1Flat)}");
            Console.WriteLine($"Key {d1Flat} equals key {e3Natural} : {d1Flat.Equals(e3Natural)}");
            Console.WriteLine($"Key {f3Flat} equals key {e3Natural} : {f3Flat.Equals(e3Natural)}");
            Console.WriteLine($"Key {f3Natural} equals key {e3Natural} : {f3Natural.Equals(e3Natural)}");
            Console.WriteLine($"Key {b4Sharp} equals key {c5Natural} : {b4Sharp.Equals(c5Natural)}");
            Console.WriteLine("-------------------------------");
            Console.WriteLine($"Key {c1Sharp} compares to key {d1Flat} : {c1Sharp.CompareTo(d1Flat)}");
            Console.WriteLine($"Key {d1Flat} compares to key {e3Natural} : {d1Flat.CompareTo(e3Natural)}");
            Console.WriteLine($"Key {f3Flat} compares to key {e3Natural} : {f3Flat.CompareTo(e3Natural)}");
            Console.WriteLine($"Key {f3Natural} compares to key {e3Natural} : {f3Natural.CompareTo(e3Natural)}");
            Console.WriteLine($"Key {b4Sharp} compares to key {c5Natural} : {b4Sharp.CompareTo(c5Natural)}");            

            Console.ReadKey();
        }
    }
}
