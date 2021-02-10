using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravellingCore.Dto.Rate;
using TravellingCore.Model;

namespace TravellingCore.Services.Models.Services.RateService
{
    public interface IRateService
    {
        public Task<string> AddRate(RateInputDto rate, string Token);
        public string Delete(int id);
        public Task<Rate> Get(int id);
        public Task<List<Rate>> GetAll();
        public IQueryable<Rate> GetQuery();
        public Task Save();
        public string Update(Rate item);
        public void Insert(Rate item);
    }
}
