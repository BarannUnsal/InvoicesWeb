using InvoicesAPI.DataAccess.Abstract.Repository.CreditCardRepo;
using InvoicesAPI.DataAccess.Context;
using InvoicesAPI.Entity;

namespace InvoicesAPI.DataAccess.Concrete.Repository.CreditCardRepo
{
    public class CreditCartWriteRepository : WriteRepository<CreditCard>, ICreditCardWriteRepository
    {
        public CreditCartWriteRepository(InvoicesApiDbContext context) : base(context)
        {
        }
    }
}
