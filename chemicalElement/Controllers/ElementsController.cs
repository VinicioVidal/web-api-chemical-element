using chemicalElement.Data.Models.ViewModels;
using chemicalElement.Data.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace chemicalElement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElementsController : ControllerBase
    {
        public ElementsService _ElementsService;
        public ElementsController(ElementsService elementsService)
        {
            _ElementsService = elementsService;
        }

        [HttpPost("add-elements")]
        public IActionResult AddElements([FromBody]ElementVM Elements)
        {
            try
            {
                _ElementsService.AddElement(Elements);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                
            }
        }
    }
}
