using chemicalElement.Data.Models.ViewModels;
using chemicalElement.DBModelUpdate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace chemicalElement.Data.Services
{
    public class ElementsService
    {
        private chemicalelementdbContext _context;

        public ElementsService(chemicalelementdbContext context)
        {
            _context = context;
        }

        public void AddElement(ElementVM element)
        {
            var _element = new Element()
            {

                Symbol = element.Symbol,
                NumberAtomic = element.NumberAtomic,
                Name = element.Name
            };
            _context.Elements.Add(_element);
            _context.SaveChanges();
        }

    }
}
