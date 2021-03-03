using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravellingCore.Dto.City.AddCity;
using TravellingCore.Dto.City.DeleteCity;
using TravellingCore.Dto.City.GetCity;
using TravellingCore.Dto.City.GetCountryCities;
using TravellingCore.Services.Models.Services.CityService;

namespace Travelling.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService CityService;

        public CityController(ICityService CityService)
        {
            this.CityService = CityService;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]AddCityInputDto addinput)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await CityService.Addcity(addinput);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetCity([FromBody] GetCityInputDto getinput)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await CityService.GetCityByName(getinput);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCities()
        {
            var result = await CityService.GetAllCities();
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetCountryCities([FromBody] GetCountryCitiesInputDto getinput)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await CityService.GetCountryCities(getinput);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCity([FromBody] DeleteCityInput deleteinput)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await CityService.DeleteCity(deleteinput);
            return Ok(result);
        }
    }
}
