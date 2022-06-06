using MediatR;

namespace InvoicesAPI.Business.Features.Command.House.CreateHouse
{
    public class CreateHouseCommandRequest : IRequest<CreateHouseCommandResponse>
    {
        public int Block { get; set; }
        public string Type { get; set; }
        public int AptNo { get; set; }
        public bool isEmpty { get; set; }
    }
}
