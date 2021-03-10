using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravellingCore.ContextRepositoryInterface;
using TravellingCore.Dto._ُSearchByCategory;
using TravellingCore.Dto.searchByCity;
using TravellingCore.Dto.SearchByCountry;
using TravellingCore.Dto.SearchByFilter;
using TravellingCore.Dto.SearchByTuristPlaceName;
using TravellingCore.Model;

namespace TravellingCore.Services.Models.Services.SearchServise
{
    public class SearchServise : ISearchservise
    {
        private readonly IMapper mapper;
        private readonly IRepository<TuristPlace> TuristPlaceRepository;
        private readonly IRepository<TuristPlaceCategory> TuristPlaceCategoryRepository;


        public SearchServise(IRepository<TuristPlace> TuristPlaceRepository
                                , IRepository<TuristPlaceCategory> TuristPlaceCategoryRepository
                                , IMapper mapper)
        {
            this.mapper = mapper;
            this.TuristPlaceRepository = TuristPlaceRepository;
            this.TuristPlaceCategoryRepository = TuristPlaceCategoryRepository;
        }
        public async Task<FilterOutputDTO> SearchByFilter(FilterInputDTO filterInputDTO)
        {
            var first = TuristPlaceRepository.GetQuery()
                                             .Include(x => x.Country)
                                             .ThenInclude(x => x.TuristPlaces)
                                             .Where(y => y.Country.Name.Contains(filterInputDTO.Country)).ToList();

            var second = TuristPlaceRepository.GetQuery()
                                              .Include(x => x.City)
                                              .ThenInclude(x => x.TuristPlaces)
                                              .Where(x => x.City.Name.Contains(filterInputDTO.City)).ToList();

            //var third = TuristPlaceCategoryRepository.GetQuery()
            //                                         .Include(x => x.Categories)
            //                                         .Include(x => x.TuristPlaces)
            //                                         .Where(x => x.Categories.Name.Contains(filterInputDTO.Category))
            //                                         .Select(x => x.TuristPlaces)
            //                                         .ToList();


            var finall = (from a in first join b in second on a.Id equals b.Id select b).ToList();
            var result = mapper.Map<List<FilterOutputDetailDTO>>(finall);

            var end = new FilterOutputDTO()
            {
                Places = result.ToArray()
            };
            return end;

        }
        public Task<List<CategoryOutputDto>> SearchByCategory(CategoryInputDto category)
        {
            var CategoryPlaces = TuristPlaceCategoryRepository.GetQuery()
                                                              .Include(x => x.Categories)
                                                              .Include(y => y.TuristPlaces)
                                                              .Where(z => z.Categories.Id == category.CategoryId)
                                                              .Select(p => p.TuristPlaces.Id)
                                                              .Select(p => mapper.Map<CategoryOutputDto>(p))
                                                              .ToListAsync();

            if (CategoryPlaces == null)
                throw new KeyNotFoundException("برای این دسته بندی مکان توریستی وجود ندارد");

            return CategoryPlaces;

        }
        public Task<List<CountryOutPutDto>> SearchByCountry(CountryInputDto country)
        {
            var CountryPlaces = TuristPlaceRepository.GetQuery()
                                                     .Include(x => x.Country)
                                                     .Include(o => o.City)
                                                     .Where(y => y.Country.Id == country.CountryId)
                                                     .Select(Z => mapper.Map<CountryOutPutDto>(Z))
                                                     .ToListAsync();

            if (CountryPlaces == null)
                throw new KeyNotFoundException("برای این دسته بندی مکان توریستی وجود ندارد");

            return CountryPlaces;

        }
        public Task<List<CityPlaceOutputDTO>> SearchByCity(CityNameInputDTO citynameinputdto)
        {
            var result = TuristPlaceRepository.GetQuery()
                                              .Include(p => p.City)
                                              .Where(p => p.City.Id == citynameinputdto.CityId)
                                              .Select(p => new CityPlaceOutputDTO()
                                              {
                                                  TuristPlaceId = p.Id
                                              })
                                              .ToListAsync();
            return result;
        }
        public async Task<TuristPlaceOutputDto> SearchByName(string turistPlace)
        {
            var place = await TuristPlaceRepository.GetQuery()
                                                   .Include(p=>p.Comments)
                                                   .Include(p=>p.Rates)
                                                   .FirstOrDefaultAsync(o => o.Name .Contains(turistPlace));
            if (place == null)
                throw new KeyNotFoundException("همچین مکانی یافت نشد");

            var Reasult = mapper.Map<TuristPlaceOutputDto>(place);

            
            return Reasult;

        }
    }
}
