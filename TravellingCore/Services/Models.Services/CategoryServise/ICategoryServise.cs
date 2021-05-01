using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TravellingCore.Dto.Category.AddCategory;
using TravellingCore.Dto.Category.DeleteCategory;
using TravellingCore.Dto.Category.GetallPlaceCategory;
using TravellingCore.Dto.Category.GetAllWithId;
using TravellingCore.Dto.Category.GetCategory;
using TravellingCore.Dto.Country.Get_CountrywithId;

namespace TravellingCore.Services.Models.Services.CategoryServise
{
    public interface ICategoryServise
    {
        public Task<string> AddCategory(AddCategoryInputDto addinput);
        public Task<GetCategoryOutputDto> GetCategoryByName(GetCategoryInputDto getinput);
        public Task<List<GetCategoryOutputDto>> GetAllCategories();
        public Task<string> DeleteCategory(DeleteCategoryInputDto deleteinput);
        public Task<List<GetPlaceCategoryOutputDto>> GetPlaceCategory(GetPlaceCategoryInputDto getinput);
        public Task<GetCategoryByIdOutput> GetCategoryById(int id);
        public Task DeleteById(int id);
        public Task<List<GetallCategoriesWithIdOutPutDto>> GetAll();
    }
}
