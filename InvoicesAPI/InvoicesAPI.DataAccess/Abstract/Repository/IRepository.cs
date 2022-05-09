using InvoicesAPI.Entity;
using InvoicesAPI.Entity.Common;
using Microsoft.EntityFrameworkCore;

namespace InvoicesAPI.DataAccess.Abstract.Repository
{
    public interface IRepository<T> where T :  BaseEntity 
    {
        DbSet<T> Table { get; }
    }
}
