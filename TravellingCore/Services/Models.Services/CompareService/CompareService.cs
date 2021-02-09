using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TravellingCore.ContextRepositoryInterface;
using TravellingCore.Model;
using System.Linq;

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

        // get avarage rate of attraction
        double Attraction(string Attraction)
        {
            var firstAttractionId = turistPlace.GetQuery()
                .FirstOrDefault(x => x.Name.Contains(Attraction)).Id;

            return rate.GetQuery()
                .Where(y => y.TuristPlaceId == firstAttractionId)
                .Select(z => z.UserRate).Average();
        }

        // compare attraction rate
        public Task<string> CompareAttraction(string firstAttraction, string secondAttraction)
        {
            if (Attraction(firstAttraction) > Attraction(secondAttraction))
                return Task.Run(() => { return $"{firstAttraction} محبوب تر از {secondAttraction} است"; });

            else if (Attraction(secondAttraction) > Attraction(firstAttraction))
                return Task.Run(() => { return $"{secondAttraction} محبوب تر از {firstAttraction} است"; });

            else
                return Task.Run(() => { return $"محبوبیت این دو مکان گردشگری برابر است"; });
        }
    }
}
