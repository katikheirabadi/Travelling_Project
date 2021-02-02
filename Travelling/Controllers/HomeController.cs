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

namespace Travelling.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly Turist_PLace_Service turist;
        public HomeController(Turist_PLace_Service turist)
        {
            this.turist = turist;
        }
        [HttpGet]
        public async Task<IActionResult> SearchbyName([FromQuery] string Name)
        {
            var place = await turist.SearchByName(Name);
            if (place == null)
                return NotFound();
            return Ok(place);
        }
        [HttpGet]
        public async Task<IActionResult> New_Places([FromQuery] int size)
        {
            var example = await turist.New_Places(size);
            if (example == null)
                return NotFound();
            return Ok(example);
        }
    }
}
