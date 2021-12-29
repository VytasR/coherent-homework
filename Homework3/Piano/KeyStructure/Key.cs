using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piano.KeyEntity
{

    public enum Octave
    {
        First,
        Second,
        Third,
        Fourth,
        Fifth,
        Sixth,
        Seventh
    }

    public enum Note
    {
        A,
        B,
        C,
        D,
        E,
        F,
        G
    }

    public enum Accidental
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
            return $"Key note: {Note}, octave: {Octave}, accidental: {Accidental}";
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
