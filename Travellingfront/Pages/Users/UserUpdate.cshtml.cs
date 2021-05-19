using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TravellingCore.Dto.Sign_in;
using TravellingCore.Model;
using TravellingCore.Services.Models.Services.CategoryServise;
using TravellingCore.Services.Models.Services.CountryService;

namespace Travellingfront.Pages.Users
{
    public class UserUpdateModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ICountryService countryService;
        private readonly ICategoryServise categoryServise;

        public UserUpdateModel(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            ICountryService countryService,
            ICategoryServise categoryServise)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            this.countryService = countryService;
            this.categoryServise = categoryServise;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public SigninInputDTO Input { get; set; }



        private async Task LoadAsync(User user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            Username = userName;

            Input = new SigninInputDTO
            {
                Username = user.UserName,
                FavoriteCategory = user.FavoriteCategory,
                FavoriteCountry = user.FavoriteCountry,
                FullName = user.FullName,
                Password = user.Password,
                RePassword = user.RePassword,
                PhoneNumber = phoneNumber
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var countries = await countryService.GetAll();
            var categories = await categoryServise.GetAll();

            ViewData["Countries"] = new SelectList(countries, "Id", "Name");
            ViewData["categories"] = new SelectList(categories, "Id", "Name");


            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound(
                    $"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound(
                    $"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }


            await _userManager.UpdateAsync(user);

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage("./UserPannel");
        }
    }
}
