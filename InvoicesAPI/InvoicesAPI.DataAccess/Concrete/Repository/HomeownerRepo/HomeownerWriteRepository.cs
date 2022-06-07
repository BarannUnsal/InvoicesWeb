using InvoicesAPI.DataAccess.Abstract.Repository.UserRepo;
using InvoicesAPI.DataAccess.Context;
using InvoicesAPI.Entity;

namespace InvoicesAPI.DataAccess.Concrete.Repository.UserRepo
{
    public class HomeownerWriteRepository : WriteRepository<Homeowner>, IHomeownerWriteRepository
    {
        public HomeownerWriteRepository(InvoicesApiDbContext context) : base(context)
        {
        }
    }
}
