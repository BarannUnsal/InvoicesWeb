using InvoicesAPI.DataAccess.Abstract.Repository.CreditCardRepo;
using InvoicesAPI.DataAccess.Context;
using InvoicesAPI.Entity;

namespace InvoicesAPI.DataAccess.Concrete.Repository.CreditCardRepo
{
    public class CreditCardReadRepository : ReadRepository<CreditCard>, ICreditCardReadRepository
    {
        public CreditCardReadRepository(InvoicesApiDbContext context) : base(context)
        {
        }
    }
}
