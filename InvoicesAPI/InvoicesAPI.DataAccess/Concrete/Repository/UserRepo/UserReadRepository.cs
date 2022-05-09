using InvoicesAPI.DataAccess.Abstract.Repository.UserRepo;
using InvoicesAPI.DataAccess.Context;
using InvoicesAPI.Entity;

namespace InvoicesAPI.DataAccess.Concrete.Repository.UserRepo
{
    public class UserReadRepository : ReadRepository<User>, IUserReadRepository
    {
        public UserReadRepository(InvoicesApiDbContext context) : base(context)
        {

        }
    }
}
