using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravellingCore.ContextRepositoryInterface;
using TravellingCore.Dto.TuristPlaceCategory.GetAll;
using TravellingCore.Dto.TuristPlaceCategory.Regisster;
using TravellingCore.Exceptions;
using TravellingCore.Model;

namespace TravellingCore.Services.Models.Services.TuristPlaceCategoryServise
{
    public class TuristPlaceCategoryServise : ITuristPlaceCategoryServise
    {
        private readonly IRepository<TuristPlaceCategory> TuristPlaceCategoryRepository;
        private readonly IRepository<Category> CategoryRepository;
        private readonly IRepository<TuristPlace> TuristPlaceRepository;
        private readonly IMapper mapper;

        public TuristPlaceCategoryServise(IRepository<TuristPlaceCategory> TuristPlaceCategoryRepository,
                                          IRepository<Category> CategoryRepository,
                                          IRepository<TuristPlace> TuristPlaceRepository,
                                          IMapper mapper)
        {
            this.TuristPlaceCategoryRepository = TuristPlaceCategoryRepository;
            this.CategoryRepository = CategoryRepository;
            this.TuristPlaceRepository = TuristPlaceRepository;
            this.mapper = mapper;
        }
        private async Task<Category> FindCategory(string category)
        {
            var categories = await CategoryRepository.GetAll();
            var findcategory = categories.Find(c => c.Name == category);

            if (findcategory == null)
                throw new KeyNotFoundException("Not Found any category with this name");

            return findcategory;

        }
        private async Task<TuristPlace> FindPlace(string place)
        {
            var places = await TuristPlaceRepository.GetAll();
            var findplace = places.Find(c => c.Name == place);

            if (findplace == null)
                throw new KeyNotFoundException("Not Found any place with this name");

            return findplace;

        }
        private async Task IsReapited(TuristPlaceCategory turistPlaceCategory)
        {
            var alltristplacecategory = await TuristPlaceCategoryRepository.GetAll();
            var reapit = alltristplacecategory.Find(a => a.TuristPlaceId == turistPlaceCategory.TuristPlaceId
                                                         && a.CategoryId == turistPlaceCategory.CategoryId);
            if (reapit != null)
                throw new ReapitException("this relation already exist");

        }
        private async Task<TuristPlaceCategory> FindRegister(Category category , TuristPlace turistPlace)
        {
            var alltristplacecategory = await TuristPlaceCategoryRepository.GetAll();
            var relation = alltristplacecategory.Find(a => a.TuristPlaceId ==turistPlace.Id
                                                         && a.CategoryId == category.Id);
            if (relation == null)
                throw new KeyNotFoundException("Not found this relation");
            return relation;

        }

        public async Task<string> Register(RegisterInputDto registerinput)
        {
            var findplace = await FindPlace(registerinput.TuristPlace);
            var findcategory = await FindCategory(registerinput.Category);

            var newregister = new TuristPlaceCategory()
            {
                CategoryId = findcategory.Id,
                TuristPlaceId = findplace.Id
            };

            await IsReapited(newregister);

            TuristPlaceCategoryRepository.Insert(newregister);
            await TuristPlaceCategoryRepository.Save();

            return "we add your relation";
        }
        public async Task<string> UnRegister(RegisterInputDto unregisterinput)
        {
            var category = await FindCategory(unregisterinput.Category);
            var place = await FindPlace(unregisterinput.TuristPlace);

            var findrelation = await FindRegister(category, place);

            var result = TuristPlaceCategoryRepository.Delete(findrelation.Id);
            await TuristPlaceCategoryRepository.Save();

            return result;

        }
        public async Task<List<GetturistPlaceOutputDto>> GetAll()
        {
            var placecategories = await TuristPlaceCategoryRepository.GetAll();
            return placecategories.Select(pr => new GetturistPlaceOutputDto()
            {
                Id = pr.Id,
                CategoryId = pr.CategoryId,
                PlacrId = pr.TuristPlaceId
            }).ToList();

        }
        public async Task DeleteById(int Id)
        {
            TuristPlaceCategoryRepository.Delete(Id);
            await TuristPlaceCategoryRepository.Save();
        }
        

    }
}
