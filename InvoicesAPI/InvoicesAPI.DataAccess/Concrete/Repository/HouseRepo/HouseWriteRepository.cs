using InvoicesAPI.DataAccess.Abstract.Repository.HouseRepo;
using InvoicesAPI.DataAccess.Context;
using InvoicesAPI.Entity;

namespace InvoicesAPI.DataAccess.Concrete.Repository.HouseRepo
{
    public class HouseWriteRepository : WriteRepository<House>, IHouseWriteRepository
    {
        public HouseWriteRepository(InvoicesApiDbContext context) : base(context)
        {

        }
    }
}
