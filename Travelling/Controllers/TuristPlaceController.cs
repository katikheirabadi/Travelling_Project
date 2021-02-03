using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravellingCore.Dto.Coment;
using TravellingCore.Dto.Rate;
using TravellingCore.Model;
using TravellingCore.ModelsServiceRepository.Models.Methods;

namespace Travelling.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TuristPlaceController : ControllerBase
    {
        private readonly ComentService coment;
        private readonly RateServicr rate;

        public TuristPlaceController(ComentService coment, RateServicr rate)
        {
            this.coment = coment;
            this.rate = rate;
        }
       
        [HttpPost]
        public async Task<IActionResult> AddComent([FromBody]ComentInsertDto coment,[FromHeader] string Token)
        {
            var result =await this.coment.Insert(coment,Token);
            if (result != "we add your coment .")
                return BadRequest(result);
            await this.coment.Save();
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> AddRate([FromBody] RateInputDto dto, [FromHeader] string Token)
        {
            var result = await this.rate.Insert(dto, Token);
            if (result != "we add your Rate .")
                return BadRequest(result);
            await this.rate.Save();
            return Ok(result);
        }
    }
}
