using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piano.KeyEntity
{
    /*
     * This structure represents a piano key on a piano keyboard.
     */
    enum Octave
    {
        Zeroth,
        First,
        Second,
        Third,
        Fourth,
        Fifth,
        Sixth,
        Seventh,
        Eigth
    }

    enum Note
    {
        C,
        D,
        E,
        F,
        G,
        A,
        B
    }

    enum Accidental
    {
        Flat,
        NoSign,
        Sharp        
    }

    struct Key: IComparable<Key>
    {
        public Note Note;
        public Octave Octave;
        public Accidental Accidental;

        public Key (Note note, Accidental accidental, Octave octave)
        {
            Note = note;
            Octave = octave;
            Accidental = accidental;
        }

        public int CompareTo(Key other)
        {
            return 14 * (Octave - other.Octave) + 2 * (Note - other.Note) + Accidental - other.Accidental;
        }

        public override string ToString()
        {
            var accidentalSign = String.Empty;

            if (Accidental == Accidental.Sharp)
            {
                accidentalSign = "#";
            }
            else if (Accidental == Accidental.Flat)
            {
                accidentalSign = "b";
            }

            return $"{Note}{accidentalSign} ({(int)Octave})";
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Key))
            {
                return false;
            }
            else
            {
                return this.CompareTo((Key)obj) == 0;
            }            
        }
    }
}
