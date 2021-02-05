using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravellingCore.Model;

namespace TravellingCore.Services.Models.Services
{
    public interface IModelServicees<T>
    {
        public string Delete(int id);
        public Task<T> Get(int id);
        public Task<List<T>> GetAll();
        public IQueryable<T> GetQuery();
        public Task Save();
        public string Update(T item);
        public void Insert(T item);
    }
}
