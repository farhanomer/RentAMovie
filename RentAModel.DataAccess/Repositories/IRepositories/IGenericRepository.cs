using RentAMovie.Models;
using System.Linq.Expressions;

namespace RentAModel.DataAccess.Repositories.IRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetById(int id);
        Task<IList<T>> GetAll(Expression<Func<T, bool>> expression=null, List<string> includes=null);
        Task<T> Find(Expression<Func<T, bool>> expression, List<string> includes = null);
        Task Add(T entity);
        Task AddRange(IEnumerable<T> entities);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        void Update(T entity);
        IQueryable<T> Table { get; }
    }
}
