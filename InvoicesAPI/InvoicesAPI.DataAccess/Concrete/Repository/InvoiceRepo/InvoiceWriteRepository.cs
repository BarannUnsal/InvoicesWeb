using InvoicesAPI.DataAccess.Abstract.Repository.InvoicesRepo;
using InvoicesAPI.DataAccess.Context;
using InvoicesAPI.Entity;

namespace InvoicesAPI.DataAccess.Concrete.Repository.InvoiceRepo
{
    public class InvoiceWriteRepository : WriteRepository<Invoice>, IInvociesWriteRepository
    {
        public InvoiceWriteRepository(InvoicesApiDbContext context) : base(context)
        {

        }
    }
}
