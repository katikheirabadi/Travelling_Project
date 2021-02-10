using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravellingCore.Dto.Coment;
using TravellingCore.Dto.Rate;
using TravellingCore.Dto.SearchByTuristPlaceName;
using TravellingCore.Dto.Visit;
using TravellingCore.Dto.TuristPlace.AddPlace;
using TravellingCore.Dto.TuristPlace.DeletePlace;
using TravellingCore.Dto.TuristPlace.GetPlace;
using TravellingCore.Dto.TuristPlace.UpdatePlace;
using TravellingCore.Model;
using TravellingCore.ModelsServiceRepository.Models.Methods;
using TravellingCore.Services.Models.Services.CommentServise;
using TravellingCore.Services.Models.Services.RateService;
using TravellingCore.Services.Models.Services.SearchServise;
using TravellingCore.Services.Models.Services.TuristPlaceService;

namespace Travelling.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TuristPlaceController : ControllerBase
    {
        private readonly ITuristPlaceService TuristPlaceService;

        public TuristPlaceController(ITuristPlaceService TuristPlaceService)
        {
            this.TuristPlaceService = TuristPlaceService;
        }

    
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]AddPlaceInputDto addinput)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await TuristPlaceService.AddTuristPlace(addinput);
            return Ok(result);

        }
        [HttpGet]
        public async Task<IActionResult> GetPlace([FromBody]GetPlaceInput getinput)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await TuristPlaceService.GetPlace(getinput);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPlace()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await TuristPlaceService.GetAllPlaces();
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> NewPlaces([FromQuery]int size)
        {
            var result = await TuristPlaceService.NewPlaces(size);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody]DeletePlaceInputDto deleteinput)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await TuristPlaceService.DeletePlace(deleteinput);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdatePlace([FromBody]UpdatePlaceInputDto updateinput)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await TuristPlaceService.UpdatePlace(updateinput);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> ShowVisit([FromQuery] int size)
        {
            var reasult = await TuristPlaceService.ShowVisit(size);
            return Ok(reasult);
        }
        [HttpGet]
        public async Task<IActionResult> ShoePopular([FromQuery] int size)
        {
            var reasult = await TuristPlaceService.ShowPopular(size);
            return Ok(reasult);
        }
    }

 }
       
            
    



