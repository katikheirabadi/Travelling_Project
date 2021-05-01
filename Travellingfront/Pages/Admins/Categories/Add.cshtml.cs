using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TravellingCore.Dto.Category.AddCategory;
using TravellingCore.Services.Models.Services.CategoryServise;

namespace Travellingfront.Pages.Admins.Categories
{
    public class AddModel : PageModel
    {
        private readonly ICategoryServise categoryServise;

        [BindProperty]
        public AddCategoryInputDto NewCategory { get; set; }
        [BindProperty]
        public bool State { get; set; }
        public AddModel(ICategoryServise categoryServise)
        {
            this.categoryServise = categoryServise;
        }
        public async Task<IActionResult> OnPost()
        {
            try
            {
                if (!ModelState.IsValid)
                    return Page();
                await categoryServise.AddCategory(NewCategory);
                State = true;
                return RedirectToPage("./Category");

            }
            catch (Exception e)
            {

                State = false;
                ViewData["Error"] = e.Message;
                return Page();
            }
        }
    }
}
