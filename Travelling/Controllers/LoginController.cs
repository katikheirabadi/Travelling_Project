using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravellingCore.Dto.LogIn;
using TravellingCore.Dto.LogIn.UpdateUserLogin;
using TravellingCore.ServiceRepository.LoginService;
using TravellingCore.Services.LoginService;

namespace Travelling.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginServicecs LoginService;

        public LoginController(ILoginServicecs login)
        {
            this.LoginService = login;
        }
        [HttpPost]
        public async Task<IActionResult> AddLogin(LoginInputDto loginitem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result =await LoginService.AddLogin(loginitem);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> ShowUserLogin([FromHeader] string Token)
        {
            var result = await LoginService.ShowUserLogin(Token);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> ShowAll()
        {
            var result = await LoginService.ShowAllUserLogin();
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateUserLogin([FromBody]UpdateUserLoginInputDto update, [FromHeader]string Token)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await LoginService.UpdateUserLogin(update, Token);
            return Ok(result);
        }
    }
}
