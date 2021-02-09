using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravellingCore.Dto.Sign_in;
using TravellingCore.Dto.User.DeleteUser;
using TravellingCore.Dto.User.GetUser;
using TravellingCore.Dto.User.UpdateUser;
using TravellingCore.ModelsServiceRepository.SigninRepository;
using TravellingCore.Services.SigninServicefoulder;

namespace Travelling.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService UserService;

        public UserController(IUserService signin)
        {
            this.UserService = signin;
        }
        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody]SigninInputDTO signin_item)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result =await UserService.AddUser(signin_item);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> ShowUser([FromBody] GetUserInputDto getinput)
        {
            return Ok(await UserService.ShowUser(getinput));
        }
        [HttpGet]
        public async Task<IActionResult> ShowAll()
        {
            var result = await UserService.ShowAllUser();
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteUser([FromBody]DeleteUseiInputDto deleteinput)
        {
            var result = await UserService.DeleteUser(deleteinput);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateUder([FromBody]UpdateUserOutputDto updateinput)
        {
            var result = await UserService.UpdateUser(updateinput);
            return Ok(result);
        }
    }
}
