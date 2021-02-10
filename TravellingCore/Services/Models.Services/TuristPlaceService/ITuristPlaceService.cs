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
using TravellingCore.Dto.SearchByCountry;
using TravellingCore.Dto.SearchByName;
using TravellingCore.Dto.TPlace;
using TravellingCore.Dto.TuristPlace.AddPlace;
using TravellingCore.Dto.TuristPlace.DeletePlace;
using TravellingCore.Dto.TuristPlace.GetPlace;
using TravellingCore.Dto.TuristPlace.UpdatePlace;
using TravellingCore.Model;

namespace TravellingCore.Services.Models.Services.TuristPlaceService
{
   public interface ITuristPlaceService
    {
        public Task<string> AddTuristPlace(AddPlaceInputDto addinput);
        public  Task<GetPlaceOutputDto> GetPlace(GetPlaceInput getinput);
        public Task<List<GetPlaceOutputDto>> GetAllPlaces();
        public  Task<NewListInputDTO> NewPlaces(int size);
        public Task<VisitOutputDto> View(VisitInputDto turistPlace);
        public Task<List<ViewOutputDto>> ShowVisit(int size);
        public Task<List<PopularOutputDto>> ShowPopular(int size);
    }
}
