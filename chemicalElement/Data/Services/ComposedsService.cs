using chemicalElement.Data.Models.ViewModels;
using chemicalElement.DBModelUpdate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace chemicalElement.Data.Services
{
    public class ComposedsService
    {
        private chemicalelementdbContext _context;

        public ComposedsService(chemicalelementdbContext context)
        {
            _context = context;
        }

        public void AddComposed(ComposedVM composed)
        {
            var _Composed = new Composed()
            {
                 Formula = composed.Formula,
                 Name = composed.Name
            };
            _context.Composeds.Add(_Composed);
            _context.SaveChanges();
        }
    }
}
