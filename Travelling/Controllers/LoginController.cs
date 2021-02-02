using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravellingCore.Dto.LogIn;
using TravellingCore.ServiceRepository.LoginService;

namespace Travelling.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly LoginServicr login;

        public LoginController(LoginServicr login)
        {
            this.login = login;
        }
        [HttpPost]
        public async Task<IActionResult> Add(LoginInputDto loginitem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result =await login.AddLogin(loginitem);
            if (result == "Not Found Any User with this Information...")
                return NotFound("Not Found Any User with this Information...");
            return Ok(result);
        }
    }
}
