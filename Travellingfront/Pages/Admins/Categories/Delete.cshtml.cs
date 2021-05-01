using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TravellingCore.Dto.Category.GetCategory;
using TravellingCore.Services.Models.Services.CategoryServise;

namespace Travellingfront.Pages.Admins.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly ICategoryServise categoryServise;

        [BindProperty]
        public bool State { get; set; }
        [BindProperty]
        public GetCategoryByIdOutput Category { get; set; }
        public DeleteModel(ICategoryServise categoryServise)
        {
            this.categoryServise = categoryServise;
        }
        public async Task<IActionResult> OnGet(int id)
        {
            try
            {
                Category = await categoryServise.GetCategoryById(id);
                await categoryServise.DeleteById(id);
                State = true;
                return Page();
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
