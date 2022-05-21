using InvoicesAPI.DataAccess.Abstract.Repository.InvoiceFileRepo;
using InvoicesAPI.DataAccess.Context;
using InvoicesAPI.Entity;

namespace InvoicesAPI.DataAccess.Concrete.Repository.InvoiceFileRepo
{
    public class InvoiceFileWriteRepository : WriteRepository<InvoiceFile>, IInvoiceFileWriteRepository
    {
        public InvoiceFileWriteRepository(InvoicesApiDbContext context) : base(context)
        {
        }
    }
}
