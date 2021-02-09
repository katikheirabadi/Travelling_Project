using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravellingCore.Dto.SearchByFilter;
using TravellingCore.Services.Models.Services.SerachByFilterService;

namespace Travelling.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchByFilterController : ControllerBase
    {
        private readonly IFilterService filterService;
        public SearchByFilterController(IFilterService filterService)
        {
            this.filterService = filterService;
        }
        [HttpGet]
        public FilterOutputDTO SearchByFilter([FromBody]FilterInputDTO filterInputDTO)
        {
            return filterService.SearchByFilter(filterInputDTO);
        }
    }
}
