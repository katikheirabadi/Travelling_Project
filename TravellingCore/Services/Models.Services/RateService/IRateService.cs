using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravellingCore.Dto.Rate;
using TravellingCore.Dto.Rate.DeleteRate;
using TravellingCore.Dto.Rate.GetPlaceRates;
using TravellingCore.Dto.Rate.GetRate;
using TravellingCore.Dto.Rate.UpdateRate;
using TravellingCore.Model;

namespace TravellingCore.Services.Models.Services.RateService
{
    public interface IRateService
    {
        public Task<string> AddRate(RateInputDto rate);
        public Task<GetRateOutputDto> GetRate(GetrateInputDto getinput);
        public Task<List<GetRateOutputDto>> GetAllRate();
        public Task<List<GetPlaceRatesOutputDto>> GetAllRatesOfPlace(GetPlaceRatesInputDto getplaceinput);
        public Task<string> DeleteRate(DeleterateInputDto deleterateinput);
        public Task<string> UpdateRate(UpdateRateInputDto updateinput);
    }
}
