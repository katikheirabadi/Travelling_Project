using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravellingCore.ContextRepositoryInterface;
using TravellingCore.Dto.NewPlace;
using TravellingCore.Dto.Popular;
using TravellingCore.Dto.searchByCity;
using TravellingCore.Dto.SearchByCountry;
using TravellingCore.Dto.TuristPlace.AddPlace;
using TravellingCore.Dto.TuristPlace.DeletePlace;
using TravellingCore.Dto.TuristPlace.GetPlace;
using TravellingCore.Dto.TuristPlace.UpdatePlace;
using TravellingCore.Exceptions;
using TravellingCore.Dto.View;
using TravellingCore.Dto.Visit;
using TravellingCore.Model;
using TravellingCore.Services.Models.Services.TuristPlaceService;

namespace TravellingCore.ModelsServiceRepository.Models.Methods
{
    public class TuristPlaceService : ITuristPlaceService
    {
        private readonly IMapper mapper;
        private readonly IRepository<Country> CountryRepository;
        private readonly IRepository<City> CityRepository;
        private readonly IRepository<TuristPlaceCategory> TuristPlaceCategoryrepository;
        private readonly IRepository<TuristPlace> TuristPlaceRepository;
        
        public TuristPlaceService(IRepository<TuristPlace> TuristPlaceRepository
                                , IMapper mapper
                                , IRepository<Country> CountryRepository
                                , IRepository<City> CityRepository
                                , IRepository<TuristPlaceCategory> TuristPlaceCategoryrepository)
        {
            this.mapper = mapper;
            this.CountryRepository = CountryRepository;
            this.CityRepository = CityRepository;
            this.TuristPlaceCategoryrepository = TuristPlaceCategoryrepository;
            this.TuristPlaceRepository = TuristPlaceRepository;
            this.TuristPlaceCategoryrepository = TuristPlaceCategoryrepository;
        }

        private async Task<Country> FindCountry(string country)
        {
            var countries = await CountryRepository.GetAll();
            var findcountry = countries.Find(c => c.Name == country);
            if (findcountry == null)
                throw new KeyNotFoundException("not found this country");
            return findcountry;
        }
        private async Task<City> FindCity(string city)
        {
            var Cities = await CityRepository.GetAll();
            if (Cities == null)
                throw new KeyNotFoundException("Not Found any City");
            var findcity = Cities.FirstOrDefault(c => c.Name == city);
            if (findcity == null)
                throw new KeyNotFoundException("Not Found This city");
            return findcity;

        }
        private async Task<TuristPlace> Findplace(string place)
        {
            var places = await TuristPlaceRepository.GetAll();
            var findplace = places.Find(p => p.Name == place);
            if (findplace == null)
                throw new KeyNotFoundException("Not found any place with this name");
            return findplace;
        }
        private async Task IsRepited(TuristPlace place)
        {
            var places = await TuristPlaceRepository.GetAll();
            var repit = places.Find(p => p.Name == place.Name);
            if (repit != null)
                throw new ReapitException("this place already exist");
        }

        public async Task<string> AddTuristPlace(AddPlaceInputDto addinput)
        {
            var findcity = await FindCity(addinput.CityName);
            var findcountry = await FindCountry(addinput.Country);

            var cityofcountry = CityRepository.GetQuery().Include(c => c.Country)
                                                          .FirstOrDefault(c => c.Country.Name == findcountry.Name &&
                                                                              c.Name == findcity.Name);
            if (cityofcountry == null)
                throw new KeyNotFoundException("this city is not in this country");

            var newplace = new TuristPlace()
            {
                Name = addinput.Name,
                CityId = findcity.Id,
                CountryId = findcity.Country.Id,
                Description = addinput.Description,
                Visit=0
            };

            await IsRepited(newplace);

            TuristPlaceRepository.Insert(newplace);
            await TuristPlaceRepository.Save();

            return "we add your place";

        }
        public async Task<GetPlaceOutputDto> GetPlace(GetPlaceInput getinput)
        {
             var findplace = await Findplace(getinput.Name);
             var ShowPlace = TuristPlaceRepository.GetQuery().Include(t => t.TuristPlaceCategory)
                                                                    .Include(p => p.Country)
                                                                    .Include(p => p.City)
                                                                    .Include(p => p.Comments)
                                                                    .Include(p => p.Rates)
                                                                    .Where(tp => tp.Name == findplace.Name)
                                                                    .Select(p => mapper.Map<GetPlaceOutputDto>(p)).FirstOrDefault();
            return ShowPlace;
        }
        public Task<List<GetPlaceOutputDto>> GetAllPlaces()
        {
            var places = TuristPlaceRepository.GetQuery().Include(t => t.TuristPlaceCategory)
                                                                   .Include(p => p.Country)
                                                                   .Include(p => p.City)
                                                                   .Include(p => p.Comments)
                                                                   .Include(p => p.Rates)
                                                                   .Select(p => mapper.Map<GetPlaceOutputDto>(p)).ToListAsync();
            return places;
        } 
        public async Task<string> DeletePlace(DeletePlaceInputDto deleteinput)
        {
            var findplace = await Findplace(deleteinput.Place);

            var result = TuristPlaceRepository.Delete(findplace.Id);
            await TuristPlaceRepository.Save();

            return result;
        }
        public async Task<string> UpdatePlace(UpdatePlaceInputDto updateinput)
        {
            var findplace = await Findplace(updateinput.Place);
            findplace.Description = updateinput.NewDescription;

            var result = TuristPlaceRepository.Update(findplace);
            await TuristPlaceRepository.Save();

            return result;
        }
        public async Task<NewListInputDTO> NewPlaces(int size)
        {
            var AllPlace = await TuristPlaceRepository.GetAll();
            var ReversePlace = AllPlace.AsQueryable().Reverse();
            var newPlace = ReversePlace.Take(size).ToList();
            var finall = mapper.Map<List<NewInputDTO>>(newPlace);
            return new NewListInputDTO()
                                       {
                                          Turism_Places = finall.ToList()
                                       };
        }
        public async Task<VisitOutputDto> View (VisitInputDto turistPlace)
        {
            var findplace =  await Findplace(turistPlace.TuristPlaceName);
            var reasult = TuristPlaceRepository.GetQuery()
                                               .Include(x => x.City)
                                               .Include(y => y.Country)
                                               .FirstOrDefault(z => z.Name == findplace.Name);
            reasult.Visit++;

            TuristPlaceRepository.Update(reasult);
            await TuristPlaceRepository.Save();

            return mapper.Map<VisitOutputDto>(reasult);                                     
                                               
          
        }
     
        public async Task<List<ViewOutputDto>> ShowVisit(int size)
        {
            var reasult = await TuristPlaceRepository.GetAll();
            return reasult.OrderByDescending(x => x.Visit)
                             .Select( p => mapper.Map<ViewOutputDto>(p))
                             .Take(size)
                             .ToList();
        }
        public  Task<List<PopularOutputDto>> ShowPopular(int size)
        {
            return TuristPlaceRepository.GetQuery()
                                               .Include(x => x.Rates)
                                               .Select(x => new PopularOutputDto() {
                                                Rate = x.Rates.Average(y => y.UserRate)
                                               ,TuristPlaceName = x.Name
                                               ,Visit = x.Visit
                                                })
                                               .OrderByDescending(z => z.Rate)
                                               .Take(size)
                                               .ToListAsync();
        }
        
    }
}
