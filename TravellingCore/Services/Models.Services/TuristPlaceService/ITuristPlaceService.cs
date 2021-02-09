using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravellingCore.Dto.NewPlace;
using TravellingCore.Dto.Popular;
using TravellingCore.Dto.searchByCity;
using TravellingCore.Dto.View;
using TravellingCore.Dto.Visit;
using TravellingCore.Model;

namespace TravellingCore.Services.Models.Services.TuristPlaceService
{
   public interface ITuristPlaceService
    {
        public  Task<NewListInputDTO> NewPlaces(int size);
        public string Delete(int id);
        public Task<TuristPlace> Get(int id);
        public Task<List<TuristPlace>> GetAll();
        public IQueryable<TuristPlace> GetQuery();
        public Task Save();
        public string Update(TuristPlace item);
        public void Insert(TuristPlace item);
        public Task<VisitOutputDto> View(VisitInputDto turistPlace);
        public Task<List<ViewOutputDto>> ShowVisit(int size);
        public Task<List<PopularOutputDto>> ShowPopular(int size);
    }
}
