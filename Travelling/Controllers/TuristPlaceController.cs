using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravellingCore.Dto.Coment;
using TravellingCore.Dto.Rate;
using TravellingCore.Model;
using TravellingCore.ModelsServiceRepository.Models.Methods;
using TravellingCore.Services.Models.Services.CommentServise;
using TravellingCore.Services.Models.Services.RateService;
using TravellingCore.Services.Models.Services.TuristPlaceService;

namespace Travelling.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TuristPlaceController : ControllerBase
    {
        private readonly ICommentService coment;
        private readonly IRateService rate;
        private readonly ITuristPlaceService service;

        public TuristPlaceController(ICommentService coment, IRateService rate, ITuristPlaceService _Service)
        {
            this.coment = coment;
            this.rate = rate;
            service = _Service;
        }

    
        }

    }



