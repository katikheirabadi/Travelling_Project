using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravellingCore.Dto.TuristPlaceCategory.Regisster;
using TravellingCore.Services.Models.Services.TuristPlaceCategoryServise;

namespace Travelling.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TuristPlaceCategoryController : ControllerBase
    {
        private readonly ITuristPlaceCategoryServise TuristPlaceCategoryServise;

        public TuristPlaceCategoryController(ITuristPlaceCategoryServise TuristPlaceCategoryServise)
        {
            this.TuristPlaceCategoryServise = TuristPlaceCategoryServise;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]RegisterInputDto registerinput)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await TuristPlaceCategoryServise.Register(registerinput);
            return Ok(result);

        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody]RegisterInputDto unregisterinput)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await TuristPlaceCategoryServise.UnRegister(unregisterinput);
            return Ok(result);
        }
    }
}
