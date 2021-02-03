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

namespace Travelling.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TuristPlaceController : ControllerBase
    {
        private readonly ComentService coment;
        private readonly RateServicr rate;
        private readonly Turist_PLace_Service service;

        public TuristPlaceController(ComentService coment, RateServicr rate, Turist_PLace_Service _Service)
        {
            this.coment = coment;
            this.rate = rate;
            service = _Service;
        }

        [HttpPost]
        public async Task<IActionResult> AddComent([FromBody] ComentInsertDto coment, [FromHeader] string Token)
        {
            var result = await this.coment.Insert(coment, Token);
            if (result != "we add your coment .")
                return BadRequest(result);
            await this.coment.Save();
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> AddRate([FromBody] RateInputDto dto, [FromHeader] string Token)
        {
            var result = await this.rate.Insert(dto, Token);
            if (result != "we add your Rate .")
                return BadRequest(result);
            await this.rate.Save();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> DBCreate(Turist_Place place)
        {
            try
            {
                service.Insert(place);
                await service.Save();
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
                var result = await service.Get(id);
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
                var result = await service.GetAll();
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
                var result = service.Delete(id);
                await service.Save();
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        //[HttpGet]
        //public async Task<IActionResult> DBUpdatePlace()
        //{

        //}

    }

}

