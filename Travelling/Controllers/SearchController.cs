using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravellingCore.ContextRepositoryInterface;
using TravellingCore.Dto.SearchByName;
using TravellingCore.Model;
using TravellingCore.ModelsServiceRepository.Models.Methods;
using TravellingCore.Services.Models.Services.TuristPlaceService;

namespace Travelling.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ITuristPlaceService turistService;
        public SearchController(ITuristPlaceService turist)
        {
            this.turistService = turist;
        }
        [HttpGet]
        public async Task<IActionResult> SearchbyName([FromQuery] string Name)
        {
            var place = await turistService.SearchByName(Name);
            if (place == null)
                return NotFound();
            return Ok(place);
        }
        [HttpGet]
        public async Task<IActionResult> NewPlaces([FromQuery] int size)
        {
            var example = await turistService.NewPlaces(size);
            if (example == null)
                return NotFound();
            return Ok(example);
        }
        [HttpGet]
        public async Task<IActionResult> SearchbyCity([FromQuery]string city_name)
        {
            var city = await turistService.SearchbyCity(city_name);
            if (city == null)
                return NotFound();
            return Ok(city);
        }
      //  [HttpGet]
        //public async Task<IActionResult> SearchbyVisted()
        //{
        //    //var place = await turist.SearchbyVisited();
        //    //return (IActionResult)place;
        //}
        public async Task<IActionResult> SearchByAttraction([FromQuery] string attraction)
        {
            var atr = await turistService.SearchByAttraction(attraction);
            if (atr == null)
                return NotFound();
            return Ok(atr);
        }
        [HttpGet]
        public async Task<IActionResult> SearchByCountryName([FromQuery] string Country)
        {
            var Places = await turistService.SearchByCountry(Country);
            if (Places == null)
                return NotFound();
            return Ok(Places);
        }
    }
}
