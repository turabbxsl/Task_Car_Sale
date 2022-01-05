using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDAL<T> where T : class
    {
        public void Delete(T t)
        {
            using var c = new Context();
            c.Remove(t);
            c.SaveChanges();
        }

        public T GetByID(int id)
        {
            using var c = new Context();
            return c.Set<T>().Find(id);
        }

        public async Task<List<T>> GetListAll()
        {
            using var c = new Context();
            return await c.Set<T>().ToListAsync();
        }

        public async Task<List<T>> GetListAll(Expression<Func<T, bool>> filter)
        {
            using var c = new Context();
            return await c.Set<T>().Where(filter).ToListAsync();
        }

        public T Insert(T t)
        {
            using var c = new Context();
            c.Add(t);
            c.SaveChanges();
            return t;
        }

        public T Update(T t)
        {
            using var c = new Context();
            c.Update(t);
             c.SaveChanges();
            return t;
        }
    }
}
