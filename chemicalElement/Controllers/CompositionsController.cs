using chemicalElement.Data.Models.ViewModels;
using chemicalElement.Data.Services;
using chemicalElement.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System;

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
            try
            {
                _CompositionsService.AddComposition(Compositions);
                
            }
            catch (CompositionException ex)
            {
                return BadRequest($"{ex.Message}, Numero de átomos : {ex.NumberOfAtoms}");
            }
            catch (Exception ex)
            {
                if (ex.InnerException.Message.Contains("UNIQUE KEY"))
                {
                  return BadRequest($"- Error al ingresar la composición quimica simbolo quimico repetido: {Compositions.Symbol}");
                }
                else
                {
                    return BadRequest($"{ex.Message}  - Error al ingresar la composición quimica : {Compositions.Symbol}");
                }

            }

            return Ok();
        }

    }
}
