using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TravellingCore.Dto.Category.AddCategory;
using TravellingCore.Dto.Category.DeleteCategory;
using TravellingCore.Dto.Category.GetallPlaceCategory;
using TravellingCore.Dto.Category.GetCategory;

namespace TravellingCore.Services.Models.Services.CategoryServise
{
    public interface ICategoryServise
    {
        public Task<string> AddCategory(AddCategoryInputDto addinput);
        public Task<GetCategoryOutputDto> GetCategory(GetCategoryInputDto getinput);
        public Task<List<GetCategoryOutputDto>> GetAllCategories();
        public Task<string> DeleteCategory(DeleteCategoryInputDto deleteinput);
        public Task<List<GetPlaceCategoryOutputDto>> GetPlaceCategory(GetPlaceCategoryInputDto getinput);
    }
}
