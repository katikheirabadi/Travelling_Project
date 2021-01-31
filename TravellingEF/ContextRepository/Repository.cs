﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravellingCore.ContextRepositoryInterface;
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
            var item=dBContext.Set<T>().FirstOrDefault(T => T.id == id);
            if(item!=null)
            {
                dBContext.Remove(id);
                return $"item with id = {id} deleted.... ";
            }
            return "Not Found ...";
        }

        public  Task<T> Get(int id)
        {
            return this.dBContext.Set<T>().FirstOrDefaultAsync(x => x.id == id);
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

        public Task Save()
        {
            return dBContext.SaveChangesAsync();
        }

        public string Update(T input)
        {
            this.dBContext.Update(input);
            return $"Item with id = {input.id } updated... ";
        }
    }
}