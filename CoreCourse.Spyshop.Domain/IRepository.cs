using System.Linq;
using System.Threading.Tasks;

namespace CoreCourse.Spyshop.Domain
{
    public interface IRepository<T, TKey> where T : BaseEntity<TKey>
    {
        /// <summary>
        /// Retrieves a single entity of type T that has the given id
        /// </summary>
        Task<T> GetByIdAsync(TKey id);

        /// <summary>
        /// Returns a query to entities of type T, but doesn't retrieve them yet
        /// </summary>
        IQueryable<T> GetAll();

        /// <summary>
        /// Adds entity of type T to the data store
        /// </summary>
        Task<T> AddAsync(T entity);

        /// <summary>
        /// Deletes entity of type T from the data store, returns deleted entity as feedback
        /// </summary>
        Task<T> DeleteAsync(T entity);

        /// <summary>
        /// Updates entity of type T from the data store, returns updated entity as feedback
        /// </summary>
        Task<T> UpdateAsync(T entity);
    }
}
