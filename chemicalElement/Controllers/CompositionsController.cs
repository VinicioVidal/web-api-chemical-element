using chemicalElement.Data.Models.ViewModels;
using chemicalElement.Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace chemicalElement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompositionsController : ControllerBase
    {
        public CompositionsService _CompositionsService;
        public CompositionsController(CompositionsService compositionsService)
        {
            _CompositionsService = compositionsService;
        }

        [HttpPost("add-compositions")]
        public IActionResult AddCompositions([FromBody]CompositionVM Compositions)
        {
            _CompositionsService.AddComposition(Compositions);
            return Ok();
        }

    }
}
