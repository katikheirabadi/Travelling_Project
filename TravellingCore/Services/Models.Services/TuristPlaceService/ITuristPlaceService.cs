using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TravellingCore.Dto.NewPlace;
using TravellingCore.Dto.SearchByAtr;
using TravellingCore.Dto.searchByCity;
using TravellingCore.Dto.SearchByCountry;
using TravellingCore.Dto.SearchByName;
using TravellingCore.Dto.TPlace;

namespace TravellingCore.Services.Models.Services.TuristPlaceService
{
   public interface ITuristPlaceService
    {
        public Task<NameOutputDTO> SearchByName(string Name);
        public  Task<NewListInputDTO> NewPlaces(int size);
        public Task<CityListOutputDTO> SearchbyCity(string city);
        public Task<AtrListOutputDTO> SearchByAttraction(string atr);
        public Task<CountryListOutPutDto> SearchByCountry(string Name);
        public  Task<PlaceOutputDto> ShoPlaceByName(string Nameplace);
    }
}
