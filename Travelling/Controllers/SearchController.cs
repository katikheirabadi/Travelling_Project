using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravellingCore.ContextRepositoryInterface;
using TravellingCore.Dto._ُSearchByCategory;
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
            var place = await searchService.SearchByName(turistPlace);
            return Ok(place);
        }
        
        [HttpGet]
        public async Task<IActionResult> SearchbyCity([FromQuery]string city_name)
        {
            var city = await searchService.SearchbyCity(city_name);
            if (city == null)
                return NotFound();
            return Ok(city);
        }
        [HttpGet]
        public async Task<IActionResult> SearchByCountryName([FromBody] CountryInputDto country)
        {
            var Places = await searchService.SearchByCountry(country);
            return Ok(Places);
        }
        public async  Task<IActionResult> SearchByCategory([FromBody] CategoryInputDto category)
        {
            var atr = await searchService.SearchByCategory(category);
            return Ok(atr);
        }
        [HttpGet]
        public FilterOutputDTO SearchByFilter([FromBody] FilterInputDTO filterInputDTO)
        {
            return searchService.SearchByFilter(filterInputDTO);
        }
        
    }
}
