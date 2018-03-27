using CoreCourse.Spyshop.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CoreCourse.Spyshop.Web.Data
{
    public class EfRepository<T,TKey> 
        where T : BaseEntity<TKey>
    {
        private readonly SpyShopContext _dbContext;

        public EfRepository(SpyShopContext dbContext)
        {
            _dbContext = dbContext;
        }

        public T GetById(TKey id)
        {
            return _dbContext.Set<T>().SingleOrDefault(e => e.Id.Equals(id));
        }

        public List<T> List()
        {
            return _dbContext.Set<T>().ToList();
        }

        public T Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();

            return entity;
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}
