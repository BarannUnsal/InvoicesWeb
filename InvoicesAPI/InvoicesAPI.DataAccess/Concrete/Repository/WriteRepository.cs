using InvoicesAPI.DataAccess.Abstract.Repository;
using InvoicesAPI.DataAccess.Context;
using InvoicesAPI.Entity;
using InvoicesAPI.Entity.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InvoicesAPI.DataAccess.Concrete.Repository
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        private readonly InvoicesApiDbContext _context;

        public WriteRepository(InvoicesApiDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<bool> AddAsync(T model)
        {
            EntityEntry<T> entityEntry = await Table.AddAsync(model);
            return entityEntry.State == EntityState.Added;
        }

        public async Task<bool> AddRangeAsync(List<T> datas)
        {
            await Table.AddRangeAsync(datas);
            return true;
        }

        public bool Remove(T model)
        {
            EntityEntry<T> entityEntry = Table.Remove(model);
            return entityEntry.State == EntityState.Deleted;
        }

        public async Task<bool> RemoveAsync(string id)
        {
            T model = await Table.FirstOrDefaultAsync(x => x.Id == Guid.Parse(id));
            return Remove(model);
        }

        public bool RemoveRange(List<T> datas)
        {
            Table.RemoveRange(datas);
            return true;
        }

        public async Task<int> SaveAsync() => await _context.SaveChangesAsync();

        public bool Update(T model)
        {
           EntityEntry<T> entityEntry = Table.Update(model);
            return entityEntry.State == EntityState.Modified;
        }
    }
}
