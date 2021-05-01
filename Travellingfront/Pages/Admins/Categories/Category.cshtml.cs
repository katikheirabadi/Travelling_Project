using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TravellingCore.Dto.Category.GetAllWithId;
using TravellingCore.Services.Models.Services.CategoryServise;

namespace Travellingfront.Pages.Admins.Categories
{
    public class CategoryModel : PageModel
    {
        private readonly ICategoryServise categoryServise;

        [BindProperty]
        public List<GetallCategoriesWithIdOutPutDto> Categories { get; set; }

        public CategoryModel(ICategoryServise categoryServise)
        {
            this.categoryServise = categoryServise;
        }
        public async Task OnGet()
        {
            Categories = await categoryServise.GetAll();
        }
    }
}
