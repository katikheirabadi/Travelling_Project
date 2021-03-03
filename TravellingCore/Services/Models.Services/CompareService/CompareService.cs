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

        // get avarage rate of place
        double Attraction(string Place)
        {
            var FirstPlace = turistPlace.GetQuery()
                                        .FirstOrDefault(x => x.Name.Contains(Place));

            if (FirstPlace == null)
                throw new KeyNotFoundException("not found this place");

            var FirstPlaceId = FirstPlace.Id;

            return rate.GetQuery()
                       .Where(y => y.TuristPlaceId == FirstPlaceId)
                       .Select(z => z.UserRate)
                       .Average();
        }

        // compare place rate
        public Task<string> CompareAttraction(string firstplace, string seccendplace)
        {
            if (Attraction(firstplace) > Attraction(seccendplace))
                return Task.Run(() => { return $"{firstplace} محبوب تر از {seccendplace} است"; });

            else if (Attraction(seccendplace) > Attraction(firstplace))
                return Task.Run(() => { return $"{seccendplace} محبوب تر از {firstplace} است"; });

            else
                return Task.Run(() => { return $"محبوبیت این دو مکان گردشگری برابر است"; });
        }
    }
}
