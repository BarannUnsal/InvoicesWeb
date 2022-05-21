using InvoicesAPI.DataAccess.Abstract.Repository.FileRepo;
using InvoicesAPI.DataAccess.Context;
using InvoicesAPI.Entity;

namespace InvoicesAPI.DataAccess.Concrete.Repository.FileRepo
{
    public class FileReadRepository : ReadRepository<File>, IFileReadRepository
    {
        public FileReadRepository(InvoicesApiDbContext context) : base(context)
        {
        }
    }
}
