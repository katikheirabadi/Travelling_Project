using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravellingCore.ContextRepositoryInterface;
using TravellingCore.Dto.NewPlace;
using TravellingCore.Dto.SearchByAtr;
using TravellingCore.Dto.searchByCity;
using TravellingCore.Dto.SearchByCountry;
using TravellingCore.Dto.SearchByName;

using TravellingCore.Dto.TPlace;
using TravellingCore.Model;
using TravellingCore.Services.Models.Services;
using TravellingCore.Services.Models.Services.TuristPlaceService;

namespace TravellingCore.ModelsServiceRepository.Models.Methods
{
    public class TuristPlaceService :  ITuristPlaceService
    {
        private readonly IMapper mapper;
        private readonly IRepository<TuristPlace> TuristPlaceRepository;
        
        public TuristPlaceService(IRepository<TuristPlace> TuristPlaceRepository, IMapper mapper)
        {
            this.mapper = mapper;
            this.TuristPlaceRepository = TuristPlaceRepository;
        }
        public  string Delete(int id)
        {
            return TuristPlaceRepository.Delete(id);
        }

        public Task<TuristPlace> Get(int id)
        {
            return TuristPlaceRepository.Get(id);
        }

        public Task<List<TuristPlace>> GetAll()
        {
            return TuristPlaceRepository.GetAll();
        }

        public IQueryable<TuristPlace> GetQuery()
        {
            return TuristPlaceRepository.GetQuery();
        }

        public void Insert(TuristPlace item)
        {
            TuristPlaceRepository.Insert(item);
        }

        public Task Save()
        {
            return TuristPlaceRepository.Save();
        }

        public string Update(TuristPlace item)
        {
            return TuristPlaceRepository.Update(item);
        }
        public async Task<NameOutputDTO> SearchByName(string Name)
        {
            var place = await TuristPlaceRepository.GetAll();
            var placeName = place.FirstOrDefault(x => x.Name == Name);
            return mapper.Map<NameOutputDTO>(placeName);
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
        public async Task<CityListOutputDTO> SearchbyCity(string city)
        {
            var myCity = await TuristPlaceRepository.GetAll();
          //  var newCity = myCity.Where(x => x.C == city).ToList();
          //  var finallcity = newCity.Select(x => mapper.Map<CityOutputDTO>(x)).ToList();
            return new CityListOutputDTO()
            {
               // Turism_Places = finallcity
            };
        }
     
        public async Task<AtrListOutputDTO> SearchByAttraction(string atr)
        {
            //var myAtr = await TuristPlaceRepository.GetAll();
            //var newAtr = myAtr.Where(x => x.Category == atr).ToList();
            //var finallAtr = newAtr.Select(x => mapper.Map<AtrOutputDTO>(x)).ToList();
            return new AtrListOutputDTO()
            {
            //    places = finallAtr
            };
        }
        public async Task<CountryListOutPutDto> SearchByCountry(string Name)
        {
            var Places = await TuristPlaceRepository.GetAll();
            //taghir mikone
            var MyPlaces = Places.Where(x => x.Name == Name).ToList();
            var Reasult = MyPlaces.Select(x => mapper.Map<CountryOutPutDto>(x)).ToList();
           return new CountryListOutPutDto() { Places = Reasult };
        }
      /*  private int AverageRate()
        {
            var result = repository.GetQuery().Include(p => p.Rates).Select(x => new { avg = x.Rates.Average(y => y.RateInt) , name = x.Name , city = x.CityName }).ToList().OrderByDescending(x => x.avg);


        }*/
        public async Task<PlaceOutputDto> ShoPlaceByName(string Nameplace)
        {
            var places = await TuristPlaceRepository.GetAll();
            var place = places.FirstOrDefault(p => p.Name == Nameplace);
            if (place == null)
                throw new Exception("we don't have this place...");
            place.Visit++;
            return mapper.Map<PlaceOutputDto>(place);

        }
     
        
    }
}
