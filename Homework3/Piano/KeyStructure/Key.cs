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
        NoSign,
        Sharp,
        Flat
    }

    struct Key
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

    }
}
