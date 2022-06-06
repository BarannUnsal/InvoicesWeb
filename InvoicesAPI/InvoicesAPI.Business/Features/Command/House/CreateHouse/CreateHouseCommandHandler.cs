using InvoicesAPI.DataAccess.Abstract.Repository.HouseRepo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InvoicesAPI.Business.Features.Command.House.CreateHouse
{
    public class CreateHouseCommandHandler : IRequestHandler<CreateHouseCommandRequest, CreateHouseCommandResponse>
    {
        readonly IHouseWriteRepository _houseWriteRepository;
        public async Task<CreateHouseCommandResponse> Handle(CreateHouseCommandRequest request, CancellationToken cancellationToken)
        {
            await _houseWriteRepository.AddAsync(new()
            {
                AptNo = request.AptNo,
                Block = request.Block,
                Type = request.Type,
                isEmpty = request.isEmpty
            });
            await _houseWriteRepository.SaveAsync();
            return new();
        }
    }
}
