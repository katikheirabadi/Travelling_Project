using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TravellingCore.Dto.Category.GetCategory;
using TravellingCore.Services.Models.Services.CategoryServise;

namespace Travellingfront.Pages
{
    public class CategoryModel : PageModel
    {
        private readonly ICategoryServise categoryServise;

        public CategoryModel(ICategoryServise categoryServise)
        {
            this.categoryServise = categoryServise;
        }

        [BindProperty]
        public GetCategoryByIdOutput Category { get; set; }

        public async Task OnGet(int id)
        {
            Category = await categoryServise.GetCategoryById(id);
        }
    }
}
