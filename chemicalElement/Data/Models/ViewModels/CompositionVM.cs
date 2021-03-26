using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace chemicalElement.Data.Models.ViewModels
{
    public class CompositionVM
    {
        public string Symbol { get; set; }
        public int CodeComposed { get; set; }
        public int NumberOfAtoms { get; set; }
    }
}
