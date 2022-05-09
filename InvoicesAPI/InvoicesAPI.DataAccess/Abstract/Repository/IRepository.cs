using InvoicesAPI.Entity;
using Microsoft.EntityFrameworkCore;

namespace InvoicesAPI.DataAccess.Abstract.Repository
{
    public interface IRepository<T> where T :  BaseEntity 
    {
        DbSet<T> Table { get; }
    }
}
