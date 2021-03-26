using chemicalElement.Data.Models.ViewModels;
using chemicalElement.DBModelUpdate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace chemicalElement.Data.Services
{
    public class CompositionsService
    {



        private chemicalelementdbContext _context;

        public CompositionsService(chemicalelementdbContext context)
        {
            _context = context;
        }


        public void AddComposition(CompositionVM composition)
        {
            var _composition = new Composition()
            {
                Symbol = composition.Symbol,
                CodeComposed = composition.CodeComposed,
                NumberOfAtoms = composition.NumberOfAtoms
            };
            _context.Compositions.Add(_composition);
            _context.SaveChanges();
        }
    }
}
