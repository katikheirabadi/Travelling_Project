using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TravellingCore.Dto.City.AddCity;
using TravellingCore.Dto.City.DeleteCity;
using TravellingCore.Dto.City.GetCity;
using TravellingCore.Dto.City.GetCitybyId;
using TravellingCore.Dto.City.GetCountryCities;

namespace TravellingCore.Services.Models.Services.CityService
{
    public interface ICityService
    {
        public Task<string> Addcity(AddCityInputDto addinput);
        public Task<GetCityOutputDto> GetCityByName(GetCityInputDto getinput);
        public Task<List<GetCityOutputDto>> GetAllCities();
        public Task<List<GetCityOutputDto>> GetCountryCities(GetCountryCitiesInputDto getinput);
        public Task<string> DeleteCity(DeleteCityInput deleteinput);
        public Task<GetCityByIdOutputDto> GetcityById(int id);
    }
}
