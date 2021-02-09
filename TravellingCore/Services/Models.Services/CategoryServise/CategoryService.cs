using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using TravellingCore.ContextRepositoryInterface;
using TravellingCore.Dto.Category.AddCategory;
using TravellingCore.Model;
using TravellingCore.Exceptions;
using TravellingCore.Dto.Category.GetCategory;
using Microsoft.EntityFrameworkCore;
using TravellingCore.Dto.Category.DeleteCategory;
using TravellingCore.Dto.Category.GetallPlaceCategory;

namespace TravellingCore.Services.Models.Services.CategoryServise
{
    public class CategoryService : ICategoryServise
    {
        private readonly IRepository<Category> CategoryRepoditory;
        private readonly IRepository<TuristPlaceCategory> TuristPlaceCategory;
        private readonly IRepository<TuristPlace> TuristplaceRepository;
        private readonly IMapper mapper;

        public CategoryService(IRepository<Category> CategoryRepoditory
                               ,IRepository<TuristPlaceCategory> TuristPlaceCategory
                               ,IRepository<TuristPlace> TuristplaceRepository
                               ,IMapper mapper)
        {
            this.CategoryRepoditory = CategoryRepoditory;
            this.TuristPlaceCategory = TuristPlaceCategory;
            this.TuristplaceRepository = TuristplaceRepository;
            this.mapper = mapper;
        }
        private async Task<Category> FindCategory(string category)
        {
            var categories = await CategoryRepoditory.GetAll();
            var findcategory = categories.FirstOrDefault(c => c.Name == category);
            if (findcategory == null)
                throw new KeyNotFoundException("Not Found this category");
            return findcategory;
        }
        private async Task IsReapited(string category)
        {
            var categories = await CategoryRepoditory.GetAll();
            var findcategory = categories.FirstOrDefault(c => c.Name == category);
            if (findcategory != null)
                throw new ReapitException("this category already exist");
        }
        private async Task Findplace(string place)
        {
            var places = await TuristplaceRepository.GetAll();
            var findplace = places.Find(p => p.Name == place);
            if (findplace == null)
                throw new KeyNotFoundException("Not found any place with this name");
        }
        public async Task<string> AddCategory(AddCategoryInputDto addinput)
        {
            await IsReapited(addinput.YourCategory);

            var newcategory = new Category() { Name = addinput.YourCategory };

            CategoryRepoditory.Insert(newcategory);
            await CategoryRepoditory.Save();

            return "we add your category..";
        }
        public async Task<GetCategoryOutputDto> GetCategory(GetCategoryInputDto getinput)
        {
            var findcategory = await FindCategory(getinput.YourCategory);
            var result = CategoryRepoditory.GetQuery().Include(c => c.TuristPlaceCategory)
                                                     .Where(c => c.Name == findcategory.Name)
                                                     .Select(c => mapper.Map<GetCategoryOutputDto>(c)).FirstOrDefault();
            return result;
        }
        public Task<List<GetCategoryOutputDto>> GetAllCategories()
        {
            var result = CategoryRepoditory.GetQuery().Include(c => c.TuristPlaceCategory)
                                                      .Select(c => mapper.Map<GetCategoryOutputDto>(c)).ToListAsync();
            if (result == null)
                throw new KeyNotFoundException("Not Found any category");
            return result;
        }
        public async Task<string> DeleteCategory(DeleteCategoryInputDto deleteinput)
        {
            var findcategory = await FindCategory(deleteinput.DeleteCategory);

            var result = CategoryRepoditory.Delete(findcategory.Id);
            await CategoryRepoditory.Save();

            return result;
        }
        public async Task<List<GetPlaceCategoryOutputDto>> GetPlaceCategory(GetPlaceCategoryInputDto getinput)
        {
            await Findplace(getinput.PlaceName);
            var categories = TuristPlaceCategory.GetQuery().Include(tc => tc.TuristPlaces)
                                                           .Include(tc => tc.Categories)
                                                           .Where(tc => tc.TuristPlaces.Name == getinput.PlaceName)
                                                           .Select(tc => tc.Categories)
                                                           .Select(c => mapper.Map<GetPlaceCategoryOutputDto>(c)).ToList();
            if (categories == null)
                throw new KeyNotFoundException("Not found category for this place");
            return categories;
        }
    }
}
