using InvoicesAPI.DataAccess.Abstract.Repository.UserRepo;
using InvoicesAPI.DataAccess.Context;
using InvoicesAPI.Entity;

namespace InvoicesAPI.DataAccess.Concrete.Repository.UserRepo
{
    public class UserWriteRepository : WriteRepository<User>, IUserWriteRepository
    {
        public UserWriteRepository(InvoicesApiDbContext context) : base(context)
        {
        }
    }
}
