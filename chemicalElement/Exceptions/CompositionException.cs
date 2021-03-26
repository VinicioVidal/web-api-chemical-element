using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace chemicalElement.Exceptions
{
    public class CompositionException : Exception
    {
        public string NumberOfAtoms { get; set; }

        public CompositionException()
        {

        }
        public CompositionException(string message) : base(message)
        {


        }

        public CompositionException(string message, Exception inner) : base(message, inner)
        {

        }

        public CompositionException(string message, string numberOfAtoms) : this(message)
        {
            NumberOfAtoms = numberOfAtoms;
        }
        

    }
}
