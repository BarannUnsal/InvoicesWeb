using InvoicesAPI.DataAccess.Abstract.Repository.HouseRepo;
using InvoicesAPI.DataAccess.Context;
using InvoicesAPI.Entity;

namespace InvoicesAPI.DataAccess.Concrete.Repository.HouseRepo
{
    public class HouseReadRepository : ReadRepository<House>, IHouseReadRepository
    {
        public HouseReadRepository(InvoicesApiDbContext context) : base(context)
        {

        }
    }
}
