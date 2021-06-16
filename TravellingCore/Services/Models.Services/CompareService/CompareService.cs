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
        private  double GetAverage(int TuricePlaceId)
        {
            var computingRate = turistPlace.GetQuery().Include(p => p.Rates).FirstOrDefault(r => r.Id == TuricePlaceId);
            return computingRate.Rates.Average(r => r.UserRate);
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

            var FirstPlaceRate =  GetAverage(FirstPlaceId);
            var secendPlaceRate =  GetAverage(SecendPlaceId);


            if (FirstPlaceRate == secendPlaceRate)
            {
                return new CompareOutputDto
                {
                    FirstPlace = compareInput.FirstPlace,

                    SecendPlace = compareInput.SecendPlace,

                    AverageRate1 = FirstPlaceRate,

                    AverageRate2 = secendPlaceRate,

                    Result = "میانگین رای  این دو مکان توریستی با هم برابر است"
                };
            }
            else if (FirstPlaceRate > secendPlaceRate)
            {
                return new CompareOutputDto
                {
                    FirstPlace = compareInput.FirstPlace,

                    SecendPlace = compareInput.SecendPlace,

                    AverageRate1 = FirstPlaceRate,

                    AverageRate2 = secendPlaceRate,

                    Result = "میانگین رای " + compareInput.FirstPlace + " بیش تر از" + compareInput.SecendPlace

                };
             }
            else
            {
                return new CompareOutputDto
                {
                    FirstPlace = compareInput.FirstPlace,

                    SecendPlace = compareInput.SecendPlace,

                    AverageRate1 = FirstPlaceRate,

                    AverageRate2 = secendPlaceRate,

                    Result = "میانگین رای " + compareInput.SecendPlace + " بیش تر از" + compareInput.FirstPlace

                };
            }
            
       
       
        }


    }   
}
