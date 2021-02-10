using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravellingCore.Model;
using TravellingCore.ModelsServiceRepository.Models.Methods;
using TravellingCore.Services.Models.Services.RateService;

namespace Travelling.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RateController : ControllerBase
    {
        private readonly IRateService service;

        public RateController(IRateService service)
        {
            this.service = service;
        }

    }
}
