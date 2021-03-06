using InvoicesAPI.DataAccess.Abstract.Repository.UserRepo;
using InvoicesAPI.DataAccess.Context;
using InvoicesAPI.Entity;

namespace InvoicesAPI.DataAccess.Concrete.Repository.UserRepo
{
    public class HomeownerReadRepository : ReadRepository<Homeowner>, IHomeownerReadRepository
    {
        public HomeownerReadRepository(InvoicesApiDbContext context) : base(context)
        {

        }
    }
}
