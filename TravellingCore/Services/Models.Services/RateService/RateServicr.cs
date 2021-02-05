using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravellingCore.ContextRepositoryInterface;
using TravellingCore.Dto.Rate;
using TravellingCore.Model;
using TravellingCore.Services.Models.Services;
using TravellingCore.Services.Models.Services.RateService;

namespace TravellingCore.ModelsServiceRepository.Models.Methods
{
    public class RateServicr : IModelServicees<Rate> , IRateService
    {
        private readonly IRepository<Rate> RateRepository;
        private readonly IRepository<UserLogin> UserLoginRepository;
        private readonly IRepository<TuristPlace> TuristPlaceRepository;

        public RateServicr(IRepository<Rate> RateRepository, IRepository<UserLogin> UserLoginRepository, IRepository<TuristPlace> TuristPlaceRepository)
        {
            this.RateRepository = RateRepository;
            this.UserLoginRepository = UserLoginRepository;
            this.TuristPlaceRepository = TuristPlaceRepository;
        }
        public string Delete(int id)
        {
            return RateRepository.Delete(id);
        }

        public Task<Rate> Get(int id)
        {
            return RateRepository.Get(id);
        }

        public Task<List<Rate>> GetAll()
        {
            return RateRepository.GetAll();
        }

        public IQueryable<Rate> GetQuery()
        {
            return RateRepository.GetQuery();
        }

        public async Task<string> AddRate(RateInputDto  rate , string Token)
        {
            var users = await UserLoginRepository.GetAll();
            var user = users.FirstOrDefault(u => u.Token == Token);
            if (user == null)
                return "We don't have any Login-user with this Token ";
            TimeSpan time = user.ExpireDate.Date - DateTime.Now.Date;
            if (time.TotalMilliseconds < 0)
                return "your accont has expierd and you must log in again";
            var places = TuristPlaceRepository.GetQuery();
            var place1 = places.FirstOrDefault(p => p.Name == rate.place);
            if (place1 == null)
                return "Not found any place with this name";

            RateRepository.Insert(new Rate()
            {
                RecordDate = DateTime.Now,
                RateInt = rate.Rate,
                Tp_id = place1.id,
                userid = user.userid
            }) ;
           
            return "we add your Rate .";
          }

        public Task Save()
        {
            return RateRepository.Save();
        }

        public string Update(Rate item)
        {
            return RateRepository.Update(item);
        }
        public void Insert(Rate rate)
        {
            RateRepository.Insert(rate);
        }

    }
}
