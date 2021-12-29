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
    }
}
