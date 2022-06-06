

using MediatR;

namespace InvoicesAPI.Business.Features.Queries.House.GetByIdHouse
{
    public class GetByIdHouseQueryRequest : IRequest<GetByIdHouseQueryResponse>
    {
        public string Id { get; set; }
    }
}
