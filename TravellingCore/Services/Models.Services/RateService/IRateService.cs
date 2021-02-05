using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TravellingCore.Dto.Rate;

namespace TravellingCore.Services.Models.Services.RateService
{
    public interface IRateService
    {
        public Task<string> AddRate(RateInputDto rate, string Token);
    }
}
