using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravellingCore.ContextRepositoryInterface;
using TravellingCore.Dto.Rate;
using TravellingCore.Model;

namespace TravellingCore.ModelsServiceRepository.Models.Methods
{
    public class RateServicr
    {
        private readonly IRepository<Rate> repository;
        private readonly IRepository<UserLogin> repository1;
        private readonly IRepository<TuristPlace> repository2;

        public RateServicr(IRepository<Rate> repository,IRepository<UserLogin> repository1,IRepository<TuristPlace> repository2)
        {
            this.repository = repository;
            this.repository1 = repository1;
            this.repository2 = repository2;
        }
        public string Delete(int id)
        {
            return repository.Delete(id);
        }

        public Task<Rate> Get(int id)
        {
            return repository.Get(id);
        }

        public Task<List<Rate>> GetAll()
        {
            return repository.GetAll();
        }

        public IQueryable<Rate> GetQuery()
        {
            return repository.GetQuery();
        }

        public async Task<string> Insert(RateInputDto  rate , string Token)
        {
            var users = await repository1.GetAll();
            var user = users.FirstOrDefault(u => u.Token == Token);
            if (user == null)
                return "We don't have any Login-user with this Token ";
            TimeSpan time = user.ExpireDate.Date - DateTime.Now.Date;
            if (time.TotalMilliseconds < 0)
                return "your accont has expierd and you must log in again";
            var places = repository2.GetQuery();
            var place1 = places.FirstOrDefault(p => p.Name == rate.place);
            if (place1 == null)
                return "Not found any place with this name";

            repository.Insert(new Rate()
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
            return repository.Save();
        }

        public string Update(Rate item)
        {
            return repository.Update(item);
        }
        public void Insert2(Rate rate)
        {
            repository.Insert(rate);
        }

    }
}
