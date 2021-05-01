using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravellingCore.ContextRepositoryInterface;
using TravellingCore.Dto.Country.AddCountry;
using TravellingCore.Dto.Country.DeleteCountry;
using TravellingCore.Dto.Country.Get_CountrywithId;
using TravellingCore.Dto.Country.GetAllCountries;
using TravellingCore.Dto.Country.GetCountry;
using TravellingCore.Exceptions;
using TravellingCore.Model;

namespace TravellingCore.Services.Models.Services.CountryService
{
    public class CountryService : ICountryService
    {
        private readonly IRepository<Country> CountryRepository;
        private readonly IMapper mapper;
        private readonly IRepository<TuristPlace> placereposirory;

        public CountryService(IRepository<Country> CountryRepository
                              ,IMapper mapper
                              ,IRepository<TuristPlace> placereposirory)
        {
            this.CountryRepository = CountryRepository;
            this.mapper = mapper;
            this.placereposirory = placereposirory;
        }
        private async Task IsReapited(Country country)
        {
            var Countries = await CountryRepository.GetAll();
            var reapited = Countries.Find(c=>c.Name==country.Name);

            if (reapited != null)
                throw new ReapitException("this country alredy exist");
        }
        private async Task<Country> FindCountry(string country)
        {
            var countries = await CountryRepository.GetAll();
            var findcountry = countries.Find(c => c.Name == country);

            if (findcountry == null)
                throw new KeyNotFoundException("not found this country");
            return findcountry;
        }

        /*
         make for postman
         */
        public async Task<string> AddCountry(AddCountryInputDto addinput)
        {
            var newcountry = new Country()
            {
                Image = addinput.Image,
                Name = addinput.YourCountry
            };

            await IsReapited(newcountry);

            CountryRepository.Insert(newcountry);
            await CountryRepository.Save();

            return "we add your Country";
        }
        public async Task<GetCountryOutputDto> GetCountry(GetCountryInputDto getinput)
        {
            await FindCountry(getinput.YourCountry);

            var yourcountry = CountryRepository.GetQuery()
                                               .Include(c => c.Cities)
                                               .Include(c => c.TuristPlaces)
                                               .Where(c => c.Name == getinput.YourCountry)
                                               .Select(c => mapper.Map<GetCountryOutputDto>(c))
                                               .FirstOrDefault();

            return yourcountry;
        }
        public Task<List<GetCountryOutputDto>> GetAllCountry()
        {
            var counreies = CountryRepository.GetQuery()
                                             .Include(c => c.Cities)
                                             .Include(c => c.TuristPlaces)
                                             .Select(c => mapper.Map<GetCountryOutputDto>(c))
                                             .ToListAsync();
            return counreies;
        }
        public async Task<string> DeleteCountry(DeleteCountryInputDto deleteinput)
        {
            var findcountry = await FindCountry(deleteinput.YourCountry);

            var result = CountryRepository.Delete(findcountry.Id);
            await CountryRepository.Save();

            return result;
        }
        /*
         make for razor page
         */
        public async Task<List<GetAllcountries>> GetAll()
        {
           var countries = await CountryRepository.GetAll();
            return countries.Select(c => new GetAllcountries() { Id = c.Id, Name = c.Name }).ToList();
        }
        public async Task<GetCountryWithIdOutputDto> GetCountryWithId(int id)
        {
            var result = new GetCountryWithIdOutputDto();
            var country = CountryRepository.GetQuery().Include(C=>C.Cities).Include(C=>C.TuristPlaces).FirstOrDefault(c => c.Id == id);


            result.Id = id;
            result.Image = country.Image;
            result.Name = country.Name;
            result.Places = placereposirory.GetQuery().Include(p => p.Country)
                                                      .Include(p => p.Comments)
                                                      .Include(p => p.City)
                                                      .Include(p => p.Rates)
                                                      .Where(p => p.Country.Id == id)
                                                      .Select(p => new Place()
                                                      {
                                                          Id = p.Id,
                                                          AverageRates = p.Rates.Average(X => X.UserRate),
                                                          CommentsNumber = p.Comments.Count,
                                                          Description = p.Description,
                                                          Image = p.Image,
                                                          Name =p.Name,
                                                          Visit = p.Visit
                                                      }).ToList();
            result.Cities =  country.Cities.Select(c => new CityDto() { Id = c.Id, Name = c.Name }).ToList();
            return result;

        }
        public async Task DeletById(int id)
        {
            CountryRepository.Delete(id);
            await CountryRepository.Save();

        }
    }
}
