using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravellingCore.Claims;
using TravellingCore.Dto.Sign_in;
using TravellingCore.Model;

namespace Travelling.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;

        public UserController(SignInManager<User> signInManager,
                              UserManager<User> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }
        [HttpPost]
        public async Task<IActionResult> Add(SigninInputDTO signin)
        {
            var user = new User();
            if (!ModelState.IsValid)
                return BadRequest();
            else if (ModelState.IsValid)
            {
                user.FullName = signin.FullName;
                user.UserName = signin.Username;
                user. Password = signin.Password;
                user.RePassword = signin.RePassword;
                user.PhoneNumber = signin.PhoneNumber;
                user.FavoriteCategory = signin.FavoriteCategory;
                user.FavoriteCountry = signin.FavoriteCountry;
            }
            var result = await userManager.CreateAsync(user, signin.Password);
            await userManager.AddToRoleAsync(user, AppRole.User.ToString());
            if (result.Succeeded)
            {
                await signInManager.SignInAsync(user, isPersistent: false);
                return Ok();
               
            }
            List<Object> errors = new List<object>();
            foreach (var error in result.Errors)
            {
                // ModelState.AddModelError("", error.Description);
                errors.Add(error.Description);
            }

            return BadRequest(errors);

        }
    }
}
