using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravellingCore.Dto.Country.AddCountry;
using TravellingCore.Dto.Country.DeleteCountry;
using TravellingCore.Dto.Country.GetCountry;
using TravellingCore.Services.Models.Services.CountryService;

namespace Travelling.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService CountryService;

        public CountryController(ICountryService CountryService)
        {
            this.CountryService = CountryService;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddCountryInputDto addinput)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await CountryService.AddCountry(addinput);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetCountry([FromBody]GetCountryInputDto getinput)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await CountryService.GetCountry(getinput);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCountry()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await CountryService.GetAllCountry();
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody]DeleteCountryInputDto deleteinput)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await CountryService.DeleteCountry(deleteinput);
            return Ok(result);
        }
    }
}
