using InvoicesAPI.DataAccess.Abstract.Repository.HouseRepo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InvoicesAPI.Business.Features.Queries.House.GetHouse
{
    public class GetHouseQueryHandler : IRequestHandler<GetHouseQueryRequest, GetHouseQueryResponse>
    {
        readonly IHouseReadRepository _houseReadRepository;
        public GetHouseQueryHandler(IHouseReadRepository houseReadRepository)
        {
            _houseReadRepository = houseReadRepository;
        }
        public async Task<GetHouseQueryResponse> Handle(GetHouseQueryRequest request, CancellationToken cancellationToken)
        {
            var totalCount = _houseReadRepository.GetAll(false).Count();
            var houses = _houseReadRepository.GetAll(false).Skip(request.Page * request.Size).Take(request.Size).Select(p => new
            {
                p.Id,
                p.AptNo,
                p.Block,
                p.isEmpty,
                p.Type,
                p.CreatedTime,
                p.UpdatedTime
            }).ToList();

            return new()
            {
                Houses = houses,
                TotalCount = totalCount
            };
        }
    }
}
