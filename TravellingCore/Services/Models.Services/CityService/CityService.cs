using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using TravellingCore.ContextRepositoryInterface;
using TravellingCore.Dto.City.AddCity;
using TravellingCore.Dto.City.GetCity;
using TravellingCore.Exceptions;
using TravellingCore.Model;
using AutoMapper;
using TravellingCore.Dto.City.DeleteCity;
using TravellingCore.Dto.City.GetCountryCities;
using TravellingCore.Dto.City.GetCitybyId;
using TravellingCore.Dto.City.GetAll;

namespace TravellingCore.Services.Models.Services.CityService
{
    public class CityService : ICityService
    {
        private readonly IRepository<City> CityRepository;
        private readonly IRepository<Country> CountryRepository;
        private readonly IRepository<TuristPlace> placeRepository;
        private readonly IMapper mapper;

        public CityService(IRepository<City> CityRepository
                           ,IRepository<Country> CountryRepository
                           ,IRepository<TuristPlace> placeRepository
                           ,IMapper mapper)
        {
            this.CityRepository = CityRepository;
            this.CountryRepository = CountryRepository;
            this.placeRepository = placeRepository;
            this.mapper = mapper;
        }
        private async Task<Country> FindCountry(string Country)
        {
            var Countries = await CountryRepository.GetAll();
            if (Countries == null)
                throw new KeyNotFoundException("Not Found any Country");
            var findcountry = Countries.Find(c => c.Name == Country);
            if (findcountry == null)
                throw new KeyNotFoundException("Not Found This Country");
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
        private async Task IsReapited(string City)
        {
            var Cities = await CityRepository.GetAll();
            if (Cities == null)
                throw new KeyNotFoundException("Not Found any city");
            var FindCity = Cities.Find(c => c.Name == City);
            if (FindCity != null)
                throw new ReapitException("this City already Exict");
        }

        /*
         make for postman
         */
        public async Task<string> Addcity(AddCityInputDto addinput)
        {
            var findCountry = await FindCountry(addinput.Country);
            await IsReapited(addinput.City);

            var newcity = new City()
            {
                Image = addinput.Image,
                Name = addinput.City,
                CountryId = findCountry.Id
            };

            CityRepository.Insert(newcity);
            await CityRepository.Save();

            return "We add your city..";
        }
        public async Task<GetCityOutputDto> GetCityByName(GetCityInputDto getinput)
        {
            var findcity = await FindCity(getinput.YourCity);

            var result = CityRepository.GetQuery()
                                       .Include(c => c.TuristPlaces)
                                       .Include(c=>c.Country)
                                       .Where(c => c.Name == findcity.Name)
                                       .Select(c => mapper.Map<GetCityOutputDto>(c))
                                       .FirstOrDefault();

            return result;
        }
        public  Task<List<GetCityOutputDto>> GetAllCities()
        {
            var result = CityRepository.GetQuery()
                                       .Include(c => c.TuristPlaces)
                                       .Include(c => c.Country)
                                       .Select(c => mapper.Map<GetCityOutputDto>(c))
                                       .ToListAsync();

            return result;

        }
        public async Task<List<GetCityOutputDto>> GetCountryCities(GetCountryCitiesInputDto getinput)
        {
            var findcountry = await FindCountry(getinput.YourCountry);
            var cities = CityRepository.GetQuery()
                                       .Include(c => c.Country)
                                       .Include(c => c.TuristPlaces)
                                       .Where(c => c.Country.Name == findcountry.Name)
                                       .Select(c => mapper.Map<GetCityOutputDto>(c))
                                       .ToList();

            return cities;
        }
        public async Task<string> DeleteCity(DeleteCityInput deleteinput)
        {
            var findcity = await FindCity(deleteinput.YourCity);

            var result = CityRepository.Delete(findcity.Id);
            await CityRepository.Save();

            return result;
        }

        /*
         make for razor page
         */
        public Task<GetCityByIdOutputDto> GetcityById(int id)
        {
            var places = placeRepository.GetQuery()
                                        .Include(p => p.City)
                                        .Include(p => p.Comments)
                                        .Include(p => p.Rates)
                                        .Where(p => p.City.Id == id)
                                        .ToList();
            if (places == null)
            {
                throw new KeyNotFoundException("Not found any city with this id");
            }

            var result = new GetCityByIdOutputDto();
            result.Name = places.Select(p=> p.City.Name).FirstOrDefault();
            result.Places = places.Select(p => new Place() { Id = p.Id,
                                                                         Description = p.Description,
                                                                         Image = p.Image,
                                                                         Name = p.Name,
                                                                         Comments = p.Comments.Count,
                                                                         AverageRates = p.Rates.Average(x=>x.UserRate)
                                                                         })
                                               .ToList();
            return Task.Run(()=>result);                                        
                                                     
        }
        public Task<List<GetAllOutputDto>> GetAll()
        {
            return CityRepository.GetQuery().Select(c => new GetAllOutputDto() { Id = c.Id, Name = c.Name }).ToListAsync();
        }
        public async Task DeleteById(int id)
        {
            CityRepository.Delete(id);
            await CityRepository.Save();
        }
    }
}
