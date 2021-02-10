using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravellingCore.ContextRepositoryInterface;
using TravellingCore.Exceptions;
using TravellingEF.DataBase;

namespace TravellingEF.ContextRepository
{
    public class Repository<T> : IRepository<T> where T : class,IEntity
    {
        private readonly TravellingDBContext dBContext;

        public Repository(TravellingDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public string Delete(int id)
        {
            var item = dBContext.Set<T>().FirstOrDefault(T => T.Id == id);
            if (item != null)
               {
                   dBContext.Remove(item);
                  return"item deleted.... ";
               };
               throw new KeyNotFoundException("Not found");
        }

        public  Task<T> Get(int id)
        {
            var item = this.dBContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
            if (item != null)
                return item;
            throw new Exception("Not Found");
        }

        public Task<List<T>> GetAll()
        {
            return this.dBContext.Set<T>().ToListAsync();
        }

        public IQueryable<T> GetQuery()
        {
            return dBContext.Set<T>().AsQueryable();
        }

        public void Insert(T input)
        {
            this.dBContext.Add<T>(input);  
        }

        public  Task Save()
        {
            var result = dBContext.SaveChangesAsync();
            if (result.Id == 106)
                throw new DependencyException("Have dependency you can't delete");
            return result;
        }

        private Exception DependencyException()
        {
            throw new NotImplementedException();
        }

        public string Update(T input)
        {
            this.dBContext.Update(input);
            return "Item  updated... ";
        }
    }
}
