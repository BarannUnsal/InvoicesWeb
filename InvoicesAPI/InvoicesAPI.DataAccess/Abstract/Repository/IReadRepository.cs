using InvoicesAPI.Entity;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace InvoicesAPI.DataAccess.Abstract.Repository
{
    public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll(bool tracking = true);
        IQueryable<T> GetWhere(Expression<Func<T, bool>>method, bool tracking = true);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tarcking = true);
        Task<T> GetByIdAsync(string id, bool tracking = true);
    }
}
