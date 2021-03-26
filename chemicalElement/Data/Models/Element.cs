using System;
using System.Collections.Generic;

#nullable disable

namespace chemicalElement.DBModelUpdate
{
    public partial class Element
    {
        public Element()
        {
            Compositions = new HashSet<Composition>();
        }

        public string Symbol { get; set; }
        public int NumberAtomic { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Composition> Compositions { get; set; }
    }
}
