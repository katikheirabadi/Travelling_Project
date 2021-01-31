using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravellingCore.ContextRepositoryInterface;
using TravellingCore.Model;

namespace TravellingCore.ModelsServiceRepository.Models.Methods
{
    public class Turist_PLace_Service 
    {
        private readonly IRepository<Turist_Place> repository;
        public Turist_PLace_Service(IRepository<Turist_Place> repository)
        {
            this.repository = repository;
        }
        public string Delete(int id)
        {
            return repository.Delete(id);
        }

        public Task<Turist_Place> Get(int id)
        {
            return repository.Get(id);
        }

        public Task<List<Turist_Place>> GetAll()
        {
            return repository.GetAll();
        }

        public IQueryable<Turist_Place> GetQuery()
        {
            return repository.GetQuery();
        }

        public void Insert(Turist_Place item)
        {
            repository.Insert(item);
        }

        public Task Save()
        {
            return repository.Save();
        }

        public string Update(Turist_Place item)
        {
            return repository.Update(item);
        }

    }
}
