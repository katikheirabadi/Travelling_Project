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

namespace Travelling.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IRepository<Turist_Place> turistPlace;
        public HomeController(IRepository<Turist_Place> turistPlace, IMapper mapper)
        {
            this.turistPlace = turistPlace;
            this.mapper = mapper;
        }
        [HttpGet]
        public NameOutputDTO SearchbyName([FromQuery] string Name)
        {
            var place = turistPlace.GetQuery()
                .FirstOrDefault(x => x.Name.Contains(Name));
            return mapper.Map<NameOutputDTO>(place);
        }
    }
}
