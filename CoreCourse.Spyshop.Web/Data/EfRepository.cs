using CoreCourse.Spyshop.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCourse.Spyshop.Web.Data
{
    public class EfRepository<T,TKey> : IRepository<T, TKey>
        where T : BaseEntity<TKey>
    {
        protected readonly SpyShopContext _dbContext;

        public EfRepository(SpyShopContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> GetByIdAsync(TKey id)
        {
            return await _dbContext.Set<T>().SingleOrDefaultAsync(e => e.Id.Equals(id));
        }

        public IQueryable<T> GetAll()
        {
            return _dbContext.Set<T>();
        }

        public async Task<T> AddAsync(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
