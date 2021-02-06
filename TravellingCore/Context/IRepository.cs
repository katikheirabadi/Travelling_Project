using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravellingCore.Dto.Sign_in;

namespace TravellingCore.ContextRepositoryInterface
{
    public interface IRepository<T>
    {
        Task<T> Get(int id);
        Task<List<T>> GetAll();
        string Delete(int id);
        void Insert(T input);
        string Update(T input);
        IQueryable<T> GetQuery();
        Task Save();
    }
}
