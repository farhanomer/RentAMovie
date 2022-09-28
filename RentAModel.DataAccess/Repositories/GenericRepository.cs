using Microsoft.EntityFrameworkCore;
using RentAModel.DataAccess.Repositories.IRepositories;
using RentAMovie.Models;
using System.Linq.Expressions;

namespace RentAModel.DataAccess.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private DbSet<T> _entity;
        private readonly RentAMovieDbCotext _context;
        public GenericRepository(RentAMovieDbCotext context)
        {
            _context = context;
            _entity = _context.Set<T>();

        }
        public IQueryable<T> Table
        {
            get
            {
                return _entity;
            }
        }

        public async Task<T> GetById(int id)
        {
            return await _entity.FindAsync(id);
        }

        public async Task<IList<T>> GetAll(Expression<Func<T, bool>> expression = null, List<string> includes = null)
        {
            IQueryable<T> query = _entity;
            if(expression != null)
            {
                query = query.Where(expression);
            }
            if (includes != null)
            {
                foreach(var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return await query.ToListAsync();
        }

        public async Task<T> Find(Expression<Func<T, bool>> expression, List<string> includes = null)
        {
            IQueryable<T> query = _entity;
            if (includes != null)
            {
                foreach(var include in includes)
                {
                    query=query.Include(include);
                }
            }
            return await query.AsNoTracking().FirstOrDefaultAsync(expression);
        }

        public async Task Add(T entity)
        {
            await _entity.AddAsync(entity);
        }

        public async Task AddRange(IEnumerable<T> entities)
        {
            await _entity.AddRangeAsync(entities);
        }

        public void Remove(T entity)
        {
            _entity.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _entity.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            _entity.Attach(entity);
            _context.Entry(entity).State=EntityState.Modified;
            //_entity.Update(entity);
        }
    }
}
