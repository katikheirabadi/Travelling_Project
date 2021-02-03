using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravellingCore.Model;
using TravellingCore.ModelsServiceRepository.Models.Methods;

namespace Travelling.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RateController : ControllerBase
    {
        private readonly RateServicr service;

        public RateController(RateServicr service)
        {
            this.service = service;
        }
        [HttpPost]
        public async Task<IActionResult> DBCreate(Rate Rate)
        {
            try
            {
                service.Insert2(Rate);
                await service.Save();
                return Ok( "your rate Add");
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
        public async Task<IActionResult> DBUpdatePlace(Rate rate)
        {
            try
            {
                var result = service.Update(rate);
                await service.Save();
                return Ok(result);
            }
            catch (Exception e)
            {
                if (e.Message == "you have Exception please check...")
                    return BadRequest(e.Message);
                return BadRequest("your update have exeption ...");
            }
        }
    }
}
