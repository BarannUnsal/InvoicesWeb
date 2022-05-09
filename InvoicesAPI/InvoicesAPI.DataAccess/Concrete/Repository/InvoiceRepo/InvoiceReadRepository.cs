using InvoicesAPI.DataAccess.Abstract.Repository.InvoicesRepo;
using InvoicesAPI.DataAccess.Context;
using InvoicesAPI.Entity;

namespace InvoicesAPI.DataAccess.Concrete.Repository.InvoiceRepo
{
    public class InvoiceReadRepository : ReadRepository<Invoice>, IInvoicesReadRepository
    {
        public InvoiceReadRepository(InvoicesApiDbContext context) : base(context)
        {

        }
    }
}
