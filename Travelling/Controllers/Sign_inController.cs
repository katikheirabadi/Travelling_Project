using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravellingCore.Dto.Sign_in;
using TravellingCore.ModelsServiceRepository.SigninRepository;

namespace Travelling.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class Sign_inController : ControllerBase
    {
        private readonly SigninService signin;

        public Sign_inController(SigninService signin)
        {
            this.signin = signin;
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody]SigninInputDTO signin_item)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result =await signin.Signin(signin_item);
            if(result=="Re_Pasword is not Correct"|| result == "Accont whit this username exist...")
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
