using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravellingCore.ContextRepositoryInterface;
using TravellingCore.Model;

namespace TravellingCore.ModelsServiceRepository.Models.Methods
{
    public class ComentService
    {
        private readonly IRepository<Comment> repository;
        public ComentService(IRepository<Comment> repository)
        {
            this.repository = repository;
        }
        public string Delete(int id)
        {
            return repository.Delete(id);
        }

        public Task<Comment> Get(int id)
        {
            return repository.Get(id);
        }

        public Task<List<Comment>> GetAll()
        {
            return repository.GetAll();
        }

        public IQueryable<Comment> GetQuery()
        {
            return repository.GetQuery();
        }

        public void Insert(Comment item)
        {
            repository.Insert(item);
        }

        public Task Save()
        {
            return repository.Save();
        }

        public string Update(Comment item)
        {
            return repository.Update(item);
        }
    }
}
