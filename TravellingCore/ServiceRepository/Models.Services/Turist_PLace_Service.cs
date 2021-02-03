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
using TravellingCore.Dto.SearchByVisted;
using TravellingCore.Dto.TPlace;
using TravellingCore.Model;

namespace TravellingCore.ModelsServiceRepository.Models.Methods
{
    public class Turist_PLace_Service
    {
        private readonly IMapper mapper;
        private readonly IRepository<Turist_Place> repository;
        
        public Turist_PLace_Service(IRepository<Turist_Place> repository, IMapper mapper)
        {
            this.mapper = mapper;
            this.repository = repository;
        }
        public  string Delete(int id)
        {
            return repository.Delete(id);
        }

        public Task<Turist_Place> Get(int id)
        {
            return repository.Get(id);
        }

        public Task<List<Turist_Place>> GetAll()
        {
            return repository.GetAll();
        }

        public IQueryable<Turist_Place> GetQuery()
        {
            return repository.GetQuery();
        }

        public void Insert(Turist_Place item)
        {
            repository.Insert(item);
        }

        public Task Save()
        {
            return repository.Save();
        }

        public string Update(Turist_Place item)
        {
            return repository.Update(item);
        }
        public async Task<NameOutputDTO> SearchByName(string Name)
        {
            var place = await repository.GetAll();
            var placeName = place.FirstOrDefault(x => x.Name == Name);
            return mapper.Map<NameOutputDTO>(placeName);
        }
        
        public async Task<NewListInputDTO> New_Places(int size)
        {
            var AllPlace = await repository.GetAll();
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
            var myCity = await repository.GetAll();
            var newCity = myCity.Where(x => x.CityName == city).ToList();
            var finallcity = newCity.Select(x => mapper.Map<CityOutputDTO>(x)).ToList();
            return new CityListOutputDTO()
            {
                Turism_Places = finallcity
            };
        }
        public async Task<VisitedListOutputDTO> SearchbyVisited()
        {
            var place1 = await repository.GetAll();
            var mcity = place1.Select(x =>place1.Max()).ToList();
            var finallplace = mcity.Select(x => mapper.Map<VisitedOutputDTO>(x)).ToList();
            return new VisitedListOutputDTO()
            {
                Turism_Places = finallplace
            };
        }
        public async Task<AtrListOutputDTO> SearchByAttraction(string atr)
        {
            var myAtr = await repository.GetAll();
            var newAtr = myAtr.Where(x => x.Atrraction == atr).ToList();
            var finallAtr = newAtr.Select(x => mapper.Map<AtrOutputDTO>(x)).ToList();
            return new AtrListOutputDTO()
            {
                places = finallAtr
            };
        }
        public async Task<CountryListOutPutDto> SearchByCountry(string Name)
        {
            var Places = await repository.GetAll();
            var MyPlaces = Places.Where(x => x.CountryName == Name).ToList();
            var Reasult = MyPlaces.Select(x => mapper.Map<CountryOutPutDto>(x)).ToList();
            return new CountryListOutPutDto() { Places = Reasult };
        }
        //private int AverageRate(Rate rate)
        //{
        //    var result = repository.GetQuery().Include(p => p.Rates).ThenInclude()

        //}
        public async Task<PlaceOutputDto> Get(string Nameplace)
        {
            var places = await repository.GetAll();
            var place = places.FirstOrDefault(p => p.Name == Nameplace);
            if (place == null)
                throw new Exception("we don't have this place...");
            place.Visit++;
            return mapper.Map<PlaceOutputDto>(place);

        }
     
        
    }
}
