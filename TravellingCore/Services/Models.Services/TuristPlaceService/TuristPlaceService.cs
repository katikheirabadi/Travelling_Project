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
using TravellingCore.Dto.TuristPlaces.GetPlaceWithId;
using TravellingCore.Dto.TuristPlaces.GetAll;

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
                throw new KeyNotFoundException("کشوری یافت نشد");
            return findcountry;
        }
        private async Task<City> FindCity(string city)
        {
            var Cities = await CityRepository.GetAll();
            if (Cities == null)
                throw new KeyNotFoundException("شهری وجود ندارد");
            var findcity = Cities.FirstOrDefault(c => c.Name == city);
            if (findcity == null)
                throw new KeyNotFoundException("این شهر یافت نشد");
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
        /*
         make for postman
         */
        public async Task<string> AddTuristPlace(AddPlaceInputDto addinput)
        {
            var findcity = await FindCity(addinput.CityName);
            var findcountry = await FindCountry(addinput.Country);

            var cityofcountry = CityRepository.GetQuery().Include(c => c.Country)
                                                          .FirstOrDefault(c => c.Country.Name == findcountry.Name &&
                                                                              c.Name == findcity.Name);
            if (cityofcountry == null)
                throw new KeyNotFoundException("این شهر برای این کشور نیست");

            var newplace = new TuristPlace()
            {
                Name = addinput.Name,
                CityId = findcity.Id,
                CountryId = findcity.Country.Id,
                Description = addinput.Description,
                Image = addinput.Image,
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
            findplace.Image = updateinput.NewImage;

            var result = TuristPlaceRepository.Update(findplace);
            await TuristPlaceRepository.Save();

            return result;
        }
        public async Task<NewListInputDTO> NewPlaces()
        {
            var AllPlace = await TuristPlaceRepository.GetAll();
            var ReversePlace = AllPlace.AsQueryable().Reverse();
            var newPlace = ReversePlace.Take(4).ToList();
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

        public async Task<List<ViewOutputDto>> ShowVisit()
        {
            var reasult = await TuristPlaceRepository.GetAll();
            return reasult.OrderByDescending(x => x.Visit)
                             .Select( p => mapper.Map<ViewOutputDto>(p))
                             .Take(4)
                             .ToList();
        }
        public  Task<List<PopularOutputDto>> ShowPopular()
        {
            return TuristPlaceRepository.GetQuery()
                                               .Include(x => x.Rates)
                                               .Select(x => new PopularOutputDto() {
                                                Rate = x.Rates.Average(y => y.UserRate)
                                               ,TuristPlaceName = x.Name
                                               ,Visit = x.Visit
                                               ,Id = x.Id
                                               ,Image = x.Image
                                                })
                                               .OrderByDescending(z => z.Rate)
                                               .Take(4)
                                               .ToListAsync();
        }

        /*
         make for razor
         */

        public async Task<GetplaceWithIdOutputDto> GetByid(int id)
        {

            var place = TuristPlaceRepository.GetQuery().Include(p => p.Comments)
                                                        .Include(p => p.Rates)
                                                        .Include(p => p.Comments)
                                                        .ThenInclude(c => c.User)
                                                        .FirstOrDefault(p => p.Id == id);
            var endplace = new GetplaceWithIdOutputDto();
            endplace.Id = id;
            endplace.Image = place.Image;
            endplace.Name = place.Name;
            endplace.Visit = place.Visit;
            endplace.Description = place.Description;
            endplace.AverageRates = place.Rates.Average(x => x.UserRate);
            endplace.Comments = place.Comments.Select(c => new CommentDto() { Comment = c.Text, Name = c.User.FullName }).ToList();

            return endplace;

        }
        public async Task<List<GetAllPlaces>> ShowAll()
        {
            var places = await TuristPlaceRepository.GetAll();
            var myplaces = places.Select(p => new GetAllPlaces() { id = p.Id, Name = p.Name }).ToList();
            return myplaces;
        } 
        public async Task<string> DeleteById(int id)
        {
             var result =TuristPlaceRepository.Delete(id);
            await TuristPlaceRepository.Save();
            return result;
        }
    }
}
