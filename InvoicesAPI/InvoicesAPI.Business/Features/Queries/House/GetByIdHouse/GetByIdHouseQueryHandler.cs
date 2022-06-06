using InvoicesAPI.DataAccess.Abstract.Repository.HouseRepo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InvoicesAPI.Business.Features.Queries.House.GetByIdHouse
{
    public class GetByIdHouseQueryHandler : IRequestHandler<GetByIdHouseQueryRequest, GetByIdHouseQueryResponse>
    {
        readonly IHouseReadRepository _houseReadRepository;
        public GetByIdHouseQueryHandler(IHouseReadRepository houseReadRepository)
        {
            _houseReadRepository = houseReadRepository;
        }
        public async Task<GetByIdHouseQueryResponse> Handle(GetByIdHouseQueryRequest request, CancellationToken cancellationToken)
        {
            InvoicesAPI.Entity.House house = await _houseReadRepository.GetByIdAsync(request.Id);
            return new()
            {
                AptNo = house.AptNo,
                Block = house.Block,
                isEmpty = house.isEmpty,
                Type = house.Type
            };
        }
    }
}
