using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TravellingCore.Dto.Country.AddCountry;
using TravellingCore.Dto.Country.DeleteCountry;
using TravellingCore.Dto.Country.GetCountry;

namespace TravellingCore.Services.Models.Services.CountryService
{
    public interface ICountryService
    {
        public  Task<string> AddCountry(AddCountryInputDto addinput);
        public Task<GetCountryOutputDto> GetCountry(GetCountryInputDto getinput);
        public Task<List<GetCountryOutputDto>> GetAllCountry();
        public  Task<string> DeleteCountry(DeleteCountryInputDto deleteinput);
    }
}
