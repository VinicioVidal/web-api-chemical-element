using System;
using System.Collections.Generic;

#nullable disable

namespace chemicalElement.DBModelUpdate
{
    public partial class Composed
    {
        public Composed()
        {
            Compositions = new HashSet<Composition>();
        }

        public int CodeComposed { get; set; }
        public string Formula { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Composition> Compositions { get; set; }
    }
}
