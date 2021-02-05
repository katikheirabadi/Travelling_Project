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
        private readonly TuristPlaceService service;

        public TuristPlaceController(ComentService coment, RateServicr rate, TuristPlaceService _Service)
        {
            this.coment = coment;
            this.rate = rate;
            service = _Service;
        }

        [HttpPost]
        public async Task<IActionResult> AddComent([FromBody] ComentInsertDto coment, [FromHeader] string Token)
        {
            var result = await this.coment.AddComment(coment, Token);
            if (result != "we add your coment .")
                return BadRequest(result);
            await this.coment.Save();
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> AddRate([FromBody] RateInputDto dto, [FromHeader] string Token)
        {
            var result = await this.rate.AddRate(dto, Token);
            if (result != "we add your Rate .")
                return BadRequest(result);
            await this.rate.Save();
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> ShowPlace([FromBody] string Name)
        {
            try
            {
                var result = service.ShoPlaceByName(Name);
                return Ok(result);
            }
            catch(Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> DBCreate(TuristPlace place)
        {
            try
            {
                service.Insert(place);
                await service.Save();
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
        [HttpGet]
        public async Task<IActionResult> DBUpdatePlace(TuristPlace place)
        {
            try
            {
                var result = service.Update(place);
                await service.Save();
                return Ok(result);
            }
            catch(Exception e)
            {
                if (e.Message == "you have Exception please check...")
                    return BadRequest(e.Message);
                return BadRequest("your update have exeption ...");
            }
        }

    }

}

