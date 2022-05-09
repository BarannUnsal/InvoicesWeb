using InvoicesAPI.DataAccess.Abstract.Repository;
using InvoicesAPI.DataAccess.Context;
using InvoicesAPI.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace InvoicesAPI.DataAccess.Concrete.Repository
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly InvoicesApiDbContext _context;
        public ReadRepository(InvoicesApiDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll(bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return query;
        }

        public async Task<T> GetByIdAsync(string id, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = Table.AsNoTracking();
            return await query.FirstOrDefaultAsync(x=>x.Id == Guid.Parse(id));
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tarcking = true)
        {
            var query = Table.AsQueryable();
            if (!tarcking)
                query = Table.AsNoTracking();
            return await query.FirstOrDefaultAsync(method);
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = Table.AsNoTracking();
            return query;
        }
    }
}
