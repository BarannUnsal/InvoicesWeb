using InvoicesAPI.DataAccess.Abstract.Repository.InvoiceFileRepo;
using InvoicesAPI.DataAccess.Context;
using InvoicesAPI.Entity;

namespace InvoicesAPI.DataAccess.Concrete.Repository.InvoiceFileRepo
{
    public class InvoiceFileReadRepository : ReadRepository<InvoiceFile>, IInvoiceFileReadRepository
    {
        public InvoiceFileReadRepository(InvoicesApiDbContext context) : base(context)
        {
        }
    }
}
