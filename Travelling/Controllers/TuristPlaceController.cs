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

        [HttpGet]
        public  IActionResult ShowPlace([FromBody] TuristPlaceInputDto turistPlace)
        {
            var result = searchServise.SearchByName(turistPlace);
            return Ok(result);
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

