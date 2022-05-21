using InvoicesAPI.DataAccess.Abstract.Repository.FileRepo;
using InvoicesAPI.DataAccess.Context;
using InvoicesAPI.Entity;

namespace InvoicesAPI.DataAccess.Concrete.Repository.FileRepo
{
    public class FileWriteRepository : WriteRepository<File>, IFileWriteRepository
    {
        public FileWriteRepository(InvoicesApiDbContext context) : base(context)
        {
        }
    }
}
