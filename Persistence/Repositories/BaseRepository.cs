using MarcasAUtosAPI.Application.Contracts;
using MarcasAUtosAPI.Application.Contracts.Persistence;
using MarcasAUtosAPI.Domain;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Linq.Expressions;

namespace Persistence.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseDomainModel
    {
        protected readonly AutosDbContext _context;

        public BaseRepository(AutosDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            // Realiza una consulta asincrónica para obtener todos los registros de la tabla
            return await _context.Set<T>().ToListAsync();
        }


        //Task<IEnumerable<T>> IBaseRepository<T>.GetAllAsync()
        //{
        //    throw new NotImplementedException();
        //}

        public IQueryable<T> Query(Expression<Func<T, bool>>? where = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, List<Expression<Func<T, object>>>? includes = null, bool disableTracking = true)
        {
            throw new NotImplementedException();
        }

        public IApplicationDbContext GetDbContext()
        {
            throw new NotImplementedException();
        }

        public Task<object?> AddAsync(MarcaAuto marca)
        {
            throw new NotImplementedException();
        }
    }
}
