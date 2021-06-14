using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TravellingCore.ContextRepositoryInterface;
using TravellingCore.Model;
using System.Linq;
using TravellingCore.Dto.Compare;

namespace TravellingCore.Services.Models.Services.CompareService
{
    public class CompareService : ICompareService
    {
        private readonly IRepository<Rate> rate;

        private readonly IRepository<TuristPlace> turistPlace;

        public CompareService(IRepository<Rate> rate, IRepository<TuristPlace> turistPlace)
        {
            this.rate = rate;
            this.turistPlace = turistPlace;
        }
        private async Task<double> GetAverage(int TuricePlaceId)
        {
            var computingRate = await rate.GetAll();
            return computingRate.Where(r => r.TuristPlaceId == TuricePlaceId)
                                .Average(r => r.UserRate);
        }
        private async Task<int> GetPlaceId(string placeName)
        {
            var compare = await turistPlace.GetAll();

            return compare.Where(c => c.Name == placeName)
                                  .Select(c => c.Id)
                                  .FirstOrDefault();
        }
        public async Task<CompareOutputDto> Compare(CompareInputDTO compareInput)
        {
            var FirstPlaceId = await GetPlaceId(compareInput.FirstPlace);
            var SecendPlaceId = await GetPlaceId(compareInput.SecendPlace);

            var FirstPlaceRate = await GetAverage(FirstPlaceId);
            var FirstPlaceIdRate = await GetAverage(SecendPlaceId);


            if (FirstPlaceRate == FirstPlaceIdRate)
            {
                return new CompareOutputDto
                {
                    FirstPlace = compareInput.FirstPlace,

                    SecendPlace = compareInput.SecendPlace,

                    AverageRate1 = FirstPlaceId,

                    AverageRate2 = SecendPlaceId,

                    Result = "میانگین رای  این دو مکان توریستی با هم برابر است"
                };
            }
            else if (FirstPlaceRate >= FirstPlaceIdRate)
            {
                return new CompareOutputDto
                {
                    FirstPlace = compareInput.FirstPlace,

                    SecendPlace = compareInput.SecendPlace,

                    AverageRate1 = FirstPlaceId,

                    AverageRate2 = SecendPlaceId,

                    Result = "میانگین رای " + compareInput.FirstPlace + "بیش تر از" + compareInput.SecendPlace

                };
             }
            else
            {
                return new CompareOutputDto
                {
                    FirstPlace = compareInput.FirstPlace,

                    SecendPlace = compareInput.SecendPlace,

                    AverageRate1 = FirstPlaceId,

                    AverageRate2 = SecendPlaceId,

                    Result = "میانگین رای " + compareInput.SecendPlace + "بیش تر از" + compareInput.FirstPlace

                };
            }
            
       
       
        }


    }   
}
