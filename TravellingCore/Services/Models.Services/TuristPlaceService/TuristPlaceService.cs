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
using TravellingCore.Dto.View;
using TravellingCore.Dto.Visit;
using TravellingCore.Model;
using TravellingCore.Services.Models.Services.TuristPlaceService;

namespace TravellingCore.ModelsServiceRepository.Models.Methods
{
    public class TuristPlaceService : ITuristPlaceService
    {
        private readonly IMapper mapper;
        private readonly IRepository<TuristPlace> TuristPlaceRepository;
        private readonly IRepository<TuristPlaceCategory> TuristPlaceCategoryRepository;


        public TuristPlaceService(IRepository<TuristPlace> TuristPlaceRepository
                                 ,IRepository<TuristPlaceCategory> TuristPlaceCategoryRepository
                                 ,IMapper mapper)
        {
            this.mapper = mapper;
            this.TuristPlaceRepository = TuristPlaceRepository;
            this.TuristPlaceCategoryRepository = TuristPlaceCategoryRepository;
        }
        private async Task<TuristPlace> FindPlace(string Place)
        {
            var place = await TuristPlaceRepository.GetAll();
            var findPlace = place.Find(x => x.Name == Place);

            if (findPlace == null)
                throw new KeyNotFoundException("Not Found This Place");

            return findPlace;
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
      /*  private int AverageRate()
        {
            var result = repository.GetQuery().Include(p => p.Rates).Select(x => new { avg = x.Rates.Average(y => y.RateInt) , name = x.Name , city = x.CityName }).ToList().OrderByDescending(x => x.avg);


        }*/
        public async Task<VisitOutputDto> View (VisitInputDto turistPlace)
        {
            var findplace =  await FindPlace(turistPlace.TuristPlaceName);
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
        public async Task<List<PopularOutputDto>> ShowPopular(int size)
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
                                               .ToList();
            
        }
        
    }
}
