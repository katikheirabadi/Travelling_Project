using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravellingCore.Dto.Category.AddCategory;
using TravellingCore.Dto.Category.DeleteCategory;
using TravellingCore.Dto.Category.GetallPlaceCategory;
using TravellingCore.Dto.Category.GetCategory;
using TravellingCore.Services.Models.Services.CategoryServise;

namespace Travelling.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryServise CategoryServise;

        public CategoryController(ICategoryServise CategoryServise)
        {
            this.CategoryServise = CategoryServise;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]AddCategoryInputDto addinput)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await CategoryServise.AddCategory(addinput);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetCategory([FromBody]GetCategoryInputDto getinput)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await CategoryServise.GetCategoryByName(getinput);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCategory()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await CategoryServise.GetAllCategories();
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetPlaceCategories([FromBody] GetPlaceCategoryInputDto getinput)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await CategoryServise.GetPlaceCategory(getinput);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody]DeleteCategoryInputDto deleteinput)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await CategoryServise.DeleteCategory(deleteinput);
            return Ok(result);
        }
    }
}
