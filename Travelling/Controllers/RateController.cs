using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravellingCore.Dto.Rate;
using TravellingCore.Dto.Rate.DeleteRate;
using TravellingCore.Dto.Rate.GetPlaceRates;
using TravellingCore.Dto.Rate.GetRate;
using TravellingCore.Dto.Rate.UpdateRate;
using TravellingCore.Model;
using TravellingCore.ModelsServiceRepository.Models.Methods;
using TravellingCore.Services.Models.Services.RateService;

namespace Travelling.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RateController : ControllerBase
    {
        private readonly IRateService RateServise;

        public RateController(IRateService RateServise)
        {
            this.RateServise = RateServise;
        }
        [HttpPost]
        public async Task<IActionResult> AddRate([FromBody]RateInputDto rate,[FromHeader]string Token)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await RateServise.AddRate(rate, Token);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetRate([FromBody]GetrateInputDto getinput)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await RateServise.GetRate(getinput);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllRates()
        {
            var result = await RateServise.GetAllRate();
            return Ok(result); 
        }
        [HttpGet]
        public async Task<IActionResult> GetAllRatesOfPlace([FromBody]GetPlaceRatesInputDto getplaceinput)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await RateServise.GetAllRatesOfPlace(getplaceinput);
            return Ok(result);
            
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteRate([FromBody]DeleterateInputDto deleterateinput)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await RateServise.DeleteRate(deleterateinput);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateRate([FromBody]UpdateRateInputDto updateinput)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await RateServise.UpdateRate(updateinput);
            return Ok(result);
        }
    }
}
