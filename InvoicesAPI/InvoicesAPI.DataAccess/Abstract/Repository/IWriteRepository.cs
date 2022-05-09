using InvoicesAPI.Entity;
using InvoicesAPI.Entity.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InvoicesAPI.DataAccess.Abstract.Repository
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
    {
        Task<bool> AddAsync(T model);
        Task<bool> AddRangeAsync(List<T> datas);
        bool Remove(T model);
        bool RemoveRange(List<T> datas);
        Task<bool> RemoveAsync(string id);
        bool Update(T model);
        Task<int> SaveAsync();
    }
}
