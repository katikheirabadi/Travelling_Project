using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravellingCore.Dto.Compare;
using TravellingCore.Services.Models.Services.CompareService;

namespace Travelling.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompareController : ControllerBase
    {
        private readonly ICompareService compareService;
        public CompareController(ICompareService compareService)
        {
            this.compareService = compareService;
        }
        [HttpGet]
        public async Task<IActionResult> CompareAttraction([FromBody] CompareInputDTO compareInputDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = await compareService.CompareAttraction(compareInputDTO.FirstAttraction, compareInputDTO.SecondAttraction);
            return Ok(result);
        }
    }
}
