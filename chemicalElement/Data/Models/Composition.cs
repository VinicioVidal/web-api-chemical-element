using System;
using System.Collections.Generic;

#nullable disable

namespace chemicalElement.DBModelUpdate
{
    public partial class Composition
    {
        public int Id { get; set; }
        public string Symbol { get; set; }
        public int CodeComposed { get; set; }
        public int NumberOfAtoms { get; set; }

        public virtual Composed CodeComposedNavigation { get; set; }
        public virtual Element SymbolNavigation { get; set; }
    }
}
