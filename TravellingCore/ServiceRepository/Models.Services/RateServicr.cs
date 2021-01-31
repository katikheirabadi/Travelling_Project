using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravellingCore.ContextRepositoryInterface;
using TravellingCore.Model;

namespace TravellingCore.ModelsServiceRepository.Models.Methods
{
    public class RateServicr
    {
        private readonly IRepository<Rate> repository;
        public RateServicr(IRepository<Rate> repository)
        {
            this.repository = repository;
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

        public void Insert(Rate item)
        {
            repository.Insert(item);
        }

        public Task Save()
        {
            return repository.Save();
        }

        public string Update(Rate item)
        {
            return repository.Update(item);
        }

    }
}
