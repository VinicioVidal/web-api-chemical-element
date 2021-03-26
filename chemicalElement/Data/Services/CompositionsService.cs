using chemicalElement.Data.Models.ViewModels;
using chemicalElement.DBModelUpdate;
using chemicalElement.Exceptions;
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
            if (!NumberOfAtomsGreaterOne(composition.NumberOfAtoms))
            {
                throw new CompositionException("El número de atomos debe ser mayor ó igual a 1", composition.NumberOfAtoms.ToString());
            }
            

            var _composition = new Composition()
            {
                Symbol = composition.Symbol,
                CodeComposed = composition.CodeComposed,
                NumberOfAtoms = composition.NumberOfAtoms
            };
            _context.Compositions.Add(_composition);
            _context.SaveChanges();
        }

        private bool NumberOfAtomsGreaterOne(int number)
        {
            if (number < 1)
                return false;
            else
                return true;
        }
        
    }
}
