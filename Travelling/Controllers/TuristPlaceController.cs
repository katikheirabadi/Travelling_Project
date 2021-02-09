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
        private readonly ICommentService commentService;
        private readonly IRateService rateService;
        private readonly ITuristPlaceService turistPlaceService;
        private readonly ISearchservise searchServise; 

        public TuristPlaceController(ICommentService commentService
                                    ,IRateService rateService
                                    ,ITuristPlaceService turistPlaceService
                                    , ISearchservise searchServise)
        {
            this.commentService = commentService;
            this.rateService = rateService;
            this.turistPlaceService = turistPlaceService;
            this.searchServise = searchServise;
        }

        [HttpPost]
        public async Task<IActionResult> AddComent([FromBody] ComentInsertDto coment, [FromHeader] string Token)
        {
            var result = await this.commentService.AddComment(coment, Token);
            if (result != "we add your coment .")
                return BadRequest(result);
            await this.commentService.Save();
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> AddRate([FromBody] RateInputDto dto, [FromHeader] string Token)
        {
            var result = await this.rateService.AddRate(dto, Token);
            if (result != "we add your Rate .")
                return BadRequest(result);
            await this.rateService.Save();
            return Ok(result);
        }
        [HttpGet]
        public  IActionResult ShowPlace([FromBody] TuristPlaceInputDto turistPlace)
        {
            var result = searchServise.SearchByName(turistPlace);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> DBCreate(TuristPlace place)
        {
            try
            {
                turistPlaceService.Insert(place);
                await turistPlaceService.Save();
                place.Visit = 0;
                return Ok(place.Name + "Add");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> DBGetPlace(int id)
        {
            try
            {
                var result = await turistPlaceService.Get(id);
                return Ok(result);
            }
            catch
            {
                return BadRequest("we don't have this id....");

            }
        }
        [HttpGet]
        public async Task<IActionResult> DBGetAllPlaces()
        {
            try
            {
                var result = await turistPlaceService.GetAll();
                return Ok(result);
            }
            catch
            {
                return BadRequest("you have exception..");
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DBDeletePlace(int id)
        {
            try
            {
                var result = turistPlaceService.Delete(id);
                await turistPlaceService.Save();
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> DBUpdatePlace(TuristPlace place)
        {
            try
            {
                var result = turistPlaceService.Update(place);
                await turistPlaceService.Save();
                return Ok(result);
            }
            catch(Exception e)
            {
                if (e.Message == "you have Exception please check...")
                    return BadRequest(e.Message);
                return BadRequest("your update have exeption ...");
            }
        }
        [HttpGet]
        public async Task<IActionResult> NewPlaces([FromQuery] int size)
        {
            var example = await turistPlaceService.NewPlaces(size);
            if (example == null)
                return NotFound();
            return Ok(example);
        }
        [HttpGet]
        public async Task<IActionResult> View([FromBody] VisitInputDto turistPlace)
        {
            var reasult = await turistPlaceService.View(turistPlace);
            return Ok(reasult);
        }
        [HttpGet]
        public async Task<IActionResult> ShowVisit([FromQuery] int size)
        {
            var reasult = await turistPlaceService.ShowVisit(size);
            return Ok(reasult);
        }
        [HttpGet]
        public async Task<IActionResult> ShoePopular([FromQuery] int size)
        {
            var reasult = await turistPlaceService.ShowPopular(size);
            return Ok(reasult);
        }
            
    }

}

