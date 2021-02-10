using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravellingCore.ContextRepositoryInterface;
using TravellingCore.Dto._ُSearchByCategory;
using TravellingCore.Dto.searchByCity;
using TravellingCore.Dto.SearchByCountry;
using TravellingCore.Dto.SearchByFilter;
using TravellingCore.Dto.SearchByTuristPlaceName;
using TravellingCore.Model;
using TravellingCore.ModelsServiceRepository.Models.Methods;
using TravellingCore.Services.Models.Services.SearchServise;
using TravellingCore.Services.Models.Services.TuristPlaceService;


namespace Travelling.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ISearchservise searchService;
        public SearchController(ISearchservise searchservise)
        {
            this.searchService = searchservise;
        }
        [HttpGet]
        public async Task<IActionResult> SearchbyName([FromBody] TuristPlaceInputDto turistPlace)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            
            var place = await searchService.SearchByName(turistPlace);
            return Ok(place);
        }
        
        [HttpGet]
        public async Task<IActionResult> SearchbyCity([FromBody] CityNameInputDTO citynameinputdto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var city = await searchService.SearchByCity(citynameinputdto);
            
            return Ok(city);
        }
        [HttpGet]
        public async Task<IActionResult> SearchByCountryName([FromBody] CountryInputDto country)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var Places = await searchService.SearchByCountry(country);
            return Ok(Places);
        }
        public async  Task<IActionResult> SearchByCategory([FromBody] CategoryInputDto category)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var reasult = await searchService.SearchByCategory(category);
            return Ok(reasult);
        }
        //[HttpGet]
        //public async Task<IActionResult> SearchByFilter([FromBody] FilterInputDTO filterInputDTO)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest();
        //    var reasult = await searchService.SearchByFilter(filterInputDTO);
        //    return Ok(reasult);
        //}
        
    }
}
