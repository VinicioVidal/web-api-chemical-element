using chemicalElement.Data.Models.ViewModels;
using chemicalElement.Data.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace chemicalElement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComposedsController : ControllerBase
    {
        public ComposedsService _ComposedService;
        public ComposedsController(ComposedsService composedsService)
        {
            _ComposedService = composedsService;
        }

        [HttpPost("add-composeds")]
        public IActionResult AddComposeds([FromBody] ComposedVM Composeds)
        {

            try
            {
                _ComposedService.AddComposed(Composeds);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }

           
        }

    }
}
